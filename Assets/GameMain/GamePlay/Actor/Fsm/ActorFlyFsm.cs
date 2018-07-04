using GameFramework.Fsm;

namespace GameMain
{
    public class ActorFlyFsm : ActorFsmStateBase
    {
        public ActorFlyFsm(ActorFsmStateType state) : base(state)
        {
        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);

        }
    }
}
