using GameFramework.Fsm;

namespace GameMain
{
    public class ActorRebornFsm : ActorFsmStateBase
    {
        public ActorRebornFsm(ActorFsmStateType state) : base(state)
        {
        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);
            RebornCommand ev = m_Command as RebornCommand;
            if (ev.LastTime > 0)
            {
                GameEntry.Timer.Register(ev.LastTime, Break);
                m_Owner.OnReborn();
            }
        }
    }
}
