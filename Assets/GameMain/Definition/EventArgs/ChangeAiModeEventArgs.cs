using GameFramework.Event;

namespace GameMain
{
    public class ChangeAiModeEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(ChangeAiModeEventArgs).GetHashCode();

        public override int Id => EventId;

        public AIModeType AiMode
        {
            get;
            private set;
        }

        public ChangeAiModeEventArgs Fill(AIModeType mode)
        {
            this.AiMode = mode;
            return this;
        }

        public override void Clear()
        {

        }
    }
}
