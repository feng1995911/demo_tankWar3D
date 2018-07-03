using GameFramework.Fsm;

namespace GameMain
{
    public class AIEmptyState : AIFsmStateBase
    {
        public AIEmptyState(AIStateType state) : base(state)
        {
        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);

            m_Owner.OnIdle();
        }

        protected override void OnUpdate(IFsm<ActorBase> fsm, float elapseSeconds, float realElapseSeconds)
        {

        }

    }
}
