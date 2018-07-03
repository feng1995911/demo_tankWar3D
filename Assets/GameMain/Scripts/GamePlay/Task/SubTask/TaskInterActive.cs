using UnityEngine;

namespace GameMain
{

    public class TaskInterActive : TaskBase<SubInterActive>
    {
        private float mProgress = -1;
        private float mSpeed = 1;

        public override void Accept(SubInterActive pData, int pTaskID, int pStep)
        {
            base.Accept(pData, pTaskID, pStep);
        }

        public override void Start()
        {
           // ZTTask.Instance.CurFindLocation.Init(Data.Npc.Location, OnFinishPathFind);
        }

        private void OnFinishPathFind()
        {
            //ZTUIManager.Instance.OpenWindow(WindowID.UI_TASKINTERACTIVE);
            //UITaskInterActive pWindow = (UITaskInterActive)ZTUIManager.Instance.GetWindow(WindowID.UI_TASKINTERACTIVE);
            //pWindow.Init(Data.Desc, DoCmd);
        }

        private void DoCmd()
        {
            if (mProgress < 0)
            {
                mProgress = 0;
                float length = GameEntry.Level.PlayerActor.GetAnimController().GetAnimLength(Data.Cmd);   
                if (length == 0)
                {
                    length = 1;
                }
                mSpeed = 1 * Time.deltaTime / length;
            }
        }

        public override void Execute()
        {
            if (mProgress < 0)
            {
                return;
            }
            if (mProgress < 1)
            {
                mProgress += mSpeed;
                //TODO:
                //UITaskInterActive pWindow = (UITaskInterActive)ZTUIManager.Instance.GetWindow(WindowID.UI_TASKINTERACTIVE);
                //pWindow.UpdateProgress(mProgress);
            }
            else
            {
                Finish();
            }

        }

        public override void Finish()
        {
            base.Finish();
            //TODO:
            //ZTUIManager.Instance.GetWindow(WindowID.UI_TASKINTERACTIVE).Hide();
        }

        public override void Reset()
        {
            mProgress = -1;
        }

        public override void Stop()
        {
            mProgress = -1;
        }
    }
}