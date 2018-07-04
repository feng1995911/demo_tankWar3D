#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace GameMain
{
    [CustomEditor(typeof(HolderMineGroup))]
    public class InsHolderMineGroup : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            HolderMineGroup pHolder = target as HolderMineGroup;
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("矿物刷新点");
            if (GUILayout.Button("添加矿物刷新点"))
            {
                pHolder.AddElement();
            }
        }
    }
}
#endif