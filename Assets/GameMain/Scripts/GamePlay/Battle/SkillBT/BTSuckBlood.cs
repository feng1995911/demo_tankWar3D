using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;
using GameMain;

namespace BT
{
    public class SuckBlood:BTTask
    {
        public float Percent = 1;
        public float Rate    = 0.1f;

        public override void Load(XmlElement xe)
        {
            base.Load(xe);
            Rate = XmlObject.ReadFloat(xe, "Rate");
            Percent = XmlObject.ReadFloat(xe, "Percent");
        }

        protected override bool Enter()
        {
            base.Enter();
            List<ActorBase> list = (List<ActorBase>)GameEntry.BT.GetData(this, Constant.Define.BTJudgeList);
            if (list == null)
            {
                return false;
            }
            for (int i = 0; i < list.Count; i++)
            {
                ActorBase actor = list[i];
                int dmg = actor.Attrbute.GetValue(AttributeType.Attack);
                dmg = (int)(dmg * Percent);
                Owner.SuckBlood(actor, dmg,Rate);

            }
            return true;
        }

        public override BTNode DeepClone()
        {
            SuckBlood pNode = new SuckBlood();
            pNode.Rate = Rate;
            pNode.Percent = Percent;
            return pNode;
        }
    }
}
