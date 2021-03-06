﻿using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;

namespace GameMain
{
    public class MapMonsterCall : MapElement
    {
        public Vector3 Position;
        public Vector3 EulerAngles;


        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Id":
                        this.Id = ReadInt(current);
                        break;
                    case "Position":
                        this.Position = ReadVector3(current);
                        break;
                    case "EulerAngles":
                        this.EulerAngles = ReadVector3(current);
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "Id", this.Id);
            XmlObject.Write(os, "Position", this.Position);
            XmlObject.Write(os, "EulerAngles", this.EulerAngles);
        }
    }
}
