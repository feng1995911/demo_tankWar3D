using UnityEngine;

namespace GameMain
{
    public class WoundCommand : ICommand
    {
        public float LastTime;

        public WoundCommand()
        {

        }

        public WoundCommand(float lastTime)
        {
            this.LastTime = lastTime;
            CommandType = CommandType.Wound;
        }

        public CommandType CommandType { get; }
    }
}
