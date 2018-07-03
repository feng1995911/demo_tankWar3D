namespace BT
{
    public class BTAction : BTNode
    {
        private BTStatus m_Status = BTStatus.Initial;
        private BTStatus m_Result = BTStatus.Initial;

        public sealed override BTStatus Step()
        {
            m_Result = BTStatus.Success;
            if(m_Status == BTStatus.Initial)
            {
                bool checkCondition = Enter();
                m_Status = checkCondition ? BTStatus.Running : BTStatus.Failure;
            }
            if (m_Status == BTStatus.Running)
            {
                bool success = Prepare();
                if (success)
                {
                    m_Result = Execute();
                    if (m_Result != BTStatus.Running)
                    {
                        Exit();
                        m_Status = BTStatus.Initial;
                        m_IsRunning = false;
                    }
                    else
                    {
                        m_IsRunning = true;
                    }
                }
                else
                {
                    m_IsRunning = true;
                    return BTStatus.Running;
                }
            }
            return m_Result;
        }

        protected virtual BTStatus Execute()
        {
            return BTStatus.Failure;
        }

        protected virtual bool Enter()
        {
            return true;
        }

        protected virtual bool Prepare()
        {
            return true;
        }

        protected virtual void Exit()
        {

        }

        public override void Clear()
        {
            base.Clear();
            if (m_Status != BTStatus.Initial)
            {
                Exit();
                m_Status = BTStatus.Initial;
            }
        }
    }
}
