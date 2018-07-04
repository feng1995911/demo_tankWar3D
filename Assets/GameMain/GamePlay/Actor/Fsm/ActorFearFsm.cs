using GameFramework.Fsm;

namespace GameMain
{
    public class ActorFearFsm : ActorFsmStateBase
    {
        public ActorFearFsm(ActorFsmStateType state) : base(state)
        {
        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);

        }
    }
}
