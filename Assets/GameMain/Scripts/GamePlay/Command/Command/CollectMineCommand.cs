using System;

namespace GameMain
{
    public class CollectMineCommand : ICommand
    {
        public CommandType CommandType { get; }

        public float LastTime;
        public Action OnFinish;

        public CollectMineCommand(Action pCallback)
        {
            this.CommandType = CommandType.Mine;
            this.OnFinish = pCallback;
        }
    }
}
