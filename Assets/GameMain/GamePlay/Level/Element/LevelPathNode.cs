namespace GameMain
{
    public class LevelPathNode : LevelElement
    {
        public float NodeTime;
        
        public override void Import(XmlObject pData,bool pBuild)
        {
            MapPathNode data = pData as MapPathNode;
            NodeTime = data.NodeTime;
            Position = data.Position;
            this.Build();
            this.SetName();
        }

        public override XmlObject Export()
        {
            MapPathNode data = new MapPathNode
            {
                NodeTime = NodeTime,
                Position = Position
            };
            return data;
        }
    }
}

