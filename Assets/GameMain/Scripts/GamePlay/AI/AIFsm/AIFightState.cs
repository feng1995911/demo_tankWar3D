using GameFramework.Fsm;

namespace GameMain
{
    public class AIFightState : AIFsmStateBase
    {
        public AIFightState(AIStateType state) : base(state)
        {

        }

        protected override void OnUpdate(IFsm<ActorBase> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

            ActorBase pTarget = m_Owner.Target;
            switch (m_Owner.ActorType)
            {
                case ActorType.Monster:
                {
                    if (pTarget == null)
                    {
                        ChangeState<AIBackState>();
                        return;
                    }
                    Fight();
                }
                    break;
                case ActorType.Partner:
                {
                    if (pTarget == null)
                    {
                        ChangeState<AIFollowState>();
                        return;
                    }
                    Fight();
                }
                    break;
                case ActorType.Player:
                {
                    if (pTarget == null)
                    {
                        ChangeState<AIIdleState>();
                        return;
                    }
                    Fight();
                }
                    break;
            }


        }

        private void Fight()
        {
            float dist = GlobalTools.GetHorizontalDistance(m_Owner.Pos, m_Owner.Target.Pos);
            if (dist > AI.AttackDist)
            {
                ChangeState<AIChaseState>();
                return;
            }

            if (m_Owner.CurFsmStateType == ActorFsmStateType.FSM_SKILL)
            {
                return;
            }
            SkillTree skill = m_Owner.ActorSkill.FindNextSkillByDist(dist);
            if (skill != null)
            {
                m_Owner.ExecuteCommand(new UseSkillCommand(skill.Pos));
            }
            else
            {
                m_Owner.ExecuteCommand(new IdleCommand());
            }
        }

    }
}