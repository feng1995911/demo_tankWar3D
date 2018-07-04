using UnityEngine;

namespace GameMain
{
    public class RoleEntityData : EntityData
    {
        [SerializeField]
        public ActorType ActorType { get; }

        [SerializeField]
        public BattleCampType CampType { get; }

        public RoleEntityData(int entityId, int typeId, ActorType actorType, BattleCampType campType) : base(entityId, typeId)
        {
            ActorType = actorType;
            CampType = campType;
        }
    }
}
