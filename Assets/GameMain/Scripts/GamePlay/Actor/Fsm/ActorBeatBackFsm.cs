using GameFramework.Fsm;

namespace GameMain
{
    public class ActorBeatBackFsm : ActorFsmStateBase
    {
        public ActorBeatBackFsm(ActorFsmStateType state) : base(state)
        {

        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);
            BeatBackCommand command = m_Command as BeatBackCommand;

            m_Owner.OnBeatBack(command);
            m_Owner.ApplyRootMotion(false);
        }

        protected override void OnLeave(IFsm<ActorBase> fsm, bool isShutdown)
        {
            base.OnLeave(fsm, isShutdown);
            m_Owner.ApplyRootMotion(true);
        }

    }
}
