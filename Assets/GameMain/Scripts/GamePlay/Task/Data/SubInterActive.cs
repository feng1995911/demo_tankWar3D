using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;

namespace GameMain
{
    [Serializable]
    public class SubInterActive : SubTaskBase
    {
        [SerializeField]
        public TaskNpc Npc;
        [SerializeField]
        public string  Cmd = string.Empty;
        public string  AnimName = string.Empty;

        public SubInterActive()
        {
            Func = TaskSubFuncType.TYPE_INTERACTIVE;
        }

        public override void Read(XmlNode os)
        {
            base.Read(os);
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Npc":
                        this.Npc = new TaskNpc();
                        this.Npc.Read(current);
                        break;
                    case "Cmd":;
                        this.Cmd = XmlObject.ReadString(current);
                        break;
                    case "AnimName":
                        this.AnimName = XmlObject.ReadString(current);
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            base.Write(os);
            XmlObject.Write(os, "Npc", Npc);
            XmlObject.Write(os, "Cmd", Cmd);
            XmlObject.Write(os, "AnimName", AnimName);
        }
    }
}

