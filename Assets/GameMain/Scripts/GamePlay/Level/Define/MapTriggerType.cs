namespace GameMain
{
    /// <summary>
    /// 地图触发类型
    /// </summary>
    public enum MapTriggerType
    {
        None = 0,         //什么也不做
        Waveset = 1,      //触发怪物波次
        Task = 2,         //触发任务
        Plot = 3,         //触发剧情
        Machine = 4,      //触发机关
        Barrier = 5,      //触发光墙  
        Region = 6,       //触发新的触发器
        Result = 7,       //触发副本结算
        Cutscene = 8,     //触发过场动画
        Portal = 9,       //触发一个传送门
        Buff = 10,        //触发Buff、光环
        Monstegroup = 11, //触发怪物堆
        Minegroup = 12,   //触发矿石堆
    }
}
