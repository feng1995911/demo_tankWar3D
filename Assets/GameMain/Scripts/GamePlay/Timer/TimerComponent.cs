using System;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Timer")]
    public class TimerComponent : GameFrameworkComponent,ICustomComponent
    {
        private Dictionary<int, Timer> m_Timers = null;
        private List<Timer> m_AddBuffer = null;
        private List<int> m_DeleteBuffer = null;
        private int m_Index = 0;

        public void Init()
        {
            m_Timers = new Dictionary<int, Timer>();
            m_AddBuffer = new List<Timer>();
            m_DeleteBuffer = new List<int>();
        }

        public void Clear()
        {
            m_Timers.Clear();
            m_AddBuffer.Clear();
            m_DeleteBuffer.Clear();
        }

        void Update()
        {
            Step();
        }


        public Timer Register(float callTime, Action callback, int tick = 1)
        {
            if (callback == null)
            {
                return null;
            }
            if (callTime <= 0)
            {
                return null;
            }
            m_Index++;
            Timer item = new Timer();
            item.key = m_Index;
            item.callTime = callTime;
            item.callback = callback;
            item.tick = tick;
            item.currTick = 0;
            item.startTime = Time.realtimeSinceStartup;
            item.currTime = item.startTime;
            m_AddBuffer.Add(item);
            return item;
        }

        public void UnRegister(Action callback)
        {
            Dictionary<int, Timer>.Enumerator em = m_Timers.GetEnumerator();
            while (em.MoveNext())
            {
                if (em.Current.Value.callback == callback)
                {
                    m_DeleteBuffer.Add(em.Current.Key);
                }
            }
            em.Dispose();
        }

        public void UnRegister(Timer timer)
        {
            if (timer == null)
            {
                return;
            }
            m_DeleteBuffer.Add(timer.key);
        }

        public void Step()
        {
            for (int i = 0; i < m_AddBuffer.Count; i++)
            {
                Timer item = m_AddBuffer[i];
                m_Timers.Add(item.key, item);
            }
            m_AddBuffer.Clear();

            Dictionary<int, Timer>.Enumerator em = m_Timers.GetEnumerator();
            while (em.MoveNext())
            {
                Timer item = em.Current.Value;
                item.currTime = Time.realtimeSinceStartup;
                if (Time.realtimeSinceStartup - item.startTime >= item.callTime)
                {
                    item.callback?.Invoke();
                    item.startTime = Time.realtimeSinceStartup;
                    if (item.tick > 0)
                    {
                        item.currTick++;
                        if (item.tick == item.currTick)
                        {
                            m_DeleteBuffer.Add(item.key);
                        }
                    }
                }
                if (item.pause)
                {
                    m_DeleteBuffer.Add(item.key);
                }
            }
            em.Dispose();
            for (int i = 0; i < m_DeleteBuffer.Count; i++)
            {
                m_Timers.Remove(m_DeleteBuffer[i]);
            }
            m_DeleteBuffer.Clear();
        }

    }
}
