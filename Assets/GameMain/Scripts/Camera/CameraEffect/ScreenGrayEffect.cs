using System;
using UnityEngine;

namespace GameMain
{
    [ExecuteInEditMode]
    public class ScreenGrayEffect : CameraEffectBase
    {
        public Shader SCShader;
        private float TimeX = 1.0f;
        private Vector4 ScreenResolution;
        private Material SCMaterial;

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
            if (!SystemInfo.supportsImageEffects)
            {
                Dispose();
                return;
            }

            SCShader = Shader.Find("Camera/ScreenGrayScale");
            enabled = true;
        }

        public override void Hide()
        {
            Dispose();

            enabled = false;
        }

        public override void FadeIn(float fadeTime, Action callback = null)
        {
            Show();
            callback?.Invoke();
        }

        public override void FadeOut(float fadeTime, Action callback = null)
        {
            Hide();
            callback?.Invoke();
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
                material.SetVector("_ScreenResolution", new Vector4(sourceTexture.width, sourceTexture.height, 0.0f, 0.0f));
                Graphics.Blit(sourceTexture, destTexture, material);
            }
            else
            {
                Graphics.Blit(sourceTexture, destTexture);
            }
        }

        void OnDestory()
        {
            this.Dispose();
        }
    }

}
