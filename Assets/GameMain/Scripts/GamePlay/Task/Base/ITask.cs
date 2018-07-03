namespace GameMain
{
    public interface ITask
    {
        void Start();

        void Execute();

        void Finish();

        void Reset();

        void Stop();
    }
}
