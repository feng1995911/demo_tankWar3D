using GameFramework.Event;

namespace GameMain
{
    public class RefreshBoardEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(RefreshBoardEventArgs).GetHashCode();

        public override int Id => EventId;

        public int OwnerId
        {
            get;
            private set;
        }

        public int MaxHp
        {
            get;
            private set;
        }

        public int CurHp
        {
            get;
            private set;
        }

        public int Level
        {
            get;
            private set;
        }

        public override void Clear()
        {
            MaxHp = 0;
            CurHp = 0;
            Level = 0;
        }

        public RefreshBoardEventArgs Fill(int ownerId, int maxHp, int curHp, int level)
        {
            OwnerId = ownerId;
            MaxHp = maxHp;
            CurHp = curHp;
            Level = level;
            return this;
        }

    }
}
