using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// 强制移动命令
    /// </summary>
    public class MoveCommand : ICommand
    {
        public MoveCommand(Vector2 delta)
        {
            Delta = delta;
            CommandType = CommandType.Moveto;
        }

        public CommandType CommandType { get; }

        public Vector2 Delta { get; }
    }
}
