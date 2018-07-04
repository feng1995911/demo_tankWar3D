using System.Collections.Generic;
using UnityEngine;

namespace GameMain
{
    public class LevelContainerBase<T> : LevelElement where T : LevelElement
    {
        private readonly List<T> m_List = new List<T>();

        public List<T> Elements
        {
            get
            {
                m_List.Clear();
                GetAllComponents<T>(transform, m_List);
                return m_List;
            }
        }

        public virtual T AddElement()
        {
            T pElem = new GameObject().AddComponent<T>();
            pElem.transform.parent = transform;
            pElem.Build();
            pElem.SetName();
            return pElem;
        }

        public T FindElement(int id)
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                if (Elements[i].Id == id)
                {
                    return Elements[i];
                }
            }
            return null;
        }
    }
}
