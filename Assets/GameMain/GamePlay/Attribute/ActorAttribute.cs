using System;
using System.Collections.Generic;
using GameFramework;

namespace GameMain
{
    [Serializable]
    public class ActorAttribute : IAttribute
    {
        /// <summary>
        /// 生命值
        /// </summary>
        public int Hp { get; protected set; }

        /// <summary>
        /// 最大生命值
        /// </summary>
        public int MaxHp { get; protected set; }

        /// <summary>
        /// 生命恢复
        /// </summary>
        public int HpRecover { get; protected set; }

        /// <summary>
        /// 魔法值
        /// </summary>     
        public int Mp { get; protected set; }

        /// <summary>
        /// 最大魔法值
        /// </summary>     
        public int MaxMp { get; protected set; }

        /// <summary>
        /// 魔法恢复
        /// </summary>
        public int MpRecover { get; protected set; }

        /// <summary>
        /// 攻击
        /// </summary>
        public int Attack { get; protected set; } 

        /// <summary>
        /// 防御
        /// </summary>
        public int Defense { get; protected set; }
       
        /// <summary>
        /// 速度
        /// </summary>
        public int Speed { get; protected set; }

        /// <summary>
        /// 暴击
        /// </summary>
        public int Crit { get; protected set; }

        /// <summary>
        /// 暴击伤害
        /// </summary>
        public int CritDamage { get; protected set; }

        /// <summary>
        /// 吸血
        /// </summary>
        public int SuckBlood { get; protected set; }

        /// <summary>
        /// 闪避
        /// </summary>
        public int Dodge { get; protected set; }

        /// <summary>
        /// 命中
        /// </summary>
        public int Hit { get; protected set; }

        /// <summary>
        /// 伤害吸收
        /// </summary>
        public int Absorb { get; protected set; }

        /// <summary>
        /// 伤害反弹
        /// </summary>
        public int Reflex { get; protected set; }


        public virtual void InitAttribute()
        {

        }

        public virtual void CopyFrom(Dictionary<PropertyType, int> data)
        {
            if (data == null)
            {
                Log.Error("Data is null.");
                return;
            }

            foreach (var p in data)
            {
                switch (p.Key)
                {
                    case PropertyType.LHP:
                        Hp = p.Value;
                        MaxHp = p.Value;
                        break;
                    case PropertyType.ATK:
                        Attack = p.Value;
                        break;
                    case PropertyType.DEF:
                        Defense = p.Value;
                        break;
                    case PropertyType.CRI:
                        Crit = p.Value;
                        break;
                    case PropertyType.BUR:
                        CritDamage = p.Value;
                        break;
                    case PropertyType.LMP:
                        Mp = p.Value;
                        MaxMp = p.Value;
                        break;
                    case PropertyType.VAM:
                        SuckBlood = p.Value;
                        break;
                    case PropertyType.HIT:
                        Hit = p.Value;
                        break;
                    case PropertyType.DOG:
                        Dodge = p.Value;
                        break;
                    case PropertyType.BAF:
                        Absorb = p.Value;
                        break;
                }
            }
        }

        public virtual int GetValue(AttributeType type)
        {
            switch (type)
            {
                case AttributeType.Hp:
                    return Hp;
                case AttributeType.MaxHp:
                    return MaxHp;
                case AttributeType.HpRecover:
                    return HpRecover;
                case AttributeType.Mp:
                    return Mp;
                case AttributeType.MaxMp:
                    return MaxMp;
                case AttributeType.MpRecover:
                    return MpRecover;
                case AttributeType.Attack:
                    return Attack;
                case AttributeType.Defense:
                    return Defense;
                case AttributeType.Speed:
                    return Speed;
                case AttributeType.Crit:
                    return Crit;
                case AttributeType.CritDamage:
                    return CritDamage;
                case AttributeType.SuckBlood:
                    return SuckBlood;
                case AttributeType.Dodge:
                    return Dodge;
                case AttributeType.Hit:
                    return Hit;
                case AttributeType.Absorb:
                    return Absorb;
                case AttributeType.Reflex:
                    return Reflex;
                default:
                    Log.Error($"Can no find {type} in this attribute.");
                    return 0;
            }
        }

        public virtual void UpdateValue(AttributeType type, int value)
        {
            switch (type)
            {
                case AttributeType.Hp:
                    Hp = value;
                    break;
                case AttributeType.MaxHp:
                    MaxHp = value;
                    break;
                case AttributeType.HpRecover:
                    HpRecover = value;
                    break;
                case AttributeType.Mp:
                    Mp = value;
                    break;
                case AttributeType.MaxMp:
                    MaxMp = value;
                    break;
                case AttributeType.MpRecover:
                    MpRecover = value;
                    break;
                case AttributeType.Attack:
                    Attack = value;
                    break;
                case AttributeType.Defense:
                    Defense = value;
                    break;
                case AttributeType.Speed:
                    Speed = value;
                    break;
                case AttributeType.Crit:
                    Crit = value;
                    break;
                case AttributeType.CritDamage:
                    CritDamage = value;
                    break;
                case AttributeType.SuckBlood:
                    SuckBlood = value;
                    break;
                case AttributeType.Dodge:
                    Dodge = value;
                    break;
                case AttributeType.Hit:
                    Hit = value;
                    break;
                case AttributeType.Absorb:
                    Absorb = value;
                    break;
                case AttributeType.Reflex:
                    Reflex = value;
                    break;
                default:
                    Log.Error($"Can no find {type} in this attribute.");
                    return;
            }
        }

        public virtual int GetFinalDamage(IAttribute attackerAttrbute)
        {
            throw new NotImplementedException();
        }

        public static ActorAttribute operator +(ActorAttribute a, ActorAttribute b)
        {
            ActorAttribute c = new ActorAttribute();
            c.Hp = a.Hp + b.Hp;
            c.MaxHp = a.MaxHp + b.MaxHp;
            c.Mp = a.Mp + b.Mp;
            c.MaxMp = a.MaxMp + b.MaxMp;
            c.Attack = a.Attack + b.Attack;
            c.Defense = a.Defense + b.Defense;
            c.HpRecover = a.HpRecover + b.HpRecover;
            c.MpRecover = a.MpRecover + b.MpRecover;
            c.Crit = a.Crit + b.Crit;
            c.CritDamage = a.CritDamage + b.CritDamage;
            c.Speed = a.Speed + b.Speed;
            c.SuckBlood = a.SuckBlood + b.SuckBlood;
            c.Dodge = a.Dodge + b.Dodge;
            c.Hit = a.Hit + b.Hit;
            c.Absorb = a.Absorb + b.Absorb;
            c.Reflex = a.Reflex + b.Reflex;
            return c;
        }

        public static ActorAttribute operator -(ActorAttribute a, ActorAttribute b)
        {
            ActorAttribute c = new ActorAttribute();
            c.Hp = a.Hp - b.Hp;
            c.MaxHp = a.MaxHp - b.MaxHp;
            c.Mp = a.Mp - b.Mp;
            c.MaxMp = a.MaxMp - b.MaxMp;
            c.Attack = a.Attack - b.Attack;
            c.Defense = a.Defense - b.Defense;
            c.HpRecover = a.HpRecover - b.HpRecover;
            c.MpRecover = a.MpRecover - b.MpRecover;
            c.Crit = a.Crit - b.Crit;
            c.CritDamage = a.CritDamage - b.CritDamage;
            c.Speed = a.Speed - b.Speed;
            c.SuckBlood = a.SuckBlood - b.SuckBlood;
            c.Dodge = a.Dodge - b.Dodge;
            c.Hit = a.Hit - b.Hit;
            c.Absorb = a.Absorb - b.Absorb;
            c.Reflex = a.Reflex - b.Reflex;
            return c;
        }
    }
}
