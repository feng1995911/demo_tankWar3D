using GameFramework.Fsm;

namespace GameMain
{
    /// <summary>
    /// 行动者状态基类
    /// </summary>
    public class ActorFsmStateBase : FsmState<ActorBase>
    {
        /// <summary>
        /// 当前状态类型
        /// </summary>
        public ActorFsmStateType StateType { get; protected set; }

        protected IFsm<ActorBase> m_Fsm;
        protected ActorBase m_Owner;

        protected ICommand m_Command;

        public ActorFsmStateBase(ActorFsmStateType state)
        {
            StateType = state;
        }

        protected override void OnInit(IFsm<ActorBase> fsm)
        {
            base.OnInit(fsm);
            m_Fsm = fsm;
            m_Owner = fsm.Owner;
        }

        protected virtual void Break()
        {
            ChangeState<ActorIdleFsm>();
        }

        public virtual void SetCommand(ICommand cmd)
        {
            m_Command = cmd;
        }

        public void ChangeState<T>() where T :ActorFsmStateBase
        {
            if (m_Fsm?.CurrentState == null)
                return;

            ChangeState<T>(m_Fsm);
        }
    }
}
