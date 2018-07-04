using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace GameMain
{
    [Serializable]
    public class SubCollectItem : SubTaskBase
    {
        [SerializeField]
        public List<TaskCollectionItem> Items = new List<TaskCollectionItem>();

        public SubCollectItem()
        {
            Func = TaskSubFuncType.TYPE_COLLECT;
        }

        public override void Read(XmlNode os)
        {
            base.Read(os);
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Items":
                        XmlObject.GetChilds(current).ForEach(delegate (XmlNode pNode)
                        {
                            TaskCollectionItem data = new TaskCollectionItem();
                            data.Read(pNode);
                            Items.Add(data);
                        });
                        break;
                }
            }
        }

        public override void Write(TextWriter os)
        {
            base.Write(os);
            XmlObject.Write(os, "Items", Items);
        }
    }
}

