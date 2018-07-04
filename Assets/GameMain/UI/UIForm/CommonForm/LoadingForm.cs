using FairyGUI;
using GameFramework;
using GameFramework.Event;

namespace GameMain
{
    public class LoadingForm : FairyGuiForm
    {
        private GProgressBar m_LoadingBar = null;
        private GTextField m_TipsText = null;
        private GTextField m_LoadInfoText = null;
        private Controller m_BgCtrl = null;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            m_LoadingBar = UI.GetChild("prg_loding").asProgress;
            m_TipsText = UI.GetChild("tf_tips").asTextField;
            m_LoadInfoText = UI.GetChild("tf_loadInfo").asTextField;
            m_BgCtrl = UI.GetController("bgCtrl");
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            GameEntry.Event.Subscribe(LoadingFormUpdateProgressEventArgs.EventId, OnProgressUpdate);
           
            int sceneId  = 0;
            try
            {
                sceneId = (int)userData;
            }
            catch
            {
                Log.Warning("LoadingFormParams is invalid.");
                return;
            }
            int index = 0;
            if (sceneId < 6 && sceneId > 0)
                index = sceneId - 1;
            m_BgCtrl.selectedIndex = index;
        }

        protected override void OnClose(object userData)
        {
            base.OnClose(userData);

            m_BgCtrl.selectedIndex = 0;
            m_TipsText.text = string.Empty;
            m_LoadInfoText.text = string.Empty;
            m_LoadingBar.value = 0;

            GameEntry.Event.Unsubscribe(LoadingFormUpdateProgressEventArgs.EventId, OnProgressUpdate);
        }

        public void OnProgressUpdate(object sender, GameEventArgs e)
        {
            LoadingFormUpdateProgressEventArgs ne = (LoadingFormUpdateProgressEventArgs)e;
            m_LoadingBar.value = ne.Progress;
            m_LoadInfoText.text = ne.Description;
        }

        public void SetProgress(float progress, string description)
        {
            m_LoadingBar.value = progress;
            m_TipsText.text = description;
        }

    }
}
