using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace GameMain
{
    public class MapNpc : MapElement
    {
        public Vector3 Position;
        public Vector3 Euler;
        public Vector3 Scale = Vector3.one;
        public List<string> Talks = new List<string>();
        public MapPathNodeSet PatrolPathNodeSet;

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
                    case "Euler":
                        this.Euler = ReadVector3(current);
                        break;
                    case "Scale":
                        this.Scale= ReadVector3(current);
                        break;
                    case "Talks":
                        XmlObject.GetChilds(current).ForEach(delegate (XmlNode pNode)
                        {
                            string s = ReadString(pNode);
                            if(!string.IsNullOrEmpty(s))
                            {
                                this.Talks.Add(s);
                            }
                        });
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
            XmlObject.Write(os, "Position", this.Position);
            XmlObject.Write(os, "Euler", this.Euler);
            XmlObject.Write(os, "Scale", this.Scale);
            XmlObject.Write(os, "Talks", this.Talks);
            XmlObject.Write(os, "PatrolPathNodeSet", this.PatrolPathNodeSet);
        }
    }
}

