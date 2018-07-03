using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;

namespace GameMain
{
    public class MapObj : MapElement
    {
        public string Name = string.Empty;
        public string Path = string.Empty;
        public float  Scale = 1;

        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Id":
                        this.Id = XmlObject.ReadInt(current);
                        break;
                    case "Name":
                        this.Name = XmlObject.ReadString(current);
                        break;
                    case "Path":
                        this.Path = XmlObject.ReadString(current);
                        break;
                    case "Scale":
                        this.Scale = XmlObject.ReadFloat(current);
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "Id", this.Id);
            XmlObject.Write(os, "Name", this.Name);
            XmlObject.Write(os, "Path", this.Path);
            XmlObject.Write(os, "Scale", this.Scale);
        }
    }
}

