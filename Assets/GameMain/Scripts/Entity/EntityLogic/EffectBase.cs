using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{
    /// <summary>
    /// 特效
    /// </summary>
    public class EffectBase : EntityBase
    {
        public EffectStateType State { get; protected set; }

        [SerializeField]
        protected EffectData m_EffectData = null;
        protected Vector3 m_TargetPos;
        protected Vector3 m_StartPos;
        protected ActorBase m_Target;
        protected ActorBase m_Owner;
        protected Timer m_DelayTimer = null;
        protected float m_ElapseSeconds = 0f;


        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_EffectData = userData as EffectData;
            if (m_EffectData == null)
            {
                Log.Error("Effect Data is invalid.");
                return;
            }

            m_Target = m_EffectData.Target;
            m_Owner = m_EffectData.Owner;
            if (m_EffectData.Owner == null || m_EffectData.Owner.CachedTransform == null)
            {
                this.SwitchState(EffectStateType.Error);
            }
            else
            {
                this.SwitchState(EffectStateType.Wait);
            }

            m_ElapseSeconds = 0f;

            if (m_EffectData.DelayTime > 0.001)
            {
                SwitchState(EffectStateType.Wait);
                m_DelayTimer = GameEntry.Timer.Register(m_EffectData.DelayTime, Load);
            }
            else
            {
                Load();
                SwitchState(EffectStateType.Update);
            }
        }

        protected override void OnAttachTo(EntityLogic parentEntity, Transform parentTransform, object userData)
        {
            base.OnAttachTo(parentEntity, parentTransform, userData);

            CachedTransform.localPosition = m_EffectData.PosOffset;
            CachedTransform.localEulerAngles = m_EffectData.EulerOffset;
            CachedTransform.localScale = m_EffectData.Scale;
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            if (this.State != EffectStateType.Update || CachedTransform == null)
            {
                return;
            }

            switch (m_EffectData.FlyType)
            {
                case FlyObjFlyType.Line:
                    {
                        MoveExecuteLine();
                    }
                    break;
                case FlyObjFlyType.Cross:
                    {
                        MoveExecuteLine();
                    }
                    break;
                case FlyObjFlyType.Throw:
                    {
                        MoveExecuteThrow();
                    }
                    break;
                case FlyObjFlyType.Back:
                    {
                        MoveExecuteGoBack();
                    }
                    break;
                case FlyObjFlyType.Pursue:
                    {
                        MoveExecutePursue();
                    }
                    break;
            }

            if (m_EffectData.KeepTime > 0)
            {
                if (m_ElapseSeconds < m_EffectData.KeepTime)
                {
                    m_ElapseSeconds += Time.deltaTime;
                }
                else
                {
                    SwitchState(EffectStateType.Dead);
                }
            }
        }

        public void Reset()
        {
            m_ElapseSeconds = 0;
        }

        public void Load()
        {
            if(m_Owner?.CachedTransform == null)
                return;

            switch (m_EffectData.BindType)
            {
                case EffectBindType.World:
                    {
                        CachedTransform.position = m_EffectData.PosOffset;
                        CachedTransform.eulerAngles = m_EffectData.EulerOffset;
                    }
                    break;
                case EffectBindType.Trans:
                    {
                        if (m_EffectData.Parent == null)
                        {
                            CachedTransform.position = m_EffectData.PosOffset;
                            CachedTransform.eulerAngles = m_EffectData.EulerOffset;
                        }
                        else
                        {
                            m_EffectData.SetParent = true;
                            CachedTransform.position = m_EffectData.Parent.position + m_EffectData.PosOffset;
                            CachedTransform.eulerAngles = m_EffectData.Parent.eulerAngles + m_EffectData.EulerOffset;
                        }
                    }
                    break;

                case EffectBindType.OwnBody:
                    {
                        CachedTransform.eulerAngles = m_Owner.CachedTransform.localEulerAngles + m_EffectData.EulerOffset;
                        CachedTransform.position = m_Owner.GetBind(ActorBindPosType.Body, m_EffectData.PosOffset);
                    }
                    break;
                case EffectBindType.OwnHead:
                    {
                        CachedTransform.eulerAngles = m_Owner.CachedTransform.localEulerAngles + m_EffectData.EulerOffset;
                        CachedTransform.position = m_Owner.GetBind(ActorBindPosType.Head, m_EffectData.PosOffset);
                    }
                    break;
                case EffectBindType.OwnFoot:
                    {
                        CachedTransform.eulerAngles = m_Owner.CachedTransform.localEulerAngles + m_EffectData.EulerOffset;
                        CachedTransform.position = m_Owner.GetBind(ActorBindPosType.Foot, m_EffectData.PosOffset);
                    }
                    break;
                case EffectBindType.OwnHand:
                    {
                        m_EffectData.SetParent = true;
                        Transform[] hands = m_Owner.GetHands();
                        if (hands != null && hands[0] != null)
                        {
                            m_EffectData.Parent = hands[0];
                            CachedTransform.position = m_EffectData.Parent.position + m_EffectData.PosOffset;
                            CachedTransform.eulerAngles = m_EffectData.Parent.eulerAngles + m_EffectData.EulerOffset;
                        }
                        else
                        {
                            CachedTransform.position = m_EffectData.PosOffset;
                            CachedTransform.eulerAngles = m_EffectData.EulerOffset;
                        }
                    }
                    break;
                case EffectBindType.TarBody:
                    {
                        ActorBase actor = m_Target ?? m_Owner;
                        CachedTransform.position = actor.GetBind(ActorBindPosType.Head, m_EffectData.PosOffset);
                    }
                    break;
                case EffectBindType.TarFoot:
                    {
                        ActorBase actor = m_Target ?? m_Owner;
                        CachedTransform.position = actor.GetBind(ActorBindPosType.Foot, m_EffectData.PosOffset);
                    }
                    break;
                case EffectBindType.TarHead:
                    {
                        ActorBase actor = m_Target ?? m_Owner;
                        CachedTransform.position = actor.GetBind(ActorBindPosType.Head, m_EffectData.PosOffset);
                    }
                    break;
                case EffectBindType.OwnVTar:
                    {
                        if (m_Owner?.CachedTransform != null && m_Target != null)
                        {
                            Vector3 pos1 = m_Target.GetBind(ActorBindPosType.Body, Vector3.zero);
                            Vector3 pos2 = m_Owner.GetBind(ActorBindPosType.Body, Vector3.zero);
                            CachedTransform.position = (pos1 - pos2) * 0.5f + pos2;
                        }
                        else
                        {
                            if (m_Owner?.CachedTransform != null)
                                CachedTransform.position = m_Owner.GetBind(ActorBindPosType.Body, Vector3.zero) + m_Owner.Dir * 10;
                        }
                    }
                    break;
            }

            if (m_EffectData.SetParent && m_EffectData.Parent != null)
            {
                CachedTransform.parent = m_EffectData.Parent;
            }

            m_StartPos = CachedTransform.position;
            this.State = EffectStateType.Update;
        }

        public void SwitchState(EffectStateType state)
        {
            State = state;
            if (state == EffectStateType.Dead)
            {
                Clear();
            }
        }

        public void MoveExecuteLine()
        {
            MoveByDir(CachedTransform.forward);
        }

        public void MoveExecuteThrow()
        {

        }

        public void MoveExecuteGoBack()
        {

        }

        public void MoveExecutePursue()
        {
            if (m_Target == null || m_Target.CachedTransform == null)
            {
                MoveByDir(CachedTransform.forward);
            }
            else
            {
                MoveTo(CachedTransform.position, m_Target.GetBind(ActorBindPosType.Body, Vector3.zero));
            }
        }

        public void MoveExecuteCross()
        {

        }

        public void MoveByDir(Vector3 dict)
        {
            Vector3 dir = dict;
            dir.Normalize();
            if (dir == Vector3.zero)
            {
                return;
            }
            CachedTransform.rotation = Quaternion.LookRotation(dir);
            Vector3 move = dir * Time.deltaTime * m_EffectData.FlySpeed;
            CachedTransform.position += move;
        }

        public void MoveTo(Vector3 from, Vector3 to)
        {
            MoveByDir(to - from);
        }

        public bool IsDead()
        {
            return State == EffectStateType.Error || State == EffectStateType.Dead;
        }

        public void Clear()
        {
            GameEntry.Timer.UnRegister(m_DelayTimer);
            GameEntry.Entity.CheckHideEntity(m_EffectData.Id);
        }

    }

}
