using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;

namespace GameMain
{
    [Serializable]
    public class TaskDialog : XmlObject
    {
        public int NpcID;
        public TaskDialogRoleType    Role = TaskDialogRoleType.TYPE_PLAYER;
        public TaskDialogPosType     Pos = TaskDialogPosType.TYPE_LF;
        public TaskDialogActionType  Action = TaskDialogActionType.TYPE_NEXT;
        public TaskDialogContentType ContentType = TaskDialogContentType.TYPE_NORMAL;
        public string Content = string.Empty;
        public string NpcAnim = string.Empty;
        public int VoiceID;
        public int Delay;

        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Role":
                        this.Role =(TaskDialogRoleType) XmlObject.ReadInt(current);
                        break;
                    case "Pos":
                        this.Pos = (TaskDialogPosType)XmlObject.ReadInt(current);
                        break;
                    case "Action":
                        this.Action = (TaskDialogActionType)XmlObject.ReadInt(current);
                        break;
                    case "ContentType":
                        this.ContentType = (TaskDialogContentType)XmlObject.ReadInt(current);
                        break;
                    case "NpcID":
                        this.NpcID = XmlObject.ReadInt(current);
                        break;
                    case "Content":
                        this.Content = XmlObject.ReadString(current);
                        break;
                    case "VoiceID":
                        this.VoiceID = XmlObject.ReadInt(current);
                        break;
                    case "Delay":
                        this.Delay = XmlObject.ReadInt(current);
                        break;
                    case "NpcAnim":
                        this.NpcAnim = XmlObject.ReadString(current);
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "Role", (int)Role);
            XmlObject.Write(os, "NpcID", this.NpcID);
            XmlObject.Write(os, "Pos", (int)Pos);
            XmlObject.Write(os, "Action", (int)Action);
            XmlObject.Write(os, "ContentType", (int)ContentType);
            XmlObject.Write(os, "Content", this.Content);
            XmlObject.Write(os, "VoiceID", this.VoiceID);
            XmlObject.Write(os, "Delay", this.Delay);
            XmlObject.Write(os, "NpcAnim", this.NpcAnim);
        }
    }
}

