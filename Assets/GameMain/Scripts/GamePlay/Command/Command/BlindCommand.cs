using UnityEngine;

namespace GameMain
{
    public class BlindCommand : ICommand
    {
        public float LastTime;

        public BlindCommand(float lastTime)
        {
            this.LastTime = lastTime;
            CommandType = CommandType.Blind;
        }

        public CommandType CommandType { get; }
    }
}
