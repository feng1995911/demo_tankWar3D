using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System;

namespace GameMain
{
    [Serializable]
    public class SubTriggerPlot : SubTaskBase
    {
        [SerializeField]
        public int PlotID;

        public SubTriggerPlot()
        {
            Func = TaskSubFuncType.TYPE_STORY;
        }

        public override void Read(XmlNode os)
        {
            base.Read(os);
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "PlotID":
                        this.PlotID = ReadInt(current);
                        break;
                }
            }

        }

        public override void Write(TextWriter os)
        {
            base.Write(os);
            XmlObject.Write(os, "PlotID", this.PlotID);
        }
    }
}