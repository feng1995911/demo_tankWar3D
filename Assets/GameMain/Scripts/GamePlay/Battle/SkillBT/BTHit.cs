using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameMain;

namespace BT
{
    public class Hit : BTTask
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
                actor.ExecuteCommand(new WoundCommand());
            }
            return true;
        }

        protected override BTStatus Execute()
        {
            return BTStatus.Success;
        }

        public override BTNode DeepClone()
        {
            Hit data = new Hit();
            return data;
        }
    }
}

