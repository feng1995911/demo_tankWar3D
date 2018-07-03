#if UNITY_EDITOR


using UnityEditor;

namespace GameMain
{
    [CustomEditor(typeof(LevelBorn))]
    public class InsLevelBorn : InsLevelElement
    {
        public override void OnInspectorGUI()
        {
            LevelBorn pElem = target as LevelBorn;
            BattleCampType pCamp = (BattleCampType)EditorGUILayout.EnumPopup("阵营类型", pElem.Camp);
            if (pCamp != pElem.Camp)
            {
                pElem.Camp = pCamp;
                pElem.Build();
                pElem.SetName();
            }
        }
    }
}

#endif
