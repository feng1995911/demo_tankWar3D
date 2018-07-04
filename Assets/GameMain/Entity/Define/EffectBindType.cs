namespace GameMain
{
    /// <summary>
    /// 特效绑定位置
    /// </summary>
    public enum EffectBindType
    {
        World   = -1, //纯坐标
        Trans   = 0, //在某一个物体下面
        OwnBody = 1, //出现在自身身体位置
        OwnHead = 2, //出现在自身头部位置
        OwnFoot = 3, //出现在自身脚部位置
        OwnHand = 4, //出现在自身手上
        TarBody = 5, //出现在目标身体位置
        TarHead = 6, //出现在目标头部位置
        TarFoot = 7, //出现在目标脚部位置
        OwnVTar = 8, //出现在目标与自身的连线中点
    }           
}
