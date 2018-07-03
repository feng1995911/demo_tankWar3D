#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace GameMain
{
    [CustomEditor(typeof(HolderBarrier))]
    public class InsHolderBarrier : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            HolderBarrier holder = target as HolderBarrier;
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("动态障碍物");
            if (GUILayout.Button("添加光墙障碍"))
            {
                holder.AddElement();
            }
        }
    }
}

#endif