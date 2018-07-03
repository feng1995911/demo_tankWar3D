using UnityEngine;

namespace GameMain
{
    public class GrabCommand : ICommand
    {
        public float LastTime;

        public GrabCommand(float lastTime)
        {
            this.LastTime = lastTime;
            CommandType = CommandType.Grab;
        }

        public CommandType CommandType { get; }
    }
}
