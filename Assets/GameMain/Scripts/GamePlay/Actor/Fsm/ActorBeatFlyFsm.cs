using GameFramework.Fsm;

namespace GameMain
{
    public class ActorBeatFlyFsm : ActorFsmStateBase
    {
        public ActorBeatFlyFsm(ActorFsmStateType state) : base(state)
        {

        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);
            m_Owner.OnBeatFly();
        }
    }
}
