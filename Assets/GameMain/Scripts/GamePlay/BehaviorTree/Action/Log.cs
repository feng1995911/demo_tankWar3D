using UnityEngine;

namespace BT
{
    /// <summary>
    /// Log节点
    /// </summary>
    public class Log : BTAction
    {
        public string Text { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;


        protected override void ReadAttribute(string key, string value)
        {
            switch (key)
            {
                case "Text":
                    Text = value;
                    break;
                case "Level":
                    Level = value;
                    break;
            }
        }

        protected override BTStatus Execute()
        {
            switch (Level)
            {
                case "1":
                    Debug.Log(Text);
                    break;
                case "2":
                    Debug.LogWarning(Text);
                    break;
                case "3":
                    Debug.LogError(Text);
                    break;
                case "Time":
                    Debug.Log(Time.time);
                    break;
                default:
                    Debug.Log(Text);
                    break;
            }
            return BTStatus.Success;
        }

        public override BTNode DeepClone()
        {
            Log log = new Log
            {
                Level = this.Level,
                Text = this.Text
            };
            return log;
        }

    }
}
