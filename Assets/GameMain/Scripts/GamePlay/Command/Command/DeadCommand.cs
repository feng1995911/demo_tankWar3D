using System;

namespace GameMain
{
    public class DeadCommand : ICommand
    {
        public CommandType CommandType { get; }

        public ActorDeadType Type { get; }

        public DeadCommand(ActorDeadType type)
        {
            this.Type = type;
            this.CommandType = CommandType.Dead;
        }
    }
}
