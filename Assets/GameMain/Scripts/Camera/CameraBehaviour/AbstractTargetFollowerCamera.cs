using UnityEngine;

namespace GameMain
{
    public abstract class AbstractTargetFollowerCamera : MonoBehaviour
    {
        public enum UpdateType 
        {
            FixedUpdate,
            LateUpdate, 
            ManualUpdate, 
        }

        [SerializeField]protected Transform m_Target;   
        [SerializeField]private bool m_AutoTargetPlayer = true;  
        [SerializeField]private UpdateType m_UpdateType;

        protected Rigidbody targetRigidbody;

        protected Transform m_Cam; 
        protected Transform m_Pivot; 
        protected Vector3 m_LastTargetPosition;

        protected virtual void Awake()
        {
            m_Cam = Camera.main.transform;
            m_Pivot = m_Cam.parent;
        }

        protected virtual void Start()
        {
            if (m_AutoTargetPlayer)
            {
                FindAndTargetPlayer();
            }

            if (m_Target == null) return;

            targetRigidbody = m_Target.GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (m_AutoTargetPlayer && (m_Target == null || !m_Target.gameObject.activeSelf))
            {
                FindAndTargetPlayer();
            }
            if (m_UpdateType == UpdateType.FixedUpdate)
            {
                FollowTarget(Time.deltaTime);
            }
        }

        private void LateUpdate()
        {
            if (m_AutoTargetPlayer && (m_Target == null || !m_Target.gameObject.activeSelf))
            {
                FindAndTargetPlayer();
            }
            if (m_UpdateType == UpdateType.LateUpdate)
            {
                FollowTarget(Time.deltaTime);
            }
        }

        public void ManualUpdate()
        {
            if (m_AutoTargetPlayer && (m_Target == null || !m_Target.gameObject.activeSelf))
            {
                FindAndTargetPlayer();
            }
            if (m_UpdateType == UpdateType.ManualUpdate)
            {
                FollowTarget(Time.deltaTime);
            }
        }

        protected abstract void FollowTarget(float deltaTime);

        public void FindAndTargetPlayer()
        {
            var targetObj = GameObject.FindGameObjectWithTag("Player");
            if (targetObj)
            {
                SetTarget(targetObj.transform);
            }
        }

        public virtual void SetTarget(Transform newTransform)
        {
            m_Target = newTransform;
        }

        public Transform Target
        {
            get { return m_Target; }
        }

    }
}
