using System.Collections.Generic;
using GameFramework;
using UnityEngine;

namespace GameMain
{
    public class FlyWordManager : Singleton<FlyWordManager>
    {
        private readonly Queue<FlyWordData> m_Queue = new Queue<FlyWordData>();
        private readonly Queue<int> m_RecycleQueue= new Queue<int>(); 
        private int m_Timer = 0;
        private int m_ShowInterval = 2;
        private int m_MinCount = 10;

        public override void Init()
        {
            base.Init();
            m_Timer = m_ShowInterval;
        }

        public void Step()
        {
            if (m_Queue.Count == 0)
            {
                return;
            }

            if (m_Timer > m_ShowInterval && m_Queue.Count > 0)
            {
                FlyWordData item = m_Queue.Dequeue();
                Play(item);
                if (m_RecycleQueue.Count > m_MinCount)
                {
                    GameEntry.UI.CloseUIForm(m_RecycleQueue.Dequeue());
                }

                m_Timer = 0;
            }
            else
            {
                m_Timer++;
            }
        }

        void Play(FlyWordData data)
        {
            int? id = GameEntry.UI.OpenUIForm(UIFormId.FlyWordForm, data);
            if (!id.HasValue)
            {
                Log.Error("Play flyWord fail.");
                return;
            }

            m_RecycleQueue.Enqueue(id.Value);
        }

        public void Show(FlyWordData data)
        {
            m_Queue.Enqueue(data);
        }

        public void Clear()
        {
            foreach (var id in m_RecycleQueue)
            {
                GameEntry.UI.CloseUIForm(id);
            }

            m_RecycleQueue.Clear();
            m_Queue.Clear();
        }

    }
}
