using GameFramework.Event;

namespace GameMain
{
    public class RefreshBuffEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(RefreshBuffEventArgs).GetHashCode();

        public override int Id => EventId;

        public ActorBase Actor { get; private set; }

        public override void Clear()
        {
            Actor = null;
        }

        public RefreshBuffEventArgs Fill(ActorBase actor)
        {
            Actor = actor;
            return this;
        }
    }
}
