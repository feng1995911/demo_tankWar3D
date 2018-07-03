namespace GameMain
{
    /// <summary>
    /// 行动者状态类型
    /// </summary>
    public enum ActorFsmStateType : int
    {
        FSM_EMPTY = 0,           //空状态
        FSM_BORN,                //出生
        FSM_IDLE,                //待机
        FSM_TURN,                //转向

        FSM_WALK,                //漫步
        FSM_RUN,                 //跑

        FSM_SKILL,               //攻击
        FSM_DEAD,                //死亡
        FSM_REBORN,              //重生

        FSM_WOUND,               //受击
        FSM_BEATBACK,            //击退
        FSM_BEATDOWN,            //击倒
        FSM_BEATFLY,             //击飞
        FSM_FLOATING,            //浮空

        FSM_FROST,               //冰冻
        FSM_STUN,                //昏迷
        FSM_FIXBODY,             //定身
        FSM_VARIATION,           //变形
        FSM_FEAR,                //恐惧
        FSM_SLEEP,               //睡眠
        FSM_PARALY,              //麻痹
        FSM_BLIND,               //致盲

        FSM_PICK,                //捡起

        FSM_RIDEIDLE,            //骑乘闲置
        FSM_RIDERUN,             //骑乘跑

        FSM_DROP,                //下落
        FSM_TALK,                //说话
        FSM_HOOK,                //钩子
        FSM_GRAB,                //抓取
        FSM_FLY,                 //飞行
        FSM_RAGDOLL,             //布娃娃
        FSM_ROLL,                //翻滚
        FSM_JUMP,                //跳跃

        FSM_DANCE,               //跳舞
        FSM_MINE,                //采集状态
        FSM_INTERACTIVE,         //交互
    }
}
