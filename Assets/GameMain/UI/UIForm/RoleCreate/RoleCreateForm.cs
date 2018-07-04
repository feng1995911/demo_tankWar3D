using FairyGUI;
using GameFramework;
using System.Collections.Generic;

namespace GameMain
{
    public class RoleCreateForm : FairyGuiForm
    {
        private GButton m_WarriorButton = null;
        private GButton m_MagicButton = null;
        private GButton m_ArcherButton = null;
        private GButton m_CreateRoleButton = null;
        private GComponent m_RoleNamePanel = null;
        private GButton m_DiceButton = null;
        private GTextInput m_NameInput = null;
        private GComponent m_RoleInfoPanel = null;
        private Controller m_RoleInfoCtrl = null;

        private Queue<string> m_RandomNames = new Queue<string>();

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            m_WarriorButton = UI.GetChild("btn_warrior").asButton;
            m_MagicButton = UI.GetChild("btn_magic").asButton;
            m_ArcherButton = UI.GetChild("btn_archer").asButton;
            m_CreateRoleButton = UI.GetChild("btn_CreateRole").asButton;
            m_RoleNamePanel = UI.GetChild("RoleNamePanel").asCom;
            m_DiceButton = m_RoleNamePanel.GetChild("btn_Dice").asButton;
            m_NameInput = m_RoleNamePanel.GetChild("ipt_RoleName").asTextInput;
            m_RoleInfoPanel = UI.GetChild("RoleInfoPanel").asCom;
            m_RoleInfoCtrl = m_RoleInfoPanel.GetController("roleInfoCtrl");
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            RoleCreateFormData data = (RoleCreateFormData)userData;
            if (data == null)
            {
                Log.Warning("RoleCreateFormParams is invalid.");
                return;
            }

            m_WarriorButton.onClick.Add(()=>
            {
                m_RoleInfoCtrl.selectedIndex = 0;
                if (data.OnClickRoleType != null)
                    data.OnClickRoleType.Invoke(1);
            });
            m_MagicButton.onClick.Add(() =>
            {
                m_RoleInfoCtrl.selectedIndex = 1;
                if (data.OnClickRoleType != null)
                    data.OnClickRoleType.Invoke(2);
            });
            m_ArcherButton.onClick.Add(() =>
            {
                m_RoleInfoCtrl.selectedIndex = 2;
                if (data.OnClickRoleType != null)
                    data.OnClickRoleType.Invoke(3);
            });

            m_RandomNames = data.RandomNameQueue;
            m_NameInput.text = GetName();
            m_DiceButton.onClick.Add(() =>
            {
                m_DiceButton.TweenRotate(360, 0.5f);
                m_DiceButton.rotation = 0;
                m_NameInput.text = GetName();
            });

            m_CreateRoleButton.onClick.Add(() =>
            {
                if (m_NameInput.text == string.Empty)
                {
                    Log.Warning("Name is invalid.");
                    return;
                }

                if (data.OnClickCreateRole != null)
                    data.OnClickCreateRole.Invoke(m_NameInput.text);
            });

        }

        protected override void OnClose(object userData)
        {
            base.OnClose(userData);

            m_RandomNames = null;
            m_WarriorButton.onClick.Clear();
            m_MagicButton.onClick.Clear();
            m_ArcherButton.onClick.Clear();
            m_DiceButton.onClick.Clear();
            m_CreateRoleButton.onClick.Clear();
        }

        private string GetName()
        {
            if (m_RandomNames == null || m_RandomNames.Count == 0)
            {
                Log.Warning("randomNames is invlid.");
                return null;
            }

            string name = m_RandomNames.Dequeue();
            m_RandomNames.Enqueue(name);
            return name;
        }
    }
}
