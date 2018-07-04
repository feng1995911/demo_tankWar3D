using UnityEngine;
using System;

namespace GameMain
{
    [Serializable]
    public class EffectData : EntityData
    {
        public EffectBindType BindType = EffectBindType.World;
        public FlyObjFlyType FlyType = FlyObjFlyType.None;
        public FlyObjDeadType DeadType = FlyObjDeadType.UntilLifeTimeEnd;

        public float KeepTime = 0f;
        public float DelayTime = 0f;
        public float FlySpeed = 0f;

        public int SoundId = 0;

        public bool SetParent = false;

        public Vector3 PosOffset = Vector3.zero;
        public Vector3 EulerOffset = Vector3.zero;

        public ActorBase Target;
        public ActorBase Owner;
        public Transform Parent;

        public EffectData(int entityId, int typeId) : base(entityId,typeId)
        {
           
        }
    }
}
