using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace GameMain
{
    public class MapRegion : MapElement
    {
        public Vector3 Center = Vector3.zero;
        public Vector3 EulerAngles = Vector3.zero;
        public bool AllowRide = true;
        public bool AllowPK = true;
        public bool AllowTrade = true;
        public bool AllowFight = true;
        public bool StartActive = false;
        public Vector3 Size = Vector3.one;
        public List<MapEvent> Events = new List<MapEvent>();

        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Id":
                        this.Id = ReadInt(current);
                        break;
                    case "Center":
                        this.Center = ReadVector3(current);
                        break;
                    case "EulerAngles":
                        this.EulerAngles = ReadVector3(current);
                        break;
                    case "Size":
                        this.Size = ReadVector3(current);
                        break;
                    case "AllowRide":
                        this.AllowRide = ReadBool(current);
                        break;
                    case "AllowPK":
                        this.AllowPK = ReadBool(current);
                        break;
                    case "AllowTrade":
                        this.AllowTrade = ReadBool(current);
                        break;
                    case "AllowFight":
                        this.AllowFight = ReadBool(current);
                        break;
                    case "StartActive":
                        this.StartActive = ReadBool(current);
                        break;
                    case "Events":
                        XmlObject.GetChilds(current).ForEach(delegate (XmlNode pNode)
                        {
                            MapEvent data = new MapEvent();
                            data.Read(pNode);
                            Events.Add(data);
                        });
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "Id", this.Id);
            XmlObject.Write(os, "Center", this.Center);
            XmlObject.Write(os, "EulerAngles", this.EulerAngles);
            XmlObject.Write(os, "Size", this.Size);
            XmlObject.Write(os, "AllowRide", AllowRide);
            XmlObject.Write(os, "AllowPK", AllowPK);
            XmlObject.Write(os, "AllowTrade", AllowTrade);
            XmlObject.Write(os, "AllowFight", AllowFight);
            XmlObject.Write(os, "StartActive", StartActive);
            XmlObject.Write(os, "Events", this.Events);
        }
    }
}

