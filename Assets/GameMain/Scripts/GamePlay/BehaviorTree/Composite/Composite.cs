namespace BT
{
    /// <summary>
    /// 复合节点
    /// </summary>
    public class Composite : BTNode
    {
        protected int m_ActiveIndex = -1;
        protected int m_PreviaIndex = -1;

        public override void Clear()
        {
            base.Clear();
            m_ActiveIndex = -1;
            m_PreviaIndex = -1;
        }
    }
}
