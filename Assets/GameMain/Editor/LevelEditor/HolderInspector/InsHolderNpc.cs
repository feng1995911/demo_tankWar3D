#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace GameMain
{
    [CustomEditor(typeof(HolderNpc))]
    public class InsHolderNpc : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            HolderNpc pHolder = target as HolderNpc;

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Npc设置");

            if (GUILayout.Button("添加Npc"))
            {
                pHolder.AddElement();
            }
        }
    }
}
#endif
