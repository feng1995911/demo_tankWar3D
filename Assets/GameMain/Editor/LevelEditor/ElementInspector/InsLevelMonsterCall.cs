#if UNITY_EDITOR

using UnityEditor;

namespace GameMain
{
    [CustomEditor(typeof(LevelMonsterCall))]
    public class InsLevelMonsterCall : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            LevelMonsterCall pElem = target as LevelMonsterCall;

            int pId = EditorGUILayout.IntField("Id", pElem.Id);
            if (pElem.Id != pId)
            {
                pElem.Id = pId;
                pElem.SetName();
            }
        }
    }
}

#endif