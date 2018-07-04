using GameFramework;

namespace GameMain
{

    public class PartnerRole : RoleEntityBase
    {
        private PartnerEntityData m_EntityData;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_EntityData = userData as PartnerEntityData;
            if (m_EntityData == null)
            {
                Log.Error("playerEntityData is null");
                return;
            }

            ActorType actorType = m_EntityData.ActorType;
            BattleCampType campType = m_EntityData.CampType;
            Actor = new ActorPartner(this, actorType, campType, m_CharacterController,
                m_Animator);
            Actor.Init();
            Actor.SetHost(m_EntityData.Host);
        }

    }
}
