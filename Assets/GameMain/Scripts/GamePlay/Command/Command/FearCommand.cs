using UnityEngine;

namespace GameMain
{
    public class FearCommand : ICommand
    {
        public float LastTime;

        public FearCommand(float lastTime)
        {
            this.LastTime = lastTime;
            CommandType = CommandType.Fear;
        }

        public CommandType CommandType { get; }
    }
}
