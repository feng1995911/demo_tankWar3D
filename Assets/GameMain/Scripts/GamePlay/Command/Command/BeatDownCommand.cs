using UnityEngine;

namespace GameMain
{
    public class BeatDownCommand : ICommand
    {
        public float LastTime;

        public BeatDownCommand():this(0)
        {
            
        }

        public BeatDownCommand(float lastTime)
        {
            this.LastTime = lastTime;
            CommandType = CommandType.Beatdown;
        }

        public CommandType CommandType { get; }
    }
}
