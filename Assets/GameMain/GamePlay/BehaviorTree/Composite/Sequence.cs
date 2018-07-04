using UnityEngine;
using System.Collections;

namespace BT
{
    public class Sequence : Composite
    {
        public override BTStatus Step()
        {
            if (m_ActiveIndex == -1)
            {
                m_ActiveIndex = 0;
            }
            for (; m_ActiveIndex < m_Children.Count; m_ActiveIndex++)
            {
                BTNode pNode = m_Children[m_ActiveIndex];
                BTStatus pStatus = pNode.Step();
                switch (pStatus)
                {
                    case BTStatus.Running:
                        {
                            m_IsRunning = true;
                            return BTStatus.Running;
                        }
                    case BTStatus.Success:
                        {
                            pNode.Clear();
                            continue;
                        }
                    case BTStatus.Failure:
                        {
                            m_ActiveIndex = -1;
                            m_IsRunning = false;
                            pNode.Clear();
                            return BTStatus.Failure;
                        }
                }
            }
            m_ActiveIndex = -1;
            m_IsRunning = false;
            return BTStatus.Success;
        }


        public override BTNode DeepClone()
        {
            Sequence sequence = new Sequence();
            sequence.CloneChildren(this);
            return sequence;
        }
    }
}