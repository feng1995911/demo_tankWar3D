namespace GameMain
{
    /// <summary>
    /// AI特征状态
    /// </summary>
    public enum AIFeatureType
    {
        CanMove,          //可移动
        CanKill,          //可击杀
        CanManualattack,  //可主动攻击
        CanPursue,        //可寻路
        CanTurn,          //可转向
        CanStun,          //可击晕
        CanAttack,        //可攻击
        CanBeatback,      //可击退
        CanBeatfly,       //可击飞
        CanBeatdown,      //可击倒
        CanWound,         //可受击
        CanReducespeed,   //可减速
        CanFixbody,       //可定身
        CanSleep,         //可睡眠
        CanVaristion,     //可变形
        CanParaly,        //可麻痹
        CanFear,          //可恐惧
    }
}
