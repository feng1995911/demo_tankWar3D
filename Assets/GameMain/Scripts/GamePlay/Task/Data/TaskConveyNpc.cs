using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;

namespace GameMain
{
    [Serializable]
    public class TaskConvoyNpc : XmlObject
    {
        [SerializeField]
        public int NpcID;
        
        public override void Read(XmlNode os)
        {
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "NpcID":
                        this.NpcID = XmlObject.ReadInt(current);
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            XmlObject.Write(os, "NpcID", NpcID);
        }
    }

}
