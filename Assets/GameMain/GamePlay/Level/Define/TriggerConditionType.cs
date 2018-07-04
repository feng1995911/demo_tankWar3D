namespace GameMain
{
    /// <summary>
    /// 触发条件类型
    /// </summary>
    public enum TriggerConditionType
    {
        InitRegion  = 0,    //触发器初始化时触发
        EnterRegion = 1,    //进入区域
        LeaveRegion = 2,    //离开区域
        WavesetEnd  = 3,    //波次结束后触发
        WaveIndex   = 4,    //第几波怪触发
    }
}
