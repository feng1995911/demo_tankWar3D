using System;

namespace GameMain
{
    /// <summary>
    /// 数据库表基类
    /// </summary>
    public abstract class DBTableBase
    {
        private readonly string m_Name;
        /// <summary>
        /// 初始化数据表基类的新实例。
        /// </summary>
        public DBTableBase()
            : this(null)
        {

        }

        /// <summary>
        /// 初始化数据表基类的新实例。
        /// </summary>
        /// <param name="name">数据表名称。</param>
        public DBTableBase(string name)
        {
            m_Name = name ?? string.Empty;
        }

        /// <summary>
        /// 获取数据表名称。
        /// </summary>
        public string Name
        {
            get
            {
                return m_Name;
            }
        }

        /// <summary>
        /// 获取数据表行的类型。
        /// </summary>
        public abstract Type Type
        {
            get;
        }

        /// <summary>
        /// 获取数据表行数。
        /// </summary>
        public abstract int Count
        {
            get;
        }

        /// <summary>
        /// 添加数据表行
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="dbRow">数据表行</param>
        public abstract void AddDBRow(int id, IDBRow dbRow);

        /// <summary>
        /// 保存到数据库
        /// </summary>
        public abstract void SaveToDB();
    }
}
