using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// 击退命令
    /// </summary>
    public class BeatBackCommand : ICommand
    {
        public BeatBackCommand()
        {
            CommandType = CommandType.Beatback;
        }

        public CommandType CommandType { get; }
    }
}
