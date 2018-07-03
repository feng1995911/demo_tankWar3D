using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GameFramework;

namespace GameMain
{
    public partial class DBTableManager : IDBTableManager
    {
        private readonly Dictionary<string, DBTableBase> m_DataTables;
        private readonly string m_AssemblyName = "GameMain";

        public DBTableManager()
        {
            m_DataTables = new Dictionary<string, DBTableBase>();
        }

        public void Init(int userId)
        {
            //反射DB数据表类型
            Assembly assembly = Assembly.Load(m_AssemblyName);
            Type[] types = assembly.GetExportedTypes();
            Func<Attribute[], bool> isAttr = o =>
            {
                foreach (Attribute a in o)
                {
                    if (a is DatabaseRowAttribute)
                    {
                        return true;
                    }
                }
                return false;
            };
            Type[] DBRowTypes = types.Where(o =>
            {
                return isAttr(Attribute.GetCustomAttributes(o, true));
            }).ToArray();

            for (int i = 0; i < DBRowTypes.Length; i++)
            {
                string dbTableName = DBRowTypes[i].Name;
                Type dbRowType = DBRowTypes[i];

                DBTableBase dbTable;
                if (m_DataTables.ContainsKey(dbTableName))
                {
                    dbTable = m_DataTables[dbTableName];
                }
                else
                {
                    dbTable = CreateDBTable(dbRowType, dbTableName);
                }
                
                if (dbTable == null)
                {
                    throw new GameFrameworkException("Can create dbTable:" + dbTableName);
                }

                //读取当前用户的数据库数据,并添加到DB表
                string[] items = {"Id", "UserId"};
                string[] cols = { "UserId" };
                string[] operation = { "=" };
                string[] values = { $"{userId}" };
                var dr = GameEntry.Database.SelectWhere(dbTableName, items, cols, operation, values);
                while (dr.Read())
                {
                    int drId = int.Parse(dr.GetString(dr.GetOrdinal("Id")));
                    int drUserId = int.Parse(dr.GetString(dr.GetOrdinal("UserId")));
                    DBRowBase dbRow = (DBRowBase)Activator.CreateInstance(DBRowTypes[i], drId, drUserId);
                    dbRow.Load();
                    dbTable.AddDBRow(drId, dbRow);
                }
            }
        }

        public bool HasDBTable<T>() where T : IDBRow
        {
            return m_DataTables.ContainsKey(typeof (T).Name);
        }

        public IDBTable<T> CreateDBTable<T>(string tableName) where T : class, IDBRow, new()
        {
            Type dbRowType = typeof (T);
            return (IDBTable<T>)CreateDBTable(dbRowType,tableName);
        }

        public DBTableBase CreateDBTable(Type dataRowType, string tableName)
        {
            if (dataRowType == null)
            {
                throw new GameFrameworkException("Data row type is invalid.");
            }

            if (!typeof(IDBRow).IsAssignableFrom(dataRowType))
            {
                throw new GameFrameworkException(string.Format("Data row type '{0}' is invalid.", dataRowType.FullName));
            }

            if (m_DataTables.ContainsKey(dataRowType.Name))
            {
                throw new GameFrameworkException(string.Format("Already exist data table '{0}'.", Utility.Text.GetFullName(dataRowType, dataRowType.Name)));
            }

            Type dbTableType = typeof(DBTable<>).MakeGenericType(dataRowType);
            DBTableBase dataTable = (DBTableBase)Activator.CreateInstance(dbTableType, tableName);

            //检察数据库，没有则创建
            if (!GameEntry.Database.CheckTable(tableName))
            {
                PropertyInfo[] propertyInfos = dataRowType.GetProperties();
      
                string[] col = new string[propertyInfos.Length];
                string[] colType = new string[propertyInfos.Length];
                for (int j = 0; j < propertyInfos.Length; j++)
                {
                    col[j] = propertyInfos[j].Name;
                    colType[j] = "text";
                }
                GameEntry.Database.CreateTable(tableName, col, colType);
            }

            if (dataTable != null)
                m_DataTables.Add(dataTable.Name, dataTable);

            return dataTable;
        }

        public IDBTable<T> GetDBTable<T>() where T : IDBRow
        {
            DBTableBase dbTable;
            if (m_DataTables.TryGetValue(typeof (T).Name, out dbTable))
            {
                return (IDBTable<T>) dbTable;
            }
            return null;
        }

        public void SaveAllToDB()
        {
            foreach (var dbTable in m_DataTables)
            {
                dbTable.Value.SaveToDB();
            }
        }

        public bool DestroyDBTable<T>() where T : IDBRow
        {
            DBTableBase dbTable;
            if (m_DataTables.TryGetValue(typeof(T).Name, out dbTable))
            {
                var dr = (IDBTable<T>)dbTable;
                dr.Clear();
                return true;
            }
            return false;
        }

    }
}
