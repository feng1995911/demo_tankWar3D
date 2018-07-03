using System.Collections;
using FairyGUI;
using UnityEngine;
using UnityGameFramework.Runtime;
using System;
using System.Collections.Generic;

namespace GameMain
{
    /// <summary>
    /// 屏幕适配方式
    /// </summary>
    public enum FitScreen
    {
        None,
        FitSize,
        FitWidthAndSetMiddle,
        FitHeightAndSetCenter
    }

    /// <summary>
    /// FairyGUI界面基类
    /// </summary>
    [ExecuteInEditMode]
    [AddComponentMenu("UI/FairyGuiForm")]
    public class FairyGuiForm : UIFormLogic, EMRenderTarget
    {             
        public Container m_Container { get; private set; }
        
        [SerializeField]
        protected int m_FormId = 0;
        [SerializeField]
        protected string m_PackagePath;
        [SerializeField]
        protected string m_PackageName;
        [SerializeField]
        protected string m_ComponentName;
        [SerializeField]
        protected FitScreen m_FitScreen;
        [SerializeField]
        protected int m_DepthFactor = 100;
        [SerializeField]
        protected int m_SortingOrder;
        [SerializeField]
        protected float m_FadeTime = 0.3f;
        [SerializeField]
        protected RenderMode m_RenderMode = RenderMode.ScreenSpaceOverlay;
        [SerializeField]
        protected bool m_FairyBatching = false;
        [SerializeField]
        protected bool m_TouchDisabled = false;       
        [SerializeField]
        protected HitTestMode m_HitTestMode = HitTestMode.Default;
        [SerializeField]
        protected bool m_SetNativeChildrenOrder = false;

        protected Vector3 m_Position;
        protected Vector3 m_Scale = new Vector3(1, 1, 1);
        protected Vector3 m_Rotation = new Vector3(0, 0, 0);
        protected Camera m_RenderCamera = null;
        protected Vector2 m_CachedUISize;

        [System.NonSerialized]
        protected int screenSizeVer;
        [System.NonSerialized]
        protected Rect uiBounds; //Track bounds even when UI is not created, edit mode

        private GComponent _ui = null;
        [NonSerialized]
        private bool _created;

        List<Renderer> _renders;

        public int OriginalDepth
        {
            get;
            private set;
        }

        public int Depth
        {
            get
            {
                return _ui.sortingOrder;
            }
        }

        /// <summary>
        /// 界面初始化。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            if (Application.isPlaying)
            {
                if (this.m_Container == null)
                {
                    CreateContainer();

                    if (!string.IsNullOrEmpty(m_PackagePath) && UIPackage.GetByName(m_PackageName) == null)
                        GameEntry.FairyGui.AddPackage(m_PackagePath);
                }
                else
                    this.m_Container._disabled = false;
            }
            else
            {
                //不在播放状态时我们不在OnEnable创建，因为Prefab也会调用OnEnable，延迟到Update里创建（Prefab不调用Update)
                //每次播放前都会disable/enable一次。。。
                if (m_Container != null)//如果不为null，可能是因为Prefab revert， 而不是因为Assembly reload，
                    Clear();

                EMRenderSupport.Add(this);
                screenSizeVer = 0;
                uiBounds.position = m_Position;
                uiBounds.size = m_CachedUISize;
                if (uiBounds.size == Vector2.zero)
                    uiBounds.size = new Vector2(30, 30);
            }

            if (!_created && Application.isPlaying)
                CreateUI_PlayMode();

            OriginalDepth = UI.sortingOrder;
            Transform transform = GetComponent<Transform>();
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        /// <summary>
        /// 界面打开。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            if (Application.isPlaying)
            {
                if (this.m_Container == null)
                {
                    CreateContainer();

                    if (!string.IsNullOrEmpty(m_PackagePath) && UIPackage.GetByName(m_PackageName) == null)
                        GameEntry.FairyGui.AddPackage(m_PackagePath);
                }
                else
                    this.m_Container._disabled = false;
            }

            UI.alpha = 0f;
            StopAllCoroutines();
            StartCoroutine(UI.FadeToAlpha(1f, m_FadeTime));
        }

        /// <summary>
        /// 界面关闭。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnClose(object userData)
        {
            base.OnClose(userData);

            if (Application.isPlaying)
            {
                if (this.m_Container != null)
                    this.m_Container._disabled = true;
            }
            else
                EMRenderSupport.Remove(this);
        }

        /// <summary>
        /// 界面暂停。
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();
        }

        /// <summary>
        /// 界面暂停恢复。
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();

            UI.alpha = 0f;
            StopAllCoroutines();
            StartCoroutine(UI.FadeToAlpha(1f, m_FadeTime));
        }

        /// <summary>
        /// 界面遮挡。
        /// </summary>
        protected override void OnCover()
        {
            base.OnCover();
        }

        /// <summary>
        /// 界面遮挡恢复。
        /// </summary>
        protected override void OnReveal()
        {
            base.OnReveal();
        }

        /// <summary>
        /// 界面激活。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnRefocus(object userData)
        {
            base.OnRefocus(userData);
        }

        /// <summary>
        /// 界面轮询。
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            if (screenSizeVer != StageCamera.screenSizeVer)
                HandleScreenSizeChanged();
            transform.localScale = Vector3.one;
        }

        /// <summary>
        /// 界面深度改变。
        /// </summary>
        /// <param name="uiGroupDepth">界面组深度。</param>
        /// <param name="depthInUIGroup">界面在界面组中的深度。</param>
        protected override void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
        {
            int oldDepth = Depth;
            base.OnDepthChanged(uiGroupDepth, depthInUIGroup);
            int deltaDepth = FairyGuiGroupHelper.DepthFactor * uiGroupDepth + m_DepthFactor * depthInUIGroup - oldDepth + OriginalDepth;
            UI.sortingOrder += deltaDepth;
            m_SortingOrder = UI.sortingOrder;
        }

        /// <summary>
        /// 界面销毁
        /// </summary>
        public virtual void Clear()
        {
            if (m_Container != null)
            {
                if (!Application.isPlaying)
                    EMRenderSupport.Remove(this);

                if (_ui != null)
                {
                    _ui.Dispose();
                    _ui = null;
                }

                GameEntry.FairyGui.RemovePackage(m_PackagePath);
                m_Container.Dispose();
                m_Container = null;
            }

            _renders = null;
        }

        private IEnumerator CloseCo(float duration)
        {
            yield return UI.FadeToAlpha(0f, duration);
            GameEntry.UI.CloseUIForm(this);
        }

        public void Close()
        {
            Close(false);
        }

        public void Close(bool ignoreFade)
        {
            StopAllCoroutines();

            if (ignoreFade)
            {
                GameEntry.UI.CloseUIForm(this);
            }
            else
            {
                StartCoroutine(CloseCo(m_FadeTime));
            }
        }


        void CreateContainer()
        {
            if (!Application.isPlaying)
            {
                Transform t = this.transform;
                int cnt = t.childCount;
                while (cnt > 0)
                {
                    GameObject go = t.GetChild(cnt - 1).gameObject;
                    if (go.name == "UI(AutoGenerated)")
                        UnityEngine.Object.DestroyImmediate(go);
                    cnt--;
                }
            }

            this.m_Container = new Container(this.gameObject);
            this.m_Container.renderMode = m_RenderMode;
            this.m_Container.renderCamera = m_RenderCamera;
            this.m_Container.touchable = !m_TouchDisabled;
            this.m_Container._panelOrder = m_SortingOrder;
            this.m_Container.fairyBatching = m_FairyBatching;
            if (Application.isPlaying)
            {
                SetSortingOrder(this.m_SortingOrder, true);
                if (this.m_HitTestMode == HitTestMode.Raycast)
                    this.m_Container.hitArea = new BoxColliderHitTest(this.gameObject.AddComponent<BoxCollider>());

                if (m_SetNativeChildrenOrder)
                {
                    CacheNativeChildrenRenderers();

                    this.m_Container.onUpdate = () =>
                    {
                        int cnt = _renders.Count;
                        int sv = UpdateContext.current.renderingOrder++;
                        for (int i = 0; i < cnt; i++)
                        {
                            Renderer r = _renders[i];
                            if (r != null)
                                _renders[i].sortingOrder = sv;
                        }
                    };
                }
            }
        }

        /// <summary>
        /// 界面根组件
        /// </summary>
        public GComponent UI
        {
            get
            {
                if (!_created && Application.isPlaying)
                {
                    if (!string.IsNullOrEmpty(m_PackagePath) && UIPackage.GetByName(m_PackageName) == null)
                        GameEntry.FairyGui.AddPackage(m_PackagePath);

                    CreateUI_PlayMode();
                }

                return _ui;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void CreateUI()
        {
            if (_ui != null)
            {
                _ui.Dispose();
                _ui = null;
            }

            CreateUI_PlayMode();
        }

        /// <summary>
        /// Change the sorting order of the panel in runtime.
        /// </summary>
        /// <param name="value">sorting order value</param>
        /// <param name="apply">false if you dont want the default sorting behavior. e.g. call Stage.SortWorldSpacePanelsByZOrder later.</param>
        public void SetSortingOrder(int value, bool apply)
        {
            this.m_SortingOrder = value;
            m_Container._panelOrder = value;

            if (apply)
                Stage.inst.ApplyPanelOrder(m_Container);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void SetHitTestMode(HitTestMode value)
        {
            if (this.m_HitTestMode != value)
            {
                this.m_HitTestMode = value;
                BoxCollider collider = this.gameObject.GetComponent<BoxCollider>();
                if (this.m_HitTestMode == HitTestMode.Raycast)
                {
                    if (collider == null)
                        collider = this.gameObject.AddComponent<BoxCollider>();
                    this.m_Container.hitArea = new BoxColliderHitTest(collider);
                    if (_ui != null)
                        UpdateHitArea();
                }
                else
                {
                    this.m_Container.hitArea = null;
                    if (collider != null)
                        Component.Destroy(collider);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void CacheNativeChildrenRenderers()
        {
            if (_renders == null)
                _renders = new List<Renderer>();
            else
                _renders.Clear();

            Transform t = this.m_Container.cachedTransform;
            int cnt = t.childCount;
            for (int i = 0; i < cnt; i++)
            {
                GameObject go = t.GetChild(i).gameObject;
                if (go.name != "GComponent")
                    _renders.AddRange(go.GetComponentsInChildren<Renderer>(true));
            }

            cnt = _renders.Count;
            for (int i = 0; i < cnt; i++)
            {
                Renderer r = _renders[i];
                if ((r is SkinnedMeshRenderer) || (r is MeshRenderer))
                {
                    //Set the object rendering in Transparent Queue as UI objects
                    if (r.sharedMaterial != null)
                        r.sharedMaterial.renderQueue = 3000;
                }
            }
        }

        void CreateUI_PlayMode()
        {
            _created = true;

            if (string.IsNullOrEmpty(m_PackageName) || string.IsNullOrEmpty(m_ComponentName))
                return;

            _ui = (GComponent)UIPackage.CreateObject(m_PackageName, m_ComponentName);
            if (_ui != null)
            {
                _ui.position = m_Position;
                if (m_Scale.x != 0 && m_Scale.y != 0)
                    _ui.scale = m_Scale;
                _ui.rotationX = m_Rotation.x;
                _ui.rotationY = m_Rotation.y;
                _ui.rotation = m_Rotation.z;
                if (this.m_Container.hitArea != null)
                {
                    UpdateHitArea();
                    _ui.onSizeChanged.Add(UpdateHitArea);
                    _ui.onPositionChanged.Add(UpdateHitArea);
                }
                this.m_Container.AddChildAt(_ui.displayObject, 0);

                HandleScreenSizeChanged();
            }
            else
                Debug.LogError("Create " + m_ComponentName + "@" + m_PackageName + " failed!");
        }

        void UpdateHitArea()
        {
            ((BoxColliderHitTest)this.m_Container.hitArea).SetArea(_ui.x, _ui.y, _ui.width, _ui.height);
        }

        void CreateUI_EditMode()
        {
            if (!EMRenderSupport.packageListReady || UIPackage.GetByName(m_PackageName) == null)
                return;

#if (UNITY_5 || UNITY_5_3_OR_NEWER)
			DisplayOptions.SetEditModeHideFlags();
			_ui = (GComponent)UIPackage.CreateObject(m_PackageName, m_ComponentName);

			if (_ui != null)
			{
				_ui.displayObject.gameObject.hideFlags |= HideFlags.HideInHierarchy;
				_ui.gameObjectName = "UI(AutoGenerated)";

				_ui.position = m_Position;
				if (m_Scale.x != 0 && m_Scale.y != 0)
					_ui.scale = m_Scale;
				_ui.rotationX = m_Rotation.x;
				_ui.rotationY = m_Rotation.y;
				_ui.rotation = m_Rotation.z;
				this.m_Container.AddChildAt(_ui.displayObject, 0);

				m_CachedUISize = _ui.size;
				uiBounds.size = m_CachedUISize;
				HandleScreenSizeChanged();
			}
#else
            //PackageItem pi = UIPackage.GetByName(packageName).GetItemByName(componentName);
            //if (pi != null)
            //{
            //    cachedUISize = new Vector2(pi.width, pi.height);
            //    uiBounds.size = cachedUISize;
            //    HandleScreenSizeChanged();
            //}
#endif
        }

        void HandleScreenSizeChanged()
        {
            if (!Application.isPlaying)
                DisplayOptions.SetEditModeHideFlags();

            screenSizeVer = StageCamera.screenSizeVer;

            if (this.m_Container != null)
            {
                if (this.m_Container.renderMode != RenderMode.WorldSpace)
                    this.m_Container.scale = new Vector2(StageCamera.UnitsPerPixel * UIContentScaler.scaleFactor, StageCamera.UnitsPerPixel * UIContentScaler.scaleFactor);
            }

            int width = Mathf.CeilToInt(Screen.width / UIContentScaler.scaleFactor);
            int height = Mathf.CeilToInt(Screen.height / UIContentScaler.scaleFactor);
            if (this._ui != null)
            {
                switch (m_FitScreen)
                {
                    case FitScreen.FitSize:
                        this._ui.SetXY(0, 0);
                        this._ui.SetSize(width, height);
                        break;

                    case FitScreen.FitWidthAndSetMiddle:
                        this._ui.SetXY(0, (int)((height - this._ui.sourceHeight) / 2));
                        this._ui.SetSize(width, this._ui.sourceHeight);
                        break;

                    case FitScreen.FitHeightAndSetCenter:
                        this._ui.SetXY((int)((width - this._ui.sourceWidth) / 2), 0);
                        this._ui.SetSize(this._ui.sourceWidth, height);
                        break;
                }
            }
            else
            {
                switch (m_FitScreen)
                {
                    case FitScreen.FitSize:
                        uiBounds.position = new Vector2(0, 0);
                        uiBounds.size = new Vector2(width, height);
                        break;

                    case FitScreen.FitWidthAndSetMiddle:
                        uiBounds.position = new Vector2(0, (int)((height - m_CachedUISize.y) / 2));
                        uiBounds.size = new Vector2(width, m_CachedUISize.y);
                        break;

                    case FitScreen.FitHeightAndSetCenter:
                        uiBounds.position = new Vector2((int)((width - m_CachedUISize.x) / 2), 0);
                        uiBounds.size = new Vector2(m_CachedUISize.x, height);
                        break;
                }
            }
        }

        #region edit mode functions

        void OnUpdateSource(object[] data)
        {
            if (Application.isPlaying)
                return;

            this.m_PackageName = (string)data[0];
            this.m_PackagePath = (string)data[1];
            this.m_ComponentName = (string)data[2];

            if ((bool)data[3])
            {
                if (m_Container == null)
                    return;

                if (_ui != null)
                {
                    _ui.Dispose();
                    _ui = null;
                }
            }
        }

        public void ApplyModifiedProperties(bool sortingOrderChanged, bool fitScreenChanged)
        {
            if (m_Container != null)
            {
                m_Container.renderMode = m_RenderMode;
                m_Container.renderCamera = m_RenderCamera;
                if (sortingOrderChanged)
                {
                    m_Container._panelOrder = m_SortingOrder;
                    if (Application.isPlaying)
                        SetSortingOrder(m_SortingOrder, true);
                    else
                        EMRenderSupport.orderChanged = true;
                }
                m_Container.fairyBatching = m_FairyBatching;
            }

            if (_ui != null)
            {
                if (m_FitScreen == FitScreen.None)
                    _ui.position = m_Position;
                if (m_Scale.x != 0 && m_Scale.y != 0)
                    _ui.scale = m_Scale;
                _ui.rotationX = m_Rotation.x;
                _ui.rotationY = m_Rotation.y;
                _ui.rotation = m_Rotation.z;
            }
            if (m_FitScreen == FitScreen.None)
                uiBounds.position = m_Position;
            screenSizeVer = 0;//force HandleScreenSizeChanged be called

            if (fitScreenChanged && this.m_FitScreen == FitScreen.None)
            {
                if (this._ui != null)
                    this._ui.SetSize(this._ui.sourceWidth, this._ui.sourceHeight);
                uiBounds.size = m_CachedUISize;
            }
        }

        public void MoveUI(Vector3 delta)
        {
            if (m_FitScreen != FitScreen.None)
                return;

            this.m_Position += delta;
            if (_ui != null)
                _ui.position = m_Position;
            uiBounds.position = m_Position;
        }

        public Vector3 GetUIWorldPosition()
        {
            if (_ui != null)
                return _ui.displayObject.cachedTransform.position;
            else
                return this.m_Container.cachedTransform.TransformPoint(uiBounds.position);
        }

        void OnDrawGizmos()
        {
            if (Application.isPlaying || this.m_Container == null)
                return;

            Vector3 pos, size;
            if (this._ui != null)
            {
                Gizmos.matrix = this._ui.displayObject.cachedTransform.localToWorldMatrix;
                pos = new Vector3(this._ui.width / 2, -this._ui.height / 2, 0);
                size = new Vector3(this._ui.width, this._ui.height, 0);
            }
            else
            {
                Gizmos.matrix = this.m_Container.cachedTransform.localToWorldMatrix;
                pos = new Vector3(uiBounds.x + uiBounds.width / 2, -uiBounds.y - uiBounds.height / 2, 0);
                size = new Vector3(uiBounds.width, uiBounds.height, 0);
            }

            Gizmos.color = new Color(0, 0, 0, 0);
            Gizmos.DrawCube(pos, size);

            Gizmos.color = Color.white;
            Gizmos.DrawWireCube(pos, size);
        }

        public int EM_sortingOrder
        {
            get { return m_SortingOrder; }
        }

        public void EM_BeforeUpdate()
        {
            if (m_Container == null)
                CreateContainer();

            if (m_PackageName != null && m_ComponentName != null && _ui == null)
                CreateUI_EditMode();

            if (screenSizeVer != StageCamera.screenSizeVer)
                HandleScreenSizeChanged();
        }

        public void EM_Update(UpdateContext context)
        {
            DisplayOptions.SetEditModeHideFlags();

            m_Container.Update(context);

            if (m_SetNativeChildrenOrder)
            {
                CacheNativeChildrenRenderers();

                int cnt = _renders.Count;
                int sv = context.renderingOrder++;
                for (int i = 0; i < cnt; i++)
                {
                    Renderer r = _renders[i];
                    if (r != null)
                        r.sortingOrder = sv;
                }
            }
        }

        public void EM_Reload()
        {
            if (_ui != null)
            {
                _ui.Dispose();
                _ui = null;
            }
        }

        #endregion
    }
}
