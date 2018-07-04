using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameMain
{
    /// <summary>
    /// 命令类型
    /// </summary>
    public enum CommandType : byte
    {
        Unknown,        //未知
        Idle,           //空闲
        Runto,          //寻路
        TurnTo,         //转向
        Useskill,       //使用技能
        Loading,        //加载场景
        Talk,           //谈话
        Dead,           //死亡
        Moveto,         //玩家强制移动
        Ride,           //骑上骑乘
        Reborn,         //重生
        Mine,           //采集
        Interactive,    //交互

        Frost,          //冰冻
        Stun,           //昏迷
        Float,          //浮空
        Variation,      //变形
        Palsy,          //麻痹
        Sleep,          //睡眠
        Fixbody,        //定身
        Grab,           //被抓取
        Hook,           //被勾取
        Roll,           //滚地
        Beatback,       //被击退
        Beatdown,       //被击倒
        Beatfly,        //被击飞
        Fear,           //恐惧
        Fly,            //飞行
        Wound,          //受击
        Blind,          //致盲
        Jump,           //跳跃
        Stealth,        //隐身
        Silent,         //沉默
    }
}
