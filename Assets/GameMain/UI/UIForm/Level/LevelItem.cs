using FairyGUI;
using FairyGUI.Utils;
using GameFramework;
using UnityEngine;

namespace GameMain
{
    public class LevelItem : GButton
    {
        public int LevelId { get; private set; }
        public SceneId SceneId { get; private set; }
        public string LevelName { get; private set; }
        public bool IsLock { get; private set; }

        private Controller m_Ctrl = null;
        private GLoader m_Icon = null;
        private GTextField m_Title = null;
        private GTextField m_Level = null;
        private ThreeStar m_Star = null;

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_Ctrl = GetController("bgCtrl");
            m_Icon = GetChild("icon").asLoader;
            m_Title = GetChild("title").asTextField;
            m_Level = GetChild("tf_Level").asTextField;
            m_Star = GetChild("star") as ThreeStar;
        }

        public void Init(DRLevel levelData)
        {
            if (levelData == null)
            {
                Log.Error("data is invalid.");
                return;
            }
            LevelId = levelData.Id;
            LevelName = levelData.Name;
            SceneId = (SceneId) levelData.Scene;

            DBPlayer player = GameEntry.Database.GetDBRow<DBPlayer>(GameEntry.Database.GetPlayerId());
            if (levelData.LevelRequest <= player.Level)
            {
                IsLock = false;
                m_Ctrl.selectedIndex = levelData.Icon;
                m_Level.color = Color.green;
            }
            else
            {
                IsLock = true;
                m_Ctrl.selectedIndex = 0;
                m_Level.color = Color.red;
            }
            m_Title.text = levelData.Name;
            m_Level.text = "LV." + levelData.LevelRequest;
        }

        public void SetStar(int count)
        {
            if (count < 0 || count > 3)
            {
                Log.Error("Count is invalid");
                return;
            }

            m_Star.SetStar(count);
        }
    }
}
