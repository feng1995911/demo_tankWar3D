#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace GameMain
{
    enum ESpawn
    {
        按顺序刷,
        全部都刷,
        随机刷怪,
        死一刷一,
    }

    [CustomEditor(typeof(LevelWave))]
    public class InsLevelWave : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            LevelWave pElem = target as LevelWave;
            int pIndex = EditorGUILayout.IntField("波次索引", pElem.Index);
            if (pElem.Index != pIndex)
            {
                pElem.Index = pIndex;
                pElem.SetName();
            }

            string pIndexName = EditorGUILayout.TextField("波次名字", pElem.IndexName);
            if (pElem.IndexName != pIndexName)
            {
                pElem.IndexName = pIndexName;
            }

            float pDelay = EditorGUILayout.FloatField("距离上一波次结束的延迟", pElem.Delay);
            if (pElem.Delay != pDelay)
            {
                pElem.Delay = pDelay;
            }

            ESpawn pChineseSpawn = (ESpawn)pElem.Spawn;
            MonsterWaveSpawnType pSpawn=(MonsterWaveSpawnType)EditorGUILayout.EnumPopup("怪物刷新方式", pChineseSpawn);
            if(pElem.Spawn!=pSpawn)
            {
                pElem.Spawn = pSpawn;
            }


            EditorGUILayout.Space();
            if (GUILayout.Button("添加怪物"))
            {
                LevelMonsterCall pMonster = pElem.AddElement();
                pMonster.SetName();
            }

        }
    }
}

#endif