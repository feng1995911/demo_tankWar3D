using System;
using FairyGUI;
using GameFramework;
using GameFramework.Event;
using UnityEngine;

namespace GameMain
{
    public class HomeForm : FairyGuiForm
    {
        private Controller m_Ctrl = null;
        private GComponent m_HeadPanel = null;
        private GTextField m_Name = null;
        private GTextField m_Level = null;
        private GProgressBar m_Hp = null;
        private GProgressBar m_Mp = null;
        private GImage m_Exp = null;
        private BuffTip[] m_BuffItems = null;
        private SkillButton[] m_SkillItems = null;
        private SkillButton m_Skill01Button = null;
        private SkillButton m_Skill02Button = null;
        private SkillButton m_Skill03Button = null;
        private SkillButton m_Skill04Button = null;
        private SkillButton m_Skill05Button = null;

        private GButton m_RoleButton  = null;
        private GButton m_BagButton   = null;
        private GButton m_PartnerButton = null;
        private GButton m_TaskButton  = null;
        private GButton m_MountButton = null;
        private GButton m_AiButton    = null;

        private GImage m_AiAuto = null;
        private GImage m_AiHand = null;

        private HomeFormData m_Data;
        private bool m_IsAuto = false;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            m_Ctrl = UI.GetController("HomeCtrl");

            m_HeadPanel = UI.GetChild("HeadPanel").asCom;
            m_Name = m_HeadPanel.GetChild("tf_Name").asTextField;
            m_Level = m_HeadPanel.GetChild("tf_Level").asTextField;
            m_Hp = m_HeadPanel.GetChild("bar_Hp").asProgress;
            m_Mp = m_HeadPanel.GetChild("bar_Mp").asProgress;
            m_Exp = m_HeadPanel.GetChild("bar_Exp").asImage;
            BuffTip m_Buff01 = m_HeadPanel.GetChild("buff_01") as BuffTip;
            BuffTip m_Buff02 = m_HeadPanel.GetChild("buff_02") as BuffTip;
            BuffTip m_Buff03 = m_HeadPanel.GetChild("buff_03") as BuffTip;
            BuffTip m_Buff04 = m_HeadPanel.GetChild("buff_04") as BuffTip;
            m_BuffItems = new[] {m_Buff01, m_Buff02, m_Buff03, m_Buff04};

            m_RoleButton = UI.GetChild("btn_Role").asButton;
            m_BagButton = UI.GetChild("btn_Bag").asButton;
            m_PartnerButton = UI.GetChild("btn_Partner").asButton;
            m_TaskButton = UI.GetChild("btn_Task").asButton;
            m_MountButton = UI.GetChild("btn_Mount").asButton;
            m_AiButton = UI.GetChild("btn_Ai").asButton;
            m_AiAuto = m_AiButton.GetChild("n1").asImage;
            m_AiHand = m_AiButton.GetChild("n2").asImage;

            m_RoleButton.visible = false;
            m_BagButton.visible = false;
            m_TaskButton.visible = false;
            m_AiButton.visible = false;
            m_AiAuto.visible = false;

            m_Skill01Button = UI.GetChild("btn_Skill01") as SkillButton;
            m_Skill02Button = UI.GetChild("btn_Skill02") as SkillButton;
            m_Skill03Button = UI.GetChild("btn_Skill03") as SkillButton;
            m_Skill04Button = UI.GetChild("btn_Skill04") as SkillButton;
            m_Skill05Button = UI.GetChild("btn_Skill05") as SkillButton;
            m_SkillItems = new[]
            {
                m_Skill01Button,
                m_Skill02Button,
                m_Skill03Button,
                m_Skill04Button,
                m_Skill05Button
            };

            for (int i = 0; i < m_BuffItems.Length; i++)
            {
                BuffTip buffTip = m_BuffItems[i];
                buffTip.HideBuff();
            }
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            AddListener();

            m_Data = userData as HomeFormData;
            if (m_Data == null)
            {
                Log.Error("UI Data is null.");
                return;
            }

            if (m_Data.SceneType == SceneType.City)
                m_Ctrl.selectedIndex = 0;
            else
                m_Ctrl.selectedIndex = 1;
        }

        protected override void OnClose(object userData)
        {
            base.OnClose(userData);

            RemoveListener();

            HideAll();
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            if(m_Data?.SceneType != SceneType.Battle)
                return;

            RefreshSkillItems();
        }

        private void AddListener()
        {
            GameEntry.Event.Subscribe(RefreshBuffEventArgs.EventId, RefreshBuffItems);

            GameEntry.Event.Subscribe(RefreshHeroInfoEventArgs.EventId, RefreshHeroInfo);
    
            GameEntry.Event.Subscribe(OnPlayerAiModeChangeEventArgs.EventId,OnPlayerAiModeChange);

            m_Skill01Button.onClick.Add(() => OnBattleSkillClick(SkillPosType.Skill_0));
            m_Skill02Button.onClick.Add(() => OnBattleSkillClick(SkillPosType.Skill_1));
            m_Skill03Button.onClick.Add(() => OnBattleSkillClick(SkillPosType.Skill_2));
            m_Skill04Button.onClick.Add(() => OnBattleSkillClick(SkillPosType.Skill_3));
            m_Skill05Button.onClick.Add(() => OnBattleSkillClick(SkillPosType.Skill_4));

            m_AiButton.onClick.Add(OnClickAiButton);
            m_MountButton.onClick.Add(OnClickMountButton);
            m_PartnerButton.onClick.Add(OnClickPartner);
        }

        private void RemoveListener()
        {
            GameEntry.Event.Unsubscribe(RefreshBuffEventArgs.EventId, RefreshBuffItems);

            GameEntry.Event.Unsubscribe(RefreshHeroInfoEventArgs.EventId, RefreshHeroInfo);

            GameEntry.Event.Unsubscribe(OnPlayerAiModeChangeEventArgs.EventId, OnPlayerAiModeChange);

            m_Skill01Button.onClick.Clear();
            m_Skill02Button.onClick.Clear();
            m_Skill03Button.onClick.Clear();
            m_Skill04Button.onClick.Clear();
            m_Skill05Button.onClick.Clear();
            m_AiButton.onClick.Clear();
            m_RoleButton.onClick.Clear();
            m_BagButton.onClick.Clear();
            m_PartnerButton.onClick.Clear();
            m_TaskButton.onClick.Clear();
        }

        private void OnClickAiButton()
        {
            m_IsAuto = !m_IsAuto;

            ChangeAiModeEventArgs eventArgs = new ChangeAiModeEventArgs();

            if (m_IsAuto)
            {
                eventArgs.Fill(AIModeType.Auto);
                m_AiAuto.visible = false;
                m_AiHand.visible = true;
            }
            else
            {
                eventArgs.Fill(AIModeType.Hand);
                m_AiAuto.visible = true;
                m_AiHand.visible = false;
            }

            GameEntry.Event.Fire(this,eventArgs);
        }

        private void OnClickMountButton()
        {
            ChangeVehicleEventArgs eventArgs = new ChangeVehicleEventArgs();
            GameEntry.Event.Fire(this, eventArgs);
        }

        private void OnClickPartner()
        {
            ChangePartnerEventArgs eventArgs = new ChangePartnerEventArgs();
            int partner01Id = UnityEngine.Random.Range(90001, 90006);
            int partner02Id = UnityEngine.Random.Range(90001, 90006);
            eventArgs.Fill(partner01Id, partner02Id);
            GameEntry.Event.Fire(this, eventArgs);
        }

        private void OnBattleSkillClick(SkillPosType skillPos)
        {
            SkillKeyDownEventArgs skillEventArgs = ReferencePool.Acquire<SkillKeyDownEventArgs>();
            skillEventArgs.Fill(skillPos);
            GameEntry.Event.Fire(this, skillEventArgs);
        }

        private void RefreshBuffItems(object sender, GameEventArgs e)
        {
            RefreshBuffEventArgs ne = e as RefreshBuffEventArgs;
            ActorBase actor = ne.Actor;
            if(actor == null)
                return;
            if(actor.IsDead)
                return;

            Map<int, BuffBase> buffs = actor.ActorBuff.GetAllBuff();
            int index = 0;
            for (buffs.Begin();buffs.Next();)
            {
                if (index > m_BuffItems.Length - 1)
                {
                    break;
                }

                BuffTip buffTip = m_BuffItems[index];
                buffTip.ShowBuff(buffs.Value);
                index++;
            }

            for (int i = index; i < m_BuffItems.Length; i++)
            {
                BuffTip buffTip = m_BuffItems[index];
                buffTip.HideBuff();
            }
        }

        private void RefreshSkillItems()
        {
            if (GameEntry.Level.PlayerActor == null)
            {
                return;
            }

            IActorSkill skill = GameEntry.Level.PlayerActor.ActorSkill;
            if(skill == null)
                return;

            for (int i = 0; i < m_SkillItems.Length; i++)
            {
                m_SkillItems[i].ShowSkill(skill.GetSkill((SkillPosType) i));
            }
        }

        private void RefreshHeroInfo(object sender, GameEventArgs e)
        {
            RefreshHeroInfoEventArgs ne = e as RefreshHeroInfoEventArgs;
            switch (ne.Type)
            {
                case RefreshType.Name:
                    m_Name.text = ne.Name;
                    break;
                case RefreshType.Level:
                    m_Level.text = GlobalTools.Format("LV.{0}", ne.Level);
                    break;
                case RefreshType.Hp:
                    if (ne.MaxHp != 0)
                    {
                        m_Hp.value = 100 * (float) ne.CurHp/ne.MaxHp;
                        m_Hp.GetChild("title").asTextField.text = GlobalTools.Format("{0}/{1}", ne.CurHp, ne.MaxHp);
                    }
                    break;
                case RefreshType.Mp:
                    if (ne.MaxMp != 0)
                    {
                        m_Mp.value = 100 * (float)ne.CurMp / ne.MaxMp;
                        m_Mp.GetChild("title").asTextField.text = GlobalTools.Format("{0}/{1}", ne.CurMp, ne.MaxMp);
                    }
                    break;
                case RefreshType.Exp:
                    if (ne.MaxExp != 0)
                    {
                        m_Exp.fillAmount =  (float) ne.CurExp/ne.MaxExp;
                    }
                    break;
                case RefreshType.All:
                    m_Name.text = ne.Name;
                    m_Level.text = GlobalTools.Format("LV.{0}", ne.Level);
                    if (ne.MaxHp != 0)
                    {
                        m_Hp.value = 100 * (float)ne.Attribute.Hp / ne.Attribute.MaxHp;
                        m_Hp.GetChild("title").asTextField.text = GlobalTools.Format("{0}/{1}", ne.Attribute.Hp, ne.Attribute.MaxHp);
                    }
                    if (ne.MaxMp != 0)
                    {
                        m_Mp.value = 100 * (float)ne.Attribute.Mp / ne.Attribute.MaxMp;
                        m_Mp.GetChild("title").asTextField.text = GlobalTools.Format("{0}/{1}", ne.Attribute.Mp, ne.Attribute.MaxMp);
                    }
                    if (ne.MaxExp != 0)
                    {
                        m_Exp.fillAmount =  (float)ne.CurExp / ne.MaxExp;
                    }
                    break;
            }

        }

        private void OnPlayerAiModeChange(object sender, GameEventArgs e)
        {
            OnPlayerAiModeChangeEventArgs ne = e as OnPlayerAiModeChangeEventArgs;

            if (ne == null)
                return;

            m_AiAuto.visible = ne.AiMode == AIModeType.Hand;
            m_AiHand.visible = ne.AiMode != AIModeType.Hand;
        }

        private void HideAll()
        {
            for (int i = 0; i < m_BuffItems.Length; i++)
            {
                BuffTip buffTip = m_BuffItems[i];
                buffTip.HideBuff();
            }

            for (int i = 0; i < m_SkillItems.Length; i++)
            {
                m_SkillItems[i].HideSkill();
            }
        }
    }
}
