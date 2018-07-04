using GameFramework.Event;

namespace GameMain
{
    public class KillMonsterEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(KillMonsterEventArgs).GetHashCode();

        public override int Id => EventId;

        public int MonsterId
        {
            get;
            private set;
        }

        public int MonsterEntityId
        {
            get;
            private set;
        }

        public override void Clear()
        {
            MonsterId = 0;
            MonsterEntityId = 0;
        }

        public KillMonsterEventArgs Fill(int id,int entityid)
        {
            this.MonsterId = id;
            this.MonsterEntityId = entityid;
            return this;
        }
    }
}
