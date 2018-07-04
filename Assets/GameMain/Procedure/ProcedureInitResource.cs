using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using GameFramework;
using UnityGameFramework.Runtime;
using GameFramework.Event;
using System;

namespace GameMain.Procedure
{
    public class ProcedureInitResource : ProcedureBase
    {
        private bool m_InitResourceComplete = false;

        public override bool UseNativeDialog
        {
            get { return true; }
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            m_InitResourceComplete = false;

            GameEntry.Event.Subscribe(ResourceInitCompleteEventArgs.EventId,OnResourceInitComplete);

            GameEntry.Resource.InitResources();
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (!m_InitResourceComplete)
            {
                return;
            }

            ChangeState<ProcedurePreload>(procedureOwner);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            GameEntry.Event.Unsubscribe(ResourceInitCompleteEventArgs.EventId, OnResourceInitComplete);
        }

        private void OnResourceInitComplete(object sender, GameEventArgs e)
        {
            m_InitResourceComplete = true;
            Log.Info("Init Resources success.");
        }



    }
}
