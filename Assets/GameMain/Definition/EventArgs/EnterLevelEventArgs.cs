using System;
using GameFramework.Event;

namespace GameMain
{
    /// <summary>
    /// 进入关卡事件
    /// </summary>
    public class EnterLevelEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(EnterLevelEventArgs).GetHashCode();

        public override int Id => EventId;

        public int LevelId
        {
            get;
            private set;
        }

        public SceneId SceneId
        {
            get;
            private set;
        }

        public override void Clear()
        {
            LevelId = 0;
            SceneId = SceneId.Undefined;
        }

        public EnterLevelEventArgs Fill(int levelId, SceneId sceneId)
        {
            this.LevelId = levelId;
            this.SceneId = sceneId;
            return this;
        }
    }
}
