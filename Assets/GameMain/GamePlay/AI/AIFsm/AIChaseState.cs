using GameFramework.Fsm;

namespace GameMain
{
    public class AIChaseState : AIFsmStateBase
    {
        public AIChaseState(AIStateType state) : base(state)
        {

        }

        protected override void OnUpdate(IFsm<ActorBase> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

            switch (m_Owner.ActorType)
            {
                case ActorType.Monster:
                {
                    if (m_Owner.Target == null)
                    {
                        return;
                    }
                    float dist = GlobalTools.GetHorizontalDistance(m_Owner.Pos, m_Owner.Target.Pos);
                    if (dist > AI.WaringDist)
                    {
                        ChangeState<AIBackState>();
                    }
                    else if (dist < AI.AttackDist)
                    {
                        ChangeState<AIFightState>();
                        return;
                    }
                }
                    break;
                case ActorType.Partner:
                {
                    if (m_Owner.Target?.CachedTransform == null)
                    {
                        ChangeState<AIIdleState>();
                        return;
                    }

                    float dist = GlobalTools.GetHorizontalDistance(m_Owner.Pos, m_Owner.Target.Pos);
                    if (dist > AI.WaringDist)
                    {
                        ChangeState<AIIdleState>();
                        return;
                    }
                    else if (dist < AI.AttackDist)
                    {
                        ChangeState<AIFightState>();
                        return;
                    }
                }
                    break;
                case ActorType.Player:
                {
                    if (m_Owner.Target == null)
                    {
                        ChangeState<AIIdleState>();
                        return;
                    }
                    float dist = GlobalTools.GetHorizontalDistance(m_Owner.Pos, m_Owner.Target.Pos);

                    if (dist < AI.AttackDist)
                    {
                        ChangeState<AIFightState>();
                        return;
                    }
                }
                    break;
            }

            if (m_Owner.Target != null)
            {
                m_Owner.ExecuteCommand(new AutoMoveCommand(m_Owner.Target));
            }

        }


    }
}