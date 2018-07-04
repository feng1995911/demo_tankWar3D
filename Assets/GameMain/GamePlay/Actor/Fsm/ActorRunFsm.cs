using GameFramework.Fsm;

namespace GameMain
{
    public class ActorRunFsm : ActorFsmStateBase
    {
        public ActorRunFsm(ActorFsmStateType state) : base(state)
        {
        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);

            if (m_Command is AutoMoveCommand)
            {
                AutoMoveCommand autoMove = m_Command as AutoMoveCommand;
                m_Owner.OnPursue(autoMove);
            }
            else
            {
                MoveCommand move = m_Command as MoveCommand;
                m_Owner.OnForceToMove(move);
            }
        }
    }
}
