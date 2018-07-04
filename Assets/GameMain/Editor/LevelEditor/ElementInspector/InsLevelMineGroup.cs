#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace GameMain
{
    [CustomEditor(typeof(LevelMineGroup))]
    public class InsLevelMineGroup : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            LevelMineGroup pElem = target as LevelMineGroup;

            int pId = EditorGUILayout.IntField("Id", pElem.Id);
            if (pElem.Id != pId)
            {
                pElem.Id = pId;
                pElem.SetName();
            }

            int pMineID = EditorGUILayout.IntField("创建矿物ID", pElem.MineID);
            if (pMineID != pElem.MineID)
            {
                pElem.MineID = pMineID;
                for (int i = 0; i < pElem.Elements.Count; i++)
                {
                    LevelMine mine = pElem.Elements[i];
                    mine.Id = pMineID;
                    mine.SetName();
                    mine.Build();
                }
            }

            float pRebornCD = EditorGUILayout.FloatField("矿物重生时间", pElem.RebornCD);
            if (pRebornCD != pElem.RebornCD)
            {
                pElem.RebornCD = pRebornCD;
            }


            if (GUILayout.Button("添加矿物"))
            {
                LevelMine pMine = pElem.AddElement();
                pMine.Id = pMineID;
                pMine.SetName();
                pMine.Build();
            }

            EditorGUILayout.Space();
            LevelRegion pRegion = (LevelRegion)EditorGUILayout.ObjectField("传送门触发器", pElem.Region, typeof(LevelRegion), true);
            if (pRegion != pElem.Region)
            {
                pElem.Region = pRegion;
            }
            EditorGUILayout.LabelField("使用触发器ID", pElem.RegionID.ToString());
        }
    }
}
#endif