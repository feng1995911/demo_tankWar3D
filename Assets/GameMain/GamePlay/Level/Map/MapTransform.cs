using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;

namespace GameMain
{
    public class MapTransform : XmlObject
    {
        public Vector3 Position = Vector3.zero;
        public Vector3 EulerAngles = Vector3.zero;
        public Vector3 Scale = Vector3.one;

        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Position":
                        this.Position = ReadVector3(current);
                        break;
                    case "EulerAngles":
                        this.EulerAngles = ReadVector3(current);
                        break;
                    case "Scale":
                        this.Scale = ReadVector3(current);
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "Position", this.Position);
            XmlObject.Write(os, "EulerAngles", this.EulerAngles);
            XmlObject.Write(os, "Scale", this.Scale);
        }
    }
}
