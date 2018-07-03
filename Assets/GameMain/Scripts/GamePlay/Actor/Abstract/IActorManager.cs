namespace GameMain
{
    /// <summary>
    /// 行动者管理器
    /// </summary>
    public interface IActorManager
    {
        /// <summary>
        /// 创建行动者
        /// </summary>
        T CreatePlayer<T>() where T : IActor;
    }
}
