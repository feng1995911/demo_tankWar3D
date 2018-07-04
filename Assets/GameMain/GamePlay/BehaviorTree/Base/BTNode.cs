using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace BT
{
    /// <summary>
    /// 行为树节点
    /// </summary>
    public class BTNode
    {
        protected List<BTNode> m_Children = new List<BTNode>();
        protected BTNode m_Parent;
        protected BTNode m_FirstChild;
        protected bool m_IsRunning = false;

        public List<BTNode> Children => m_Children;

        public BTNode Parent => m_Parent;

        public BTNode FirstChild
        {
            get
            {
                if (m_FirstChild == null)
                {
                    m_FirstChild = m_Children.Count > 0 ? m_Children[0] : null;
                }
                return m_FirstChild;
            }
        }

        public bool IsRunning => m_IsRunning;

        public int ChildCount => m_Children.Count;


        public virtual void Init() { }

        public virtual BTStatus Step()
        {
            return BTStatus.Failure;
        }

        public virtual void Break() { }

        public virtual void Clear()
        {
            m_IsRunning = false;
            for (int i = 0; i < m_Children.Count; i++)
            {
                m_Children[i].Clear();
            }
        }

        public virtual bool CheckCondition()
        {
            return false;
        }

        public virtual void Load(XmlElement element)
        {
            if (element == null)
            {
                Debug.LogError("XmlElement is null" + this.GetType().ToString());
            }

            for (int i = 0; i < element.Attributes.Count; i++)
            {
                XmlAttribute attr = element.Attributes[i];
                ReadAttribute(attr.Name, attr.Value);
            }

            XmlNode child = element.FirstChild;
            while (child != null)
            {
                Type classType = null;
                try
                {
                    classType = Type.GetType("BT." + child.Name, true);
                }
                catch (Exception)
                {
                    throw new Exception("XmlElement is null:" + this.GetType() + "." + child.Name);
                }

                if (classType == null)
                {
                    Debug.LogError("XmlElement is null:" + this.GetType() + "." + child.Name);
                    return;
                }
                
                BTNode node = Activator.CreateInstance(classType) as BTNode;
                if (node == null)
                {
                    Debug.LogError("Can no create node bt type:" + classType);
                    return;
                }

                node.Load(child as XmlElement);
                this.AddChild(node);
                child = child.NextSibling;
            }
        }

        public virtual void Save(XmlDocument doc, XmlElement xe)
        {
            this.SaveAttribute(doc, xe);
            for (int i = 0; i < m_Children.Count; i++)
            {
                BTNode node = m_Children[i];
                XmlElement child = doc.CreateElement(node.GetType().Name);
                node.Save(doc, child);
                xe.AppendChild(child);
            }
        }

        protected virtual void ReadAttribute(string key, string value) { }

        protected virtual void SaveAttribute(XmlDocument doc, XmlElement xe) { }

        public virtual BTNode DeepClone()
        {
            Debug.LogError("clone object error:" + this.GetType());
            return null;
        }

        public void AddChild(BTNode child)
        {
            child.m_Parent = this;
            this.m_Children.Add(child);
        }

        public BTNode GetChild(int index)
        {
            if (index < m_Children.Count)
            {
                return m_Children[index];
            }
            return null;
        }

        public void DelChild(BTNode pChild)
        {
            this.m_Children.Remove(pChild);
        }

        public void CloneChildren(BTNode pNode)
        {
            for (int i = 0; i < pNode.Children.Count; i++)
            {
                BTNode node = pNode.Children[i];
                BTNode newNode = node.DeepClone();
                AddChild(newNode);
            }
        }

    }
}
