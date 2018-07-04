using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FairyGUI;
using GameFramework;
using GameFramework.Event;
using UnityEngine;

namespace GameMain
{
    public class ComboForm : FairyGuiForm
    {
        private GTextField m_Combo;
        private Transition m_Transition;

        private float m_ValidTime = 4;
        private float m_Timer = 0;
        private int m_ComboCount = 0;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            m_Combo = UI.GetChild("tf_Combo").asTextField;

            m_Transition = UI.GetTransition("t0");

            Hide();
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            GameEntry.Event.Subscribe(OnPlayerAttackEventArgs.EventId,OnPlayerAttack);
        }


        protected override void OnClose(object userData)
        {
            base.OnClose(userData);

            GameEntry.Event.Unsubscribe(OnPlayerAttackEventArgs.EventId, OnPlayerAttack);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            if (m_Timer > m_ValidTime)
            {
                Hide();
            }
            m_Timer += elapseSeconds;       
        }

        private void OnPlayerAttack(object sender, GameEventArgs e)
        {
            OnPlayerAttackEventArgs ne = e as OnPlayerAttackEventArgs;
            if (ne == null)
            {
                return;
            }

            Vector3 wordPos = ne.Target.CachedTransform.position + new Vector3(0, ne.Target.Height, 0);
            Vector2 screenPos = GameEntry.Camera.MainCamera.WorldToScreenPoint(wordPos);

            screenPos.y = Screen.height - screenPos.y;
            Vector2 pt = GRoot.inst.GlobalToLocal(screenPos);
            UI.SetXY(pt.x - 100, pt.y);

            Refresh();
            m_Timer = 0;
        }

        private void Refresh()
        {
            this.UI.visible = true;
            m_ComboCount++;
            m_Combo.text = m_ComboCount.ToString();
            m_Transition.Play();
        }

        private void Hide()
        {
            this.UI.visible = false;
            m_ComboCount = 0;
            m_Timer = 0;
        }

    }
}
