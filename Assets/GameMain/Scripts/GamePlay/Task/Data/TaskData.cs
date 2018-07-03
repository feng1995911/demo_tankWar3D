using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace GameMain
{
    [Serializable]
    public class TaskData : XmlObject
    {
        public int Id;
        public string Name = string.Empty;
        public TaskType TaskType;
        public bool CanbeCancle = false;
        public bool CanbeSearch = false;
        public bool IsAutoPathFind = true;
        public bool IsFinishedTaskCount = true;
        public bool IsAutoFinish = false;
        public int PreTaskID;
        [SerializeField]
        public List<SubTaskBase> SubTasks = new List<SubTaskBase>();

        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Id":
                        this.Id = ReadInt(current);
                        break;
                    case "Name":
                        this.Name = ReadString(current);
                        break;
                    case "TaskType":
                        this.TaskType = (TaskType)ReadInt(current);
                        break;
                    case "CanbeCancle":
                        this.CanbeCancle = ReadBool(current);
                        break;
                    case "CanbeSearch":
                        this.CanbeSearch = ReadBool(current);
                        break;
                    case "IsAutoPathFind":
                        this.IsAutoPathFind = ReadBool(current);
                        break;
                    case "IsFinishedTaskCount":
                        this.IsFinishedTaskCount = ReadBool(current);
                        break;
                    case "IsAutoFinish":
                        this.IsAutoFinish = ReadBool(current);
                        break;
                    case "PreTaskID":
                        this.PreTaskID = XmlObject.ReadInt(current);
                        break;
                    case "SubTasks":
                        XmlObject.GetChilds(current).ForEach(delegate (XmlNode pNode)
                        {
                            SubTaskBase data = null;
                            switch (XmlObject.ReadAttribute(pNode,"Type"))
                            {
                                case "SubTalk":
                                    data = XmlObject.ReadObject<SubTalk>(pNode);
                                    break;
                                case "SubKillMonster":
                                    data = XmlObject.ReadObject<SubKillMonster>(pNode);
                                    break;
                                case "SubCollectItem":
                                    data = XmlObject.ReadObject<SubCollectItem>(pNode);
                                    break;
                                case "SubUseItem":
                                    data = XmlObject.ReadObject<SubUseItem>(pNode);
                                    break;
                                case "SubUseSkill":
                                    data = XmlObject.ReadObject<SubUseSkill>(pNode);
                                    break;
                                case "SubInterActive":
                                    data = XmlObject.ReadObject<SubInterActive>(pNode);
                                    break;
                                case "SubGather":
                                    data = XmlObject.ReadObject<SubGather>(pNode);
                                    break;
                                case "SubConvoy":
                                    data = XmlObject.ReadObject<SubConvoy>(pNode);
                                    break;
                                case "SubTriggerCutscene":
                                    data = XmlObject.ReadObject<SubTriggerCutscene>(pNode);
                                    break;
                                case "SubTriggerPlot":
                                    data = XmlObject.ReadObject<SubTriggerPlot>(pNode);
                                    break;
                            }
   
                            if(data!=null)
                            {
                                this.SubTasks.Add(data);
                            }

                        });
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "Id", Id);
            XmlObject.Write(os, "Name", this.Name);
            XmlObject.Write(os, "TaskType", (int)this.TaskType);
            XmlObject.Write(os, "CanbeCancle", this.CanbeCancle);
            XmlObject.Write(os, "CanbeSearch", this.CanbeSearch);
            XmlObject.Write(os, "IsAutoPathFind", this.IsAutoPathFind);
            XmlObject.Write(os, "IsFinishedTaskCount", this.IsFinishedTaskCount);
            XmlObject.Write(os, "IsAutoFinish", this.IsAutoFinish);
            XmlObject.Write(os, "PreTaskID", this.PreTaskID);
            XmlObject.Write(os, "SubTasks", this.SubTasks);
        }
    }
}

