namespace GameMain
{
    public class HolderBorn : LevelContainerBase<LevelBorn>
    {
        public BattleCampType Camp;

        public override LevelBorn AddElement()
        {
            LevelBorn pBorn = base.AddElement();
            pBorn.Camp = Camp;
            return pBorn;
        }
    }
}

