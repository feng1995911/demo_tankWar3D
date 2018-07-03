using UnityEngine;
using System.Collections;

namespace BT
{
    /// <summary>
    /// 选择节点
    /// </summary>
    public class Selector : Composite
    {
        public override BTStatus Step()
        {
            for (int i = 0; i < m_Children.Count; i++)
            {
                BTNode pNode = m_Children[i];
                BTStatus pStatus = pNode.Step();
                switch (pStatus)
                {
                    case BTStatus.Running:
                        {
                            if (m_ActiveIndex != i && m_ActiveIndex != -1)
                            {
                                m_Children[m_ActiveIndex].Clear();
                            }
                            m_ActiveIndex = i;
                            m_PreviaIndex = -1;
                            m_IsRunning = true;
                            return BTStatus.Running;
                        }
                    case BTStatus.Success:
                        {
                            if (m_ActiveIndex != i && m_ActiveIndex != -1)
                            {
                                m_Children[m_ActiveIndex].Clear();
                            }
                            pNode.Clear();
                            m_ActiveIndex = -1;
                            m_PreviaIndex = i;
                            m_IsRunning = false;
                            return BTStatus.Success;
                        }
                    case BTStatus.Failure:
                        {
                            pNode.Clear();
                            return BTStatus.Failure;
                        }
                }
            }

            m_IsRunning = false;
            return BTStatus.Failure;
        }

        public override BTNode DeepClone()
        {
            Selector select = new Selector();
            select.CloneChildren(this);
            return select;
        }
    }
}
