using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FairyGUI;
using GameFramework;

namespace GameMain
{
    public class LevelResultForm : FairyGuiForm
    {
        private Controller m_Ctrl;
        private ThreeStar m_Star;
        private GTextField m_Gold;
        private GTextField m_Exp;
        private GButton m_ExitButton;

        private LevelResultFormData m_Data;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            m_Ctrl = UI.GetController("c1");
            m_Star = UI.GetChild("Star") as ThreeStar;
            m_Gold = UI.GetChild("tf_Gold").asTextField;
            m_Exp = UI.GetChild("tf_Exp").asTextField;
            m_ExitButton = UI.GetChild("btn_Exit").asButton;

            m_ExitButton.onClick.Add(() =>
            {
                BackCityEventArgs eventArgs = new BackCityEventArgs();
                GameEntry.Event.Fire(this, eventArgs);

                GameEntry.UI.CloseUIForm(UIFormId.LevelResultForm);
            });
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            m_Data = userData as LevelResultFormData;
            if(m_Data == null)
                return;

            m_Ctrl.selectedIndex = m_Data.Victory ? 0 : 1;
            m_Star.SetStar(m_Data.StarCount);
            m_Gold.text = m_Data.GlodAward.ToString();
            m_Exp.text = m_Data.ExpAward.ToString();
        }

        protected override void OnClose(object userData)
        {
            base.OnClose(userData);

            m_ExitButton.onClick.Clear();
        }

    }
}
