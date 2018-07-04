using GameFramework.Event;

namespace GameMain
{
    public class ChangeVehicleEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(ChangeVehicleEventArgs).GetHashCode();

        public override int Id => EventId;

        public override void Clear()
        {

        }
    }
}
