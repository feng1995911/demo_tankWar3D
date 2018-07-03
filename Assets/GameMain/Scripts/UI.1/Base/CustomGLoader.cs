using System;
using FairyGUI;
using GameFramework;
using GameFramework.Resource;
using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// 自定义FairyGui装载器
    /// </summary>
    public class CustomGLoader : GLoader
    {
        private readonly LoadAssetCallbacks m_LoadAssetCallbacks;


        public CustomGLoader()
        {
            m_LoadAssetCallbacks = new LoadAssetCallbacks(LoadTextureSuccessCallback,
                LoadTextureFailureCallback);
        }


        protected override void LoadExternal()
        {
            GameEntry.Resource.LoadAsset(url, m_LoadAssetCallbacks);
        }

        protected override void FreeExternal(NTexture texAsset)
        {
            if(texAsset != null)
               Resources.UnloadAsset(texAsset.nativeTexture);
        }

        private void LoadTextureFailureCallback(string assetName, LoadResourceStatus status, string errorMessage, object userData)
        {
            Log.Error("Load Texture Fail.AssetName:{0}", assetName);
            onExternalLoadFailed();
        }

        private void LoadTextureSuccessCallback(string assetName, object asset, float duration, object userData)
        {
            Texture2D tex = asset as Texture2D;
            onExternalLoadSuccess(new NTexture(tex));
        }

    }
}
