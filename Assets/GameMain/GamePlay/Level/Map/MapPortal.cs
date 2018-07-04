using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;

namespace GameMain
{
    public class MapPortal: MapElement
    {
        public int        RegionID;
        public int        DestMapID;
        public Vector3    DestPos;
        public bool    DisplayText;
        public string  PortalName = string.Empty;
        public Vector3 Center;
        public Vector3 Euler;

        public ConditionRelationType ConditionRelation = ConditionRelationType.And;
        public int OpenLevel;
        public int OpenItemID;
        public int OpenVIP;


        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Id":
                        this.Id = ReadInt(current);
                        break;
                    case "RegionID":
                        this.RegionID = ReadInt(current);
                        break;
                    case "DestMapID":
                        this.DestMapID = ReadInt(current);
                        break;
                    case "DestPos":
                        this.DestPos = ReadVector3(current);
                        break;
                    case "DisplayText":
                        this.DisplayText = ReadBool(current);
                        break;
                    case "PortalName":
                        this.PortalName = ReadString(current);
                        break;
                    case "Center":
                        this.Center = ReadVector3(current);
                        break;
                  case "Euler":
                        this.Euler = ReadVector3(current);
                        break;
                    case "ConditionRelation":
                        this.ConditionRelation = (ConditionRelationType)ReadInt(current);
                        break;
                    case "OpenLevel":
                        this.OpenLevel = XmlObject.ReadInt(current);
                        break;
                    case "OpenItemID":
                        this.OpenItemID = XmlObject.ReadInt(current);
                        break;
                    case "OpenVIP":
                        this.OpenVIP = XmlObject.ReadInt(current);
                        break;

                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "Id", this.Id);
            XmlObject.Write(os, "RegionID", this.RegionID);
            XmlObject.Write(os, "DestMapID", this.DestMapID);
            XmlObject.Write(os, "DestPos", this.DestPos);
            XmlObject.Write(os, "DisplayText", this.DisplayText);
            XmlObject.Write(os, "PortalName", this.PortalName);
            XmlObject.Write(os, "Center", this.Center);
            XmlObject.Write(os, "Euler", this.Euler);
            XmlObject.Write(os, "ConditionRelation", (int)this.ConditionRelation);
            XmlObject.Write(os, "OpenLevel", this.OpenLevel);
            XmlObject.Write(os, "OpenItemID", this.OpenItemID);
            XmlObject.Write(os, "OpenVIP", this.OpenVIP);
        }
    }
}

