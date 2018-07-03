using UnityEngine;

namespace GameMain
{
    public class RebornCommand : ICommand
    {
        public float LastTime;

        public RebornCommand(float lastTime)
        {
            this.LastTime = lastTime;
            CommandType = CommandType.Reborn;
        }

        public CommandType CommandType { get; }
    }
}
