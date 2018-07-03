namespace GameMain
{
    /// <summary>
    /// 战斗行为类型
    /// </summary>
    public enum BattleActType
    {
        None      = 0,  //无
        Addattr   = 1,  //增加属性
        Subattr   = 2,  //减少属性
        Lddattr   = 3,  //间隔增加属性
        Lubattr   = 4,  //间隔减少属性
        Super     = 5,  //霸体
        Variation = 6,  //变形
        Stun      = 7,  //昏迷
        Fixbody   = 8,  //定身
        Stealth   = 9,  //隐身
        Frozen    = 10, //冻住
        Blind     = 11, //致盲
        Silent    = 12, //沉默
        Sleep     = 13, //睡眠
        Absorb    = 14, //吸收伤害
        Wild      = 15, //狂暴
        Divive    = 16, //无敌
        Paraly    = 17, //麻痹
        Fear      = 18, //恐惧
        Reflex    = 19, //反弹伤害
        Dead      = 20, //倒计时死亡

        Addbuff   = 21,  //添加BUFF
        Dispel    = 22,  //驱散
        Hitfly    = 23,  //击飞
        Hitdown   = 24,  //击倒
        Hitback   = 25,  //击退
        Anim      = 26,  //动画
        Sound     = 27,  //声音
        Charm     = 28,  //蓄力
        Camera    = 29,  //相机特效
        Summon    = 30,  //召唤
        Flash     = 31,  //闪现
        Spurt     = 32,  //冲锋
        Float     = 33,  //浮空

        Push      = 34,  //推人
        Effect    = 35,  //特效
        Tip       = 36,  //技能提示
        Taunt     = 37,  //嘲讽
        Color     = 38,  //变色
        Shader    = 39,  //Shader效果
        Scale     = 40,  //变换大小
        CreateObj = 41,  //创建一个物体
    }
}
