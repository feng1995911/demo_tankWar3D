using System;
using DG.Tweening;
using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// 屏幕抖动特效
    /// </summary>
    public class ScreenShakeEffect: CameraEffectBase
    {
        [SerializeField]
        private float m_DefaultDuration = 1f;

        [SerializeField]
        private Vector3 m_DefaultShakePos = new Vector3(0.3f, 0.3f, 0.3f);



        public override void Init()
        {
            
        }

        public override void Show()
        {
            GameEntry.Camera.MainCamera.transform.parent?.DOShakePosition(m_DefaultDuration, m_DefaultShakePos).SetAutoKill(true);
        }

        public override void Hide()
        {
            
        }

        public override void FadeIn(float fadeTime, Action callback = null)
        {
            throw new NotImplementedException();
        }

        public override void FadeOut(float fadeTime, Action callback = null)
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
       
        }
    }
}
