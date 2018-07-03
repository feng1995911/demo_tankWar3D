using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace GameMain
{
    public class MapWaveSet: MapElement
    {
        public int AddBuffID;
        public List<MapMonsterWave> Waves = new List<MapMonsterWave>();

        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Id":
                        this.Id = XmlObject.ReadInt(current);
                        break;
                    case "AddBuffID":
                        this.AddBuffID = XmlObject.ReadInt(current);
                        break;
                    case "Waves":
                        {
                            XmlObject.GetChilds(current).ForEach(delegate (XmlNode pNode)
                            {
                                MapMonsterWave data = new MapMonsterWave();
                                data.Read(pNode);
                                Waves.Add(data);
                            });
                        }
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "Id", this.Id);
            XmlObject.Write(os, "AddBuffID", this.AddBuffID);
            XmlObject.Write(os, "Waves", this.Waves);
        }
    }
}

