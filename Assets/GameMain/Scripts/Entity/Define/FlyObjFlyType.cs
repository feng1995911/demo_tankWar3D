using System;

namespace GameMain
{
    /// <summary>
    /// 飞行物体飞行类型
    /// </summary>
    public enum FlyObjFlyType
    {
        None   = 0,  //无
        Stay   = 1,  //停留原地
        Line   = 2,  //直线
        Pursue = 3,  //追踪
        Throw  = 4,  //抛物线
        Cross  = 5,  //回旋
        Back   = 6,  //返回施法者
    }
}
