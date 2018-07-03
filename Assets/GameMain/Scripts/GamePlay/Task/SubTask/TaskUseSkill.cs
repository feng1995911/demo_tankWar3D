namespace GameMain
{

    public class TaskUseSkill : TaskBase<SubUseSkill>
    {
        private int mCurTimes = 0;

        public override void Accept(SubUseSkill pData, int pTaskID, int pStep)
        {
            base.Accept(pData, pTaskID, pStep);
            //TODO:
            //ZTEvent.AddHandler<ESkillPos>(EventID.REQ_CAST_SKILL, OnUseSkill);
        }

        private void OnUseSkill(SkillPosType pos)
        {
            if (Data.Pos == pos)
            {
                mCurTimes++;
            }
            if (mCurTimes >= Data.Times)
            {
                Finish();
            }
        }

        public override void Start()
        {

        }

        public override void Execute()
        {

        }

        public override void Finish()
        {
            base.Finish();
            //ZTEvent.RemoveHandler<ESkillPos>(EventID.REQ_CAST_SKILL, OnUseSkill);
        }

        public override void Reset()
        {
            mCurTimes = 0;
        }

        public override void Stop()
        {

        }
    }
}