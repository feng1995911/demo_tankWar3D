using System;
using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// 交谈命令
    /// </summary>
    public class TurnToCommand : ICommand
    {
        public CommandType CommandType { get; }

        public Vector3 LookDirection { get; }
        public Action OnFinish { get; set; }

        public TurnToCommand(Vector3 lookDirection, Action onFinish)
        {
            this.LookDirection = lookDirection;
            this.OnFinish = onFinish;
            CommandType = CommandType.TurnTo;
        }
    }
}