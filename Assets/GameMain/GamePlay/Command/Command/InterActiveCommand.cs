using System;
using GameFramework;

namespace GameMain
{
    public class InteractiveCommand : ICommand
    {
        public CommandType CommandType { get; }

        public float LastTime;
        public Action OnFinish;
        public string AnimName = "idle";

        public InteractiveCommand(string pAnimName, Action pCallback)
        {
            this.CommandType = CommandType.Interactive;
            this.OnFinish = pCallback;

            if (string.IsNullOrEmpty(pAnimName))
            {
                Log.Error("AnimName is null.");
            }
            AnimName = pAnimName;
        }
    }
}
