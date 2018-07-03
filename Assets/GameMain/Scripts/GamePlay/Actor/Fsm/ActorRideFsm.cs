using GameFramework.Fsm;

namespace GameMain
{
    public class ActorRideFsm : ActorFsmStateBase
    {
        public ActorRideFsm(ActorFsmStateType state) : base(state)
        {
        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);

        }
    }
}
