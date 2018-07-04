using GameFramework.Fsm;
using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// AI状态基类
    /// </summary>
    public class AIFsmStateBase : FsmState<ActorBase>
    {
        /// <summary>
        /// 当前状态类型
        /// </summary>
        public AIStateType StateType { get; protected set; }

        protected IFsm<ActorBase> m_Fsm;
        protected ActorBase m_Owner;

        public IActorAI AI
        {
            get { return m_Owner.ActorAI; }
        }

        public AIFsmStateBase(AIStateType state)
        {
            StateType = state;
        }

        protected override void OnInit(IFsm<ActorBase> fsm)
        {
            base.OnInit(fsm);
            m_Fsm = fsm;
            m_Owner = fsm.Owner;
        }

        protected override void OnUpdate(IFsm<ActorBase> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

            if (m_Owner.IsDead)
            {
                ChangeState<AIDeadState>();
                return;
            }
            if (AI.AIMode == AIModeType.Auto && m_Owner.Target == null)
            {
                IntervalFindEnemy();
            }
        }

        private void IntervalFindEnemy()
        {
            if (AI.FindEnemyInterval >= Constant.Define.MinFindenemyInterval)
            {
                ActorBase enemy = m_Owner.GetNearestEnemy(AI.WaringDist);
                if (enemy != null)
                    this.m_Owner.SetTarget(enemy);
                AI.FindEnemyTimer = 0;
            }
            else
            {
                AI.FindEnemyTimer += Time.deltaTime;
            }
        }


        public void ChangeState<T>() where T : AIFsmStateBase
        {
            ChangeState<T>(m_Fsm);
        }
    }
}
