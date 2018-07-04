namespace GameMain
{
    /// <summary>
    /// 命令接受者
    /// </summary>
    public interface ICommandReceiver
    {
        /// <summary>
        /// 是否存在该类型命令
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <returns></returns>
        bool HasCommand(CommandType commandType);

        /// <summary>
        /// 添加命令
        /// </summary>
        /// <typeparam name="T">命令</typeparam>
        /// <param name="commandType">命令类型</param>
        /// <param name="handler">命令处理回调</param>
        void AddCommand<T>(CommandType commandType, CommandHandler<T> handler) where T : ICommand;

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <typeparam name="T">命令类型</typeparam>
        /// <param name="command">命令</param>
        /// <returns></returns>
        CommandReplyType ExecuteCommand<T>(T command) where T : ICommand;

        /// <summary>
        /// 清空
        /// </summary>
        void Clear();
    }
}
