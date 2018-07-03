using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;

namespace GameMain
{
    public class MapBarrier : MapElement
    {
        public float Width;
        public MapTransform TransParam;

        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Id":
                        this.Id = ReadInt(current);
                        break;
                    case "TransParam":
                        this.TransParam = new MapTransform();
                        this.TransParam.Read(current);
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "Id", (int)this.Id);
            XmlObject.Write(os, "TransParam", this.TransParam);
        }
    }
}

