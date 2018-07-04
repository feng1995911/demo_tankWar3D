using UnityEngine;

namespace GameMain
{
    public class SleepCommand : ICommand
    {
        public float LastTime;

        public SleepCommand(float lastTime)
        {
            this.LastTime = lastTime;
            CommandType = CommandType.Sleep;
        }

        public CommandType CommandType { get; }
    }
}
