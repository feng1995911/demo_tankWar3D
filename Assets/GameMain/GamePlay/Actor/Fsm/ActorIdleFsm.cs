using GameFramework.Fsm;

namespace GameMain
{
    public class ActorIdleFsm : ActorFsmStateBase
    {
        public ActorIdleFsm(ActorFsmStateType state) : base(state)
        {
        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);
            m_Owner.OnIdle();
        }
    }
}
