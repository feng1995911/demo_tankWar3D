using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FairyGUI;
using GameFramework;

namespace GameMain
{
    public class LevelSelectForm : FairyGuiForm
    {
        private GList m_LeveList;
        private GTextField m_SelectText;
        private GButton m_EnterButton;
        private GButton m_CloseButton;

        private LevelItem[] m_LevelItems = null;
        private int m_CurSelectLevelId = 0;
        private SceneId m_LevelScene = 0;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            m_LeveList = UI.GetChild("list_Level").asList;
            m_SelectText = UI.GetChild("tf_Select").asTextField;
            m_EnterButton = UI.GetChild("btn_Enter").asButton;
            m_CloseButton = UI.GetChild("n1").asCom.GetChild("btn_Close").asButton;

            m_LeveList.RemoveChildrenToPool();

            DRLevel[] drLevels = GameEntry.DataTable.GetDataTable<DRLevel>().GetAllDataRows();
            m_LevelItems = new LevelItem[drLevels.Length];
            for (int i = 0; i < drLevels.Length; i++)
            {
                LevelItem item = m_LeveList.AddItemFromPool() as LevelItem;
                if (item == null)
                {
                    Log.Error("levelItem is null.");
                    break;
                }
                item.Init(drLevels[i]);
                m_LevelItems[i] = item;
            }

            //默认选中第一个
            m_CurSelectLevelId = m_LevelItems[0].LevelId;
            m_LevelScene = m_LevelItems[0].SceneId;
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            for (int i = 0; i < m_LevelItems.Length; i++)
            {
                int levelId = m_LevelItems[i].LevelId;
                string levelName = m_LevelItems[i].LevelName;
                SceneId sceneId = m_LevelItems[i].SceneId;
                LevelItem item = m_LevelItems[i];

                item.onClick.Add(() =>
                {
                    m_CurSelectLevelId = levelId;
                    m_LevelScene = sceneId;
                    m_SelectText.text = levelName;
                    m_EnterButton.enabled = !item.IsLock;
                });
            }
          
            m_EnterButton?.onClick.Add(() =>
            {
                EnterLevelEventArgs eventArgs = ReferencePool.Acquire<EnterLevelEventArgs>();
                eventArgs.Fill(m_CurSelectLevelId, m_LevelScene);
                GameEntry.Event.Fire(this, eventArgs);

                GameEntry.UI.CloseUIForm(UIFormId.LevelSelectForm);
            });

            m_CloseButton?.onClick.Add(() =>
            {
                GameEntry.UI.CloseUIForm(UIFormId.LevelSelectForm);
            });
        }

        protected override void OnClose(object userData)
        {
            base.OnClose(userData);

            for (int i = 0; i < m_LevelItems.Length; i++)
            {
                m_LevelItems[i]?.onClick.Clear();
            }

            m_EnterButton?.onClick.Clear();
            m_CloseButton?.onClick.Clear();
        }

    }
}
