using UnityEngine;
using System.Collections;
using GameFramework.Fsm;

namespace GameMain
{
    public class AIBackState : AIFsmStateBase
    {
        public AIBackState(AIStateType state) : base(state)
        {
        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);

            m_Owner.SetTarget(null);
            m_Owner.ExecuteCommand(new AutoMoveCommand(m_Owner.BornParam.Position, OnBackFinished));
        }

        protected override void OnUpdate(IFsm<ActorBase> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

            if (m_Owner.Target == null)
            {
                return;
            }

            float dist = GlobalTools.GetHorizontalDistance(m_Owner.Pos, m_Owner.Target.Pos);

            if (dist < AI.AttackDist)
            {
                ChangeState<AIFightState>();
            }
        }

        private void OnBackFinished()
        {
            if (!m_Owner.IsDead)
                ChangeState<AIIdleState>();
        }
    }
}