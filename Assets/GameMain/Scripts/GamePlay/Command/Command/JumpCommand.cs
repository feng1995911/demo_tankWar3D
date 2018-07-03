using UnityEngine;

namespace GameMain
{
    public class JumpCommand : ICommand
    {
        public JumpCommand()
        {
            CommandType = CommandType.Jump;
        }

        public CommandType CommandType { get; }
    }
}
