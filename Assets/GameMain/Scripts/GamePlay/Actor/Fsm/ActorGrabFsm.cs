using GameFramework.Fsm;

namespace GameMain
{
    public class ActorGrabFsm : ActorFsmStateBase
    {
        public ActorGrabFsm(ActorFsmStateType state) : base(state)
        {
        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);

        }
    }
}
