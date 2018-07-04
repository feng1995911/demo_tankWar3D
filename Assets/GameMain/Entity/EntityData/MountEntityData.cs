namespace GameMain
{
    public class MountEntityData : RoleEntityData
    {
        public ActorPlayer Host { get; }

        public MountEntityData(int entityId, int typeId, ActorType actorType, BattleCampType campType, ActorPlayer host) : base(entityId, typeId, actorType, campType)
        {
            Host = host;
        }
    }
}
