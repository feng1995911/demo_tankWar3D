using UnityEngine;
using System.Collections.Generic;
using GameFramework.Event;

namespace GameMain
{
    public class LevelMonsterGroup : LevelElement
    {
        public int   MonsterID = 0;
        public float RebornCD = 0;
        public int   MaxCount = 0;
        public bool TriggerResult = false;

        private HashSet<int> m_Monsters = new HashSet<int>();

        public LevelRegion Region
        {
            get; set;
        }

        public LevelBarrier Barrier
        {
            get;
            set;
        }

        private MapMonsterGroup data;


        public int RegionID
        {
            get { return Region == null ? 0 : Region.Id; }
        }

        public int BarrierID
        {
            get { return Barrier == null ? 0 : Barrier.Id; }
        }

        public override void SetName()
        {
            transform.name = "Monster_Group_" + Id;
        }

        public override void Import(XmlObject pData,bool pBuild)
        {
            data = pData as MapMonsterGroup;
            Id = data.Id;
            RebornCD = data.RebornCD;
            MaxCount = data.MaxCount;
            MonsterID = data.MonsterID;
            TriggerResult = data.TriggerResult;
            HolderRegion pHolder = GameEntry.Level.GetHolder(MapHolderType.Region) as HolderRegion;
            this.Region = pHolder.FindElement(data.RegionID);
   
            this.Build();
            this.SetName();
        }

        public override XmlObject Export()
        {
            MapMonsterGroup data = new MapMonsterGroup();
            data.Id = Id;
            data.RegionID = RegionID;
            data.UnlockBarrierId = BarrierID;
            data.RebornCD = RebornCD;
            data.MaxCount = MaxCount;
            data.MonsterID = MonsterID;
            data.TriggerResult = TriggerResult;
            return data;
        }

        public override void Init()
        {
            GameEntry.Event.Subscribe(KillMonsterEventArgs.EventId, OnKillMonster);
            for (int i = 0; i < MaxCount; i++)
            {
                CreateMonster();
            }
        }

        private void CreateMonster()
        {
            if(Region==null)
            {
                Debug.LogError("找不到区域" + Region.Id);
                return;
            }
            Vector3 pos = GlobalTools.RandomOnCircle(5)+Region.Position;
            Vector3 angle = new Vector3(0, UnityEngine.Random.Range(0, 360), 0);
            TransformParam param = TransformParam.Create(pos, angle);
            int serialId = GameEntry.Level.CreateEnemy(MonsterID, param);
            m_Monsters.Add(serialId);
        }

        private void OnKillMonster(object sender,GameEventArgs e)
        {
            KillMonsterEventArgs ne = e as KillMonsterEventArgs;
            if(ne == null)
                return;

            if (!this.m_Monsters.Contains(ne.MonsterEntityId))
            {
                return;
            }
            m_Monsters.Remove(ne.MonsterEntityId);
            //if(m_Monsters.Count<MaxCount)
            //{
            //    if (RebornCD > 0)
            //        Invoke("CreateMonster", RebornCD);
            //}

            if (m_Monsters.Count == 0)
            {
                HolderBarrier pHolder = GameEntry.Level.GetHolder(MapHolderType.Barrier) as HolderBarrier;
                this.Barrier = pHolder.FindElement(data.UnlockBarrierId);
                Barrier?.Hide();

                if (TriggerResult)
                {
                    GameEntry.Timer.Register(5, () =>
                    {
                        GameEntry.Event.Fire(this, new PassLevelEventArgs());
                    });
                }
            }
        }

        void OnDestroy()
        {
            CancelInvoke();
            GameEntry.Event.Unsubscribe(KillMonsterEventArgs.EventId, OnKillMonster);
        }
    }
}
