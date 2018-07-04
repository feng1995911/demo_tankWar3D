using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace GameMain
{
    public class MapConfig : XmlObject
    {
        public int Id;
        public float Delay;
        public string MapName = string.Empty;
        public string MapPath = string.Empty;
        public bool AllowRide = true;
        public bool AllowPK = true;
        public bool AllowTrade = true;
        public bool AllowFight = true;
        public MapBorn Ally;
        public MapBorn Enemy;
        public MapBorn Neutral;
        public List<MapBarrier> Barriers = new List<MapBarrier>();
        public List<MapPortal>  Portals = new List<MapPortal>();
        public List<MapRegion>  Regions = new List<MapRegion>();
        public List<MapMonsterGroup> MonsterGroups = new List<MapMonsterGroup>();
        public List<MapWaveSet>  WaveSets = new List<MapWaveSet>();
        public List<MapNpc> Npcs = new List<MapNpc>();
        public List<MapMineGroup> MineGroups = new List<MapMineGroup>();

        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Id":
                        this.Id = ReadInt(current);
                        break;
                    case "Delay":
                        this.Delay = ReadFloat(current);
                        break;
                    case "MapName":
                        this.MapName = ReadString(current);
                        break;
                    case "MapPath":
                        this.MapPath = ReadString(current);
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
                    case "Ally":
                        this.Ally = new MapBorn();
                        this.Ally.Read(current);
                        break;
                    case "Enemy":
                        this.Enemy = new MapBorn();
                        this.Enemy.Read(current);
                        break;
                    case "Neutral":
                        this.Neutral = new MapBorn();
                        this.Neutral.Read(current);
                        break;
                    case "Barriers":
                        XmlObject.GetChilds(current).ForEach(delegate (XmlNode pNode)
                        {
                            MapBarrier data = new MapBarrier();
                            data.Read(pNode);
                            this.Barriers.Add(data);
                        });
                        break;
                    case "Portals":
                        XmlObject.GetChilds(current).ForEach(delegate (XmlNode pNode)
                        {
                            MapPortal data = new MapPortal();
                            data.Read(pNode);
                            this.Portals.Add(data);
                        });
                        break;
                    case "Regions":
                        XmlObject.GetChilds(current).ForEach(delegate (XmlNode pNode)
                        {
                            MapRegion data = ReadDynamicObject<MapRegion>(pNode);
                            this.Regions.Add(data);
                        });
                        break;
                    case "MonsterGroups":
                        XmlObject.GetChilds(current).ForEach(delegate (XmlNode pNode)
                        {
                            MapMonsterGroup data = new MapMonsterGroup();
                            data.Read(pNode);
                            this.MonsterGroups.Add(data);
                        });
                        break;
                    case "MineGroups":
                        XmlObject.GetChilds(current).ForEach(delegate (XmlNode pNode)
                        {
                            MapMineGroup data = new MapMineGroup();
                            data.Read(pNode);
                            this.MineGroups.Add(data);
                        });
                        break;
                    case "WaveSets":
                        XmlObject.GetChilds(current).ForEach(delegate (XmlNode pNode)
                        {
                            MapWaveSet data = new MapWaveSet();
                            data.Read(pNode);
                            this.WaveSets.Add(data);
                        });
                        break;
                    case "Npcs":
                        XmlObject.GetChilds(current).ForEach(delegate (XmlNode pNode)
                        {
                            MapNpc data = new MapNpc();
                            data.Read(pNode);
                            this.Npcs.Add(data);
                        });
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "Id", Id);
            XmlObject.Write(os, "Delay", Delay);
            XmlObject.Write(os, "MapName", MapName);
            XmlObject.Write(os, "MapPath", MapPath);
            XmlObject.Write(os, "AllowRide", AllowRide);
            XmlObject.Write(os, "AllowPK", AllowPK);
            XmlObject.Write(os, "AllowTrade", AllowTrade);
            XmlObject.Write(os, "AllowFight", AllowFight);
            XmlObject.Write(os, "Ally", Ally);
            XmlObject.Write(os, "Enemy", Enemy);
            XmlObject.Write(os, "Neutral", Neutral);
            XmlObject.Write(os, "Barriers", Barriers);
            XmlObject.Write(os, "Portals", Portals);
            XmlObject.Write(os, "Regions", Regions); 
            XmlObject.Write(os, "MonsterGroups", MonsterGroups);
            XmlObject.Write(os, "MineGroups", MineGroups);
            XmlObject.Write(os, "WaveSets", WaveSets);
            XmlObject.Write(os, "Npcs", Npcs);
        }
    }
}

