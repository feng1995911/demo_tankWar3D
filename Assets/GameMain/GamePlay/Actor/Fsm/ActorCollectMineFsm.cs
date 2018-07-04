using GameFramework.Fsm;

namespace GameMain
{
    public class ActorCollectMineFsm : ActorFsmStateBase
    {
        public ActorCollectMineFsm(ActorFsmStateType state) : base(state)
        {

        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);
            CollectMineCommand ev = m_Command as CollectMineCommand;
            if (ev.LastTime > 0)
            {
                GameEntry.Timer.Register(ev.LastTime, Break);
            }
            m_Owner.OnCollectMine(ev);
        }

    }
}
