using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BT
{

    public class Parallel : Composite
    {
        private List<int> m_FinishChildrenIndexList = new List<int>();

        public override BTStatus Step()
        {
            for (int i = 0; i < m_Children.Count; i++)
            {
                if (m_FinishChildrenIndexList.Contains(i))
                {
                    continue;
                }
                BTNode pNode = m_Children[i];
                BTStatus pStatus = pNode.Step();

                if (pStatus != BTStatus.Running)
                {
                    pNode.Clear();
                    m_FinishChildrenIndexList.Add(i);
                }
            }

            m_IsRunning = (m_FinishChildrenIndexList.Count < m_Children.Count);
            return (m_IsRunning) ? BTStatus.Running : BTStatus.Success;
        }

        public override void Clear()
        {
            base.Clear();
            m_FinishChildrenIndexList.Clear();
        }

        public override BTNode DeepClone()
        {
            Parallel parallel = new Parallel();
            parallel.CloneChildren(this);
            return parallel;
        }
    }
}
