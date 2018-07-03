using GameFramework.Fsm;

namespace GameMain
{
    public class ActorJumpFsm : ActorFsmStateBase
    {
        public ActorJumpFsm(ActorFsmStateType state) : base(state)
        {
        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);
            m_Owner.OnJump();
        }
    }
}
