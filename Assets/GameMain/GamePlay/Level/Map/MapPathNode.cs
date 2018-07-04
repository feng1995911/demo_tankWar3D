using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;

namespace GameMain
{
    public class MapPathNode : XmlObject
    {
        public float   NodeTime;
        public Vector3 Position;

        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "NodeTime":
                        this.NodeTime = ReadInt(current);
                        break;
                    case "Position":
                        this.Position = ReadVector3(current);
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "NodeTime", this.NodeTime);
            XmlObject.Write(os, "Position", this.Position);
        }
    }
}

