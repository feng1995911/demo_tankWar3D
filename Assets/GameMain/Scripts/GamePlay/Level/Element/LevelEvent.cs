using System.Collections.Generic;
using UnityEngine;

namespace GameMain
{
    public class LevelEvent : LevelElement
    {
        public int TypeId = 1;
        public bool Active = true;
        public bool UseIntervalTrigger = false;

        public int TriggerNum = 1;
        public float TriggerInterval = 0;
        public float TriggerDelay = 0;

        public MapTriggerType Type = MapTriggerType.None;
        public ConditionRelationType Relation1 = ConditionRelationType.And;
        public ConditionRelationType Relation2 = ConditionRelationType.And;

        [SerializeField]
        public List<MapEventCondition> Conditions1 = new List<MapEventCondition>();//首次触发条件
        [SerializeField]
        public List<MapEventCondition> Conditions2 = new List<MapEventCondition>();//间隔触发条件

        public override void SetName()
        {
            transform.name = "Event_" + Type.ToString() + "_" + TypeId;
        }

        public override void Import(XmlObject pData, bool pBuild)
        {
            MapEvent data = pData as MapEvent;
            if (data == null)
            {
                return;
            }

            Type = data.Type;
            TypeId = data.Id;
            Relation1 = data.Relation1;
            Conditions1 = data.Conditions1;
            TriggerDelay = data.TriggerDelay;
            Active = data.Active;
            if (data.Conditions2 != null)
            {
                Relation2 = data.Relation2;
                Conditions2 = data.Conditions2;
                TriggerNum = data.TriggerNum;
                TriggerInterval = data.TriggerInterval;
            }

            Build();
            SetName();
        }

        public override XmlObject Export()
        {
            MapEvent data = new MapEvent();
            data.Type = Type;
            data.Id = TypeId;
            data.Relation1 = Relation1;
            data.Conditions1 = Conditions1;
            data.TriggerDelay = TriggerDelay;
            data.Active = Active;
            if (UseIntervalTrigger)
            {
                data.Relation2 = Relation2;
                data.Conditions2 = Conditions2;
                data.TriggerNum = TriggerNum;
                data.TriggerInterval = TriggerInterval;
            }
            return data;
        }
    }
}
