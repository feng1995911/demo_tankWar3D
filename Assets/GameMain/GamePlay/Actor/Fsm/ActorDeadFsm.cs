using GameFramework.Fsm;

namespace GameMain
{
    public class ActorDeadFsm : ActorFsmStateBase
    {
        public ActorDeadFsm(ActorFsmStateType state) : base(state)
        {
        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);
            m_Owner.ApplyCharacterCtrl(false);
            m_Owner.OnDead(m_Command as DeadCommand);
        }
    }
}
