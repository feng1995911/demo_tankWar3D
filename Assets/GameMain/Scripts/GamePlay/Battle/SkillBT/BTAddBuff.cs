using System.Collections.Generic;
using GameMain;

namespace BT
{
    public class AddBuff : BTTask
    {
        public AffectType Affect;
        public int BuffID;
        public float Ratio = 1;

        protected override bool Enter()
        {
            base.Enter();
            bool isTrigger = GlobalTools.IsTrigger(Ratio);
            if(isTrigger==false)
            {
                return false;
            }
            List<ActorBase> list = Owner.GetActorsByAffectType(Affect);
            if (list == null)
            {
                return false;
            }

            for(int i=0;i<list.Count;i++)
            {
                list[i].ActorBuff.AddBuff(BuffID,Owner);
            }
            return true;
        }

        protected override void ReadAttribute(string key, string value)
        {
            switch (key)
            {
                case "Affect":
                    this.Affect = (AffectType)value.ToInt32();
                    break;
                case "BuffID":
                    this.BuffID = value.ToInt32();
                    break;
                case "Ratio":
                    this.Ratio = value.ToFloat();
                    break;
            }
        }

        protected override BTStatus Execute()
        {
            return BTStatus.Success;
        }

        public override BTNode DeepClone()
        {
            AddBuff buff = new AddBuff
            {
                Affect = this.Affect,
                BuffID = this.BuffID,
                Ratio = this.Ratio
            };
            return buff;
        }
    }
}