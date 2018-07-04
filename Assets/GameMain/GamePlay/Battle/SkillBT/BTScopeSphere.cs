using UnityEngine;
using System.Collections;
using GameMain;

namespace BT
{
    public class ScopeSphere : BTScopeShape
    {
        public float Radius;
        public Collider collider;

        public override bool IsTouch(ActorBase actor)
        {
            if (actor == null || actor.CachedTransform == null)
            {
                return false;
            }
            if (Radius <= 0)
            {
                return false;
            }
            if (GlobalTools.GetHorizontalDistance(Center.position, actor.Pos) < actor.Radius)
            {
                return true;
            }
            return false;
        }
    }
}