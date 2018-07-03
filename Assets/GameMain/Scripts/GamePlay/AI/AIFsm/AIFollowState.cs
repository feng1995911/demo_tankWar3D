using GameFramework.Fsm;
using UnityEngine;

namespace GameMain
{

    public class AIFollowState : AIFsmStateBase
    {
        public AIFollowState(AIStateType state) : base(state)
        {
        }

        protected override void OnUpdate(IFsm<ActorBase> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

            ActorPlayer host = m_Owner.Host as ActorPlayer;
            if (host == null)
            {
                return;
            }

            Vector3 pos = host.GetPartnerPosBySort(m_Owner.Sort);

            m_Owner.ExecuteCommand(new AutoMoveCommand(pos, OnFollowFinished));
        }

        private void OnFollowFinished()
        {
            ChangeState<AIIdleState>();
        }

        protected override void OnLeave(IFsm<ActorBase> fsm, bool isShutdown)
        {
            m_Owner.GotoEmptyFsm();
        }
    }
}