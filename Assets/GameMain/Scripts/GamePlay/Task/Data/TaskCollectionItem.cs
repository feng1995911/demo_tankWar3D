using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;

namespace GameMain
{
    [Serializable]
    public class TaskCollectionItem : XmlObject
    {
        [SerializeField]
        public int ID;
        [SerializeField]
        public int Count;
        [SerializeField]
        public int NpcID;
        [SerializeField]
        public float DropRate = 1;
        [SerializeField]
        public TaskLocation Location;

        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "ID":
                        this.ID = XmlObject.ReadInt(current);
                        break;
                    case "Count":
                        this.Count = XmlObject.ReadInt(current);
                        break;
                    case "NpcID":
                        this.NpcID = XmlObject.ReadInt(current);
                        break;
                    case "DropRate":
                        this.DropRate = XmlObject.ReadFloat(current);
                        break;
                    case "Location":
                        this.Location = new TaskLocation();
                        this.Location.Read(os);
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "ID", ID);
            XmlObject.Write(os, "Count", Count);
            XmlObject.Write(os, "NpcID", NpcID);
            XmlObject.Write(os, "DropRate", DropRate);
            XmlObject.Write(os, "Location", Location);
        }
    }
}

