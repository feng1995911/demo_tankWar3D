#if UNITY_EDITOR


using UnityEditor;
using UnityEngine;

namespace GameMain
{
    [CustomEditor(typeof(HolderBorn))]
    public class InsHolderBorn : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            HolderBorn pHolder = target as HolderBorn;

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("出生点设置");
            BattleCampType pCamp = (BattleCampType)EditorGUILayout.EnumPopup("选择出生阵营", pHolder.Camp);

            if (pCamp != pHolder.Camp)
            {
                pHolder.Camp = pCamp;
            }

            if (GUILayout.Button("添加出生点"))
            {
                pHolder.AddElement();
            }
        }
    }
}

#endif
