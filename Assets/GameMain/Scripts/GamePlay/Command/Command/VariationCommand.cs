using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// 变身命令
    /// </summary>
    public class VariationCommand : ICommand
    {
        public float LastTime;
        public int ChangeModelID;

        public VariationCommand(float lastTime, int changeModelId)
        {
            this.LastTime = lastTime;
            this.ChangeModelID = changeModelId;
            CommandType = CommandType.Variation;
        }

        public CommandType CommandType { get; }
    }
}
