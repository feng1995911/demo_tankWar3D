using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;

namespace GameMain
{
    [Serializable]
    public class SubKillMonster : SubTaskBase
    {
        [SerializeField]
        public int   ID;
        [SerializeField]
        public int   Count;
        [SerializeField]
        public TaskLocation Location;

        public SubKillMonster()
        {
            Func = TaskSubFuncType.TYPE_HUNTER;
        }

        public override void Read(XmlNode os)
        {
            base.Read(os);
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
                    case "Location":
                        this.Location = new TaskLocation();
                        this.Location.Read(current);
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            base.Write(os);
            XmlObject.Write(os, "ID", this.ID);
            XmlObject.Write(os, "Count", this.Count);
            XmlObject.Write(os, "Location", this.Location);
        }
    }
}

