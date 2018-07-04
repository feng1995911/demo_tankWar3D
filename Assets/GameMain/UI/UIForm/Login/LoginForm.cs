using System.Text.RegularExpressions;
using FairyGUI;
using GameFramework;

namespace GameMain
{
    public class LoginForm : FairyGuiForm
    {
        private GTextField m_VersionText = null;
        private GButton m_NoticeButton = null;
        private GButton m_AccountButton = null;
        private GComponent m_NoticePanel = null;
        private GComponent m_LoginPanel = null;
        private GComponent m_RegisterPanel = null;
        private GTextInput m_LoginAccountInput = null;
        private GTextInput m_LoginPasswordInput = null;
        private GTextInput m_RegisterAccountInput = null;
        private GTextInput m_RegisterPasswordInput = null;
        private GButton m_AccountRegisterButton = null;
        private GButton m_RegisterButton = null;
        private GButton m_LoginButton = null;

        private LoginFormData m_Params;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            m_VersionText = UI.GetChild("tf_Version").asTextField;
            m_NoticeButton = UI.GetChild("btn_Notice").asButton;
            m_AccountButton = UI.GetChild("btn_Account").asButton;
            m_NoticePanel = UI.GetChild("notice").asCom;
            m_LoginPanel = UI.GetChild("login").asCom;
            m_RegisterPanel = UI.GetChild("register").asCom;
            m_LoginAccountInput = m_LoginPanel.GetChild("ipt_account").asTextInput;
            m_LoginPasswordInput = m_LoginPanel.GetChild("ipt_password").asTextInput;
            m_RegisterAccountInput = m_RegisterPanel.GetChild("ipt_account").asTextInput;
            m_RegisterPasswordInput = m_RegisterPanel.GetChild("ipt_password").asTextInput;
            m_AccountRegisterButton = m_RegisterPanel.GetChild("btn_register").asButton;
            m_RegisterButton = m_LoginPanel.GetChild("btn_rigister").asButton;
            m_LoginButton = m_LoginPanel.GetChild("btn_login").asButton;

            m_NoticePanel.visible = false;
            m_LoginPanel.visible = false;
            m_RegisterPanel.visible = false;
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            m_Params = (LoginFormData)userData;
            if (m_Params == null)
            {
                Log.Warning("LoginFormParams is invalid.");
                return;
            }

            m_VersionText.text = m_Params.Version;
            m_NoticeButton.onClick.Add(() =>
            {
                m_NoticePanel.visible = !m_NoticePanel.visible;
            });
            m_AccountButton.onClick.Add(() =>
            {
                m_LoginPanel.visible = !m_LoginPanel.visible;
            });
            m_RegisterButton.onClick.Add(() =>
            {
                m_RegisterPanel.visible = true; 
            });
            m_LoginButton.onClick.Add(OnLoginClick);
            m_AccountButton.onClick.Add(OnRegisterClick);
        }

        protected override void OnClose(object userData)
        {
            base.OnClose(userData);

            m_VersionText.text = string.Empty;
            m_NoticeButton.onClick.Clear();
            m_AccountButton.onClick.Clear();
            m_RegisterButton.onClick.Clear();
            m_LoginButton.onClick.Clear();
            m_RegisterButton.onClick.Clear();
        }

        private void OnLoginClick()
        {
            string account = m_LoginAccountInput.text;
            string password = m_LoginPasswordInput.text;
            if (CheckInput(account) && CheckInput(password))
            {
                m_Params.OnClickLogin(account, password);
            }
        }

        private void OnRegisterClick()
        {
            string account = m_RegisterAccountInput.text;
            string password = m_RegisterPasswordInput.text;
            if (CheckInput(account) && CheckInput(password))
            {
                m_Params.OnClickRegister(account, password, () =>
                {
                    m_RegisterPanel.visible = false;
                });
            }
        }

        private bool CheckInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                Log.Error("账号密码不能为空！");
                return false;
            }

            if (input.Length > 6)
            {
                Log.Error("账号密码不能超出6位！");
                return false;
            }

            const string pattern = "^[0-9]*$";
            Regex rx = new Regex(pattern);
            if(rx.IsMatch(input))
            {
                return true;
            }
            else
            {
                Log.Error("账号密码只能是6位数字！");
                return false;
            }
        }
    }
}
