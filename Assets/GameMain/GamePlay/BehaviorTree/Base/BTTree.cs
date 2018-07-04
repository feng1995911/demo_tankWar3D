using System.Collections.Generic;
using GameMain;

namespace BT
{
    public class BTTree : BTNode
    {
        public int Id { get; set; }

        public ActorBase Owner { get; set; }

        protected Dictionary<string, object> mDataMap = new Dictionary<string, object>();

        public virtual void Start()
        {
            GameEntry.BT.Run(this);
        }

        public override BTStatus Step()
        {
            if (FirstChild == null)
            {
                return BTStatus.Failure;
            }
            return FirstChild.Step();
        }

        public void FindAllChildren(BTNode pNode, List<BTNode> pList)
        {
            pList.AddRange(pNode.Children);
            for (int i = 0; i < pNode.Children.Count; i++)
            {
                BTNode node = pNode.Children[i];
                FindAllChildren(node, pList);
            }
        }

        public override void Break()
        {
            GameEntry.BT.Remove(this);
        }

        public void SetData(string key, object value)
        {
            if (string.IsNullOrEmpty(key))
            {
                return;
            }
            mDataMap[key] = value;
        }

        public object GetData(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }
            object var = null;
            mDataMap.TryGetValue(key, out var);
            return var;
        }
    }
}
