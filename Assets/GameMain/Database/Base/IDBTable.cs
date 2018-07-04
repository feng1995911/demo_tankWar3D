using System;
using System.Collections.Generic;

namespace GameMain
{
    /// <summary>
    /// DB数据表
    /// </summary>
    public interface IDBTable<T>:IEnumerable<T> where T:IDBRow
    {
        /// <summary>
        /// 获取数据表名称。
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// 获取数据表行的类型。
        /// </summary>
        Type Type
        {
            get;
        }

        /// <summary>
        /// 获取数据表行数。
        /// </summary>
        int Count
        {
            get;
        }

        /// <summary>
        /// 获取数据表行。
        /// </summary>
        /// <param name="id">数据表行的编号。</param>
        /// <returns>数据表行。</returns>
        T this[int id]
        {
            get;
        }

        /// <summary>
        /// 检查是否存在数据表行。
        /// </summary>
        /// <param name="id">数据表行的编号。</param>
        /// <returns>是否存在数据表行。</returns>
        bool HasDBRow(int id);

        /// <summary>
        /// 添加数据行
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="dbRow">数据行</param>
        void AddDBRow(int id, IDBRow dbRow);

        /// <summary>
        /// 获取数据表行。
        /// </summary>
        /// <param name="id">数据表行的编号。</param>
        /// <returns>数据表行。</returns>
        T GetDBRow(int id);

        /// <summary>
        /// 获取所有数据表行。
        /// </summary>
        /// <returns>所有数据表行。</returns>
        T[] GetAllDBRows();

        /// <summary>
        /// 获取所有符合条件的数据表行。
        /// </summary>
        /// <param name="condition">要检查的条件。</param>
        /// <returns>所有符合条件的数据表行。</returns>
        T[] GetAllDBRows(Predicate<T> condition);

        /// <summary>
        /// 获取所有排序后的数据表行。
        /// </summary>
        /// <param name="comparison">要排序的条件。</param>
        /// <returns>所有排序后的数据表行。</returns>
        T[] GetAllDBRows(Comparison<T> comparison);

        /// <summary>
        /// 删除数据表行
        /// </summary>
        /// <param name="id">数据表行编号</param>
        void DeleteDBRow(int id);

        /// <summary>
        /// 清空数据表
        /// </summary>
        void Clear();
    }
}
