using System;
using System.Xml;
using GameMain;

namespace BT
{
    public class Clone : Composite
    {
        public int Times = 1;
        public float Interval = 0;

        protected Timer m_Timer;
        protected int m_CloneIndex = 0;

        protected override void ReadAttribute(string key, string value)
        {
            switch (key)
            {
                case "Times":
                    this.Times = value.ToInt32();
                    break;
                case "Interval":
                    this.Interval = value.ToFloat();
                    break;
            }
        }

        protected override void SaveAttribute(System.Xml.XmlDocument doc, XmlElement xe)
        {
            base.SaveAttribute(doc, xe);
            xe.SetAttribute("Times", Times >= 1 ? Times.ToString() : "1");
            xe.SetAttribute("Interval", Interval.ToString());
        }

        public override BTStatus Step()
        {
            if (Times < 1 || Interval < 0)
            {
                return BTStatus.Failure;
            }

            if (m_CloneIndex == 0)
            {
                if (Interval > 0)
                {
                    m_Timer = GameEntry.Timer.Register(Interval, DoForeach, Times);
                }
                else
                {
                    for (int i = 0; i < Times; i++)
                    {
                        DoForeach();
                    }
                }
            }
            return m_CloneIndex >= Times ? BTStatus.Success : BTStatus.Running;
        }

        public override void Clear()
        {
            base.Clear();
            m_CloneIndex = 0;
            GameEntry.Timer.UnRegister(DoForeach);
        }

        protected void DoForeach()
        {
            m_CloneIndex++;
            CloneTree tree = new CloneTree();
            tree.Owner = GameEntry.BT.GetOwnerByNode(this);
            tree.CloneChildren(this);
            GameEntry.BT.Run(tree);
        }

        public override BTNode DeepClone()
        {
            Clone clone = new Clone();
            clone.Times = this.Times;
            clone.Interval = this.Interval;
            return clone;
        }

    }
}
