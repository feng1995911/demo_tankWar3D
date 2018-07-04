using System.Xml;
using GameMain;

namespace BT
{
    /// <summary>
    /// 概率节点
    /// </summary>
    public class Probability : Condition
    {
        public float SuccessProbability = 0.5f;

        protected override void ReadAttribute(string key, string value)
        {
            switch (key)
            {
                case "Percent":
                    SuccessProbability = value.ToFloat();
                    break;
            }
        }

        public override bool CheckCondition()
        {
            float r = UnityEngine.Random.Range(0, 1);
            return r < SuccessProbability;
        }

        protected override void SaveAttribute(XmlDocument doc, XmlElement xe)
        {
            xe.SetAttribute("Percent", SuccessProbability.ToString());
        }

        public override BTNode DeepClone()
        {
            Probability random = new Probability();
            random.SuccessProbability = this.SuccessProbability;
            return random;
        }
    }
}
