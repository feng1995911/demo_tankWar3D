using System.Collections.Generic;
using GameFramework.Fsm;

namespace GameMain
{
    public class ActorFsmAI : ActorAIBase
    {
        protected IFsm<ActorBase> m_AIFsm;
        protected string m_FsmName = string.Empty;

        public ActorFsmAI(ActorBase owner, AIModeType mode, float atkDist, float followDist, float waringDist, float findEnemyInterval)
            : base(owner, mode, atkDist, followDist, waringDist, findEnemyInterval)
        {
            m_FsmName = GlobalTools.Format("ActorAIFsm[{0}][{1}]", Owner.Id, owner.EntityId);

            FsmState<ActorBase>[] states =
            {
                new AIEmptyState(AIStateType.Empty), 
                new AIIdleState(AIStateType.Idle),
                new AIFollowState(AIStateType.Follow),
                new AIFleeState(AIStateType.Flee),
                new AIPatrolState(AIStateType.Patrol),
                new AIEscapeState(AIStateType.Escape),
                new AIBackState(AIStateType.Back),
                new AIFightState(AIStateType.Fight),
                new AIDeadState(AIStateType.Dead),
                new AIChaseState(AIStateType.Chase),
            };
            m_AIFsm = GameEntry.Fsm.CreateFsm(m_FsmName, Owner as ActorBase, states);
        }

        public override void Start()
        {
            if (AIMode == AIModeType.Hand || Owner.IsDead)
            {
                return;
            }

            if (m_AIFsm.IsRunning)
            {
                ChangeAIState(AIStateType.Idle);
                return;
            }

            m_AIFsm.Start<AIIdleState>();
            this.AIStateType = AIStateType.Idle;
        }

        public override void Step()
        {
            if (AIMode == AIModeType.Hand || Owner.IsDead)
            {
                return;
            }
        }

        public override void Stop()
        {
            ChangeAIState(AIStateType.Empty);
        }

        public override void Clear()
        {
            GameEntry.Fsm.DestroyFsm<ActorBase>(m_FsmName);
        }

        public override void ChangeAIState(AIStateType stateType)
        {
            if (AIStateType != stateType)
            {
                AIStateType = stateType;
                AIFsmStateBase curState = m_AIFsm.CurrentState as AIFsmStateBase;
                if(curState == null)
                    return;

                switch (stateType)
                {
                    case AIStateType.Empty:
                        curState.ChangeState<AIEmptyState>();
                        break;
                    case AIStateType.Idle:
                        curState.ChangeState<AIIdleState>();
                        break;
                    case AIStateType.Follow:
                        curState.ChangeState<AIFollowState>();
                        break;
                    case AIStateType.Flee:
                        curState.ChangeState<AIFleeState>();
                        break;
                    case AIStateType.Patrol:
                        curState.ChangeState<AIPatrolState>();
                        break;
                    case AIStateType.Escape:
                        curState.ChangeState<AIEscapeState>();
                        break;
                    case AIStateType.Back:
                        curState.ChangeState<AIBackState>();
                        break;
                    case AIStateType.Fight:
                        curState.ChangeState<AIFightState>();
                        break;
                    case AIStateType.Dead:
                        curState.ChangeState<AIDeadState>();
                        break;
                    case AIStateType.Chase:
                        curState.ChangeState<AIChaseState>();
                        break;
                }

            }
        }
    }
}
