using GameFramework.Event;

namespace GameMain
{
    public class OnPlayerDeadEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(OnPlayerDeadEventArgs).GetHashCode();

        public override int Id => EventId;

        public ActorDeadType DeadType
        {
            get;
            private set;
        }

        public OnPlayerDeadEventArgs Fill(ActorDeadType deadType)
        {
            this.DeadType = deadType;
            return this;
        }

        public override void Clear()
        {
            DeadType = ActorDeadType.Normal;
        }


    }
}
