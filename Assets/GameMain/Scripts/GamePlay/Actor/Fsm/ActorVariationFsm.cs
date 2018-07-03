using GameFramework.Fsm;

namespace GameMain
{
    public class ActorVariationFsm : ActorFsmStateBase
    {
        public ActorVariationFsm(ActorFsmStateType state) : base(state)
        {
        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);

        }
    }
}
