using GameFramework.Fsm;

namespace GameMain
{
    public class ActorHookFsm : ActorFsmStateBase
    {
        public ActorHookFsm(ActorFsmStateType state) : base(state)
        {
        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);

        }
    }
}
