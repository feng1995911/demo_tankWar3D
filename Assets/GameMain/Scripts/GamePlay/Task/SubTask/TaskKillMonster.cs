using System;

namespace GameMain
{
    public class TaskKillMonster : TaskBase<SubKillMonster>
    {
        private int mCurCount = 0;

        public override void Accept(SubKillMonster pData, int pTaskID, int pStep)
        {
            base.Accept(pData, pTaskID, pStep);
            //TODO:
         //   ZTEvent.AddHandler<int, int>(EventID.RECV_KILL_MONSTER, OnKillMonster);
        }

        private void OnKillMonster(int guid, int id)
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
            Action pAutoAttack = delegate () { };//TODO:
            TaskManager.Instance.CurFindLocation.Init(Data.Location, pAutoAttack);
        }

        public override void Execute()
        {

        }

        public override void Finish()
        {
            base.Finish();
           // ZTEvent.RemoveHandler<int, int>(EventID.RECV_KILL_MONSTER, OnKillMonster);
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