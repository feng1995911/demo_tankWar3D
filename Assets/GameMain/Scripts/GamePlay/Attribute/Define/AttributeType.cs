namespace GameMain
{
    /// <summary>
    /// 属性类型
    /// </summary>
    public enum AttributeType
    {
        Unkonwn     = 0,   //未知
        MaxHp       = 1,   //最大生命值  
        Hp          = 2,   //生命值
        MaxMp       = 3,   //最大魔法值
        Mp          = 4,   //魔法值
        Attack      = 5,   //攻击力
        Defense     = 6,   //防御力
        Speed       = 7,   //速度
        Crit        = 8,   //爆击
        CritDamage  = 9,   //爆击伤害
        SuckBlood   = 10,  //吸血
        HpRecover   = 11,  //生命恢复
        MpRecover   = 12,  //魔法恢复
        Dodge       = 13,  //闪避
        Hit         = 14,  //命中
        Absorb      = 15,  //伤害吸收
        Reflex      = 16,  //伤害反弹
    }
}
