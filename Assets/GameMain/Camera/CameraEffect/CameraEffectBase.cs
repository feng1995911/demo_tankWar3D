using System;
using UnityEngine;

namespace GameMain
{
    public abstract class CameraEffectBase : MonoBehaviour, ICameraEffect
    {
        public abstract void Init();

        public abstract void Show();

        public abstract void Hide();

        public abstract void FadeIn(float fadeTime,Action callback = null);

        public abstract void FadeOut(float fadeTime, Action callback = null);

        public abstract void Dispose();
    }
}
