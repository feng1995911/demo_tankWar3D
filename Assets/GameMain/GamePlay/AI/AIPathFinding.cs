using System;
using UnityEngine;
using UnityEngine.AI;

namespace GameMain
{
    public class AIPathFinding : IAIPathFinding
    {
        private readonly ActorBase m_Owner;
        private readonly NavMeshAgent m_NavMeshAgent;
        private readonly NavMeshPath m_NavMeshPath;
        private GameObject m_GameObject;
        private Vector3 m_DestPosition;
        private Action m_OnFinished;

        public bool CheckReached()
        {
            if (!m_NavMeshAgent.enabled)
            {
                return false;
            }

            float dis = Mathf.Abs(m_NavMeshAgent.remainingDistance);
            return dis <= 1f && dis > 0.01f;
        }

        public AIPathFinding(ActorBase owner)
        {
            m_Owner = owner;
            m_GameObject = m_Owner.EntityGo;
            this.m_NavMeshAgent = m_GameObject.GetOrAddComponent<NavMeshAgent>();
            this.m_NavMeshPath = new NavMeshPath();
            m_NavMeshAgent.enabled = false;
            m_NavMeshAgent.radius = m_Owner.Radius;
            m_NavMeshAgent.height = m_Owner.Height;
            m_NavMeshAgent.acceleration = 360;
            m_NavMeshAgent.angularSpeed = 360;
            m_NavMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
        }

        public void SetAgentEnable(bool enable)
        {
            this.m_NavMeshAgent.enabled = enable;
        }

        public void SetDestPosition(Vector3 dest)
        {
            m_DestPosition = dest;
            SetAgentEnable(true);
            this.m_NavMeshAgent.speed = m_Owner.Attrbute.GetValue(AttributeType.Speed);
            m_NavMeshAgent.SetDestination(m_DestPosition);
            m_Owner.CachedTransform.LookAt2D(new Vector2(m_DestPosition.x, m_DestPosition.z));
        }

        public void Step()
        {
            if (m_NavMeshAgent.enabled == false)
            {
                return;
            }
            if (!m_Owner.CheckActorState(ActorStateType.IsAutoToMove))
            {
                return;
            }
            if (!CheckReached())
                return;

            m_Owner.OnArrive();
            m_OnFinished?.Invoke();
            m_OnFinished = null;
        }

        public void Start()
        {

        }

        public void Clear()
        {

        }

        public void StopPathFinding()
        {
            if (m_NavMeshAgent.enabled == true && m_NavMeshAgent.isOnNavMesh)
            {
                m_NavMeshAgent.isStopped = true;
                SetAgentEnable(false);
            }
        }

        public bool CanReachPosition(Vector3 dest)
        {
            Vector3 position = GlobalTools.NavSamplePosition(dest);
            m_NavMeshAgent.enabled = true;
            m_NavMeshAgent.CalculatePath(position, m_NavMeshPath);
            if (m_NavMeshPath.status != NavMeshPathStatus.PathPartial)
            {
                return true;
            }
            return false;
        }

        public void SetOnFinished(Action callback)
        {
            m_OnFinished = callback;
        }
    }
}
