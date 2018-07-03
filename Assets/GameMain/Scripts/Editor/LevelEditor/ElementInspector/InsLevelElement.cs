#if UNITY_EDITOR

using UnityEditor;

namespace GameMain
{
    [CustomEditor(typeof(LevelElement))]
    public class InsLevelElement : UnityEditor.Editor
    {

        void OnEnable()
        {
            Init();
        }

        public virtual void Init()
        {

        }

        public override void OnInspectorGUI()
        {
            LevelElement pElem = target as LevelElement;
            int pId = EditorGUILayout.IntField("Id", pElem.Id);
            if (pElem.Id != pId)
            {
                pElem.Id = pId;
                pElem.SetName();
            }

            float pLifeTime = EditorGUILayout.FloatField("生命周期", pElem.LifeTime);
            if (pElem.LifeTime != pLifeTime)
            {
                pElem.LifeTime = pLifeTime;
            }
        }
    }
}
#endif