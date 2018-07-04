﻿using System;

namespace GameMain
{
    public abstract class Singleton<T> where T : class, new()
    {
        private static T m_instance;
        private static object syncRoot = new object();

        public static T Instance
        {
            get
            {
                if (m_instance == null)
                {
                    lock (syncRoot)
                    {
                        m_instance = Activator.CreateInstance<T>();
                        if (m_instance != null)
                        {
                            (m_instance as Singleton<T>).Init();
                        }
                    }
                }

                return m_instance;
            }
        }

        public static void Release()
        {
            if (m_instance != null)
            {
                m_instance = (T)((object)null);
            }
        }

        public virtual void Init()
        {

        }

    }
}