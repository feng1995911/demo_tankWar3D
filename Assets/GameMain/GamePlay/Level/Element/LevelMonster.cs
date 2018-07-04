namespace GameMain
{
    public class LevelMonster: LevelElement
    {
        public LevelPathNodeSet PatrolPathNodeSet;

        public override void SetName()
        {
            transform.name = "Monster_" + Id;
        }

        public override void Import(XmlObject pData,bool pBuild)
        {
            MapMonster data = pData as MapMonster;
            Id = data.Id;
            this.Build();
            this.SetName();
        }

        public override XmlObject Export()
        {
            MapMonster data = new MapMonster();
            data.Id = Id;
            return data;
        }  
    }
}
