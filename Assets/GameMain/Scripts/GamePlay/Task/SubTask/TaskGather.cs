namespace GameMain
{
    /// <summary>
    /// 采集任务
    /// </summary>
    public class TaskGather : TaskBase<SubGather>
    {
        private int mCurCount = 0;

        public override void Accept(SubGather pData, int pTaskID, int pStep)
        {
            base.Accept(pData, pTaskID, pStep);
            //TODO: 当采集到矿石
            //ZTEvent.AddHandler<int, int, int>(EventID.RECV_GATHER_MINE, OnRecvGatherMine);
        }

        private void OnRecvGatherMine(int guid, int id, int count)
        {
            if (id == Data.ID)
            {
                mCurCount++;
            }
            if (mCurCount >= Data.Count)
            {
                Finish();
            }
        }

        public override void Start()
        {
            //TODO: 当采集到矿石
            //  ZTTask.Instance.CurFindLocation.Init(Data.Location, OnFinishPathFind);
        }

        private void OnFinishPathFind()
        {

        }

        public override void Execute()
        {

        }

        public override void Finish()
        {
            base.Finish();
            //TODO: 当采集到矿石
            // ZTEvent.RemoveHandler<int, int, int>(EventID.RECV_GATHER_MINE, OnRecvGatherMine);
        }

        public override void Reset()
        {
            mCurCount = 0;
        }

        public override void Stop()
        {

        }
    }
}