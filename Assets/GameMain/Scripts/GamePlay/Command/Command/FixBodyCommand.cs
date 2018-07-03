using UnityEngine;

namespace GameMain
{
    public class FixBodyCommand : ICommand
    {
        public float LastTime;

        public FixBodyCommand(float lastTime)
        {
            this.LastTime = lastTime;
            CommandType = CommandType.Fixbody;
        }

        public CommandType CommandType { get; }
    }
}
