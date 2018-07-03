using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace GameMain
{
    public class MapMonsterGroup : MapElement
    {
        public int RegionID;
        public int   MonsterID;
        public float RebornCD;
        public int MaxCount;
        public int UnlockBarrierId;
        public bool TriggerResult;

        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Id":
                        this.Id = ReadInt(current);
                        break;
                    case "MonsterID":
                        this.MonsterID = ReadInt(current);
                        break;
                    case "RegionID":
                        this.RegionID = ReadInt(current);
                        break;
                    case "RebornCD":
                        this.RebornCD = ReadFloat(current);
                        break;
                    case "MaxCount":
                        this.MaxCount = ReadInt(current);
                        break;
                    case "UnlockBarrierId":
                        this.UnlockBarrierId = ReadInt(current);
                        break;
                    case "TriggerResult":
                        this.TriggerResult = ReadBool(current);
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "Id", Id);
            XmlObject.Write(os, "RegionID", this.RegionID);
            XmlObject.Write(os, "RebornCD", this.RebornCD);
            XmlObject.Write(os, "MonsterID", this.MonsterID);
            XmlObject.Write(os, "MaxCount", this.MaxCount);
            XmlObject.Write(os, "UnlockBarrierId", this.UnlockBarrierId);
            XmlObject.Write(os, "TriggerResult", this.TriggerResult);          
        }

    }
}

