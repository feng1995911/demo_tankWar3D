using System;
using GameFramework;
using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMain
{
    /// <summary>
    /// 主城流程
    /// </summary>
    public class ProcedureMainCity : ProcedureBase
    {
        public override bool UseNativeDialog => false;

        private ProcedureOwner m_ProcedureOwner;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);

            m_ProcedureOwner = procedureOwner;


            GameEntry.Event.Subscribe(EnterLevelEventArgs.EventId, OnEnterLevel);

            int playerId = m_ProcedureOwner.GetData<VarInt>(Constant.ProcedureData.PlayerId);

            GameEntry.Level.EnterLevel(Constant.Define.MainCityLevelId, SceneId.MainCity, playerId);

            GameEntry.UI.OpenUIForm(UIFormId.ControllerForm);

            HomeFormData data = new HomeFormData();
            data.SceneType = SceneType.City;
            GameEntry.UI.OpenUIForm(UIFormId.HomeForm, data);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            GameEntry.UI.CloseUIForm(UIFormId.HomeForm);
            GameEntry.UI.CloseUIForm(UIFormId.ControllerForm);

            GameEntry.Event.Unsubscribe(EnterLevelEventArgs.EventId, OnEnterLevel);
        }

        private void OnEnterLevel(object sender, GameEventArgs e)
        {
            EnterLevelEventArgs ne = e as EnterLevelEventArgs;
            m_ProcedureOwner.SetData<VarInt>(Constant.ProcedureData.NextSceneId, (int) ne.SceneId);
            m_ProcedureOwner.SetData<VarInt>(Constant.ProcedureData.NextLevelId, ne.LevelId);

            GameEntry.Level.LeaveCurrentLevel();
            ChangeState<ProcedureChangeScene>(m_ProcedureOwner);
        }

     }
}
