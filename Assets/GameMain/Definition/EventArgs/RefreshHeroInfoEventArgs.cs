using GameFramework.Event;

namespace GameMain
{
    public enum RefreshType
    {
        None = 0,
        All,
        Attribute,
        Name,
        Level,
        Hp,
        Mp,
        Exp,
    }

    public class RefreshHeroInfoEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(RefreshHeroInfoEventArgs).GetHashCode();

        public override int Id => EventId;

        public RefreshType Type
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public int Level
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

        public int MaxMp
        {
            get;
            private set;
        }

        public int CurMp
        {
            get;
            private set;
        }

        public int MaxExp
        {
            get;
            private set;
        }

        public int CurExp
        {
            get;
            private set;
        }

        public ActorAttribute Attribute
        {
            get;
            private set;
        }

        public RefreshHeroInfoEventArgs FillName(string name)
        {
            Type = RefreshType.Name;
            this.Name = name;
            return this;
        }

        public RefreshHeroInfoEventArgs FillLevel(int level)
        {
            Type = RefreshType.Level;
            this.Level = level;
            return this;
        }

        public RefreshHeroInfoEventArgs FillHp(int curHp, int maxHp)
        {
            Type = RefreshType.Hp;
            this.MaxHp = maxHp;
            this.CurHp = curHp;
            return this;
        }

        public RefreshHeroInfoEventArgs FillMp(int curMp, int maxMp)
        {
            Type = RefreshType.Mp;
            this.CurMp = curMp;
            this.MaxMp = maxMp;
            return this;
        }

        public RefreshHeroInfoEventArgs FillExp(int curExp, int maxExp)
        {
            Type = RefreshType.Exp;
            this.CurExp = curExp;
            this.MaxExp = maxExp;
            return this;
        }

        public RefreshHeroInfoEventArgs FillAttribute(ActorAttribute attribute)
        {
            Type = RefreshType.Attribute;
            this.Attribute = attribute;
            return this;
        }

        public RefreshHeroInfoEventArgs Fill(string name, int level, int curExp, int maxExp, ActorAttribute attribute)
        {
            Type = RefreshType.All;
            this.Name = name;
            this.Level = level;
            this.CurHp = curExp;
            this.MaxHp = maxExp;
            this.Attribute = attribute;
            return this;
        }

        public override void Clear()
        {
            Type = RefreshType.None;
            Name = null;
        }
    }
}
