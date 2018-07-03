using System.Collections.Generic;
using System.Xml;
using GameMain;

namespace BT
{
    public class Hurt : BTTask
    {
        public DamageType Damage = DamageType.None;
        public float Percent = 1;

        public override void Load(XmlElement xe)
        {
            base.Load(xe);
        }

        protected override void ReadAttribute(string key, string value)
        {
           switch(key)
            {
                case "Damage":
                    this.Damage = (DamageType)value.ToInt32();
                    break;
                case "Percent":
                    this.Percent = value.ToFloat();
                    break;
            }
        }

        protected override bool Enter()
        {
            base.Enter();
            List<ActorBase> list =(List<ActorBase>) GameEntry.BT.GetData(this, Constant.Define.BTJudgeList);
            if(list==null)
            {
                return false;
            }

            switch(Damage)
            {
                case DamageType.None:
                    {

                    }
                    break;
                case DamageType.Phys:
                case DamageType.Arcane:
                case DamageType.Fire:
                case DamageType.Ice:
                case DamageType.Dark:
                    {
                        for(int i=0;i<list.Count;i++)
                        {
                            ActorBase actor = list[i];
                            int dmg = Owner.Attrbute.GetValue(AttributeType.Attack);
                            dmg = (int)(dmg * Percent);
                            Owner.Attack(actor, dmg);
                        }
                    }
                    break;
                case DamageType.Heal:
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            ActorBase actor = list[i];
                            int dmg = actor.Attrbute.GetValue(AttributeType.Attack);
                            dmg = (int)(dmg * Percent);
                            actor.AddHp(dmg,true);
                        }
                    }
                    break;

            }
            return true;
        }

        public override BTNode DeepClone()
        {
            Hurt pNode = new Hurt();
            pNode.Damage = Damage;
            pNode.Percent = Percent;
            return pNode;
        }
    }
}

