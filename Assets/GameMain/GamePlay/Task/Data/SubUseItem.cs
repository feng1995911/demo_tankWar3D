using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;

namespace GameMain
{
    [Serializable]
    public class SubUseItem : SubTaskBase
    {
        [SerializeField]
        public int ID;
        [SerializeField]
        public int Times;

        public SubUseItem()
        {
            Func = TaskSubFuncType.TYPE_USEITEM;
        }

        public override void Read(XmlNode os)
        {
            base.Read(os);
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "ID":
                        this.ID = ReadInt(current);
                        break;
                    case "Times":
                        this.Times = ReadInt(current);
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            base.Write(os);
            XmlObject.Write(os, "ID", this.ID);
            XmlObject.Write(os, "Times", this.Times);
        }
    }
}

