using UnityEngine;
using System;
using GameMain;

namespace BT
{
    /// <summary>
    /// 召唤
    /// </summary>
    public class Summon : BTTask
    {
        public ActorType ActorType;
        public Int32 Id;
        public int Count = 1;
        public float MaxRadius = 5;
        public float MinRadius = 2;

        protected override bool Enter()
        {
            for (int i = 0; i < Count; i++)
            {
                Vector3 pos = GlobalTools.RandomOnCircle(Owner.Pos, MinRadius, MaxRadius);

                int entityId = GameEntry.Entity.GenerateSerialId();
                RoleEntityData data = new RoleEntityData(entityId, Id, ActorType, Owner.Camp)
                {
                    Position = pos,
                    Rotation = Quaternion.identity,
                    Scale = Vector3.one
                };
            }
            return true;
        }

        protected override void ReadAttribute(string key, string value)
        {
            switch (key)
            {
                case "Type":
                    this.ActorType = (ActorType)value.ToInt32();
                    break;
                case "Id":
                    this.Id = value.ToInt32();
                    break;
                case "Count":
                    this.Count = value.ToInt32();
                    break;
                case "MaxRadius":
                    this.MaxRadius = value.ToFloat();
                    break;
                case "MinRadius":
                    this.MinRadius = value.ToFloat();
                    break;
            }
        }
    }

}
