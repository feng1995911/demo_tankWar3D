using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;

namespace GameMain
{
    public class MapMonsterWave : XmlObject
    {
        public int    Index;
        public string IndexName = string.Empty;
        public float  Delay;
        public MonsterWaveSpawnType Spawn;
        public List<MapMonsterCall>     Monsters = new List<MapMonsterCall>();
        public int AddBuffID;

        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Index":
                        this.Index = ReadInt(current);
                        break;
                    case "IndexName":
                        this.IndexName = ReadString(current);
                        break;
                    case "Delay":
                        this.Delay = ReadFloat(current);
                        break;
                    case "Spawn":
                        this.Spawn = (MonsterWaveSpawnType)ReadInt(current);
                        break;
                    case "Monsters":
                        {
                            XmlObject.GetChilds(current).ForEach(delegate (XmlNode pNode)
                            {
                                MapMonsterCall data = new MapMonsterCall();
                                data.Read(pNode);
                                Monsters.Add(data);
                            });
                        }
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "Index", this.Index);
            XmlObject.Write(os, "IndexName", this.IndexName);
            XmlObject.Write(os, "Delay", this.Delay);
            XmlObject.Write(os, "Spawn", (int)Spawn);
            XmlObject.Write(os, "Monsters", this.Monsters);
        }
    }
}

