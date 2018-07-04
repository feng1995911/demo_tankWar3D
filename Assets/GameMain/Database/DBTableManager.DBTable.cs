using System;
using System.Collections;
using System.Collections.Generic;
using GameFramework;

namespace GameMain
{
    public partial class DBTableManager
    {
        private sealed class DBTable<T> :DBTableBase, IDBTable<T> where T : class, IDBRow, new()
        {
            private readonly Dictionary<int, T> m_DataSet;

            public DBTable(string name) : base(name)
            {
                m_DataSet = new Dictionary<int, T>();
            } 

            public T this[int id]
            {
                get { return m_DataSet[id]; }
            }

            public override int Count
            {
                get
                {
                    return m_DataSet.Count;
                }
            }

            public override Type Type
            {
                get { return typeof (T); }
            }

            public override void AddDBRow(int id, IDBRow dbRow)
            {
                if (m_DataSet.ContainsKey(id))
                {
                    throw new GameFrameworkException("DBRow is exist.id:" + id);
                }
                
                m_DataSet.Add(id, (T)dbRow);
            }

            public bool HasDBRow(int id)
            {
                return m_DataSet.ContainsKey(id);
            }

            public T GetDBRow(int id)
            {
                T dataRow = null;
                if (m_DataSet.TryGetValue(id, out dataRow))
                {
                    return dataRow;
                }

                return null;
            }

            public T[] GetAllDBRows()
            {
                int index = 0;
                T[] allDataRows = new T[m_DataSet.Count];
                foreach (KeyValuePair<int, T> dataRow in m_DataSet)
                {
                    allDataRows[index++] = dataRow.Value;
                }

                return allDataRows;
            }

            public T[] GetAllDBRows(Predicate<T> condition)
            {
                if (condition == null)
                {
                    throw new GameFrameworkException("Condition is invalid.");
                }

                List<T> results = new List<T>();
                foreach (KeyValuePair<int, T> dataRow in m_DataSet)
                {
                    T dr = dataRow.Value;
                    if (condition(dr))
                    {
                        results.Add(dr);
                    }
                }

                return results.ToArray();
            }

            public T[] GetAllDBRows(Comparison<T> comparison)
            {
                if (comparison == null)
                {
                    throw new GameFrameworkException("Comparison is invalid.");
                }

                List<T> allDataRows = new List<T>();
                foreach (KeyValuePair<int, T> dataRow in m_DataSet)
                {
                    allDataRows.Add(dataRow.Value);
                }

                allDataRows.Sort(comparison);
                return allDataRows.ToArray();
            }

            public void DeleteDBRow(int id)
            {
                if (!m_DataSet.ContainsKey(id))
                {
                    throw new GameFrameworkException("DBRow is not exist.id:" + id);
                }

                m_DataSet[id].Delete();
                m_DataSet.Remove(id);
            }

            public override void SaveToDB()
            {
                foreach (KeyValuePair<int, T> dataRow in m_DataSet)
                {
                    dataRow.Value.Save();
                }
            }

            public void Clear()
            {
                foreach (KeyValuePair<int, T> dataRow in m_DataSet)
                {
                    T dr = dataRow.Value;
                    dr.Delete();
                }
                m_DataSet.Clear();
            }

            public IEnumerator<T> GetEnumerator()
            {
                return m_DataSet.Values.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return m_DataSet.Values.GetEnumerator();
            }
        }
    }
}
