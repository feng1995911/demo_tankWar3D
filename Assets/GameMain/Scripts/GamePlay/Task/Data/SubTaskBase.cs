using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Xml;

namespace GameMain
{
    public class SubTaskBase : XmlObject
    {
        [SerializeField]
        public string Desc = string.Empty;
        [SerializeField]
        public TaskSubFuncType Func;

        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Desc":
                        this.Desc = XmlObject.ReadString(current);
                        break;
                    case "Func":
                        this.Func = (TaskSubFuncType)XmlObject.ReadInt(current);
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "Desc", Desc);
            XmlObject.Write(os, "Func", (int)Func);
        }
    }
}