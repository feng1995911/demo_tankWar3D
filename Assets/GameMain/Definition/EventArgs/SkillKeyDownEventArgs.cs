using GameFramework.Event;

namespace GameMain
{
    public class SkillKeyDownEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(SkillKeyDownEventArgs).GetHashCode();

        public override int Id => EventId;

        public SkillPosType SkillPos
        {
            get;
            private set;
        }

        public override void Clear()
        {
            SkillPos = SkillPosType.Skill_0;
        }

        public SkillKeyDownEventArgs Fill(SkillPosType skillPos)
        {
            this.SkillPos = skillPos;
            return this;
        }
    }
}
