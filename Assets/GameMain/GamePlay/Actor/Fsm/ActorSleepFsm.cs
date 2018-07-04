using GameFramework.Fsm;

namespace GameMain
{
    public class ActorSleepFsm : ActorFsmStateBase
    {
        public ActorSleepFsm(ActorFsmStateType state) : base(state)
        {
        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);

        }
    }
}
