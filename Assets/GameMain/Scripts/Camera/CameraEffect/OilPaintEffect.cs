using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace GameMain
{
    [ExecuteInEditMode]
    public class OilPaintEffect : CameraEffectBase
    {
        public Shader SCShader;
        private Material SCMaterial;

        [Range(0, 5), Tooltip("分辨率比例值")]
        public float ResolutionValue = 0.9f;
        [Range(1, 30), Tooltip("半径的值，决定了迭代的次数")]
        public int RadiusValue = 5;

        public static float ChangeValue;
        public static int ChangeValue2;

        private float defaultValue = 0.5f;
        private float minValue = 0f;
        private float maxValue = 1.5f;

        private TweenerCore<float, float, FloatOptions> showTweenerCore;

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
            showTweenerCore = DOTween.To(() => ChangeValue, x => ChangeValue = x, maxValue, 1)
      .SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
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
            ChangeValue2 = RadiusValue;

            SCShader = Shader.Find("Camera/ScreenOilPaintEffect");
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
                material.SetFloat("_ResolutionValue", ResolutionValue);
                material.SetInt("_Radius", RadiusValue);
                material.SetVector("_ScreenResolution", new Vector4(sourceTexture.width, sourceTexture.height, 0.0f, 0.0f));

                //拷贝源纹理到目标渲染纹理，加上我们的材质效果
                Graphics.Blit(sourceTexture, destTexture, material);
            }
            else
            {
                Graphics.Blit(sourceTexture, destTexture);
            }
        }

        void OnValidate()
        {
            ChangeValue = ResolutionValue;
            ChangeValue2 = RadiusValue;
        }

        void Update()
        {
            if (Application.isPlaying)
            {
                ResolutionValue = ChangeValue;
                RadiusValue = ChangeValue2;
            }
        }

        void OnDestory()
        {
            this.Dispose();
        }
    }
}
