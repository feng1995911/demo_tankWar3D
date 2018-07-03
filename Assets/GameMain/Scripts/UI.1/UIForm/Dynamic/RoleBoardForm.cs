using FairyGUI;
using GameFramework;
using GameFramework.Event;
using UnityEngine;

namespace GameMain
{
    public class RoleBoardForm : FairyGuiForm
    {
        protected bool m_NeedUpdate = true;
        protected float m_Height = 0;
        protected Transform m_Target;
        protected BoardFormData m_Data;

        protected GProgressBar m_HpBar;
        protected GTextField m_BarText;
        protected GTextField m_Name;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            m_HpBar = UI.GetChild("bar_Hp").asProgress;
            m_BarText = m_HpBar.GetChild("title").asTextField;
            m_Name = UI.GetChild("tf_Name").asTextField;
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            m_Data = userData as BoardFormData;
            if (m_Data == null)
            {
                Log.Error("Open Board fail");
                return;
            }

            SetTarget(m_Data.CacheTransform);
            m_Height = m_Data.Height + 0.3f;

            if (m_Data.ActorType == ActorType.Player)
            {
                m_Name.color = Color.green;
                m_HpBar.visible = false;
            }
            else if (m_Data.ActorType == ActorType.Monster)
            {
                m_Name.color = Color.red;
                m_HpBar.visible = true;
            }
            else
            {
                m_Name.color = Color.blue;
                m_HpBar.visible = false;
            }

            m_Name.text = GlobalTools.Format("Lv.{0} {1}", m_Data.Level, m_Data.Name);         
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            if(m_NeedUpdate == false || m_Target == null)
                return;

            UpdatePosition(m_Target);
        }

        public void SetTarget(Transform target)
        {
            m_Target = target;
        }

        public void SetVisbale(bool visibe)
        {
            UI.visible = visibe;
        }

        public void UpdatePosition(Transform target)
        {
            if (GameEntry.Scene.MainCamera == null )
            {
                return;
            }

            Vector3 wordPos = target.position + new Vector3(0, m_Height, 0);
            Vector2 screenPos = GameEntry.Camera.MainCamera.WorldToScreenPoint(wordPos);

            //FairyGui 的坐标系与unity相反，需要转换      
            screenPos.y = Screen.height - screenPos.y;
            Vector2 pt = GRoot.inst.GlobalToLocal(screenPos);
            //UI.SetXY(pt.x - GRoot.inst.width/2, pt.y - GRoot.inst.height);
            UI.SetXY(pt.x - 100, pt.y);
        }

        public void Refresh(int curHp,int maxHp,int level)
        {
            if (maxHp == 0)
                return;

            m_HpBar.value = 100*(float) curHp/maxHp;
            m_Name.text = GlobalTools.Format("Lv.{0} {1}", level, m_Data.Name);            
            m_BarText.text = GlobalTools.Format("{0}/{1}", curHp, maxHp);
        }

    }
}
