using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace GameMain
{
    public class MapEvent : XmlObject
    {
        public int  Id = 1;
        public bool Active = false;//激活还是销毁
        public int TriggerNum = 1;
        public float TriggerInterval = 0;
        public float TriggerDelay = 0;

        public MapTriggerType Type = MapTriggerType.None;
        public ConditionRelationType Relation1 = ConditionRelationType.And;
        public ConditionRelationType Relation2 = ConditionRelationType.And;

        public List<MapEventCondition> Conditions1 = new List<MapEventCondition>();//首次触发条件
        public List<MapEventCondition> Conditions2;//间隔触发条件

        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Type":
                        this.Type = (MapTriggerType)ReadInt(current);
                        break;
                    case "Id":
                        this.Id = ReadInt(current);
                        break;
                    case "Active":
                        this.Active = ReadBool(current);
                        break;
                    case "Relation1":
                        this.Relation1 = (ConditionRelationType)ReadInt(current);
                        break;
                    case "Relation2":
                        this.Relation2 = (ConditionRelationType)ReadInt(current);
                        break;
                    case "Conditions1":
                        XmlObject.GetChilds(current).ForEach(delegate (XmlNode pNode)
                        {
                            MapEventCondition data = new MapEventCondition();
                            data.Read(pNode);
                            Conditions1.Add(data);
                        });
                        break;
                    case "Conditions2":
                        XmlObject.GetChilds(current).ForEach(delegate (XmlNode pNode)
                        {
                            MapEventCondition data = new MapEventCondition();
                            data.Read(pNode);
                            Conditions2.Add(data);
                        });
                        break;
                    case "TriggerNum":
                        this.TriggerNum = ReadInt(current);
                        break;
                    case "TriggerInterval":
                        this.TriggerInterval = ReadFloat(current);
                        break;
                    case "TriggerDelay":
                        this.TriggerDelay = ReadFloat(current);
                        break;

                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "Type", (int)this.Type);
            XmlObject.Write(os, "Id", this.Id);
            XmlObject.Write(os, "Active", this.Active);
            XmlObject.Write(os, "TriggerDelay", this.TriggerDelay);
            XmlObject.Write(os, "Relation1", (int)this.Relation1);
            XmlObject.Write(os, "Conditions1", this.Conditions1);
            if (Conditions2!=null)
            {
                XmlObject.Write(os, "Relation2", (int)this.Relation2);
                XmlObject.Write(os, "Conditions2", this.Conditions2);
                XmlObject.Write(os, "TriggerInterval", this.TriggerInterval);
                XmlObject.Write(os, "TriggerNum", this.TriggerNum);
            }
        }
    }
}

