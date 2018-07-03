using GameFramework.Fsm;

namespace GameMain
{
    public class ActorFixBodyFsm : ActorFsmStateBase
    {
        public ActorFixBodyFsm(ActorFsmStateType state) : base(state)
        {
        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);
            m_Owner.ApplyRootMotion(false);
        }

        protected override void OnLeave(IFsm<ActorBase> fsm, bool isShutdown)
        {
            base.OnLeave(fsm, isShutdown);
            m_Owner.ApplyRootMotion(true);
        }
    }
}
