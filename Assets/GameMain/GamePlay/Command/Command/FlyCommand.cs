using UnityEngine;

namespace GameMain
{
    public class FlyCommand : ICommand
    {
        public float LastTime;

        public FlyCommand(float lastTime)
        {
            this.LastTime = lastTime;
            CommandType = CommandType.Fly;
        }

        public CommandType CommandType { get; }
    }
}
