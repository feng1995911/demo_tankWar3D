#if UNITY_EDITOR

using GameMain;
using UnityEditor;
using UnityEngine;

namespace GameMain
{
    [CustomEditor(typeof(LevelRegion),true)]
    public class InsLevelRegion : InsLevelElement
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            LevelRegion pElem = target as LevelRegion;
            Color pColor = EditorGUILayout.ColorField("颜色", pElem.color);
            if(pColor!=pElem.color)
            {
                pElem.color = pColor;
                pElem.Build();
            }

            Vector3 pSize = EditorGUILayout.Vector3Field("大小", pElem.Size);
            if (pSize != pElem.Size)
            {
                pElem.Size = pSize;
                pElem.Build();
            }

            bool  pStartActive = EditorGUILayout.Toggle("默认是否开启", pElem.StartActive);
            if (pStartActive != pElem.StartActive)
            {
                pElem.StartActive = pStartActive;
            }

            if (GUILayout.Button("添加事件"))
            {
                pElem.AddElement();
            }
        }
    }
}

#endif