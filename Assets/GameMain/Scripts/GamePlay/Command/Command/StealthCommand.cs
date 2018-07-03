using UnityEngine;

namespace GameMain
{
    public class StealthCommand : ICommand
    {
        public float LastTime;

        public StealthCommand(float lastTime)
        {
            this.LastTime = lastTime;
            CommandType = CommandType.Stealth;
        }

        public CommandType CommandType { get; }
    }
}
