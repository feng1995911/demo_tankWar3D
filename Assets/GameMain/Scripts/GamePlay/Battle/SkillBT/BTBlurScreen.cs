using UnityEngine;
using System.Collections;
using GameMain;

namespace BT
{
    public class BlurScreen : BTAction
    {
        protected override bool Enter()
        {
            base.Enter();
            GameEntry.Camera.ShowEffect(CameraEffectType.BlurRadial);
            return true;
        }
    }
}