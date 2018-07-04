using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// 使用技能
    /// </summary>
    public class UseSkillCommand : ICommand
    {
        public CommandType CommandType { get; }

        public SkillPosType SkillPos = SkillPosType.Skill_0;
        public SkillTree Tree = null;
        public float LastTime;

        public UseSkillCommand(SkillPosType pos)
        {
            CommandType = CommandType.Useskill;
            SkillPos = pos;
        }

    }
}
