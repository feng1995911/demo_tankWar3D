using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// 关卡元素
    /// </summary>
    public class LevelElement : LevelBehaviour
    {
        public float LifeTime = -1;

        public Vector3 Position
        {
            get { return transform.position; }
            set { transform.position = value; }
        }

        public Vector3 Scale
        {
            get { return transform.localScale; }
            set { transform.localScale = value; }
        }

        public Vector3 Euler
        {
            get { return transform.eulerAngles; }
            set { transform.eulerAngles = value; }
        }

        public virtual void SetName()
        {

        }

        public virtual void Build()
        {

        }

        public virtual void Hide()
        {
            
        }

        public override void Init()
        {

        }

        public override XmlObject Export()
        {
            return null;
        }

        public override void Import(XmlObject pData, bool build)
        {

        }

        public override void Destroy()
        {

        }

        public static void GetAllComponents<T>(Transform trans, List<T> pList) where T : Component
        {
            if (trans == null) return;
            for (int i = 0; i < trans.childCount; i++)
            {
                T t = trans.GetChild(i).GetComponent<T>();
                if (t != null)
                {
                    pList.Add(t);
                }
            }
        }
    }
}
