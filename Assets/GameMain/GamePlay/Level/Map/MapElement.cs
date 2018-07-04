using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;

namespace GameMain
{
    public class MapElement:XmlObject
    {
        public int Id;

        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Id":
                        this.Id = ReadInt(current);
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "Id", this.Id);
        }
    }
}
