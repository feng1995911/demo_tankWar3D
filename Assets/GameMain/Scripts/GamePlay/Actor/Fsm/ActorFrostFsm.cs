using GameFramework.Fsm;

namespace GameMain
{
    public class ActorFrostFsm : ActorFsmStateBase
    {
        public ActorFrostFsm(ActorFsmStateType state) : base(state)
        {
        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);
            FrostCommand ev = m_Command as FrostCommand;
            if (ev.LastTime > 0)
            {
                GameEntry.Timer.Register(ev.LastTime, Break);
            }
            m_Owner.ApplyRootMotion(false);
            m_Owner.ApplyAnimator(false);
        }

        protected override void OnLeave(IFsm<ActorBase> fsm, bool isShutdown)
        {
            base.OnLeave(fsm, isShutdown);
            m_Owner.ApplyRootMotion(true);
            m_Owner.ApplyAnimator(true);
        }
    }
}
