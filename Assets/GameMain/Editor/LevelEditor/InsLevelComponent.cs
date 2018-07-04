#if UNITY_EDITOR


using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

namespace GameMain
{
    [CustomEditor(typeof(LevelComponent))]
    public class InsLevelComponent : UnityEditor.Editor
    {
        private LevelComponent m_level;

        public override void OnInspectorGUI()
        {
            m_level = target as LevelComponent;

            if (Application.isPlaying)
            {
                RunTimeModeInspector();
            }
            else
            {
                EditorModeInspector();
            }
        }
        
        private void EditorModeInspector()
        {
            RefreshField();

            EditorGUILayout.Space();
            EditorGUILayout.Space();
            if (GUILayout.Button("导出"))
            {
                ExportAll();
            }

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            if (GUILayout.Button("导入"))
            {
                ImportAll();
                RefreshField();
            }
        }

        private void RefreshField()
        {
            int levelID = EditorGUILayout.IntField("关卡ID", m_level.LevelID);
            if (levelID != m_level.LevelID)
            {
                m_level.LevelID = levelID;
            }

            string levelName = EditorGUILayout.TextField("关卡名字", m_level.MapName);
            if (levelName != null && levelName != m_level.MapName)
            {
                m_level.MapName = levelName;
            }

            //string configPath = EditorGUILayout.TextField("关卡配置路径", m_level.MapPath);
            //if (configPath != null && configPath != m_level.MapName)
            //{
            //    m_level.MapPath = configPath;
            //}
        }

        private void RunTimeModeInspector()
        {
            EditorGUILayout.LabelField("ID:", m_level.LevelID.ToString());

            EditorGUILayout.LabelField("Name:", m_level.MapName);

            EditorGUILayout.LabelField("ConfigPath:", m_level.MapPath);

            EditorGUILayout.LabelField("Scene:", m_level.CurSceneId.ToString());

            EditorGUILayout.LabelField("SceneType:", m_level.CurSceneType.ToString());
        }

        private void ExportAll()
        {
            string fsPath = AssetUtility.GetLevelConfigPath();
            if (!Directory.Exists(fsPath))
            {
                Directory.CreateDirectory(fsPath);
            }
            string path = GlobalTools.Format("{0}/{1}.xml", fsPath, GameEntry.Level.LevelID);
            MapConfig data = Export();
            if (!File.Exists(path))
            {
                FileStream fs = File.Create(path);
                fs.Close();
                fs.Dispose();
            }
            data.Save(path);

            Debug.Log("导出关卡数据：" + fsPath);
        }

        private void ImportAll()
        {
            Import();
        }

        private MapConfig Export()
        {
            LevelComponent pHandler = target as LevelComponent;
            MapConfig data = new MapConfig();
            data.Id = pHandler.LevelID;
            data.MapName = pHandler.MapName;
            data.MapPath = pHandler.MapPath;

            List<LevelElement> pList = new List<LevelElement>();
            for (int i = 0; i < pHandler.transform.childCount; i++)
            {
                Transform child = pHandler.transform.GetChild(i);
                LevelElement pElem = child.GetComponent<LevelElement>();
                if (pElem)
                {
                    pList.Add(pElem);
                }
            }

            for (int k = 0; k < pList.Count; k++)
            {
                string classType = pList[k].GetType().Name;
                LevelElement current = pList[k];
                switch (classType)
                {
                    case "HolderBorn":
                        {
                            HolderBorn pHolder = current as HolderBorn;
                            if (pHolder != null)
                            {
                                for (int i = 0; i < pHolder.Elements.Count; i++)
                                {
                                    LevelElement pElem = pHolder.Elements[i];
                                    switch (pHolder.Elements[i].Camp)
                                    {
                                        case BattleCampType.Ally:
                                            data.Ally = pElem.Export() as MapBorn;
                                            break;
                                        case BattleCampType.Enemy:
                                            data.Enemy = pElem.Export() as MapBorn;
                                            break;
                                        case BattleCampType.Neutral:
                                            data.Neutral = pElem.Export() as MapBorn;
                                            break;
                                    }
                                }
                            }
                        }
                        break;
                    case "HolderBarrier":
                        {
                            HolderBarrier pHolder = current as HolderBarrier;
                            if (pHolder != null)
                            {
                                for (int i = 0; i < pHolder.Elements.Count; i++)
                                {
                                    LevelElement pElem = pHolder.Elements[i];
                                    data.Barriers.Add(pElem.Export() as MapBarrier);
                                }
                            }
                        }
                        break;
                    case "HolderPortal":
                        {
                            HolderPortal pHolder = current as HolderPortal;
                            if (pHolder != null)
                            {
                                for (int i = 0; i < pHolder.Elements.Count; i++)
                                {
                                    LevelElement pElem = pHolder.Elements[i];
                                    data.Portals.Add(pElem.Export() as MapPortal);
                                }
                            }
                        }
                        break;
                    case "HolderRegion":
                        {
                            HolderRegion pHolder = current as HolderRegion;
                            if (pHolder != null)
                            {
                                for (int i = 0; i < pHolder.Elements.Count; i++)
                                {
                                    LevelElement pElem = pHolder.Elements[i];
                                    data.Regions.Add(pElem.Export() as MapRegion);
                                }
                            }
                        }
                        break;
                    case "HolderWaveSet":
                        {
                            HolderWaveSet pHolder = current as HolderWaveSet;
                            if (pHolder != null)
                            {
                                for (int i = 0; i < pHolder.Elements.Count; i++)
                                {
                                    LevelElement pElem = pHolder.Elements[i];
                                    data.WaveSets.Add(pElem.Export() as MapWaveSet);
                                }
                            }
                        }
                        break;
                    case "HolderMonsterGroup":
                        {
                            HolderMonsterGroup pHolder = current as HolderMonsterGroup;
                            if (pHolder != null)
                            {
                                for (int i = 0; i < pHolder.Elements.Count; i++)
                                {
                                    LevelElement pElem = pHolder.Elements[i];
                                    data.MonsterGroups.Add(pElem.Export() as MapMonsterGroup);
                                }
                            }
                        }
                        break;
                    case "HolderMineGroup":
                        {
                            HolderMineGroup pHolder = current as HolderMineGroup;
                            if (pHolder != null)
                            {
                                for (int i = 0; i < pHolder.Elements.Count; i++)
                                {
                                    LevelElement pElem = pHolder.Elements[i];
                                    data.MineGroups.Add(pElem.Export() as MapMineGroup);
                                }
                            }
                        }
                        break;
                    case "HolderNpc":
                        {
                            HolderNpc pHolder = current as HolderNpc;
                            if (pHolder != null)
                            {
                                for (int i = 0; i < pHolder.Elements.Count; i++)
                                {
                                    LevelElement pElem = pHolder.Elements[i];
                                    data.Npcs.Add(pElem.Export() as MapNpc);
                                }
                            }
                        }
                        break;
                }
            }
            return data;
        }

        private void Import()
        {
            LevelComponent levelCom = target as LevelComponent;
            levelCom.transform.DestroyChildren();
            levelCom.InitHolder();
            string fsPath =AssetUtility.GetLevelConfigAsset(levelCom.LevelID.ToString());
            MapConfig data = new MapConfig();
            data.EditorLoad(fsPath);

            levelCom.MapName = data.MapName;

            for (int i = 0; i < data.Regions.Count; i++)
            {
                LevelElement pHolder = levelCom.GetHolder(MapHolderType.Region);
                GameObject go = pHolder.gameObject.AddChild();
                LevelRegion pRegion = go.AddComponent<LevelRegion>();
                pRegion.Import(data.Regions[i], true);
            }

            for (int i = 0; i < data.Barriers.Count; i++)
            {
                LevelElement pHolder = levelCom.GetHolder(MapHolderType.Barrier);
                GameObject go = pHolder.gameObject.AddChild();
                LevelBarrier pBarrier = go.AddComponent<LevelBarrier>();
                pBarrier.Import(data.Barriers[i], true);
            }


            for (int i = 0; i < data.WaveSets.Count; i++)
            {
                LevelElement pHolder = levelCom.GetHolder(MapHolderType.WaveSet);
                GameObject go = pHolder.gameObject.AddChild();
                LevelWaveSet pWaveSet = go.AddComponent<LevelWaveSet>();
                pWaveSet.Import(data.WaveSets[i], true);
            }

            for (int i = 0; i < data.MonsterGroups.Count; i++)
            {
                LevelElement pHolder = levelCom.GetHolder(MapHolderType.MonsterGroup);
                GameObject go = pHolder.gameObject.AddChild();
                LevelMonsterGroup pGroup = go.AddComponent<LevelMonsterGroup>();
                pGroup.Import(data.MonsterGroups[i], true);
            }

            for (int i = 0; i < data.MineGroups.Count; i++)
            {
                LevelElement pHolder = levelCom.GetHolder(MapHolderType.MineGroup);
                GameObject go = pHolder.gameObject.AddChild();
                LevelMineGroup pGroup = go.AddComponent<LevelMineGroup>();
                pGroup.Import(data.MineGroups[i], true);
            }

            for (int i = 0; i < data.Portals.Count; i++)
            {
                LevelElement pHolder = levelCom.GetHolder(MapHolderType.Portal);
                GameObject go = pHolder.gameObject.AddChild();
                LevelPortal pPortal = go.AddComponent<LevelPortal>();
                pPortal.Import(data.Portals[i], true);
            }

            for (int i = 0; i < data.Npcs.Count; i++)
            {
                LevelElement pHolder = levelCom.GetHolder(MapHolderType.Npc);
                GameObject go = pHolder.gameObject.AddChild();
                LevelNpc pNpc = go.AddComponent<LevelNpc>();
                pNpc.Import(data.Npcs[i], true);
            }

            {
                LevelElement pHolder = levelCom.GetHolder(MapHolderType.Born);
                if (data.Ally != null)
                {
                    GameObject gA = pHolder.gameObject.AddChild();
                    LevelBorn pBornA = gA.AddComponent<LevelBorn>();
                    pBornA.Import(data.Ally, true);
                }
                if (data.Enemy != null)
                {
                    GameObject gB = pHolder.gameObject.AddChild();
                    LevelBorn pBornB = gB.AddComponent<LevelBorn>();
                    pBornB.Import(data.Enemy, true);
                }
                if (data.Neutral != null)
                {
                    GameObject gC = pHolder.gameObject.AddChild();
                    LevelBorn pBornC = gC.AddComponent<LevelBorn>();
                    pBornC.Import(data.Neutral, true);
                }
            }

            Debug.Log("导入关卡数据：" + fsPath);
        }
    }
}

#endif