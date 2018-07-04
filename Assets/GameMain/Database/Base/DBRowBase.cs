using System;
using GameFramework;
using System.Reflection;

namespace GameMain
{
    public class DBRowBase : IDBRow
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        private PropertyInfo[] m_PropertyInfos;
        private string[] m_Items;
        private string[] m_Values;
        private string[] m_SelectKeys;
        private string[] m_SelectValues;
        private string m_DBName;
        

        public DBRowBase(int id, int userId)
        {
            this.Id = id;
            this.UserId = userId;
            m_DBName = this.GetType().Name;
            m_PropertyInfos = this.GetType().GetProperties();
 
            m_SelectKeys = new[]
            {
                "Id",
                "UserId",
            };

            m_Items = new string[m_PropertyInfos.Length];
            m_Values = new string[m_PropertyInfos.Length];
            for (int i = 0; i < m_PropertyInfos.Length; i++)
            {
                m_Items[i] = m_PropertyInfos[i].Name;             
            }
        }

        public void Insert()
        {
            UpdateValues();
            GameEntry.Database.InsertInto(m_DBName, m_Values);
        }

        public void Load()
        {
            UpdateValues();
            var dr = GameEntry.Database.SelectWhereEqual(m_DBName, m_Items, m_SelectKeys, m_SelectValues);

            if (!dr.HasRows)
            {
                Log.Error("Can no find data. id:{0},userId:{1}", Id, UserId);
                return;
            }

            while (dr.Read())
            {
                for (int i = 0; i < m_PropertyInfos.Length; i++)
                {
                    object value = null;
                    if (m_PropertyInfos[i].PropertyType== typeof(int))
                    {
                        value = int.Parse(dr.GetString(dr.GetOrdinal(m_PropertyInfos[i].Name)));
                    }
                    else if (m_PropertyInfos[i].PropertyType == typeof(float))
                    {
                        value = float.Parse(dr.GetString(dr.GetOrdinal(m_PropertyInfos[i].Name)));
                    }
                    else if (m_PropertyInfos[i].PropertyType == typeof (string))
                    {
                        value = dr.GetString(dr.GetOrdinal(m_PropertyInfos[i].Name));
                    }

                    m_PropertyInfos[i].SetValue(this, value, null);
                }
            }
        }

        public void Save()
        {
            UpdateValues();
            GameEntry.Database.UpdateInto(m_DBName, m_Items, m_Values, m_SelectKeys, m_SelectValues);
        }

        public void Delete()
        {
            UpdateValues();
            GameEntry.Database.Delete(m_DBName, m_Items, m_Values);
        }

        private void UpdateValues()
        {
            for (int i = 0; i < m_PropertyInfos.Length; i++)
            {
                m_Values[i] = $"'{m_PropertyInfos[i].GetValue(this, null)}'";
            }

            m_SelectValues = new[]
            {
                $"'{Id}'",
                $"'{UserId}'",
            };
        }
    }
}
