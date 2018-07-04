using GameFramework.Event;

namespace GameMain
{
    public class OnPlayerAttackEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(OnPlayerAttackEventArgs).GetHashCode();

        public override int Id => EventId;

        public IActor Target
        {
            get;
            private set;
        }

        public OnPlayerAttackEventArgs Fill(IActor target)
        {
            Target = target;
            return this;
        }

        public override void Clear()
        {
 
        }


    }
}
