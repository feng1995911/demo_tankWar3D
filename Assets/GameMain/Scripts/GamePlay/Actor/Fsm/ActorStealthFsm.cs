using GameFramework.Fsm;

namespace GameMain
{
    public class ActorStealthFsm : ActorFsmStateBase
    {
        public ActorStealthFsm(ActorFsmStateType state) : base(state)
        {
        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);

        }
    }
}
