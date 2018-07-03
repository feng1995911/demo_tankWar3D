using UnityEngine;

namespace GameMain
{
    public class LevelMineGroup : LevelContainerBase<LevelMine>
    {
        public int   MineID;
        public float RebornCD = 3;

        public LevelRegion Region
        {
            get; set;
        }

        public int RegionID
        {
            get { return Region == null ? 0 : Region.Id; }
        }

        public override void SetName()
        {
            transform.name = "Mine_Group_" + Id;
        }

        public override LevelMine AddElement()
        {
            LevelMine pElem = new GameObject().AddComponent<LevelMine>();
            pElem.transform.parent = transform;
            return pElem;
        }

        public override void Import(XmlObject pData, bool pBuild)
        {
            MapMineGroup data = pData as MapMineGroup;
            Id = data.Id;
            HolderRegion pHolder = GameEntry.Level.GetHolder(MapHolderType.Region) as HolderRegion;
            if (pHolder != null)
                this.Region = pHolder.FindElement(data.RegionID);

            for(int i=0;i<data.Mines.Count;i++)
            {
                GameObject go = gameObject.AddChild();
                LevelMine pMine = go.AddComponent<LevelMine>();
                pMine.Import(data.Mines[i], pBuild);
            }
            this.Build();
            this.SetName();
        }

        public override XmlObject Export()
        {
            MapMineGroup data = new MapMineGroup
            {
                Id = Id,
                RegionID = RegionID
            };

            for (int i = 0; i < Elements.Count; i++)
            {
                data.Mines.Add(Elements[i].Export() as MapMine);
            }
            return data;
        }
    }
}