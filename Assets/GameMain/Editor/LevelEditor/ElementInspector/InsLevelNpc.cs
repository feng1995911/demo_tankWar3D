#if UNITY_EDITOR


using UnityEditor;
using UnityEngine;

namespace GameMain
{
    [CustomEditor(typeof(LevelNpc))]
    public class InsLevelNpc : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            LevelNpc pElem = target as LevelNpc;

            int pId = EditorGUILayout.IntField("Id", pElem.Id);
            if (pElem.Id != pId)
            {
                pElem.Id = pId;
                pElem.SetName();
            }

            if(GUILayout.Button("添加巡逻路径"))
            {
                if(pElem.PatrolPathNodeSet!=null)
                {
                    return;
                }
                pElem.transform.DestroyChildren();
                LevelPathNodeSet elem = new GameObject().AddComponent<LevelPathNodeSet>();
                elem.name = "WayPath";
                elem.transform.parent = pElem.transform;
                elem.transform.localPosition = Vector3.zero;
                elem.transform.localEulerAngles = Vector3.zero;
                elem.transform.localScale = Vector3.one;
                pElem.PatrolPathNodeSet = elem;
            }

            EditorGUILayout.ObjectField("巡逻路径", pElem.PatrolPathNodeSet, typeof(LevelPathNodeSet), true);
            serializedObject.FindProperty("Talks");
            if(GUILayout.Button("添加Word"))
            {
                pElem.Talks.Add(string.Empty);
            }

        }
    }
}

#endif