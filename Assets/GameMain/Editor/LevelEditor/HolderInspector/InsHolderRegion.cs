#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace GameMain
{
    [CustomEditor(typeof(HolderRegion))]
    public class InsHolderRegion : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            HolderRegion pHolder = target as HolderRegion;
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("添加区域");
            if (GUILayout.Button("添加触发区"))
            {
                pHolder.AddElement();
            }
        }
    }
}

#endif