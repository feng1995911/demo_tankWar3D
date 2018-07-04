using UnityEngine;

namespace GameMain
{
    public class LevelWave : LevelContainerBase<LevelMonsterCall>
    {
        public int Index;
        public string IndexName = string.Empty;
        public float Delay;
        public MonsterWaveSpawnType Spawn = MonsterWaveSpawnType.Along;

        public override void SetName()
        {
            gameObject.name = "Wave_Index_" + Index.ToString();
        }

        public override void Import(XmlObject pData,bool pBuild)
        {
            MapMonsterWave data = pData as MapMonsterWave;
            Index = data.Index;
            IndexName = data.IndexName;
            Delay = data.Delay;
            Spawn = data.Spawn;
            this.Build();
            this.SetName();
            if(pBuild)
            {
                for (int i = 0; i < data.Monsters.Count; i++)
                {
                    GameObject go = gameObject.AddChild();
                    LevelMonsterCall pCall = go.AddComponent<LevelMonsterCall>();
                    pCall.Import(data.Monsters[i],pBuild);
                }
            }
        }

        public override XmlObject Export()
        {
            MapMonsterWave data = new MapMonsterWave();
            data.Index = Index;
            data.IndexName = IndexName;
            data.Delay = Delay;
            data.Spawn = Spawn;
            for (int i = 0; i < Elements.Count; i++)
            {
                data.Monsters.Add(Elements[i].Export() as MapMonsterCall);
            }
            return data;
        }
    }
}

