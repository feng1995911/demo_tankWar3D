using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameMain
{
    /// <summary>
    /// 地图类型
    /// </summary>
    public enum MapHolderType
    {
        Born,           //出生点
        MonsterGroup,   //怪物组
        WaveSet,        //怪物波
        Barrier,        //障碍物
        Region,         //范围
        Portal,         //传送门
        Npc,            //NPC
        MineGroup,      //矿石组
        Role,           //角色
    }
}
