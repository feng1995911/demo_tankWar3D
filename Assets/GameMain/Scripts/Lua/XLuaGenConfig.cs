using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using FairyGUI;
using GameFramework;
using GameMain;
using UnityEngine;
using UnityGameFramework.Runtime;
using XLua;

/// <summary>
/// XLua 配置
/// </summary>
public static class XLuaGenConfig
{
    //lua中要使用到C#库的配置，比如C#标准库，或者Unity API，第三方库等。
    [LuaCallCSharp]
    public static List<Type> LuaCallCSharp = new List<Type>() {
        #region ***** Unity *****
                typeof(UnityEngine.Object),
                typeof(Vector2),
                typeof(Vector3),
                typeof(Vector4),
                typeof(Quaternion),
                typeof(Color),
                typeof(Ray),
                typeof(Bounds),
                typeof(Ray2D),
                typeof(Time),
                typeof(GameObject),
                typeof(Component),
                typeof(Behaviour),
                typeof(Transform),
                typeof(Resources),
                typeof(TextAsset),
                typeof(Keyframe),
                typeof(AnimationCurve),
                typeof(AnimationClip),
                typeof(MonoBehaviour),
                typeof(ParticleSystem),
                typeof(SkinnedMeshRenderer),
                typeof(Renderer),
                typeof(WWW),
                typeof(UnityEngine.Debug),
        #endregion

        #region ***** System *****
                typeof(System.Collections.Generic.List<int>),
                typeof(Action<string>),
                typeof(System.Object),
                typeof(Array),
                typeof(IList),
                typeof(IDictionary),
                typeof(Activator),
                typeof(Type),
                typeof(BindingFlags),
        #endregion

        #region ***** GameMain *****
                //---GameFramework---
                typeof(Log),
                typeof(DatabaseComponent),
                typeof(DataTableComponent),
                typeof(EntityComponent),
                typeof(EventComponent),
                typeof(FairyGuiComponent),
                typeof(LocalizationComponent),
                typeof(ProcedureComponent),
                typeof(SceneComponent),
                typeof(SettingComponent),
                typeof(SoundComponent),
                typeof(UIComponent),

                //---Action---
                typeof(GameFrameworkAction),
                typeof(GameFrameworkAction<object>),
                typeof(GameFrameworkAction<int>),
                typeof(GameFrameworkAction<float>),
                typeof(GameFrameworkAction<string>),
                typeof(GameFrameworkAction<object,object>),
                typeof(GameFrameworkAction<int,int>),
                typeof(GameFrameworkAction<int,float>),
                typeof(GameFrameworkAction<int,string>),
                typeof(GameFrameworkAction<float,float>),

                //---UI---
                typeof(FairyGuiLuaForm),

                //---EventArgs---
                typeof(LoadSceneSuccessEventArgs),
                typeof(LoadSceneFailureEventArgs),

                //---Misc---
                typeof(XLuaHelper),
        #endregion

        #region ***** FairyGUI *****
                typeof(EventContext),
                typeof(EventDispatcher),
                typeof(EventListener),
                typeof(InputEvent),
                typeof(DisplayObject),
                typeof(Container),
                typeof(Stage),
                typeof(Controller),
                typeof(GObject),
                typeof(GGraph),
                typeof(GGroup),
                typeof(GImage),
                typeof(GLoader),
                typeof(PlayState),
                typeof(GMovieClip),
                typeof(TextFormat),
                typeof(GTextField),
                typeof(GRichTextField),
                typeof(GTextInput),
                typeof(GComponent),
                typeof(GList),
                typeof(GRoot),
                typeof(GLabel),
                typeof(GButton),
                typeof(GComboBox),
                typeof(GProgressBar),
                typeof(GSlider),
                typeof(PopupMenu),
                typeof(ScrollPane),
                typeof(Transition),
                typeof(UIPackage),
                typeof(Window),
                typeof(GObjectPool),
                typeof(Relations),
                typeof(RelationType),
        #endregion

        #region *****Other*****

        #endregion
    };

    //C#静态调用Lua的配置（包括事件的原型），仅可以配delegate，interface
    [CSharpCallLua]
    public static List<Type> CSharpCallLua = new List<Type>() {
        #region ***** Unity *****

        #endregion

        #region ***** System *****
                typeof(System.Object),
                typeof(Action),
                typeof(Action<int>),
                typeof(Action<string>),
                typeof(Action<double>),
                typeof(Action<double,double>),
                typeof(Func<string,string,bool>),
                typeof(Func<double, double, double>),
                typeof(Func<string,string,Action,bool>),
                typeof(UnityEngine.Events.UnityAction),
                typeof(System.Collections.IEnumerator),
        #endregion

        #region ***** GameMain *****
                //-----Action----
                typeof(GameFrameworkAction),
                typeof(GameFrameworkAction<object>),
                typeof(GameFrameworkAction<int>),
                typeof(GameFrameworkAction<float>),
                typeof(GameFrameworkAction<string>),
                typeof(GameFrameworkAction<object,object>),
                typeof(GameFrameworkAction<int,int>),
                typeof(GameFrameworkAction<int,float>),
                typeof(GameFrameworkAction<int,string>),
                typeof(GameFrameworkAction<float,float>),

                //----UIFormParams----
                typeof(LoginFormData),

        #endregion

        #region ***** FairyGUI *****
                typeof(EventCallback0),
                typeof(EventCallback1),
        #endregion
            };

    //黑名单
    [BlackList]
    public static List<List<string>> BlackList = new List<List<string>>()  {
                new List<string>(){"UnityEngine.WWW", "movie"},
    #if UNITY_WEBGL
                new List<string>(){"UnityEngine.WWW", "threadPriority"},
    #endif
                new List<string>(){"UnityEngine.Texture2D", "alphaIsTransparency"},
                new List<string>(){"UnityEngine.Security", "GetChainOfTrustValue"},
                new List<string>(){"UnityEngine.CanvasRenderer", "onRequestRebuild"},
                new List<string>(){"UnityEngine.Light", "areaSize"},
                new List<string>(){"UnityEngine.AnimatorOverrideController", "PerformOverrideClipListCleanup"},
    #if !UNITY_WEBPLAYER
                new List<string>(){"UnityEngine.Application", "ExternalEval"},
    #endif
                new List<string>(){"UnityEngine.GameObject", "networkView"}, //4.6.2 not support
                new List<string>(){"UnityEngine.Component", "networkView"},  //4.6.2 not support
                new List<string>(){"System.IO.FileInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections"},
                new List<string>(){"System.IO.FileInfo", "SetAccessControl", "System.Security.AccessControl.FileSecurity"},
                new List<string>(){"System.IO.DirectoryInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections"},
                new List<string>(){"System.IO.DirectoryInfo", "SetAccessControl", "System.Security.AccessControl.DirectorySecurity"},
                new List<string>(){"System.IO.DirectoryInfo", "CreateSubdirectory", "System.String", "System.Security.AccessControl.DirectorySecurity"},
                new List<string>(){"System.IO.DirectoryInfo", "Create", "System.Security.AccessControl.DirectorySecurity"},
                new List<string>(){"UnityEngine.MonoBehaviour", "runInEditMode"},
            };
}