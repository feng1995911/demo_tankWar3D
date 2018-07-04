using System;
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMain
{
    public class ProcedureLogin : ProcedureBase
    {
        public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }

        private ProcedureOwner m_ProcedureOwner;

        private bool m_LoginSuccess = false;
        private bool m_GetPlayerSuccess = false;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            m_ProcedureOwner = procedureOwner;

            LoginFormData data = new LoginFormData();
            data.Version = GameEntry.Base.GameVersion;
            data.OnClickLogin = OnLoginClick;
            data.OnClickRegister = OnRegisterClick;
            GameEntry.UI.OpenUIForm(UIFormId.LoginForm, data);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (m_LoginSuccess)
            {
                if (m_GetPlayerSuccess)
                {
                    procedureOwner.SetData<VarInt>(Constant.ProcedureData.NextSceneId, (int)SceneId.MainCity);
                    ChangeState<ProcedureChangeScene>(procedureOwner);
                }
                else
                {
                    procedureOwner.SetData<VarInt>(Constant.ProcedureData.NextSceneId, (int)SceneId.CreateRole);
                    ChangeState<ProcedureChangeScene>(procedureOwner);
                }
            }

        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
            GameEntry.UI.CloseUIForm(UIFormId.LoginForm);
        }

        private bool OnLoginClick(string accountInput,string passwordInput)
        {
            int account;
            int password;

            if (!int.TryParse(accountInput, out account))
            {
                //Log.Error("Account must be number！");
                return false;
            }

            if (!int.TryParse(passwordInput, out password))
            {
                //Log.Error("Password must be number！");
                return false;
            }

            if (GameEntry.Database.TryLogin(account, password))
            {
                m_ProcedureOwner.SetData<VarInt>(Constant.ProcedureData.UserId, account);
                m_LoginSuccess = true;

                IDBTable<DBUser> dtUser = GameEntry.Database.GetDBTable<DBUser>();
                DBUser drUser = dtUser.GetDBRow(account);
                if (drUser == null || drUser.Player == 0)
                {
                    m_GetPlayerSuccess = false;
                }
                else
                {
                    m_ProcedureOwner.SetData<VarInt>(Constant.ProcedureData.PlayerId, drUser.Player);
                    m_GetPlayerSuccess = true;
                }

                return true;
            }
            else
            {
                //Log.Error("账号密码不存在！");
                return false;
            }
        }

        private bool OnRegisterClick(string account, string password,Action callback)
        {
            int pAccount = 0;
            int pPassword = 0;

            if (!int.TryParse(account,out pAccount))
            {
                //Log.Error("Account is invalid.");
                return false;
            }

            if (!int.TryParse(password, out pPassword))
            {
                //Log.Error("Password is invalid.");
                return false;
            }

            if (GameEntry.Database.TryRegister(pAccount, pPassword))
            {
                callback?.Invoke();
                return true;
            }
            else
            {
                Log.Error("账号已存在！");
                return false;
            }
            
        }

    }
}
