namespace GameMain
{
    /// <summary>
    /// 技能影响类型
    /// </summary>
    public enum AffectType
    {
        None = 0,  //无
        Self = 1,  //影响自己
        Enem = 2,  //影响敌方
        Ally = 3,  //影响友方
        Each = 4,  //影响所有
        Boss = 5,  //影响Boss
        Host = 6,  //影响主人
    }
}
