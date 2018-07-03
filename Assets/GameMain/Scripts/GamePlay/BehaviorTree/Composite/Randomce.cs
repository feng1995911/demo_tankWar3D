using UnityEngine;
using System.Collections;

namespace BT
{
    public class Randomce : Composite
    {
        public override BTStatus Step()
        {
            if (m_ActiveIndex == -1)
            {
                m_ActiveIndex = UnityEngine.Random.Range(0, m_Children.Count);
            }

            if (m_Children.Count > 0)
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
                            m_ActiveIndex = -1;
                            m_PreviaIndex = m_ActiveIndex;
                            m_IsRunning = false;
                            return BTStatus.Success;
                        }
                    case BTStatus.Failure:
                        {
                            pNode.Clear();
                            m_ActiveIndex = -1;
                            m_PreviaIndex = -1;
                            m_IsRunning = false;
                            return BTStatus.Failure;
                        }
                }
            }
            m_ActiveIndex = -1;
            m_PreviaIndex = -1;
            m_IsRunning = false;
            return BTStatus.Failure;
        }

        public override BTNode DeepClone()
        {
            Randomce rc = new Randomce();
            rc.CloneChildren(this);
            return rc;
        }
    }
}
