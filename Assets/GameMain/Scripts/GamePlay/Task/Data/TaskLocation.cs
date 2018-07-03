using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using UnityEngine;

namespace GameMain
{
    [Serializable]
    public class TaskLocation : XmlObject
    {
        public int     MapID;
        public Vector3 Pos;

        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Pos":
                        this.Pos = XmlObject.ReadVector3(current);
                        break;
                    case "MapID":
                        this.MapID = XmlObject.ReadInt(current);
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "MapID", this.MapID);
            XmlObject.Write(os, "Pos", Pos);
        }
    }
}
