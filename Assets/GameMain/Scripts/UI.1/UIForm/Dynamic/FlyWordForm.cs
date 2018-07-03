using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FairyGUI;
using GameFramework;
using UnityEngine;

namespace GameMain
{
    public class FlyWordForm : FairyGuiForm
    {
        private Controller m_Ctrl;
        private GTextField m_Normal;
        private GTextField m_Crit;
        private Transition m_Transition;
        private FlyWordData m_Data;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            m_Ctrl = UI.GetController("hurtTypeCtrl");
            m_Normal = UI.GetChild("tf_Normal").asTextField;
            m_Crit = UI.GetChild("tf_Crit").asTextField;
            m_Transition = UI.GetTransition("t1");
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            m_Data = userData as FlyWordData;
            if (m_Data == null)
            {
                Log.Error("userData is invlid.");
                return;
            }

            switch (m_Data.Type)
            {
                case FlyWordType.NormalHurt:
                    m_Ctrl.selectedIndex = 0;
                    m_Normal.text = GlobalTools.Format("-{0}", m_Data.Value);
                    m_Normal.color = Color.red;
                    break;
                case FlyWordType.CritHurt:
                    m_Ctrl.selectedIndex = 3;
                    m_Crit.text = GlobalTools.Format("-{0}", m_Data.Value);
                    m_Crit.color = Color.yellow;
                    break;
                case FlyWordType.HpHeal:
                    m_Ctrl.selectedIndex = 0;
                    m_Normal.text = GlobalTools.Format("+{0}", m_Data.Value);
                    m_Normal.color = Color.green;
                    break;
                case FlyWordType.MpHeal:
                    m_Ctrl.selectedIndex = 0;
                    m_Normal.text = GlobalTools.Format("+{0}", m_Data.Value);
                    m_Normal.color = Color.blue;
                    break;
                case FlyWordType.Miss:
                    m_Ctrl.selectedIndex = 1;
                    break;
                case FlyWordType.Parry:
                    m_Ctrl.selectedIndex = 2;
                    break;
            }

            m_Transition.Stop();

            if (UI != null && UI.visible)
                m_Transition.Play();
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            if(m_Data?.Target == null)
                return;

            Vector3 wordPos = m_Data.Target.position + new Vector3(0, m_Data.Height/2, 0);
            Vector2 screenPos = GameEntry.Camera.MainCamera.WorldToScreenPoint(wordPos);
  
            screenPos.y = Screen.height - screenPos.y;
            Vector2 pt = GRoot.inst.GlobalToLocal(screenPos);
            UI.SetXY(pt.x - 100, pt.y);
        }

    }
}
