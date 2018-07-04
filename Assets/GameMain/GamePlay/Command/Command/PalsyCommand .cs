using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// 麻痹命令
    /// </summary>
    public class PalsyCommand : ICommand
    {
        public float LastTime;

        public PalsyCommand(float lastTime)
        {
            this.LastTime = lastTime;
            CommandType = CommandType.Palsy;
        }

        public CommandType CommandType { get; }
    }
}
