using GameFramework;
using GameFramework.Fsm;

namespace GameMain
{
    public class ActorSkillFsm : ActorFsmStateBase
    {
        public ActorSkillFsm(ActorFsmStateType state) : base(state)
        {
        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            base.OnEnter(fsm);
            UseSkillCommand useSkillCommand = m_Command as UseSkillCommand;

            if (useSkillCommand == null)
            {
                Log.Error("UseSkillCommand convert failure.");
                return;
            }

            if (useSkillCommand.LastTime > 0)
            {
                GameEntry.Timer.Register(useSkillCommand.LastTime, Break);

            }
            m_Owner.ApplyRootMotion(false);
            m_Owner.OnUseSkill(useSkillCommand);
        }

        protected override void OnLeave(IFsm<ActorBase> fsm, bool isShutdown)
        {
            base.OnLeave(fsm, isShutdown);
            m_Owner.ApplyRootMotion(true);
        }
    }
}
