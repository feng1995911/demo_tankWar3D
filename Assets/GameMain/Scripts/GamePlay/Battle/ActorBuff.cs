using System.Collections.Generic;
using GameFramework;

namespace GameMain
{
    public class ActorBuff : IActorBuff
    {
        private readonly List<int> m_DelBuffList = new List<int>();
        private readonly Map<int, BuffBase> m_BuffMap = new Map<int, BuffBase>();
        private ActorBase m_Owner;

        public ActorBuff(ActorBase owner)
        {
            this.m_Owner = owner;
        }

        public void AddBuff(int id, ActorBase caster)
        {
            if (m_Owner.IsDead)
            {
                return;
            }

            DRBuff db = GameEntry.DataTable.GetDataTable<DRBuff>()?.GetDataRow(id);
            if (db == null)
            {
                return;
            }

            BuffBase commonBuff = FindBuff(id);
            if (commonBuff != null)
            {
                switch ((BuffOverlayType)commonBuff.Data.OverlayType)
                {
                    case BuffOverlayType.Overlay:
                        commonBuff.Overlay();
                        break;
                    case BuffOverlayType.Reset:
                        commonBuff.Refresh();
                        break;
                    case BuffOverlayType.Cancle:
                        m_DelBuffList.Add(commonBuff.Id);
                        break;
                }
                return;
            }
            CommandReplyType reply = CommandReplyType.NO;
            switch ((BattleActType)db.Result)
            {
                case BattleActType.Addattr:
                case BattleActType.Subattr:
                case BattleActType.Lddattr:
                case BattleActType.Lubattr:
                    {
                        reply = CommandReplyType.YES;
                    }
                    break;
                case BattleActType.Super:
                    {
                        reply = CommandReplyType.YES;
                    }
                    break;
                case BattleActType.Variation:
                    {
                        reply = m_Owner.ExecuteCommand(new VariationCommand(db.LifeTime, db.ChangeModelID));
                    }
                    break;
                case BattleActType.Hitfly:
                    {
                        reply = m_Owner.ExecuteCommand(new BeatFlyCommand());
                    }   
                    break;
                case BattleActType.Hitdown:
                    {
                        reply = m_Owner.ExecuteCommand(new BeatDownCommand());
                    }
                    break;
                case BattleActType.Hitback:
                    {
                        reply = m_Owner.ExecuteCommand(new BeatBackCommand());
                    }
                    break;
                case BattleActType.Stun:
                    {
                        reply = m_Owner.ExecuteCommand(new StunCommand(db.LifeTime));
                    }
                    break;
                case BattleActType.Fixbody:
                    {
                        reply = m_Owner.ExecuteCommand(new FixBodyCommand(db.LifeTime));
                    }
                    break;
                case BattleActType.Stealth:
                    {
                        reply = m_Owner.ExecuteCommand(new StealthCommand(db.LifeTime));
                    }
                    break;
                case BattleActType.Frozen:
                    {
                        reply = m_Owner.ExecuteCommand(new FrostCommand(db.LifeTime));
                    }
                    break;
                case BattleActType.Blind:
                    {
                        reply = m_Owner.ExecuteCommand(new BlindCommand(db.LifeTime));
                    }
                    break;
                case BattleActType.Silent:
                    {
                        reply = m_Owner.ExecuteCommand(new SilentCommand(db.LifeTime));
                    }
                    break;
                case BattleActType.Sleep:
                    {
                        reply = m_Owner.ExecuteCommand(new SleepCommand(db.LifeTime));
                    }
                    break;
                case BattleActType.Absorb:
                    {
                        reply = CommandReplyType.YES;
                    }
                    break;
                case BattleActType.Wild:
                    {
                        reply = CommandReplyType.YES;
                    }
                    break;
                case BattleActType.Divive:
                    {
                        RemoveAllDebuff();
                        reply = CommandReplyType.YES;
                    }
                    break;
                case BattleActType.Paraly:
                    {
                        reply = CommandReplyType.YES;
                    }
                    break;
                case BattleActType.Fear:
                    {
                        reply = CommandReplyType.YES;
                    }
                    break;
                case BattleActType.Reflex:
                    {
                        reply = CommandReplyType.YES;
                    }
                    break;
                case BattleActType.Dead:
                    {
                        reply = CommandReplyType.YES;
                    }
                    break;
            }

            if (reply == CommandReplyType.YES)
            {
                BuffBase buff = new BuffBase(id, m_Owner, caster);
                m_BuffMap.Add(id, buff);
            }

            m_Owner.UpdateCurAttribute();
        }

        public void Step()
        {
            if(m_Owner.IsDead)
                return;

            if (m_BuffMap.Count > 0)
            {
                for (m_BuffMap.Begin(); m_BuffMap.Next();)
                {
                    BuffBase buff = m_BuffMap.Value;
                    buff.Update();
                    if (buff.IsDead)
                    {
                        m_DelBuffList.Add(buff.Id);
                    }
                }
            }
            for (int i = 0; i < m_DelBuffList.Count; i++)
            {
                int id = m_DelBuffList[i];
                if (m_BuffMap.ContainsKey(id))
                {
                    m_BuffMap[id].Exit();
                    m_BuffMap.Remove(id);
                }
            }
            if (m_DelBuffList.Count > 0)
            {
                m_Owner.UpdateCurAttribute();
                m_DelBuffList.Clear();
            }
        }

        public Map<int, BuffBase> GetAllBuff()
        {
            return m_BuffMap;
        }

        public void SetAllEffectEnable(bool enabled)
        {
            Map<int, BuffBase>.Enumerator em = m_BuffMap.GetEnumerator();
            while (em.MoveNext())
            {
                BuffBase buff = em.Current.Value;
                buff.SetEffectEnable(enabled);
            }
            em.Dispose();
        }

        public void Clear()
        {
            RemoveAllBuff();
        }

        public BuffBase FindBuff(int id)
        {
            BuffBase buff = null;
            m_BuffMap.TryGetValue(id, out buff);
            return buff;
        }

        public void RemoveBuff(int id)
        {
            m_DelBuffList.Add(id);
        }

        public void RemoveAllDot()
        {
            for (m_BuffMap.Begin(); m_BuffMap.Next();)
            {
                if ((BattleActType) m_BuffMap.Value.Data.Result == BattleActType.Lubattr)
                {
                    m_DelBuffList.Add(m_BuffMap.Key);
                }
            }
        }

        public void RemoveAllDebuff()
        {
            for (m_BuffMap.Begin(); m_BuffMap.Next();)
            {
                if ((BuffType) m_BuffMap.Value.Data.BuffType == BuffType.Debuff)
                {
                    m_DelBuffList.Add(m_BuffMap.Key);
                }
            }
        }

        public void RemoveAllControl()
        {
            for (m_BuffMap.Begin(); m_BuffMap.Next();)
            {
                if (IsControlBuff(m_BuffMap.Value))
                {
                    m_DelBuffList.Add(m_BuffMap.Key);
                }
            }
        }

        public void RemoveAllBuff()
        {
            for (m_BuffMap.Begin(); m_BuffMap.Next();)
            {
                m_DelBuffList.Add(m_BuffMap.Value.Id);
            }
        }

        private bool IsControlBuff(BuffBase buff)
        {
            switch ((BattleActType)buff.Data.Result)
            {
                case BattleActType.Blind:
                case BattleActType.Fear:
                case BattleActType.Fixbody:
                case BattleActType.Frozen:
                case BattleActType.Paraly:
                case BattleActType.Sleep:
                case BattleActType.Stun:
                case BattleActType.Variation:
                    return true;
            }
            return false;
        }


    }
}
