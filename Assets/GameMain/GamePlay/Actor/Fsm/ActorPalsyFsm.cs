using GameFramework.Fsm;

namespace GameMain
{
    public class ActorPalsyFsm : ActorFsmStateBase
    {
        public ActorPalsyFsm(ActorFsmStateType state) : base(state)
        {
        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);

        }
    }
}
