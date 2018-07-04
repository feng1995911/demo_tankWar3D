using GameFramework.Event;

namespace GameMain
{
    public class BackCityEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(BackCityEventArgs).GetHashCode();

        public override int Id => EventId;

        public override void Clear()
        {

        }
    }
}
