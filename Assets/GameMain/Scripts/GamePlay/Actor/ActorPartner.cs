using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GameMain
{
    public class ActorPartner : ActorBase
    {
        public ActorPartner(RoleEntityBase entity, ActorType type, BattleCampType camp, CharacterController cc, Animator anim) : base(entity, type, camp, cc, anim)
        {

        }

    }
}
