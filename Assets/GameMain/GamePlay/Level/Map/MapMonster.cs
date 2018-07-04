using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;

namespace GameMain
{
    public class MapMonster : MapElement
    {
        public Vector3 Position;
        public Vector3 EulerAngles;
        public MapPathNodeSet PatrolPathNodeSet;
        public float RebornCD;

        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Id":
                        this.Id = ReadInt(current);
                        break;
                    case "RebornCD":
                        this.RebornCD = ReadFloat(current);
                        break;
                    case "Position":
                        this.Position = ReadVector3(current);
                        break;
                    case "EulerAngles":
                        this.EulerAngles = ReadVector3(current);
                        break;
                    case "PatrolPathNodeSet":
                        this.PatrolPathNodeSet = new MapPathNodeSet();
                        this.PatrolPathNodeSet.Read(current);
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "Id", this.Id);
            XmlObject.Write(os, "RebornCD", this.RebornCD);
            XmlObject.Write(os, "Position", this.Position);
            XmlObject.Write(os, "EulerAngles", this.EulerAngles);
            XmlObject.Write(os, "PatrolPathNodeSet", this.PatrolPathNodeSet);
        }
    }
}

