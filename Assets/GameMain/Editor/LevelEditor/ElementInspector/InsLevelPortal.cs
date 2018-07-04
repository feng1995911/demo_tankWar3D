#if UNITY_EDITOR


using UnityEngine;
using UnityEditor;

namespace GameMain
{
    [CustomEditor(typeof(LevelPortal))]
    public class InsLevelPortal : InsLevelElement
    {    
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            LevelPortal pElem = target as LevelPortal;

            int pDestID = EditorGUILayout.IntField("目标区域ID", pElem.DestMapID);
            if (pDestID != pElem.DestMapID)
            {
                pElem.DestMapID = pDestID;
                pElem.Build();
            }

            bool pIsDisplayText = EditorGUILayout.Toggle("显示文字", pElem.DisplayText);
            if (pIsDisplayText != pElem.DisplayText)
            {
                pElem.DisplayText = pIsDisplayText;
                pElem.Build();
            }

            string pPortalName = EditorGUILayout.TextField("传送门名字",pElem.PortalName);
            if (pPortalName != pElem.PortalName)
            {
                pElem.PortalName = pPortalName;
                pElem.Build();
            }

            EditorGUILayout.Space();
            EditorGUILayout.IntField("特效ID", pElem.SerialId);

            EditorGUILayout.Space();
            EditorGUILayout.BeginVertical();
            EditorGUILayout.LabelField("传送所需条件之间的关系,当一个条件值为-1时不参与");
            ConditionRelationType pRelation = (ConditionRelationType)EditorGUILayout.EnumPopup(string.Empty, pElem.Relation);
            if (pRelation != pElem.Relation)
            {
                pElem.Relation = pRelation;
            }
            EditorGUILayout.EndVertical();

            int pOpenLevel = EditorGUILayout.IntField("传送所需等级", pElem.OpenLevel);
            if (pOpenLevel != pElem.OpenLevel)
            {
                pElem.OpenLevel = pOpenLevel;
            }

            int pOpenItemID = EditorGUILayout.IntField("传送所需所需物品ID", pElem.OpenItemID);
            if (pOpenItemID != pElem.OpenItemID)
            {
                pElem.OpenItemID = pOpenItemID;
            }

            int pOpenVIP = EditorGUILayout.IntField("传送所需VIP等级", pElem.OpenVIP);
            if (pOpenVIP != pElem.OpenVIP)
            {
                pElem.OpenVIP = pOpenVIP;
            }

            EditorGUILayout.Space();
            LevelRegion pRegion = (LevelRegion)EditorGUILayout.ObjectField("传送门触发器", pElem.Region, typeof(LevelRegion), true);
            if(pRegion!=pElem.Region)
            {
                pElem.Region = pRegion;
            }
            EditorGUILayout.LabelField("使用触发器ID", pElem.RegionID.ToString());
        }
    }
}

#endif