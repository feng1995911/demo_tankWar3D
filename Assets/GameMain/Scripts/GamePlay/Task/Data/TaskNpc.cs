using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;

namespace GameMain
{
    [Serializable]
    public class TaskNpc : XmlObject
    {
        public int NpcID;
        public int LifeTime;
        [SerializeField]
        public TaskLocation Location;

        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "NpcID":
                        this.NpcID = XmlObject.ReadInt(current);
                        break;
                    case "Location":
                        this.Location = new TaskLocation();
                        this.Location.Read(current);
                        break;
                    case "LifeTime":
                        this.LifeTime = XmlObject.ReadInt(current);
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "NpcID", this.NpcID);
            XmlObject.Write(os, "LifeTime", this.LifeTime);
            XmlObject.Write(os, "Location", this.Location);
        }
    }
}

