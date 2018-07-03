using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace GameMain
{
    public class MapMineGroup : MapElement
    {
        public int RegionID;
        public List<MapMine> Mines = new List<MapMine>();
  
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
                    case "Mines":
                        XmlObject.GetChilds(current).ForEach(delegate (XmlNode pNode)
                        {
                            MapMine data = new MapMine();
                            data.Read(pNode);
                            this.Mines.Add(data);
                  
                        });
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "Id", Id);
            XmlObject.Write(os, "RegionID", this.RegionID);
            XmlObject.Write(os, "Mines", this.Mines);
        }
    }

}
