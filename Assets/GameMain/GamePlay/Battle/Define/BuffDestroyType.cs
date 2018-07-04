namespace GameMain
{
    /// <summary>
    ///Buff销毁类型
    /// </summary>
    public enum BuffDestroyType
    {
        None = 0,

        /// <summary>
        /// 战斗结束
        /// </summary>
        BattleEnd,

        /// <summary>
        /// 持续时间结束
        /// </summary>
        TimeEnd,

        /// <summary>
        /// 掉线
        /// </summary>
        Offline,

        /// <summary>
        /// 死亡
        /// </summary>
        Dead
    }
}
