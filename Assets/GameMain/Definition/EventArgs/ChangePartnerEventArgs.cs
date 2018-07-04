using GameFramework.Event;

namespace GameMain
{
    public class ChangePartnerEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(ChangePartnerEventArgs).GetHashCode();

        public override int Id => EventId;

        public int Partner01ID
        {
            get;
            private set;
        }

        public int Partner02ID
        {
            get;
            private set;
        }

        public ChangePartnerEventArgs Fill(int partner01ID,int partner02ID)
        {
            this.Partner01ID = partner01ID;
            this.Partner02ID = partner02ID;
            return this;
        }

        public override void Clear()
        {

        }
    }
}
