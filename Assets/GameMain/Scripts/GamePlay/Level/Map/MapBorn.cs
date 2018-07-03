using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;

namespace GameMain
{
    public class MapBorn : XmlObject
    {
        public BattleCampType Camp;
        public MapTransform TransParam;

        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Camp":
                        this.Camp = (BattleCampType)ReadInt(current);
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
            XmlObject.Write(os, "Camp", (int)this.Camp);
            XmlObject.Write(os, "TransParam", this.TransParam);
        }
    }
}

