using System;
using DG.Tweening;
using UnityEngine;

namespace GameMain
{
    [ExecuteInEditMode]
    public class BlurRadialEffect : CameraEffectBase
    {
        public Shader SCShader;
        private float TimeX = 1.0f;
        private Vector4 ScreenResolution;
        private Material SCMaterial;
        [Range(-0.5f, 0.5f)]
        public float Intensity = 0.125f;
        [Range(-2f, 2f)]
        public float MovX = 0.5f;
        [Range(-2f, 2f)]
        public float MovY = 0.5f;
        [Range(0f, 10f)]
        private float blurWidth = 1f;
        public static float ChangeValue;
        public static float ChangeValue2;
        public static float ChangeValue3;
        public static float ChangeValue4;

        private float defaultValue = 0;
        private float minValue = -0.1f;
        private float maxValue = 0f;
        private bool isShowing = false;

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

        public override void Init()
        {
            Hide();
        }

        public override void Show()
        {
            if(isShowing)
                return;

            Show(0);
            FadeIn(0.3f, () =>
            {
                Hide();
                isShowing = false;
            });
        }

        public void Show(float value)
        {
            if (!SystemInfo.supportsImageEffects)
            {
                Dispose();
                return;
            }

            enabled = true;

            ChangeValue = value;
            ChangeValue2 = MovX;
            ChangeValue3 = MovY;
            ChangeValue4 = blurWidth;
            SCShader = Shader.Find("Camera/ScreenBlurRadial");
        }

        public override void Hide()
        {
            Dispose();

            enabled = false;
        }

        public override void FadeIn(float fadeTime, Action callback = null)
        {
            Show(minValue);
            DOTween.To(() => ChangeValue, x => ChangeValue = x, maxValue, fadeTime)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    ChangeValue = maxValue;
                    callback?.Invoke();
                }).SetAutoKill(true);
        }

        public override void FadeOut(float fadeTime, Action callback = null)
        {
            Show(maxValue);
            DOTween.To(() => ChangeValue, x => ChangeValue = x, minValue, fadeTime)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    ChangeValue = minValue;
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
                material.SetFloat("_Value", Intensity);
                material.SetFloat("_Value2", MovX);
                material.SetFloat("_Value3", MovY);
                material.SetFloat("_Value4", blurWidth);
                material.SetVector("_ScreenResolution", new Vector4(sourceTexture.width, sourceTexture.height, 0.0f, 0.0f));
                Graphics.Blit(sourceTexture, destTexture, material);
            }
            else
            {
                Graphics.Blit(sourceTexture, destTexture);
            }
        }

        void OnValidate()
        {
            ChangeValue = Intensity;
            ChangeValue2 = MovX;
            ChangeValue3 = MovY;
            ChangeValue4 = blurWidth;
        }

        void Update()
        {
            if (Application.isPlaying)
            {
                Intensity = ChangeValue;
                MovX = ChangeValue2;
                MovY = ChangeValue3;
                blurWidth = ChangeValue4;
            }
        }

        void OnDestory()
        {
            this.Dispose();
        }
    }
}
