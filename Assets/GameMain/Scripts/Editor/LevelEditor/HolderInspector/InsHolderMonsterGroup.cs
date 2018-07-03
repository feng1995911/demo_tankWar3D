#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace GameMain
{
    [CustomEditor(typeof(HolderMonsterGroup))]
    public class InsHolderMonsterGroup : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            HolderMonsterGroup pHolder = target as HolderMonsterGroup;
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("怪物刷新点");
            if (GUILayout.Button("添加怪物刷新点"))
            {
                pHolder.AddElement();
            }
        }
    }
}

#endif