namespace GameMain
{
    /// <summary>
    /// 行动者状态
    /// </summary>
    public enum ActorStateType
    {
        None = 0,       //空
        IsAutoToMove,   //移动中
        IsTask,         //任务中
        IsStory,        //剧情中
        IsStealth,      //潜行中
        IsSilent,       //沉默中
        IsDivine,       //无敌中
        IsSuper,        //变大中
        IsRide,         //骑行中
    }
}
