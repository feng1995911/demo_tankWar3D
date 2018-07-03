#if UNITY_EDITOR


using UnityEditor;

namespace GameMain
{
    [CustomEditor(typeof(LevelBarrier))]
    public class InsLevelBarrier : InsLevelElement
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            LevelBarrier pElem = target as LevelBarrier;
            float pWidth = EditorGUILayout.FloatField("宽度", pElem.Width);
            if (pWidth != pElem.Width)
            {
                pElem.Width = pWidth;
                pElem.Build();
            }
        }
    }
}

#endif