#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace GameMain
{
    [CustomEditor(typeof(HolderWaveSet))]
    public class InsHolderWaveSet : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            HolderWaveSet pHolder = target as HolderWaveSet;
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("怪物波");
            if (GUILayout.Button("添加怪物刷新波"))
            {
                pHolder.AddElement();
            }
        }
    }
}
#endif