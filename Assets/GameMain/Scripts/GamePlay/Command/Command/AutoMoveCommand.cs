using System;
using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// 寻路命令
    /// </summary>
    public class AutoMoveCommand : ICommand
    {
        public CommandType CommandType { get; }

        public PursueType Pursue { get; }

        public Vector3 TargetPos { get; }

        public Transform Target { get; }

        public IActor TargetActor { get; }

        public Action Callback { get; }

        public Vector3 DestPosition
        {
            get
            {
                switch (Pursue)
                {
                    case PursueType.Actor:
                        return TargetActor.CachedTransform.position;
                    case PursueType.Position:
                        return TargetPos;
                    case PursueType.Transform:
                        return Target.position;
                }
                return Vector3.zero;
            }
        }



        public AutoMoveCommand(Vector3 destPosition, Action callback = null)
        {
            this.TargetPos = destPosition;
            this.CommandType = CommandType.Runto;
            this.Pursue = PursueType.Position;
            this.Callback = callback;
        }

        public AutoMoveCommand(Transform target, Action callback = null)
        {
            this.Target = target;
            this.CommandType = CommandType.Runto;
            this.Pursue = PursueType.Transform;
            this.Callback = callback;
        }

        public AutoMoveCommand(IActor actor, Action callback = null)
        {
            this.TargetActor = actor;
            this.CommandType = CommandType.Runto;
            this.Pursue = PursueType.Actor;
            this.Callback = callback;
        }

    }
}
