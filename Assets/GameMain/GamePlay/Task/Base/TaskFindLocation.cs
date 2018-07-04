using System;
using UnityEngine;

namespace GameMain
{
    public class TaskFindLocation : ITask
    {
        private TaskLocation mLocation;
        private Action mOnFinish;
        private Action mOnLoadSceneCallback;

        public TaskFindLocation()
        {
            //TODO
           // ZTEvent.AddHandler(EventID.STOP_AUTOTASK, Stop);
        }

        public void Init(TaskLocation pLocation, Action callback)
        {
            Reset();
            mLocation = pLocation;
            mOnFinish = callback;
            Start();
        }

        public void Reset()
        {
            mOnFinish = null;
           // ZTLevel.Instance.UnRegisterLoadSceneCallback(mOnLoadSceneCallback);
        }

        public void Start()
        {
            if (mLocation.MapID == (int)GameEntry.Level.CurSceneId)
            {
                GameEntry.Level.PlayerActor.ExecuteCommand(new AutoMoveCommand(mLocation.Pos, mOnFinish));
                return;
            }

            Vector3 pPortalPos = Vector3.zero;
            //bool success = GameEntry.Level.GetPortalByDestMapID(mLocation.MapID, ref pPortalPos);
            //if (success == false)
            //{
            //    Finish();
            //    //ZTItemHelper.ShowTip("200007");
            //    return;
            //}

            GameEntry.Level.PlayerActor.ExecuteCommand(new AutoMoveCommand(pPortalPos, null));
            mOnLoadSceneCallback = delegate
            {
                GameEntry.Level.PlayerActor.ExecuteCommand(new AutoMoveCommand(mLocation.Pos, mOnFinish));
                //ZTLevel.Instance.RegisterLoadSceneCallback(mOnLoadSceneCallback);
            };
        }

        public void Execute()
        {

        }

        public void Stop()
        {

        }

        public void Finish()
        {
            Reset();
        }

        public void Clear()
        {
            //ZTLevel.Instance.UnRegisterLoadSceneCallback(mOnLoadSceneCallback);
            //ZTEvent.RemoveHandler(EventID.STOP_AUTOTASK, Stop);
        }

    }
}
