using UnityEngine;

namespace GameMain
{
    public class HookCommand : ICommand
    {
        public float LastTime;

        public HookCommand(float lastTime)
        {
            this.LastTime = lastTime;
            CommandType = CommandType.Hook;
        }

        public CommandType CommandType { get; }
    }
}
