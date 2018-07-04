using System;
using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace GameMain
{
    public class SkillButton : GButton
    {
        private GTextField m_Title = null;
        private GLoader m_Icon = null;
        private GImage m_Normal = null;
        private GImage m_Skill = null;
        private GImage m_Mask = null;

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);
            m_Title = GetChild("title").asTextField;
            m_Icon = GetChild("icon").asLoader;
            m_Normal = GetChild("normal").asImage;
            m_Skill = GetChild("skill").asImage;
            m_Mask = GetChild("mask").asImage;

            m_Title.visible = false;
            m_Mask.visible = false;
            m_Icon.texture = null;
        }

        public void ShowSkill(SkillTree skill)
        {
            if (skill.Pos == SkillPosType.Skill_0)
            {
                m_Normal.visible = true;
                m_Skill.visible = false;
            }
            else
            {
                m_Normal.visible = false;
                m_Skill.visible = true;
            }

            string iconPath = AssetUtility.GetSkillIconAsset(skill.Id);
            if (m_Icon.url != iconPath)
            {
                m_Icon.url = iconPath;
            }

            if (Math.Abs(skill.GetLeftTime()) < float.Epsilon)
            {
                m_Title.visible = false;
                m_Mask.visible = false;
            }
            else
            {
                m_Title.visible = true;
                m_Mask.visible = true;
                m_Title.text = GlobalTools.Format("{0}{1}", skill.GetLeftTime().ToString("F1"), "s");
                m_Mask.fillAmount = skill.GetLeftTime()/skill.CD;
            }
        }

        public void HideSkill()
        {
            if (m_Icon.texture != null)
            {
                //Resources.UnloadAsset(m_Icon.texture.nativeTexture);
                m_Icon.texture = null;
            }
        }

    }
}
