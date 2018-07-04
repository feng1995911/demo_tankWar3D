using FairyGUI;
using GameFramework;

namespace GameMain
{
    public class DialogForm : FairyGuiForm
    {
        private Controller m_ModeController = null;
        private GTextField m_TitleText = null;
        private GTextField m_MessageText = null;
        private GButton m_Button01 = null;
        private GButton m_Button02 = null;
        private GButton m_Button03 = null;

        private GButton m_ConfirmButton = null;
        private GButton m_CancelButton = null;
        private GButton m_OtherButton = null;

        private int m_DialogMode = 1;
        private bool m_PauseGame = false;
        private object m_UserData = null;
        private GameFrameworkAction<object> m_OnClickConfirm = null;
        private GameFrameworkAction<object> m_OnClickCancel = null;
        private GameFrameworkAction<object> m_OnClickOther = null;

        public int DialogMode
        {
            get
            {
                return m_DialogMode;
            }
        }

        public bool PauseGame
        {
            get
            {
                return m_PauseGame;
            }
        }

        public object UserData
        {
            get
            {
                return m_UserData;
            }
        }


        public void OnConfirmButtonClick()
        {
            Close();

            if (m_OnClickConfirm != null)
            {
                m_OnClickConfirm(m_UserData);
            }
        }

        public void OnCancelButtonClick()
        {
            Close();

            if (m_OnClickCancel != null)
            {
                m_OnClickCancel(m_UserData);
            }
        }

        public void OnOtherButtonClick()
        {
            Close();

            if (m_OnClickOther != null)
            {
                m_OnClickOther(m_UserData);
            }
        }

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
          
            m_ModeController = UI.GetController("dialogMode");
            m_TitleText = UI.GetChild("frame/title").asTextField;
            m_MessageText = UI.GetChild("message").asTextField;
            m_Button01 = UI.GetChild("btn_01").asButton;
            m_Button02 = UI.GetChild("btn_02").asButton;
            m_Button03 = UI.GetChild("btn_03").asButton;
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            DialogFormData data = (DialogFormData)userData;
            if (data == null)
            {
                Log.Warning("DialogFormParams is invalid.");
                return;
            }

            m_DialogMode = data.Mode;
            RefreshDialogMode();

            m_TitleText.text = data.Title;
            m_MessageText.text = data.Message;

            m_PauseGame = data.PauseGame;
            RefreshPauseGame();

            m_UserData = data.UserData;

            if (m_ConfirmButton != null)
            {
                RefreshConfirmText(data.ConfirmText);
                m_OnClickConfirm = data.OnClickConfirm;
                m_ConfirmButton.onClick.Add(OnConfirmButtonClick);
            }

            if (m_CancelButton != null)
            {
                RefreshCancelText(data.CancelText);
                m_OnClickCancel = data.OnClickCancel;
                m_CancelButton.onClick.Add(OnCancelButtonClick);
            }

            if (m_OtherButton != null)
            {
                RefreshOtherText(data.OtherText);
                m_OnClickOther = data.OnClickOther;
                m_OtherButton.onClick.Add(OnOtherButtonClick);
            }
        }

        protected override void OnClose(object userData)
        {
            if (m_PauseGame)
            {
                GameEntry.Base.ResumeGame();
            }

            m_DialogMode = 1;
            m_TitleText.text = string.Empty;
            m_MessageText.text = string.Empty;
            m_PauseGame = false;
            m_UserData = null;

            m_Button01.onClick.Clear();
            m_Button02.onClick.Clear();
            m_Button03.onClick.Clear();

            RefreshConfirmText(string.Empty);
            m_OnClickConfirm = null;
            m_ConfirmButton = null;

            RefreshCancelText(string.Empty);
            m_OnClickCancel = null;
            m_CancelButton = null;

            RefreshOtherText(string.Empty);
            m_OnClickOther = null;
            m_OtherButton = null;

            base.OnClose(userData);
        }

        private void RefreshDialogMode()
        {
            m_ModeController.selectedIndex = m_DialogMode;
            switch (m_DialogMode)
            {
                case 1:
                {
                    m_ConfirmButton = m_Button02;
                }
                    break;
                case 2:
                {
                    m_ConfirmButton = m_Button01;
                    m_CancelButton = m_Button03;
                }
                    break;
                case 3:
                {
                    m_ConfirmButton = m_Button01;
                    m_CancelButton = m_Button02;
                    m_OtherButton = m_Button03;
                }
                    break;
            }
        }

        private void RefreshPauseGame()
        {
            if (m_PauseGame)
            {
                GameEntry.Base.PauseGame();
            }
        }

        private void RefreshConfirmText(string confirmText)
        {
            if (string.IsNullOrEmpty(confirmText))
            {
                confirmText = GameEntry.Localization.GetString("Dialog.ConfirmButton");
            }

            m_ConfirmButton.title = confirmText;
        }

        private void RefreshCancelText(string cancelText)
        {
            if (string.IsNullOrEmpty(cancelText))
            {
                cancelText = GameEntry.Localization.GetString("Dialog.CancelButton");
            }

            m_CancelButton.title = cancelText;
        }

        private void RefreshOtherText(string otherText)
        {
            if (string.IsNullOrEmpty(otherText))
            {
                otherText = GameEntry.Localization.GetString("Dialog.OtherButton");
            }

            m_OtherButton.title = otherText;
        }

    }
}
