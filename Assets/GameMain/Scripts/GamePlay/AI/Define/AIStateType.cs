namespace GameMain
{
    /// <summary>
    /// AI状态
    /// </summary>
    public enum AIStateType
    {
        Empty, //空
        Idle,  //闲逛
        Fight, //战斗
        Follow,//跟随
        Patrol,//巡逻
        Dead,  //死亡
        Back,  //回家
        Chase, //追击
        Flee,  //避开
        Escape,//逃跑
        Born,  //出生
        Plot,  //剧情
    }
}
