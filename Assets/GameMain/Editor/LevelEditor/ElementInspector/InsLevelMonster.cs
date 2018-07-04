#if UNITY_EDITOR

using UnityEditor;

namespace GameMain
{
    [CustomEditor(typeof(LevelMonster))]
    public class InsLevelMonster : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            LevelMonster pElem = target as LevelMonster;

            int pId = EditorGUILayout.IntField("Id", pElem.Id);
            if (pElem.Id != pId)
            {
                pElem.Id = pId;
                pElem.SetName();
            }

            EditorGUILayout.Space();
            LevelPathNodeSet pSet = (LevelPathNodeSet)EditorGUILayout.ObjectField("巡逻路径", pElem.PatrolPathNodeSet, typeof(LevelPathNodeSet), true);
            if (pSet != pElem.PatrolPathNodeSet)
            {
                pElem.PatrolPathNodeSet = pSet;
            }
        }
    }
}

#endif