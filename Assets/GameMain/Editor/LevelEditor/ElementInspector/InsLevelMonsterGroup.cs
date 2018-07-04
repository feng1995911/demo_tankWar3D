#if UNITY_EDITOR
using UnityEditor;

namespace GameMain
{
    [CustomEditor(typeof(LevelMonsterGroup))]
    public class InsLevelMonsterGroup : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            LevelMonsterGroup pElem = target as LevelMonsterGroup;

            int pId = EditorGUILayout.IntField("Id", pElem.Id);
            if (pElem.Id != pId)
            {
                pElem.Id = pId;
                pElem.SetName();
            }


            int pMonsterID = EditorGUILayout.IntField("创建怪物ID", pElem.MonsterID);
            if (pMonsterID != pElem.MonsterID)
            {
                pElem.MonsterID = pMonsterID;
            }

            float pRebornCD= EditorGUILayout.FloatField("创建怪物重生时间", pElem.RebornCD);
            if (pRebornCD != pElem.RebornCD)
            {
                pElem.RebornCD = pRebornCD;
            }

            bool TriggerResult = EditorGUILayout.Toggle("是否触发结算", pElem.TriggerResult);
            if (TriggerResult != pElem.TriggerResult)
            {
                pElem.TriggerResult = TriggerResult;
            }

            int pMaxCount = EditorGUILayout.IntField("创建怪物最大数量", pElem.MaxCount);
            if (pMaxCount != pElem.MaxCount)
            {
                pElem.MaxCount = pMaxCount;
            }

            EditorGUILayout.Space();
            LevelRegion pRegion = (LevelRegion)EditorGUILayout.ObjectField("传送门触发器", pElem.Region, typeof(LevelRegion), true);
            if (pRegion != pElem.Region)
            {
                pElem.Region = pRegion;
            }
            EditorGUILayout.LabelField("使用触发器ID", pElem.RegionID.ToString());

            EditorGUILayout.Space();
            LevelBarrier pBarrier = (LevelBarrier)EditorGUILayout.ObjectField("解锁障碍物", pElem.Barrier, typeof(LevelBarrier), true);
            if (pBarrier != pElem.Barrier)
            {
                pElem.Barrier = pBarrier;
            }
            EditorGUILayout.LabelField("解锁障碍物ID", pElem.BarrierID.ToString());
        }
    }
}

#endif