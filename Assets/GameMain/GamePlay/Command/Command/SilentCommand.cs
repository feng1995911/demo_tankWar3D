using UnityEngine;

namespace GameMain
{
    public class SilentCommand : ICommand
    {
        public float LastTime;

        public SilentCommand(float lastTime)
        {
            this.LastTime = lastTime;
            CommandType = CommandType.Hook;
        }

        public CommandType CommandType { get; }
    }
}
