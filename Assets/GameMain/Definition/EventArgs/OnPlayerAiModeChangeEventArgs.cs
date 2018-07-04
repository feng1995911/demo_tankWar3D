using GameFramework.Event;

namespace GameMain
{
    public class OnPlayerAiModeChangeEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(OnPlayerAiModeChangeEventArgs).GetHashCode();

        public override int Id => EventId;

        public AIModeType AiMode
        {
            get;
            private set;
        }

        public OnPlayerAiModeChangeEventArgs Fill(AIModeType mode)
        {
            this.AiMode = mode;
            return this;
        }

        public override void Clear()
        {

        }
    }
}
