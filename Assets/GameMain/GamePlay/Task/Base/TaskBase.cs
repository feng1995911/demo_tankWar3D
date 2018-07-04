namespace GameMain
{
    public abstract class TaskBase<T> :ITask where T :SubTaskBase
    {
        public T Data { get; protected set; }
        public SubTaskStateType State { get; protected set; }
        public int TaskID { get; private set; }
        public int TaskStep { get; private set; }

        public virtual void Accept(T pData, int pTaskID, int pStep)
        {
            this.Data = pData;
            this.TaskID = pTaskID;
            this.TaskStep = pStep;
            this.State = SubTaskStateType.TYPE_INIT;
        }

        public virtual void Start()
        {

        }
        public virtual void Execute()
        {

        }
        public virtual void Stop()
        {

        }
        public virtual void Reset()
        {

        }

        public virtual void Finish()
        {
            //TODO:提交任务
           // ZSTask.Instance.OnSubmitDailyTask(TaskID, TaskStep);
        }

    }
}
