using UnityEngine;
using System.Collections;

namespace GameMain
{
    public enum TaskType
    {
        NONE,
        THREAD = 1,   //主线任务
        BRANCH = 2,   //支线任务
        DAILY = 3,   //日常任务
    }

    public enum TaskTargetType
    {
        TYPE_NONE,
        TYPE_KILL_COPYBOSS = 1,//击杀副本BOSS
        TYPE_MAIN_PASSCOPY = 2,//通关副本（次数）
        TYPE_UPEQUIP = 3,//升级装备
        TYPE_UPPET = 4,//升级宠物
        TYPE_UPGEM = 5,//升级星石
        TYPE_UPPARTNER = 6,//升级伙伴
        TYPE_UPSKILL = 7,//升级角色技能
        TYPE_TALK = 8,//对话
        TYPE_ROB_TREASURE = 9,//夺宝
        TYPE_AREAE = 10,//竞技场战斗
        TYPE_PASS_ELITECOPY = 11,//通关精英副本
        TYPE_CHARGE_RELICE = 12,//神器充能
        TYPE_EQUIPSTAR = 13,//装备星级
        TYPE_XHJJC = 14,//虚幻竞技场
        TYPE_KILLRACE = 15,//杀死种族怪物
    }


    public enum TaskCycleType
    {
        TYPE_NONE,
        TYPE_DAILY,   //每日重置
        TYPE_WEEKLY,  //每周重置
        TYPE_SCENE,   //副本重置
    }

    public enum TaskState
    {
        QUEST_NONE,           //无类型
        QUEST_DOING,          //正在进行任务
        QUEST_CANSUBMIT,      //可提交
        QUEST_FAILED,         //任务失败
        QUEST_HASSUBMIT,      //已经提交
    }

    public enum TaskDialogActionType
    {
        TYPE_NULL     = -1, 
        TYPE_NEXT     =  0,//下一条
        TYPE_LINK     =  1,//
        TYPE_COMPLETE =  2,//完成
        TYPE_PASS     =  3,//通过
    }

    public enum TaskDialogPosType
    {
        TYPE_NO  =-1,
        TYPE_LF  = 0,//左
        TYPE_RT  = 1 //右
    }

    public enum TaskDialogRoleType
    {
        TYPE_PLAYER = 0,//玩家
        TYPE_NPC    = 1,//Npc
    }

    public enum TaskDialogContentType
    {
        TYPE_NORMAL,     //正常显示
        TYPE_TYPEEFFECT, //TypeEffect
    }

    // 任务子功能类型
    public enum TaskSubFuncType
    {
        TYPE_ERROR        =0, // 错误类型
        TYPE_TALK         =1, // 对话
        TYPE_HUNTER       =2, // 猎杀类型
        TYPE_COLLECT      =3, // 收集类
        TYPE_INTERACTIVE  =4, // 交互类型
        TYPE_CONVOY       =5, // 护送类
        TYPE_STORY        =6, // 触发剧情
        TYPE_CUTSCENE     =7, // 触发过场动画	
        TYPE_USEITEM      =8, // 使用道具类	
        TYPE_USESKILL     =9, // 使用技能
        TYPE_GATHER       =10,// 采集

    }

    //任务子功能状态
    public enum SubTaskStateType
    {
        TYPE_NONE,
        TYPE_INIT,
        TYPE_ENTER,
        TYPE_STEP,
        TYPE_EXIT,
        TYPE_STOP,
    }

    public enum TaskNPCFlagType
    {
        TYPE_NONE                 = 0,	// 没有任务处理(无标记)
        TYPE_CANSUBMIT            = 1,  // 有可以提交的任务(绿色问号)
        TYPE_CANSUBMIT_REPEAT     = 2,	// 有可以提交的重复任务(蓝色问号)
        TYPE_NOT_COMPOLETE        = 3,	// 接受了但未完成的任务(红色问号)
        TYPE_CAN_ACCEPT           = 4,	// 可以接受的任务(绿色叹号)
        TYPE_CAN_ACCEPT_REPEAT    = 5,	// 可以接受的重复任务(蓝色叹号)
        TYPE_NOT_ACCEPT           = 6,	// 没有达到接受条件的任务(红色叹号)
        TYPE_LOW_LEVEL            = 7,	// 未做过的低等级任务
        TYPE_INTERACTIVE          = 8,	// 多环节交互
    }

    public enum ConveyType
    {
        TYPE_AUTO,   //Npc自动走
        TYPE_FOLLOW, //跟随玩家
    }
}