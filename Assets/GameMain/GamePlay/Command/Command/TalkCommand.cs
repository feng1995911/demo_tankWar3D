using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// 交谈命令
    /// </summary>
    public class TalkCommand : ICommand
    {
        public CommandType CommandType { get; }

        public string Word { get; }

        public Vector3 Rotation { get; }

        public TalkCommand(string word,Vector3 rot)
        {
            this.Word = word;
            this.Rotation = rot;
            CommandType = CommandType.Talk;
        }
    }
}