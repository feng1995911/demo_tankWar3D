using System.Collections.Generic;
using BT;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/BehaviorTree")]
    public class BehaviorTreeComponent : GameFrameworkComponent,ICustomComponent
    {
        private List<BTTree> m_BTTrees = null;
        private List<BTTree> m_DeleteList = null;

        public void Init()
        {
            m_BTTrees = new List<BTTree>();
            m_DeleteList = new List<BTTree>();
        }

        public void Clear()
        {
            for (int i = 0; i < m_BTTrees.Count; i++)
            {
                BTTree tree = m_BTTrees[i];
                tree.Clear();
            }
            m_BTTrees.Clear();
            m_DeleteList.Clear();
        }

        void Update()
        {
            Step();
        }

        public void Run(BTTree tree)
        {
            if (tree == null) return;
            tree.Clear();
            m_BTTrees.Add(tree);
        }

        public void Step()
        {
            for (int i = 0; i < m_BTTrees.Count; i++)
            {
                BTTree tree = m_BTTrees[i];
                BTStatus pStatus = tree.Step();

                switch (pStatus)
                {
                    case BTStatus.Initial:
                        break;
                    case BTStatus.Running:
                        break;
                    case BTStatus.Success:
                    case BTStatus.Failure:
                        {
                            m_DeleteList.Add(tree);
                        }
                        break;
                }
            }

            for (int i = 0; i < m_DeleteList.Count; i++)
            {
                BTTree tree = m_DeleteList[i];
                m_BTTrees.Remove(tree);
                tree.Clear();
            }
            m_DeleteList.Clear();
        }

        public void GetTreeInParents(BTNode pNode, ref BTTree result)
        {
            if (pNode == null)
            {
                return;
            }
            if (pNode.Parent is BTTree)
            {
                result = pNode.Parent as BTTree;
            }
            else
            {
                GetTreeInParents(pNode.Parent, ref result);
            }
        }

        public BTTree GetFirstTreeInParent(BTNode pNode)
        {
            BTTree result = null;
            GetTreeInParents(pNode, ref result);
            if (result == null)
            {
                Debug.LogError("找不到BTree类型的Parent：" + pNode);
                return null;
            }
            return result;
        }

        public void SaveData(BTNode pNode, string key, object value)
        {
            BTTree result = GetFirstTreeInParent(pNode);
            if (result != null)
            {
                result.SetData(key, value);
            }
        }

        public void ClearData(BTNode pNode, string key)
        {
            BTTree result = GetFirstTreeInParent(pNode);
            if (result != null)
            {
                result.SetData(key, null);
            }
        }

        public object GetData(BTNode pNode, string key)
        {
            BTTree result = GetFirstTreeInParent(pNode);
            if (result != null)
            {
                return result.GetData(key);
            }
            return null;
        }

        public ActorBase GetOwnerByNode(BTNode pNode)
        {
            BTTree tree = GetFirstTreeInParent(pNode);
            if (tree == null)
            {
                return null;
            }
            return tree.Owner;
        }

        public void Remove(BTTree tree)
        {
            if (tree == null)
            {
                return;
            }
            m_DeleteList.Add(tree);
        }
        
    }
}
