using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{
    public class EntityBase : EntityLogic
    {
        [SerializeField] private EntityData m_EntityData = null;

        private string m_GoName = "";

        public int Id
        {
            get
            {
                if (m_EntityData == null)
                {
                    Log.Error("EntityData is null.");
                    return 0;
                }
                return m_EntityData.Id;
            }
        }

        public int TypeId
        {
            get
            {
                if (m_EntityData == null)
                {
                    Log.Error("EntityData is null.");
                    return 0;
                }
                return m_EntityData.TypeId;
            }
        }
        
        public Animator CachedAnimator
        {
            get;
            private set;
        }

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            CachedAnimator = GetComponent<Animator>();
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_EntityData = userData as EntityData;
            if (m_EntityData == null)
            {
                Log.Error("Entity data is invalid.");
                return;
            }
            Name = $"[{m_EntityData.TypeId}][{Id}]";
            m_GoName = Name;

            CachedTransform.position = m_EntityData.Position;
            CachedTransform.rotation = m_EntityData.Rotation;
            CachedTransform.localScale = m_EntityData.Scale;
        }

        protected override void OnHide(object userData)
        {
            base.OnHide(userData);
        }

        protected override void OnAttached(EntityLogic childEntity, Transform parentTransform, object userData)
        {
            base.OnAttached(childEntity, parentTransform, userData);
        }

        protected override void OnDetached(EntityLogic childEntity, object userData)
        {
            base.OnDetached(childEntity, userData);
        }

        protected override void OnAttachTo(EntityLogic parentEntity, Transform parentTransform, object userData)
        {
            base.OnAttachTo(parentEntity, parentTransform, userData);
        }

        protected override void OnDetachFrom(EntityLogic parentEntity, object userData)
        {
            base.OnDetachFrom(parentEntity, userData);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }

        public virtual void SetPosition(Vector3 Position,bool isLocal = false)
        {
            if (isLocal)
            {
                CachedTransform.localPosition = Position;
            }
            else
            {
                CachedTransform.position = Position;
            }
        }

        public virtual void SetRotation(Quaternion rotation,bool isLocal = false)
        {
            if (isLocal)
            {
                CachedTransform.localRotation = rotation;
            }
            else
            {
                CachedTransform.rotation = rotation;
            }
        }

        public virtual void SetScale(Vector3 scale)
        {
            CachedTransform.localScale = scale;
        }

    }
}
