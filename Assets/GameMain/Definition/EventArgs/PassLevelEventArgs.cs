using GameFramework.Event;

namespace GameMain
{
    public class PassLevelEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(PassLevelEventArgs).GetHashCode();

        public override int Id => EventId;

        public override void Clear()
        {

        }

    }
}
