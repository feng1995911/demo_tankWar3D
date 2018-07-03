using System;
using GameFramework.DataTable;

namespace GameMain
{
    public interface IDBTableManager
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="userId">用户ID。</param>
        void Init(int userId);

        /// <summary>
        /// 是否存在数据表。
        /// </summary>
        /// <typeparam name="T">数据表行的类型。</typeparam>
        /// <returns>是否存在数据表。</returns>
        bool HasDBTable<T>() where T : IDBRow;

        /// <summary>
        /// 获取数据表。
        /// </summary>
        /// <typeparam name="T">数据表行的类型。</typeparam>
        /// <returns>要获取的数据表。</returns>
        IDBTable<T> GetDBTable<T>() where T : IDBRow;

        /// <summary>
        /// 创建数据表。
        /// </summary>
        /// <typeparam name="T">数据表行的类型。</typeparam>
        /// <param name="tableName">要创建的数据表名字。</param>
        /// <returns>要创建的数据表。</returns>
        IDBTable<T> CreateDBTable<T>(string tableName) where T : class, IDBRow, new();

        /// <summary>
        /// 创建数据表。
        /// </summary>
        /// <param name="dataRowType">数据表行的类型</param>
        /// <param name="tableName">要创建的数据表名字</param>
        /// <returns>要创建的数据表</returns>
        DBTableBase CreateDBTable(Type dataRowType, string tableName);

        /// <summary>
        /// 保存所有数据到数据库
        /// </summary>
        void SaveAllToDB();

        /// <summary>
        /// 销毁数据表。
        /// </summary>
        /// <typeparam name="T">数据表行的类型。</typeparam>
        /// <returns>是否销毁数据表成功。</returns>
        bool DestroyDBTable<T>() where T : IDBRow;
    }
}
