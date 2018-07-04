using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameFramework.Event;
using UnityEngine;

namespace GameMain
{
    public class LevelWaveSet : LevelContainerBase<LevelWave>
    {
        public int CurrIndex { get; private set; }
        public int CurrKillNum { get; private set; }
        public int CurrMonsterNum { get; private set; }
        public bool IsEnd { get; protected set; }
        public LevelRegion Region;

        private MapWaveSet mWaveSet;
        private HashSet<int> mMonsterGUIDSet = new HashSet<int>();
        private bool mIsCreateDone = false;

        public override void SetName()
        {
            transform.name = "WaveSet_" + Id.ToString();
        }

        public override void Import(XmlObject pData, bool pBuild)
        {
            MapWaveSet data = pData as MapWaveSet;
            Id = data.Id;
            this.Build();
            this.SetName();
            if (pBuild)
            {
                for (int i = 0; i < data.Waves.Count; i++)
                {
                    GameObject go = gameObject.AddChild();
                    LevelWave pWave = go.AddComponent<LevelWave>();
                    pWave.Import(data.Waves[i], pBuild);
                }
            }
            mWaveSet = data;
        }

        public override XmlObject Export()
        {
            MapWaveSet data = new MapWaveSet();
            data.Id = Id;
            for (int i = 0; i < Elements.Count; i++)
            {
                data.Waves.Add(Elements[i].Export() as MapMonsterWave);
            }
            return data;
        }

        public override void Init()
        {
            this.CurrIndex = 0;
            this.Enter();

            GameEntry.Event.Subscribe(KillMonsterEventArgs.EventId, OnKillMonster);
        }

        public void Enter()
        {
            CreateWaveMonsters(mWaveSet.Waves[CurrIndex]);
        }

        public void Exit()
        {
            IsEnd = true;
            if (Region != null)
            {
                Region.ActiveEventsByCondition(TriggerConditionType.WavesetEnd, mWaveSet.Id);
            }

            GameEntry.Event.Unsubscribe(KillMonsterEventArgs.EventId, OnKillMonster);
            DestroyImmediate(gameObject);
        }

        private void CreateMonster(MapMonsterCall data)
        {
            Vector3 bornEulerAngles = data.EulerAngles;
            Vector3 bornPosition = GlobalTools.NavSamplePosition(data.Position);
            TransformParam param = TransformParam.Create(bornPosition, bornEulerAngles);

            int serialId = GameEntry.Level.CreateEnemy(data.Id, param);
            mMonsterGUIDSet.Add(serialId);
            
        }

        private IEnumerator CreateMonsterDelay(MapMonsterCall data, float delay, bool isDone)
        {
            yield return delay;
            CreateMonster(data);
            if (isDone != mIsCreateDone)
            {
                mIsCreateDone = isDone;
            }
        }

        private void CreateWaveMonsters(MapMonsterWave pWaveData)
        {
            mIsCreateDone = false;
            switch (pWaveData.Spawn)
            {
                case MonsterWaveSpawnType.Whole:
                    {
                        pWaveData.Monsters.ForEach(delegate (MapMonsterCall data)
                        {
                            CreateMonster(data);
                        });
                        CurrIndex++;
                        mIsCreateDone = true;
                    }
                    break;
                case MonsterWaveSpawnType.Along:
                    {
                        for (int i = 0; i < pWaveData.Monsters.Count; i++)
                        {
                            MapMonsterCall data = pWaveData.Monsters[i];
                            float delay = 0.2f + 0.2f * i;
                            bool isDone = (i == pWaveData.Monsters.Count - 1);
                            GameEntry.Coroutinue.StartCoroutine(CreateMonsterDelay(data, delay, isDone));
                        }
                        CurrIndex++;
                    }
                    break;
                case MonsterWaveSpawnType.Radom:
                    {
                        int range = UnityEngine.Random.Range(0, pWaveData.Monsters.Count);
                        CreateMonster(pWaveData.Monsters[range]);
                        CurrIndex++;
                        mIsCreateDone = true;
                    }
                    break;
            }
            if (Region != null)
            {
                Region.ActiveEventsByCondition(TriggerConditionType.WaveIndex, CurrIndex);
            }
        }

        private void OnKillMonster(object sender, GameEventArgs e)
        {
            KillMonsterEventArgs ne = e as KillMonsterEventArgs;
            if (ne == null)
                return;

            if (!this.mMonsterGUIDSet.Contains(ne.MonsterEntityId))
            {
                return;
            }
            this.mMonsterGUIDSet.Remove(ne.MonsterEntityId);
            this.CurrKillNum++;
            this.CurrMonsterNum = mMonsterGUIDSet.Count;
            if (CurrMonsterNum > 0)
            {
                return;
            }
            if (CurrIndex >= mWaveSet.Waves.Count)
            {
                Exit();
            }
            else
            {
                CreateWaveMonsters(mWaveSet.Waves[CurrIndex]);
            }
        }
    }
}
