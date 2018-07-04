using GameFramework;

namespace GameMain
{

    public class NpcRole : RoleEntityBase
    {
        private RoleEntityData m_EnemyEntityData;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_EnemyEntityData = userData as RoleEntityData;
            if (m_EnemyEntityData == null)
            {
                Log.Error("playerEntityData is null");
                return;
            }

            ActorType actorType = m_EnemyEntityData.ActorType;
            BattleCampType campType = m_EnemyEntityData.CampType;
            Actor = new ActorNpc(this, actorType, campType, m_CharacterController,
                m_Animator);
            Actor.Init();
        }

    }
}
