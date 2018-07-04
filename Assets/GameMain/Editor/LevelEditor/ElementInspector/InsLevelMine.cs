#if UNITY_EDITOR


using UnityEditor;

namespace GameMain
{
    [CustomEditor(typeof(LevelMine))]
    public class InsLevelMine : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            LevelMine pElem = target as LevelMine;

            int pId = EditorGUILayout.IntField("Id", pElem.Id);
            if (pElem.Id != pId)
            {
                pElem.Id = pId;
                pElem.SetName();
                pElem.Build();
            }

            int pDropItemCount = EditorGUILayout.IntField("掉落物品数量", pElem.DropItemCount);
            if (pElem.DropItemCount != pDropItemCount)
            {
                pElem.DropItemCount = pDropItemCount;
            }
        }
    }
}

#endif