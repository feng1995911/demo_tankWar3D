using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System;

namespace GameMain
{
    [Serializable]
    public class SubTriggerCutscene : SubTaskBase
    {
        [SerializeField]
        public int CutsceneID;

        public SubTriggerCutscene()
        {
            Func = TaskSubFuncType.TYPE_CUTSCENE;
        }

        public override void Read(XmlNode os)
        {
            base.Read(os);
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "CutsceneID":
                        this.CutsceneID = ReadInt(current);
                        break;
                }
            }

        }

        public override void Write(TextWriter os)
        {
            base.Write(os);
            XmlObject.Write(os, "CutsceneID", this.CutsceneID);
        }
    }
}
