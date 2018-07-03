using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using GameMain;

namespace BT
{

    public class LoopParallel : Parallel
    {
        public int Times = 1;
        public int Count = 0;

        public override BTStatus Step()
        {

            BTStatus pStatus = base.Step();
            switch (pStatus)
            {
                case BTStatus.Success:
                    {
                        Count++;
                        base.Clear();
                        break;
                    }

                case BTStatus.Running:
                    {
                        break;
                    }
                case BTStatus.Failure:
                    {
                        return BTStatus.Failure;
                    }

            }
            return Count >= Times ? BTStatus.Success : BTStatus.Running;
        }

        public override void Clear()
        {
            base.Clear();
            Count = 0;
        }

        protected override void ReadAttribute(string key, string value)
        {
            switch (key)
            {
                case "Times":
                    this.Times = value.ToInt32();
                    break;
            }
        }

        protected override void SaveAttribute(XmlDocument doc, XmlElement xe)
        {
            xe.SetAttribute("Times", Times.ToString());
        }


        public override BTNode DeepClone()
        {
            LoopParallel ls = new LoopParallel();
            ls.Times = this.Times;
            ls.CloneChildren(this);
            return ls;
        }
    }
}
