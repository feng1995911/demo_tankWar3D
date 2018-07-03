namespace GameMain
{
    public class PartnerEntityData : RoleEntityData
    {
        public ActorBase Host { get; }

        public PartnerSortType SortPos { get; }

        public PartnerEntityData(int entityId, int typeId, ActorType actorType, BattleCampType campType, ActorBase host, PartnerSortType sortPos) : base(entityId, typeId, actorType, campType)
        {
            Host = host;
            SortPos = sortPos;
        }
    }
}
