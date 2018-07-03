using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// 冰冻命令
    /// </summary>
    public class FrostCommand : ICommand
    {
        public float LastTime;

        public FrostCommand(float lastTime)
        {
            this.LastTime = lastTime;
            CommandType = CommandType.Frost;
        }

        public CommandType CommandType { get; }
    }
}
