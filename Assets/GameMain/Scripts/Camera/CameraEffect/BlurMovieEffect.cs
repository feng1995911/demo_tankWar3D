using System;
using DG.Tweening;
using UnityEngine;

namespace GameMain
{
    [ExecuteInEditMode]
    public class BlurMovieEffect : CameraEffectBase
    {
        public Shader SCShader;
        private float TimeX = 1.0f;
        private Vector4 ScreenResolution;
        private Material SCMaterial;
        [Range(0, 1000)]
        public float Radius = 500.0f;
        [Range(0, 1000)]
        public float Factor = 200.0f;
        [Range(1, 8)]
        public int FastFilter = 2;

        public static float ChangeRadius;
        public static float ChangeFactor;
        public static int ChangeFastFilter;

        private float defaultValue = 500f;
        private float minValue = 0f;
        private float maxValue = 1000f;

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
        }

        public void Show(float radius)
        {
            if (!SystemInfo.supportsImageEffects)
            {
                Dispose();
                return;
            }

            enabled = true;

            ChangeRadius = radius;
            ChangeFactor = Factor;
            ChangeFastFilter = FastFilter;
            SCShader = Shader.Find("Camera/ScreenBlurMovie");
        }

        public override void Hide()
        {
            Dispose();

            enabled = false;
        }

        public override void FadeIn(float fadeTime, Action callback = null)
        {
            Show(minValue);
            DOTween.To(() => ChangeRadius, x => ChangeRadius = x, maxValue, fadeTime)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    ChangeRadius = maxValue;
                    callback?.Invoke();
                }).SetAutoKill(true);
        }

        public override void FadeOut(float fadeTime, Action callback = null)
        {
            Show(maxValue);
            DOTween.To(() => ChangeRadius, x => ChangeRadius = x, minValue, fadeTime)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    ChangeRadius = minValue;
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
                int DownScale = FastFilter;
                TimeX += Time.deltaTime;
                if (TimeX > 100) TimeX = 0;
                material.SetFloat("_TimeX", TimeX);
                material.SetFloat("_Radius", Radius / DownScale);
                material.SetFloat("_Factor", Factor);
                material.SetVector("_ScreenResolution", new Vector2(Screen.width / DownScale, Screen.height / DownScale));
                int rtW = sourceTexture.width / DownScale;
                int rtH = sourceTexture.height / DownScale;

                if (FastFilter > 1)
                {
                    RenderTexture buffer = RenderTexture.GetTemporary(rtW, rtH, 0);
                    Graphics.Blit(sourceTexture, buffer, material);
                    Graphics.Blit(buffer, destTexture);
                    RenderTexture.ReleaseTemporary(buffer);
                }
                else
                {
                    Graphics.Blit(sourceTexture, destTexture, material);
                }
            }
            else
            {
                Graphics.Blit(sourceTexture, destTexture);
            }


        }

        void OnValidate()
        {
            ChangeRadius = Radius;
            ChangeFactor = Factor;
            ChangeFastFilter = FastFilter;
        }

        void Update()
        {
            if (Application.isPlaying)
            {
                Radius = ChangeRadius;
                Factor = ChangeFactor;
                FastFilter = ChangeFastFilter;
            }
        }

        void OnDestory()
        {
            this.Dispose();
        }


    }
}
