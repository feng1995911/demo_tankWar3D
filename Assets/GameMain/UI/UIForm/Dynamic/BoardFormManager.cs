using System.Collections.Generic;
using GameFramework;
using GameFramework.Event;
using UnityGameFramework.Runtime;

namespace GameMain
{
    public class BoardFormManager : Singleton<BoardFormManager>
    {
        private readonly Dictionary<int,int> m_BoardForms = new Dictionary<int, int>();

        public override void Init()
        {
            base.Init();

            GameEntry.Event.Subscribe(RefreshBoardEventArgs.EventId, OnRefreshBoard);
        }

        public void Clear()
        {
            GameEntry.Event.Unsubscribe(RefreshBoardEventArgs.EventId, OnRefreshBoard);
        }

        public void Create(BoardFormData data)
        {
            if(data == null || data.OwnerId == 0)
                return;

            if (m_BoardForms.ContainsKey(data.OwnerId))
            {
                Log.Error("Board is exit.Id:{0}", data.OwnerId);
                return;
            }

            int? serialId = GameEntry.UI.OpenUIForm(UIFormId.RoleBoardForm, data);
            if (!serialId.HasValue)
            {
                Log.Error("Open form fail.");
                return;
            }

            m_BoardForms.Add(data.OwnerId, serialId.Value);
        }

        public void Release(int ownerId)
        {
            int boardId;
            if (m_BoardForms.TryGetValue(ownerId, out boardId))
            {
                if (GameEntry.UI.HasUIForm(boardId))
                    GameEntry.UI.CloseUIForm(boardId);
            }
            else
            {
                Log.Error("Can no find board.");
            }
        }

        public void OnRefreshBoard(object sender, GameEventArgs e)
        {
            RefreshBoardEventArgs ne = e as RefreshBoardEventArgs;
            if (ne == null)
                return;

            int boardId;
            if(m_BoardForms.TryGetValue(ne.OwnerId,out boardId))
            {
                UIForm uiform = GameEntry.UI.GetUIForm(boardId);
                RoleBoardForm borderForm = uiform?.Logic as RoleBoardForm;

                borderForm?.Refresh(ne.CurHp, ne.MaxHp, ne.Level);
            }
        }

    }
}
