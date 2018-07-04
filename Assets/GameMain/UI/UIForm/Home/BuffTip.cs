using FairyGUI;
using FairyGUI.Utils;
using GameFramework;
using UnityEngine;

namespace GameMain
{
    public class BuffTip : GComponent
    {
        private GImage m_Mask = null;
        private GLoader m_Icon = null;
        private GTextField m_Title = null;

        private BuffBase m_Buff = null;

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_Mask = GetChild("mask").asImage;
            m_Icon = GetChild("icon").asLoader;
            m_Title = GetChild("title").asTextField;

            HideBuff();
        }

        public void ShowBuff(BuffBase buff)
        {
            if (buff?.Data == null)
            {
                Log.Error("buff is invalid.");
                return;
            }
            if (m_Buff != null)
            {
                UpdateBuff();
                return;
            }

            m_Buff = buff;
            if (m_Buff.GetLeftTime() < float.Epsilon)
            {
                HideBuff();
                return;
            }

            if(m_Buff.Data.Icon == 0)
                return;

            this.visible = true;
            string iconPath = AssetUtility.GetBuffIconAsset(m_Buff.Data.Icon);
            m_Icon.url = iconPath;
            m_Title.text = GlobalTools.Format("{0}{1}", m_Buff.GetLeftTime().ToString("F1"), "s");
            m_Mask.fillAmount = m_Buff.GetLeftTime() / m_Buff.Data.LifeTime;
        }

        public void HideBuff()
        {
            m_Buff = null;
            this.visible = false;
            if (m_Icon.texture != null)
            {
                //GameEntry.Resource.UnloadAsset(m_Icon.texture);
                m_Icon.texture = null;
            }
        }

        private void UpdateBuff()
        {
            if(m_Buff == null)
                return;

            m_Title.text = m_Buff.GetLeftTime().ToString("F1");
            m_Mask.fillAmount = m_Buff.GetLeftTime() / m_Buff.Data.LifeTime;
        }


    }
}
