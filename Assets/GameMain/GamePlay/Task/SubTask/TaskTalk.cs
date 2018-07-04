using System;

namespace GameMain
{
    public class TaskTalk : TaskBase<SubTalk>
    {
        private Int32 mTalkIndex = -1;

        public override void Accept(SubTalk pData, int pTaskID, int pStep)
        {
            base.Accept(pData, pTaskID, pStep);
        }

        public override void Start()
        {
            State = SubTaskStateType.TYPE_ENTER;
            TaskManager.Instance.CurFindLocation.Init(Data.Npc.Location, OnFinishPathFind);
        }

        private void OnFinishPathFind()
        {
            //TODO
            //ZTUIManager.Instance.OpenWindow(WindowID.UI_TASKTALK);
            DoNextStep();
        }

        public override void Execute()
        {
            State = SubTaskStateType.TYPE_STEP;
        }

        public void DoNextStep()
        {
            if (mTalkIndex < Data.Dialogs.Count - 1)
            {
                mTalkIndex++;
                TaskDialog pDialog = Data.Dialogs[mTalkIndex];
               // ZTUIManager.Instance.GetWindow<UITaskTalk>(WindowID.UI_TASKTALK).ShowTalk(pDialog);
            }
            else
            {
                Finish();
            }
        }

        public override void Finish()
        {
            base.Finish();
            State = SubTaskStateType.TYPE_EXIT;
          //  ZTUIManager.Instance.GetWindow<UITaskTalk>(WindowID.UI_TASKTALK).Hide();
        }

        public override void Stop()
        {
            mTalkIndex = -1;
            State = SubTaskStateType.TYPE_STOP;
           // ZTUIManager.Instance.GetWindow<UITaskTalk>(WindowID.UI_TASKTALK).Hide();
        }

        public override void Reset()
        {

        }
    }
}