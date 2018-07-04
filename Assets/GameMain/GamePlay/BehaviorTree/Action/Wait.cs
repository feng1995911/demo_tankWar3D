using System.Xml;
using GameMain;
using UnityEngine;

namespace BT
{
    /// <summary>
    /// 等待节点
    /// </summary>
    public class Wait : BTAction
    {
        public float Seconds { get; set; }

        protected float m_Clocker;

        protected override bool Enter()
        {
            m_Clocker = Time.realtimeSinceStartup;
            return Seconds > 0;
        }

        protected override void ReadAttribute(string key, string value)
        {
            switch (key)
            {
                case "Seconds":
                    this.Seconds = value.ToFloat();
                    break;
            }
        }

        protected override void SaveAttribute(XmlDocument doc, XmlElement xe)
        {
            xe.SetAttribute("Seconds", Seconds.ToString());
        }

        protected override BTStatus Execute()
        {
            if (Time.realtimeSinceStartup - m_Clocker > Seconds)
            {
                return BTStatus.Success;
            }
            return BTStatus.Running;
        }

        public override void Clear()
        {
            base.Clear();
            m_Clocker = 0;
        }

        public override BTNode DeepClone()
        {
            Wait node = new Wait();
            node.Seconds = this.Seconds;
            return node;
        }
    }
}
