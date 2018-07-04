using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Xml;

namespace GameMain
{
    [Serializable]
    public class SubTalk: SubTaskBase
    {
        [SerializeField]
        public List<TaskDialog> Dialogs = new List<TaskDialog>();
        [SerializeField]
        public TaskNpc Npc;

        public SubTalk()
        {
            Func = TaskSubFuncType.TYPE_TALK;
        }

        public override void Read(XmlNode os)
        {
            base.Read(os);
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Dialogs":
                        XmlObject.GetChilds(current).ForEach(delegate (XmlNode pNode)
                        {
                            TaskDialog data = new TaskDialog();
                            data.Read(pNode);
                            Dialogs.Add(data);
                        });
                        break;
                    case "Npc":
                        this.Npc = new TaskNpc();
                        this.Npc.Read(current);
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            base.Write(os);
            XmlObject.Write(os, "Npc", this.Npc);
            XmlObject.Write(os, "Dialogs", this.Dialogs);
        }
    }
}

