namespace GameMain
{
    public delegate CommandReplyType CommandHandler<T>(T command) where T : ICommand;

    public delegate CommandReplyType CommandHandler(params object[] args);
}
