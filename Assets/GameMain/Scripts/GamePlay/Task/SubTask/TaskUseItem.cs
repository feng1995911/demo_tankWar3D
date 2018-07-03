namespace GameMain
{

    public class TaskUseItem : TaskBase<SubUseItem>
    {
        private int mCurTimes = 0;

        public override void Accept(SubUseItem pData, int pTaskID, int pStep)
        {
            base.Accept(pData, pTaskID, pStep);
            //TODO
            //ZTEvent.AddHandler<int, int>(EventID.RECV_USE_ITEM, OnUseItem);
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
            //TODO
            //ZTEvent.RemoveHandler<int, int>(EventID.RECV_USE_ITEM, OnUseItem);
        }

        public override void Reset()
        {
            mCurTimes = 0;
        }

        public override void Stop()
        {

        }

        private void OnUseItem(int id, int num)
        {
            if (id == Data.ID)
            {
                mCurTimes = mCurTimes + num;
            }
            if (mCurTimes >= Data.Times)
            {
                mCurTimes = Data.Times;
                Finish();
            }
        }
    }
}