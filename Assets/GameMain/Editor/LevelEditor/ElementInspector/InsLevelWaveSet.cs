#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace GameMain
{
    [CustomEditor(typeof(LevelWaveSet))]
    public class InsLevelWaveSet : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            LevelWaveSet pElem = target as LevelWaveSet;
            int pId = EditorGUILayout.IntField("Id", pElem.Id);
            if (pElem.Id != pId)
            {
                pElem.Id = pId;
                pElem.SetName();
            }

            if(GUILayout.Button("添加波次"))
            {
                LevelWave pWave=pElem.AddElement();
            }
        }
    }
}

#endif