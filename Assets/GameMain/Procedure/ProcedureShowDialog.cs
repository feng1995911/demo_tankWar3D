using GameFramework;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using UnityGameFramework.Runtime;
using GameFramework.Event;

namespace GameMain
{
    public class ProcedureShowDialog : ProcedureBase
    {
        public override bool UseNativeDialog
        {
            get { return false; }
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);            

            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

            DialogFormData parms = new DialogFormData();
            parms.Title = "Title";
            parms.Message = "是否退出游戏？";
            parms.Mode = 3;
            parms.ConfirmText = "Confirm";
            parms.CancelText = "Cancel";
            parms.OtherText = "Other";
            parms.OnClickConfirm += o => { Log.Debug("确定"); };
            parms.OnClickCancel += o => { GameEntry.UI.CloseUIForm(UIFormId.DialogForm); };
            parms.OnClickOther += o => { Log.Debug("其他"); };

            GameEntry.UI.OpenUIForm(UIFormId.DialogForm, parms);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

            //GameMainEntry.UI.CloseUIForm(UIFormId.DialogForm);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        }

        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            //Debug.Log(e.ToString());
        }

    }
}
