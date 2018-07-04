using GameFramework.Fsm;

namespace GameMain
{
    public class ActorInteractiveFsm : ActorFsmStateBase
    {
        public ActorInteractiveFsm(ActorFsmStateType state) : base(state)
        {
        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);
            InteractiveCommand ev = m_Command as InteractiveCommand;
            if (ev.LastTime > 0)
            {
                GameEntry.Timer.Register(ev.LastTime, Break);
            }
            m_Owner.OnInteractive(ev);
        }
    }
}
