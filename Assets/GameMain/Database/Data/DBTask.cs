using GameFramework;

namespace GameMain
{
    public class DBTask : DBRowBase
    {
        public DBTask(int id, int userId) : base(id, userId)
        {

        }

        public int ThreadTaskID   { get; set; } = 0;
        public int ThreadTaskStep { get; set; } = 0;
        public int BranchTaskID   { get; set; } = 0;
        public int BranchTaskStep { get; set; } = 0;
    }
}
