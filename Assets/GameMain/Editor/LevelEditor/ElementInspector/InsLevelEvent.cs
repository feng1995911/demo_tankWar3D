#if UNITY_EDITOR


using UnityEditor;

namespace GameMain
{
    [CustomEditor(typeof(LevelEvent))]
    public class InsLevelEvent : InsLevelElement
    {

        public override void OnInspectorGUI()
        {
            LevelEvent pElem = target as LevelEvent;

            MapTriggerType pType = (MapTriggerType)EditorGUILayout.EnumPopup("触发事件类型", pElem.Type);
            if (pType != pElem.Type)
            {
                pElem.Type = pType;
                pElem.SetName();
            }

            int pTypeId = EditorGUILayout.IntField("触发事件类型ID", pElem.TypeId);
            if (pTypeId != pElem.TypeId)
            {
                pElem.TypeId = pTypeId;
                pElem.SetName();
            }

            bool pActive = EditorGUILayout.Toggle("激活或者销毁", pElem.Active);
            if (pActive != pElem.Active)
            {
                pElem.Active = pActive;
            }

            ConditionRelationType pR1 = (ConditionRelationType)EditorGUILayout.EnumPopup("首次触发条件之间关系", pElem.Relation1);
            if (pR1 != pElem.Relation1)
            {
                pElem.Relation1 = pR1;
            }

            float pTriggerDelay = EditorGUILayout.FloatField("触发延迟", pElem.TriggerDelay);
            if (pElem.TriggerDelay != pTriggerDelay)
            {
                pElem.TriggerDelay = pTriggerDelay;
            }

            EditorGUILayout.Space();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("首次触发条件");
            if (UnityEngine.GUILayout.Button("添加"))
            {
                pElem.Conditions1.Add(new MapEventCondition());
            }
            EditorGUILayout.EndHorizontal();

            int pDeleteIndex1 = -1;
            for (int i = 0; i < pElem.Conditions1.Count; i++)
            {
                EditorGUILayout.Space();
                EditorGUIUtility.labelWidth = 100;
                MapEventCondition data = pElem.Conditions1[i];
                EditorGUILayout.LabelField("条件" + (i + 1));
                EditorGUIUtility.labelWidth = 100;
                TriggerConditionType p = (TriggerConditionType)EditorGUILayout.EnumPopup("类型", data.Type);
                if (p != data.Type)
                {
                    data.Type = p;
                }

                EditorGUILayout.BeginHorizontal();
                EditorGUIUtility.labelWidth = 100;
                string s = EditorGUILayout.TextField("参数", data.Args);
                if (s != data.Args)
                {
                    data.Args = s;
                }

                if (UnityEngine.GUILayout.Button("删除"))
                {
                    pDeleteIndex1 = i;
                }
                EditorGUILayout.EndHorizontal();
            }

            if (pDeleteIndex1 >= 0)
            {
                pElem.Conditions1.RemoveAt(pDeleteIndex1);
            }

            EditorGUILayout.Space();
            EditorGUILayout.Space();
            bool pUseTriggerInterval = EditorGUILayout.Toggle("是否间隔触发", pElem.UseIntervalTrigger);
            if (pElem.UseIntervalTrigger != pUseTriggerInterval)
            {
                pElem.UseIntervalTrigger = pUseTriggerInterval;
            }
            if (pElem.UseIntervalTrigger == false)
            {
                return;
            }

            EditorGUILayout.Space();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("间隔触发条件");
            if (UnityEngine.GUILayout.Button("添加"))
            {
                pElem.Conditions2.Add(new MapEventCondition());
            }
            EditorGUILayout.EndHorizontal();

            int pTriggerNum = EditorGUILayout.IntField("间隔触发次数(<=0代表无限)", pElem.TriggerNum);
            if (pElem.TriggerNum != pTriggerNum)
            {
                pElem.TriggerNum = pTriggerNum;
            }

            float pTriggerInterval = EditorGUILayout.FloatField("触发间隔时间", pElem.TriggerInterval);
            if (pElem.TriggerInterval != pTriggerInterval)
            {
                pElem.TriggerInterval = pTriggerInterval;
            }

            int pDeleteIndex2 = -1;
            for (int i = 0; i < pElem.Conditions2.Count; i++)
            {
                EditorGUILayout.Space();
                MapEventCondition data = pElem.Conditions2[i];
                TriggerConditionType p = (TriggerConditionType)EditorGUILayout.EnumPopup(GlobalTools.Format("条件{0}:  类型", i + 1), data.Type);
                if (p != data.Type)
                {
                    data.Type = p;
                }
                string s = EditorGUILayout.TextField("参数", data.Args);
                if (s != data.Args)
                {
                    data.Args = s;
                }

                if (UnityEngine.GUILayout.Button("删除"))
                {
                    pDeleteIndex2 = i;
                }
            }

            if (pDeleteIndex2 >= 0)
            {
                pElem.Conditions2.RemoveAt(pDeleteIndex2);
            }
        }
    }
}

#endif