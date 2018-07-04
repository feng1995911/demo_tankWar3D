using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace GameMain
{
    public class MapPathNodeSet : XmlObject
    {
        public PathType Type = PathType.Linear;
        public List<MapPathNode> PathNodes = new List<MapPathNode>();

        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Type":
                        {
                            this.Type = (PathType)XmlObject.ReadInt(current);
                        }
                        break;
                    case "PathNodes":
                        {
                            XmlObject.GetChilds(current).ForEach(delegate (XmlNode pNode)
                            {
                                MapPathNode data = new MapPathNode();
                                data.Read(pNode);
                                PathNodes.Add(data);
                            });
                        }
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "Type", (int)this.Type);
            XmlObject.Write(os, "PathNodes", this.PathNodes);
        }
    }
}

