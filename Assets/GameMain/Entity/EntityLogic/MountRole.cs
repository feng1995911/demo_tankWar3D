using GameFramework;
using UnityEngine;

namespace GameMain
{

    public class MountRole : RoleEntityBase
    {
        private MountEntityData m_EntityData;
        private ActorPlayer m_Host;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            CachedTransform.rotation = Quaternion.identity;

            m_EntityData = userData as MountEntityData;
            if (m_EntityData == null)
            {
                Log.Error("playerEntityData is null");
                return;
            }

            ActorType actorType = m_EntityData.ActorType;
            BattleCampType campType = m_EntityData.CampType;
            Actor = new ActorMount(this, actorType, campType, m_CharacterController,
                m_Animator);
            Actor.Init();

            if (m_EntityData.Host != null)
            {
                m_Host = m_EntityData.Host;
                Actor.SetHost(m_Host);
                m_Host.Vehicle = Actor;

                Transform ridePoint = ((ActorMount) Actor).GetRidePoint();

                if (ridePoint != null)
                {
                    m_Host.CachedTransform.parent = ridePoint;
                    m_Host.CachedTransform.localPosition = Vector3.zero;
                    m_Host.CachedTransform.localRotation = Quaternion.identity;
                }
            }
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            if (CachedTransform.eulerAngles.x != 0|| CachedTransform.eulerAngles.z != 0)
            {
                CachedTransform.eulerAngles = Vector3.zero;
            }
        }
    }
}
