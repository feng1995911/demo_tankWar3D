using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace GameMain
{
    [Serializable]
    public class MapEventCondition : XmlObject
    {
        public TriggerConditionType Type = TriggerConditionType.EnterRegion;
        public string Args = string.Empty;
        
        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Type":
                        this.Type = (TriggerConditionType)ReadInt(current);
                        break;
                    case "Args":
                        this.Args = ReadString(current);
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "Type", (int)Type);
            XmlObject.Write(os, "Args", Args);
        }
    }
}
