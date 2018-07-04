using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace GameMain
{
    [ExecuteInEditMode]
    public class WaterDropEffect : CameraEffectBase
    {
        public Shader SCShader;
        private float TimeX = 1.0f;
        private Vector4 ScreenResolution;
        private Material SCMaterial;

        [Range(-1, 1)]
        public float CenterX = 0f;
        [Range(-1, 1)]
        public float CenterY = 0f;
        [Range(0, 10)]
        public float WaveIntensity = 1;
        [Range(0, 20)]
        public int NumberOfWaves = 5;

        public static float ChangeCenterX;
        public static float ChangeCenterY;
        public static float ChangeWaveIntensity;
        public static int ChangeNumberOfWaves;

        private float defaultValue = 1f;
        private float minValue = 0f;
        private float maxValue = 1.5f;

        private TweenerCore<float,float,FloatOptions> showTweenerCore;

        Material material
        {
            get
            {
                if (SCMaterial == null)
                {
                    SCMaterial = new Material(SCShader);
                    SCMaterial.hideFlags = HideFlags.HideAndDontSave;
                }
                return SCMaterial;
            }
        }

        void Start()
        {
            Init();
        }

        public override void Init()
        {
            Hide();
        }

        public override void Show()
        {
            Show(defaultValue);
            showTweenerCore = DOTween.To(() => ChangeWaveIntensity, x => ChangeWaveIntensity = x, maxValue, 1)
                .SetEase(Ease.Linear).SetLoops(-1,LoopType.Yoyo);
        }

        public void Show(float value)
        {
            if (!SystemInfo.supportsImageEffects)
            {
                Dispose();
                return;
            }

            enabled = true;

            ChangeCenterX = CenterX;
            ChangeCenterY = CenterY;
            ChangeWaveIntensity = value;
            ChangeNumberOfWaves = NumberOfWaves;

            SCShader = Shader.Find("Camera/ScreenDistortionWaterDrop");
        }

        public override void Hide()
        {
            if (showTweenerCore != null)
                showTweenerCore.Kill();

            Dispose();

            enabled = false;
        }

        public override void FadeIn(float fadeTime, Action callback = null)
        {
            Show(minValue);
            DOTween.To(() => ChangeWaveIntensity, x => ChangeWaveIntensity = x, maxValue, fadeTime)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    ChangeWaveIntensity = maxValue;
                    callback?.Invoke();
                }).SetAutoKill(true);
        }

        public override void FadeOut(float fadeTime, Action callback = null)
        {
            Show(maxValue);
            DOTween.To(() => ChangeWaveIntensity, x => ChangeWaveIntensity = x, minValue, fadeTime)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    ChangeWaveIntensity = minValue;
                    callback?.Invoke();
                }).SetAutoKill(true);
        }

        public override void Dispose()
        {
            if (SCMaterial)
            {
                DestroyImmediate(SCMaterial);
            }
        }


        void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
        {
            if (SCShader != null)
            {
                TimeX += Time.deltaTime;
                if (TimeX > 100) TimeX = 0;
                material.SetFloat("_TimeX", TimeX);
                material.SetVector("_ScreenResolution", new Vector2(Screen.width, Screen.height));
                material.SetFloat("_CenterX", CenterX);
                material.SetFloat("_CenterY", CenterY);
                material.SetFloat("_WaveIntensity", WaveIntensity);
                material.SetInt("_NumberOfWaves", NumberOfWaves);
                Graphics.Blit(sourceTexture, destTexture, material);
            }
            else
            {
                Graphics.Blit(sourceTexture, destTexture);
            }
        }

        void OnValidate()
        {
            ChangeCenterX = CenterX;
            ChangeCenterY = CenterY;
            ChangeWaveIntensity = WaveIntensity;
            ChangeNumberOfWaves = NumberOfWaves;
        }

        void Update()
        {
            if (Application.isPlaying)
            {
                CenterX = ChangeCenterX;
                CenterY = ChangeCenterY;
                WaveIntensity = ChangeWaveIntensity;
                NumberOfWaves = ChangeNumberOfWaves;
            }
        }

        void OnDestory()
        {
            this.Dispose();
        }

    }
}
