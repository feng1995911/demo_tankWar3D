using System.Threading;
using GameFramework;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Database")]
    public class DatabaseComponent : GameFrameworkComponent,ICustomComponent
    {
        [SerializeField] private string DBName = "userData.db";
        [SerializeField] private float SaveInterval = 60;

        private SqliteConnection dbConnection;
        private SqliteCommand dbCommand;
        private SqliteDataReader reader;
        private string appDBPath = "";
        private string userTableName = "DBUser";

        private IDBTableManager m_DBTableManager = null;
        private IDBTable<DBUser> m_UserTable;

        private DBUser m_UserData;

        private float m_ElapseSeconds = 0;
        private static readonly object m_LockObj = new object();

        public void Init()
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            appDBPath = Application.streamingAssetsPath + "/DB/" + DBName;
#elif UNITY_ANDROID
            appDBPath = Application.persistentDataPath + "/" + DBName;  
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DBName);
            while (loadDB.isDone)
            {
                File.WriteAllBytes(appDBPath, loadDB.bytes);
            } 
#endif
            OpenDB("URI=file:" + appDBPath);
            m_DBTableManager = new DBTableManager();           
            m_UserTable = CreateDBTable<DBUser>(userTableName);
        }

        void Update()
        {
            m_ElapseSeconds += Time.deltaTime;
            if (m_ElapseSeconds > SaveInterval)
            {
                //SaveDatabase(); //一定时间间隔，自动保存数据
                m_ElapseSeconds = 0;
            }
        }

        public void Clear()
        {
            //退出游戏前，保存数据
            SaveDatabase();
        }

        public bool TryLogin(int account, int password)
        {
            if (!CheckTable(userTableName))
            {
                return false;
            }

            string[] items =
            {
                "Account",
                "Password",
            };

            string[] selectKeys =
            {
                "UserId",
            };

            string[] selectValues =
            {
                $"'{account}'",
            };

            var dr = SelectWhereEqual(userTableName, items, selectKeys, selectValues);

            while (dr.Read())
            {
                string drAccount = dr.GetString(dr.GetOrdinal("Account"));
                string drPassword = dr.GetString(dr.GetOrdinal("Password"));

                if (account.ToString() == drAccount && password.ToString() == drPassword)
                {
                    if(!m_UserTable.HasDBRow(account))
                    {
                        DBUser dbUser = new DBUser(account, password);
                        dbUser.Load();
                        m_UserTable.AddDBRow(account, dbUser);
                    }
     
                    m_DBTableManager.Init(account);
                    m_UserData = GetDBRow<DBUser>(account);
                    
                    //CloseSqlConnection();

                    return true;
                }
            }

            return false;
        }

        public bool TryRegister(int account, int password)
        {
            string[] items =
            {
                "Account",
                "Password",
            };

            string[] selectKeys =
            {
                "UserId",
            };

            string[] selectValues =
            {
                $"'{account}'",
            };

            var dr = SelectWhereEqual(userTableName, items, selectKeys, selectValues);
            //账号已存在
            if (dr.Read())
            {
                return false;
            }


            DBUser dbUser = new DBUser(account, password);
            dbUser.Account = account;
            dbUser.Password = password;
            dbUser.Player = 0;
            dbUser.Insert();
            m_UserTable.AddDBRow(account, dbUser);
            return true;
        }

        /// <summary>
        /// 保存数据库
        /// </summary>
        public void SaveDatabase()
        {
            m_DBTableManager.SaveAllToDB();
            CloseSqlConnection();
            Log.Info("Save Database...");
        }

        /// <summary>
        /// 是否存在数据表
        /// </summary>
        /// <typeparam name="T">数据行类型</typeparam>
        public bool HasDBTable<T>() where T : IDBRow
        {
            return m_DBTableManager.HasDBTable<T>();
        }

        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IDBTable<T> GetDBTable<T>() where T : IDBRow
        {
            return m_DBTableManager.GetDBTable<T>();
        }

        /// <summary>
        /// 创建数据表
        /// </summary>
        /// <typeparam name="T">数据表行类型</typeparam>
        /// <param name="tableName">数据表名称</param>
        /// <returns></returns>
        public IDBTable<T> CreateDBTable<T>(string tableName) where T : class, IDBRow, new()
        {
            IDBTable<T> dbTable = m_DBTableManager.CreateDBTable<T>(tableName);
            return dbTable;
        }

        /// <summary>
        /// 添加数据行当数据表
        /// </summary>
        /// <typeparam name="T">数据行类型</typeparam>
        /// <param name="dbTable">数据表</param>
        /// <param name="id">编号</param>
        /// <param name="dbRow">数据行</param>
        public void AddDBRow<T>(int id, IDBRow dbRow) where T : IDBRow
        {
            IDBTable<T> dbTable = GetDBTable<T>();
            dbTable.AddDBRow(id, (T) dbRow);
        }

        /// <summary>
        /// 获取数据行
        /// </summary>
        /// <typeparam name="T">数据行类型</typeparam>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public T GetDBRow<T>(int id) where T : IDBRow
        {
            IDBTable<T> dbTable = GetDBTable<T>();
            return dbTable.GetDBRow(id);
        }

        public int GetUserId()
        {
            return m_UserData.UserId;
        }

        public int GetPlayerId()
        {
            return m_UserData.Player;
        }


        #region SQLite

        public void OpenDB(string connectionString)
        {
            try
            {
                if (dbConnection == null)
                {
                    dbConnection = new SqliteConnection(connectionString);

                    dbConnection.Open();
                    Log.Info("Connected to db");
                }
            }
            catch (GameFrameworkException e)
            {
                string temp1 = e.ToString();
                Log.Info(temp1);
            }

        }

        public void CloseSqlConnection()
        {

            if (dbCommand != null)
            {

                dbCommand.Dispose();

            }

            dbCommand = null;

            if (reader != null)
            {

                reader.Dispose();

            }

            reader = null;

            if (dbConnection != null)
            {

                dbConnection.Close();

            }

            dbConnection = null;

            Log.Info("Disconnected from db.");

        }

        public SqliteDataReader ExecuteQuery(string sqlQuery)
        {
            lock (m_LockObj)
            {
                dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandText = sqlQuery;
                reader = dbCommand.ExecuteReader();
            }
            return reader;
        }

        public SqliteDataReader ReadFullTable(string tableName)

        {

            string query = "SELECT * FROM " + tableName;

            return ExecuteQuery(query);

        }

        public SqliteDataReader InsertInto(string tableName, string[] values)
        {
            string query = "INSERT INTO " + tableName + " VALUES (" + values[0];

            for (int i = 1; i < values.Length; ++i)
            {

                query += ", " + values[i];

            }

            query += ")";

            var r = ExecuteQuery(query);

            return r;
        }

        public SqliteDataReader UpdateInto(string tableName, string[] cols, string[] colsvalues, string[] selectkey, string[] selectvalue)
        {

            string query = "UPDATE " + tableName + " SET " + cols[0] + " = " + colsvalues[0];

            for (int i = 1; i < colsvalues.Length; ++i)
            {

                query += ", " + cols[i] + " =" + colsvalues[i];
            }

            query += " WHERE " + selectkey[0] + " = " + selectvalue[0] + " ";


            for (int i = 1; i < selectkey.Length; ++i)
            {

                query += " And " + selectkey[i] + " = " + selectvalue[i];

            }

            return ExecuteQuery(query);
        }

        public SqliteDataReader Delete(string tableName, string[] cols, string[] colsvalues)
        {
            string query = "DELETE FROM " + tableName + " WHERE " + cols[0] + " = " + colsvalues[0];

            for (int i = 1; i < colsvalues.Length; ++i)
            {

                query += " or " + cols[i] + " = " + colsvalues[i];
            }
            Log.Info(query);
            return ExecuteQuery(query);
        }

        public SqliteDataReader InsertIntoSpecific(string tableName, string[] cols, string[] values)

        {

            if (cols.Length != values.Length)
            {

                throw new SqliteException("columns.Length != values.Length");

            }

            string query = "INSERT INTO " + tableName + "(" + cols[0];

            for (int i = 1; i < cols.Length; ++i)
            {

                query += ", " + cols[i];

            }

            query += ") VALUES (" + values[0];

            for (int i = 1; i < values.Length; ++i)
            {

                query += ", " + values[i];

            }

            query += ")";

            return ExecuteQuery(query);

        }

        public SqliteDataReader DeleteContents(string tableName)

        {

            string query = "DELETE FROM " + tableName;

            return ExecuteQuery(query);

        }

        public SqliteDataReader CreateTable(string name, string[] col, string[] colType)

        {

            if (col.Length != colType.Length)
            {

                throw new SqliteException("columns.Length != colType.Length");

            }

            string query = "CREATE TABLE " + name + " (" + col[0] + " " + colType[0];

            for (int i = 1; i < col.Length; ++i)
            {

                query += ", " + col[i] + " " + colType[i];

            }

            query += ")";

            return ExecuteQuery(query);

        }

        public SqliteDataReader SelectWhere(string tableName, string[] items, string[] col, string[] operation, string[] values)

        {

            if (col.Length != operation.Length || operation.Length != values.Length) {

                throw new SqliteException("col.Length != operation.Length != values.Length");

            }

            string query = "SELECT " + items[0];

            for (int i = 1; i < items.Length; ++i)
            {

                query += ", " + items[i];

            }

            query += " FROM " + tableName + " WHERE " + col[0] + operation[0] + values[0];

            for (int i = 1; i < col.Length; ++i)
            {

                query += " And " + col[i] + operation[i] + values[i];

            }

            return ExecuteQuery(query);

        }

        public SqliteDataReader SelectWhereEqual(string tableName, string[] items, string[] col, string[] values)
        {
            string query = "SELECT " + items[0];

            for (int i = 1; i < items.Length; ++i)
            {

                query += ", " + items[i];

            }

            query += " FROM " + tableName + " WHERE " + col[0] + "=" + values[0];

            for (int i = 1; i < col.Length; ++i)
            {

                query += " And " + col[i] + "=" + values[i];

            }

            return ExecuteQuery(query);
        }

        public bool CheckTable(string tableName)
        {
            string query = string.Format("SELECT * FROM sqlite_master WHERE type='table' And name='{0}'", tableName);
            return ExecuteQuery(query).Read();
        }
        #endregion
    }
}
