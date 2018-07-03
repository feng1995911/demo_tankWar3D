using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameMain;

namespace BT
{
    public class BeatDown:BTTask
    {
        protected override bool Enter()
        {
            base.Enter();
            List<ActorBase> list = (List<ActorBase>)GameEntry.BT.GetData(this, Constant.Define.BTJudgeList);
            if (list == null)
            {
                return false;
            }
            for (int i = 0; i < list.Count; i++)
            {
                ActorBase actor = list[i];
                actor.ExecuteCommand(new BeatDownCommand());
            }
            return true;
        }

        protected override BTStatus Execute()
        {
            return BTStatus.Success;
        }

        public override BTNode DeepClone()
        {
            BeatDown data = new BeatDown();
            return data;
        }
    }
}

