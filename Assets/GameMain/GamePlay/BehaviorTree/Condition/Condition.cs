namespace BT
{
    /// <summary>
    /// 条件节点
    /// </summary>
    public class Condition : BTNode
    {
        public override BTStatus Step()
        {
            return CheckCondition() ? BTStatus.Success : BTStatus.Failure;
        }
    }
}
