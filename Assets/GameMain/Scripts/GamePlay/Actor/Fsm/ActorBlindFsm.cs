using GameFramework.Fsm;

namespace GameMain
{
    public class ActorBlindFsm : ActorFsmStateBase
    {
        public ActorBlindFsm(ActorFsmStateType state) : base(state)
        {

        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);

        }

    }
}
