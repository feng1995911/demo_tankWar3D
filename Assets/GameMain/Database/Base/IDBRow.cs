namespace GameMain
{
    public interface IDBRow
    {
        /// <summary>
        /// 插入数据到数据库
        /// </summary>
        void Insert();

        /// <summary>
        /// 从数据库获取数据
        /// </summary>
        void Load();

        /// <summary>
        /// 保存数据到数据库
        /// </summary>
        void Save();

        /// <summary>
        /// 删除数据
        /// </summary>
        void Delete();
    }
}
