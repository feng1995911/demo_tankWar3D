using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace GameMain
{
    [Serializable]
    public class SubConvoy : SubTaskBase
    {
        [SerializeField]
        public List<TaskConvoyNpc> ConvoyNpcs  = new List<TaskConvoyNpc>();
        [SerializeField]
        public TaskLocation  SrcLocation = new TaskLocation();
        [SerializeField]
        public TaskLocation  TarLocation = new TaskLocation();
        [SerializeField]
        public List<Vector3> WayPoints   = new List<Vector3>();

        public SubConvoy()
        {
            Func = TaskSubFuncType.TYPE_CONVOY;
        }

        public override void Read(XmlNode os)
        {
            base.Read(os);
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "ConvoyNpcs":
                        XmlObject.GetChilds(current).ForEach(delegate (XmlNode pNode)
                        {
                            TaskConvoyNpc data = new TaskConvoyNpc();
                            data.Read(pNode);
                            this.ConvoyNpcs.Add(data);
                        });
                        break;
                    case "SrcLocation":
                        this.SrcLocation = new TaskLocation();
                        this.SrcLocation.Read(current);
                        break;
                    case "TarLocation":
                        this.TarLocation = new TaskLocation();
                        this.TarLocation.Read(current);
                        break;
                    case "WayPoints":
                        XmlObject.GetChilds(current).ForEach(delegate (XmlNode pNode)
                        {
                            Vector3 pos = ReadVector3(pNode);
                            this.WayPoints.Add(pos);
                        });
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            base.Write(os);
            XmlObject.Write(os, "ConvoyNpcs", ConvoyNpcs);
            XmlObject.Write(os, "SrcLocation", SrcLocation);
            XmlObject.Write(os, "TarLocation", TarLocation);
            XmlObject.Write(os, "WayPoints", WayPoints);
        }
    }
}

