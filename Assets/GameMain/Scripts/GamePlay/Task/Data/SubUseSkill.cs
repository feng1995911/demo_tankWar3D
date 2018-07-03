using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;

namespace GameMain
{
    [Serializable]
    public class SubUseSkill : SubTaskBase
    {
        [SerializeField]
        public SkillPosType Pos;
        [SerializeField]
        public int       Times;

        public SubUseSkill()
        {
            Func = TaskSubFuncType.TYPE_USESKILL;
        }

        public override void Read(XmlNode os)
        {
            base.Read(os);
            foreach (XmlNode current in XmlObject.GetChilds(os))
            {
                switch (current.Name)
                {
                    case "Pos":
                        this.Pos = (SkillPosType)ReadInt(current);
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
            XmlObject.Write(os, "Pos", (int)this.Pos);
            XmlObject.Write(os, "Times", this.Times);
        }
    }
}

