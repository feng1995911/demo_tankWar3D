#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace GameMain.Editor
{
    [CustomEditor(typeof(HolderPortal))]
    public class InsHolderPortal : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            HolderPortal pHolder = target as HolderPortal;
            if (GUILayout.Button("添加传送门"))
            {
                pHolder.AddElement();
            }
        }
    }
}

#endif