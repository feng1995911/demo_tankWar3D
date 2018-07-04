namespace GameMain
{
    /// <summary>
    /// 飞行物体销毁方式
    /// </summary>
    public enum FlyObjDeadType
    {
        UntilLifeTimeEnd = 0,    //生命周期结束
        UntilColliderTar = 1,    //触碰目标结束
        DirectDestroy    = 2,    //暴力销毁
    }
}
