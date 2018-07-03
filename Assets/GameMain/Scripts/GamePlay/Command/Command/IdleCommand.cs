using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// 空闲命令
    /// </summary>
    public class IdleCommand : ICommand
    {
        public IdleCommand()
        {
            CommandType = CommandType.Idle;
        }

        public CommandType CommandType { get; }
    }
}
