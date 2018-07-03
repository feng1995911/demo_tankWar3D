using System;
using DG.Tweening;
using UnityEngine;

namespace GameMain
{
    [ExecuteInEditMode]
    public class ScreenFadeEffect : CameraEffectBase
    {
        public Texture2D mFadeTexture2D;
        [Range(0, 1)]
        public float alpha = 0;
        public Rect rect = new Rect(0, 0, 2000, 2000);

        private float minValue = 0;
        private float maxValue = 1f;


        void Start()
        {
            Init();
        }

        void OnGUI()
        {
            if (mFadeTexture2D == null)
            {
                return;
            }
            Color color = Color.black;
            color.a = alpha;
            Graphics.DrawTexture(rect, mFadeTexture2D, rect, 0, 0, 0, 0, color);
        }

        public override void Init()
        {
            Hide();
        }

        public override void Show()
        {
            enabled = true;

            if (mFadeTexture2D == null)
                mFadeTexture2D = Resources.Load<Texture2D>("Texture/ScreenFade");

            mFadeTexture2D = new Texture2D(2, 2, TextureFormat.ARGB32, false);
        }

        public override void Hide()
        {
            enabled = false;
        }

        public override void FadeIn(float fadeTime, Action callback = null)
        {
            alpha = minValue;
            DOTween.To(() => alpha, x => alpha = x, maxValue, fadeTime)
             .SetEase(Ease.Linear)
             .OnComplete(() =>
             {
                 alpha = maxValue;
                 callback?.Invoke();
             }).SetAutoKill(true);
        }

        public override void FadeOut(float fadeTime, Action callback = null)
        {
            alpha = maxValue;
            DOTween.To(() => alpha, x => alpha = x, minValue, fadeTime)
             .SetEase(Ease.Linear)
             .OnComplete(() =>
             {
                 alpha = minValue;
                 callback?.Invoke();
             }).SetAutoKill(true);
        }

        public override void Dispose()
        {
            enabled = false;
        }
    }
}
