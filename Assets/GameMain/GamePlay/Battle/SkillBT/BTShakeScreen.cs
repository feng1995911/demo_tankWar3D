using UnityEngine;
using System.Collections;
using GameMain;

namespace BT
{
    public class ShakeScreen : BTAction
    {
        protected override bool Enter()
        {
            base.Enter();
            GameEntry.Camera.ShowEffect(CameraEffectType.ScreenShake);
            return true;
        }
    }
}