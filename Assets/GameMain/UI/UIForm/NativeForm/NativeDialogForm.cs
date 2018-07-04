using GameFramework;
using UnityEngine;
using UnityEngine.UI;

namespace GameMain
{
    public class NativeDialogForm :MonoBehaviour
    {
        [SerializeField]
        private Text m_TitleText = null;
        [SerializeField]
        private Text m_MessageText = null;
        [SerializeField]
        private Button m_Button01 = null;
        [SerializeField]
        private Button m_Button02 = null;
        [SerializeField]
        private Button m_Button03 = null;

        private Button m_ConfirmButton = null;
        private Button m_CancelButton = null;
        private Button m_OtherButton = null;
        private Text m_ConfirmText = null;
        private Text m_CancelText = null;
        private Text m_OtherText = null;

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
            CloseDialog();

            if (m_OnClickConfirm != null)
            {
                m_OnClickConfirm(m_UserData);
            }
        }

        public void OnCancelButtonClick()
        {
            CloseDialog();

            if (m_OnClickCancel != null)
            {
                m_OnClickCancel(m_UserData);
            }
        }

        public void OnOtherButtonClick()
        {
            CloseDialog();

            if (m_OnClickOther != null)
            {
                m_OnClickOther(m_UserData);
            }
        }

        public void OpenDialog(DialogFormData data)
        {
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
                m_ConfirmButton.onClick.AddListener(OnConfirmButtonClick);
            }

            if (m_CancelButton != null)
            {
                RefreshCancelText(data.CancelText);
                m_OnClickCancel = data.OnClickCancel;
                m_CancelButton.onClick.AddListener(OnCancelButtonClick);
            }

            if (m_OtherButton != null)
            {
                RefreshOtherText(data.OtherText);
                m_OnClickOther = data.OnClickOther;
                m_OtherButton.onClick.AddListener(OnOtherButtonClick);
            }
        }

        public void CloseDialog()
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

            m_Button01.onClick.RemoveAllListeners();
            m_Button02.onClick.RemoveAllListeners();
            m_Button03.onClick.RemoveAllListeners();

            RefreshConfirmText(string.Empty);
            m_OnClickConfirm = null;
            m_ConfirmButton = null;
            m_ConfirmText = null;

            RefreshCancelText(string.Empty);
            m_OnClickCancel = null;
            m_CancelButton = null;
            m_CancelText = null;

            RefreshOtherText(string.Empty);
            m_OnClickOther = null;
            m_OtherButton = null;
            m_OtherText = null;
        }

        private void RefreshDialogMode()
        {
            switch (m_DialogMode)
            {
                case 1:
                    {
                        m_ConfirmButton = m_Button02;
                        m_ConfirmText = m_ConfirmButton.transform.GetChild(0).GetComponent<Text>();
                    }
                    break;
                case 2:
                    {
                        m_ConfirmButton = m_Button01;
                        m_CancelButton = m_Button03;
                        m_ConfirmText = m_ConfirmButton.transform.GetChild(0).GetComponent<Text>();
                        m_CancelText = m_CancelButton.transform.GetChild(0).GetComponent<Text>();
                    }
                    break;
                case 3:
                    {
                        m_ConfirmButton = m_Button01;
                        m_CancelButton = m_Button02;
                        m_OtherButton = m_Button03;
                        m_ConfirmText = m_ConfirmButton.transform.GetChild(0).GetComponent<Text>();
                        m_CancelText = m_CancelButton.transform.GetChild(0).GetComponent<Text>();
                        m_OtherText = m_OtherButton.transform.GetChild(0).GetComponent<Text>();
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

            m_ConfirmText.text = confirmText;
        }

        private void RefreshCancelText(string cancelText)
        {
            if (string.IsNullOrEmpty(cancelText))
            {
                cancelText = GameEntry.Localization.GetString("Dialog.CancelButton");
            }

            m_CancelText.text = cancelText;
        }

        private void RefreshOtherText(string otherText)
        {
            if (string.IsNullOrEmpty(otherText))
            {
                otherText = GameEntry.Localization.GetString("Dialog.OtherButton");
            }

            m_OtherText.text = otherText;
        }

    }
}
