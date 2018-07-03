using GameFramework;
using UnityEngine;
using XLua;

namespace GameMain
{
    /// <summary>
    /// Lua界面，管理lua界面的生命周期等
    /// </summary>
    public class FairyGuiLuaForm : FairyGuiForm
    {
        private GameFrameworkAction<object> luaOnInit;
        private GameFrameworkAction<object> luaOnOpen;
        private GameFrameworkAction<object> luaOnClose;
        private GameFrameworkAction luaOnPause;
        private GameFrameworkAction luaOnResume;
        private GameFrameworkAction luaOnCover;
        private GameFrameworkAction luaOnReveal;
        private GameFrameworkAction luaOnRefocus;
        private GameFrameworkAction<float,float> luaOnUpdate;
        private GameFrameworkAction<int, int> luaOnDepthChanged;
        private GameFrameworkAction luaOnDestroy;
        private LuaTable m_luaForm;
        private LuaEnv m_luaEnv;
        private object m_UserData;
        private bool m_visible;

        /// <summary>
        /// 界面重载
        /// </summary>
        public void Reload()
        {
            luaOnInit?.Invoke(m_UserData);

            if (m_visible)
            {
                luaOnOpen?.Invoke(m_UserData);
            }
            else
            {
                luaOnClose?.Invoke(m_UserData);
            }
        }

        /// <summary>
        /// 界面初始化。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            m_UserData = userData;

            m_luaEnv = GameEntry.Lua.LuaEnv;
            string luaFormName = GameEntry.FairyGui.GetLuaForm(m_FormId);
            if (string.IsNullOrEmpty(luaFormName))
            {
                Log.Error("luaForm is invalid. ID:{0}", m_FormId);
                return;
            }

            string assetName = AssetUtility.GetLuaAsset(luaFormName);
            string script = string.Empty;

            if (GameEntry.Base.EditorResourceMode)
            {
                script = GameEntry.Resource.LoadTextAsset(assetName);
            }
            else
            {
                TextAsset asset = GameEntry.Resource.LoadAssetSync(assetName) as TextAsset;
                if (asset == null)
                {
                    Log.Error("Can no load Lua file:{0}", assetName);
                    return;
                }
                script = asset.text;
                GameEntry.Resource.UnloadAsset(asset);
            }

            if (string.IsNullOrEmpty(script))
            {
                Log.Error("Lua script file is empty. file:{0}", assetName);
                return;
            }

            m_luaForm = m_luaEnv.NewTable();

            LuaTable meta = m_luaEnv.NewTable();
            meta.Set("__index",m_luaEnv.Global);
            m_luaForm.SetMetaTable(meta);
            meta.Dispose();

            m_luaForm.Set("self", this);
            m_luaEnv.DoString(script, luaFormName, m_luaForm);

            luaOnInit = m_luaForm.Get<GameFrameworkAction<object>>("OnInit");
            luaOnOpen = m_luaForm.Get<GameFrameworkAction<object>>("OnOpen");
            luaOnClose = m_luaForm.Get<GameFrameworkAction<object>>("OnClose");
            luaOnPause = m_luaForm.Get<GameFrameworkAction>("OnPause");
            luaOnResume = m_luaForm.Get<GameFrameworkAction>("OnResume");
            luaOnCover = m_luaForm.Get<GameFrameworkAction>("OnCover");
            luaOnReveal = m_luaForm.Get<GameFrameworkAction>("OnReveal");
            luaOnRefocus = m_luaForm.Get<GameFrameworkAction>("OnRefocus");
            luaOnUpdate = m_luaForm.Get<GameFrameworkAction<float, float>>("OnUpdate");
            luaOnDepthChanged = m_luaForm.Get<GameFrameworkAction<int, int>>("OnDepthChanged");
            luaOnDestroy = m_luaForm.Get<GameFrameworkAction>("OnDestroy");

            luaOnInit?.Invoke(userData);
        }

        /// <summary>
        /// 界面打开。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            m_visible = true;

            luaOnOpen?.Invoke(userData);
        }

        /// <summary>
        /// 界面关闭。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnClose(object userData)
        {
            base.OnClose(userData);
            m_visible = false;

            luaOnClose?.Invoke(userData);
        }

        /// <summary>
        /// 界面暂停。
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();
            luaOnPause?.Invoke();
        }

        /// <summary>
        /// 界面暂停恢复。
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
            luaOnResume?.Invoke();
        }

        /// <summary>
        /// 界面遮挡。
        /// </summary>
        protected override void OnCover()
        {
            base.OnCover();
            luaOnCover?.Invoke();
        }

        /// <summary>
        /// 界面遮挡恢复。
        /// </summary>
        protected override void OnReveal()
        {
            base.OnReveal();
            luaOnReveal?.Invoke();
        }

        /// <summary>
        /// 界面激活。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnRefocus(object userData)
        {
            base.OnRefocus(userData);
            luaOnRefocus?.Invoke();
        }

        /// <summary>
        /// 界面轮询。
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            luaOnUpdate?.Invoke(elapseSeconds, realElapseSeconds);
        }

        /// <summary>
        /// 界面深度改变。
        /// </summary>
        /// <param name="uiGroupDepth">界面组深度。</param>
        /// <param name="depthInUIGroup">界面在界面组中的深度。</param>
        protected override void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
        {
            base.OnDepthChanged(uiGroupDepth, depthInUIGroup);
            luaOnDepthChanged?.Invoke(uiGroupDepth, depthInUIGroup);
        }

        /// <summary>
        /// 界面销毁
        /// </summary>
        public override void Clear()
        {
            luaOnDestroy?.Invoke();

            luaOnInit = null;
            luaOnOpen = null;
            luaOnClose = null;
            luaOnPause = null;
            luaOnResume = null;
            luaOnCover = null;
            luaOnReveal = null;
            luaOnRefocus = null;
            luaOnUpdate = null;
            luaOnDepthChanged = null;
            luaOnDestroy = null;
            m_luaForm?.Dispose();

            base.Clear();
        }
    }
}
