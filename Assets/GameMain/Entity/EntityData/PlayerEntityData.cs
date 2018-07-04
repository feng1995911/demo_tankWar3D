namespace GameMain
{
    public class PlayerEntityData : RoleEntityData
    {
        public bool BattleState { get; }

        public PlayerEntityData(int entityId, int typeId, ActorType actorType, BattleCampType campType, bool battleState) : base(entityId, typeId, actorType, campType)
        {
            BattleState = battleState;
        }
    }
}
