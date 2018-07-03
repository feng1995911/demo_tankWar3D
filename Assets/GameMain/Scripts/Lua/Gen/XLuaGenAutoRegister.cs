#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using System;
using System.Collections.Generic;
using System.Reflection;


namespace XLua.CSObjectWrap
{
    public class XLua_Gen_Initer_Register__
	{
	    static XLua_Gen_Initer_Register__()
        {
		    XLua.LuaEnv.AddIniter((luaenv, translator) => {
			    
				translator.DelayWrapLoader(typeof(CoroutineRunner), CoroutineRunnerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.WaitForSeconds), UnityEngineWaitForSecondsWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.WaitForEndOfFrame), UnityEngineWaitForEndOfFrameWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.WaitForFixedUpdate), UnityEngineWaitForFixedUpdateWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.WWW), UnityEngineWWWWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Object), UnityEngineObjectWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Vector2), UnityEngineVector2Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Vector3), UnityEngineVector3Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Vector4), UnityEngineVector4Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Quaternion), UnityEngineQuaternionWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Color), UnityEngineColorWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Ray), UnityEngineRayWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Bounds), UnityEngineBoundsWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Ray2D), UnityEngineRay2DWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Time), UnityEngineTimeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.GameObject), UnityEngineGameObjectWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Component), UnityEngineComponentWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Behaviour), UnityEngineBehaviourWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Transform), UnityEngineTransformWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Resources), UnityEngineResourcesWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.TextAsset), UnityEngineTextAssetWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Keyframe), UnityEngineKeyframeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.AnimationCurve), UnityEngineAnimationCurveWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.AnimationClip), UnityEngineAnimationClipWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.MonoBehaviour), UnityEngineMonoBehaviourWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem), UnityEngineParticleSystemWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.SkinnedMeshRenderer), UnityEngineSkinnedMeshRendererWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Renderer), UnityEngineRendererWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityEngine.Debug), UnityEngineDebugWrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.Generic.List<int>), SystemCollectionsGenericList_1_SystemInt32_Wrap.__Register);
				
				translator.DelayWrapLoader(typeof(object), SystemObjectWrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Array), SystemArrayWrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.IList), SystemCollectionsIListWrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Collections.IDictionary), SystemCollectionsIDictionaryWrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Activator), SystemActivatorWrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Type), SystemTypeWrap.__Register);
				
				translator.DelayWrapLoader(typeof(System.Reflection.BindingFlags), SystemReflectionBindingFlagsWrap.__Register);
				
				translator.DelayWrapLoader(typeof(GameFramework.Log), GameFrameworkLogWrap.__Register);
				
				translator.DelayWrapLoader(typeof(GameMain.DatabaseComponent), GameMainDatabaseComponentWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityGameFramework.Runtime.DataTableComponent), UnityGameFrameworkRuntimeDataTableComponentWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityGameFramework.Runtime.EntityComponent), UnityGameFrameworkRuntimeEntityComponentWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityGameFramework.Runtime.EventComponent), UnityGameFrameworkRuntimeEventComponentWrap.__Register);
				
				translator.DelayWrapLoader(typeof(GameMain.FairyGuiComponent), GameMainFairyGuiComponentWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityGameFramework.Runtime.LocalizationComponent), UnityGameFrameworkRuntimeLocalizationComponentWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityGameFramework.Runtime.ProcedureComponent), UnityGameFrameworkRuntimeProcedureComponentWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityGameFramework.Runtime.SceneComponent), UnityGameFrameworkRuntimeSceneComponentWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityGameFramework.Runtime.SettingComponent), UnityGameFrameworkRuntimeSettingComponentWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityGameFramework.Runtime.SoundComponent), UnityGameFrameworkRuntimeSoundComponentWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityGameFramework.Runtime.UIComponent), UnityGameFrameworkRuntimeUIComponentWrap.__Register);
				
				translator.DelayWrapLoader(typeof(GameMain.FairyGuiLuaForm), GameMainFairyGuiLuaFormWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityGameFramework.Runtime.LoadSceneSuccessEventArgs), UnityGameFrameworkRuntimeLoadSceneSuccessEventArgsWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UnityGameFramework.Runtime.LoadSceneFailureEventArgs), UnityGameFrameworkRuntimeLoadSceneFailureEventArgsWrap.__Register);
				
				translator.DelayWrapLoader(typeof(XLuaHelper), XLuaHelperWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.EventContext), FairyGUIEventContextWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.EventDispatcher), FairyGUIEventDispatcherWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.EventListener), FairyGUIEventListenerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.InputEvent), FairyGUIInputEventWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.DisplayObject), FairyGUIDisplayObjectWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.Container), FairyGUIContainerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.Stage), FairyGUIStageWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.Controller), FairyGUIControllerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.GObject), FairyGUIGObjectWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.GGraph), FairyGUIGGraphWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.GGroup), FairyGUIGGroupWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.GImage), FairyGUIGImageWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.GLoader), FairyGUIGLoaderWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.PlayState), FairyGUIPlayStateWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.GMovieClip), FairyGUIGMovieClipWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.TextFormat), FairyGUITextFormatWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.GTextField), FairyGUIGTextFieldWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.GRichTextField), FairyGUIGRichTextFieldWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.GTextInput), FairyGUIGTextInputWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.GComponent), FairyGUIGComponentWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.GList), FairyGUIGListWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.GRoot), FairyGUIGRootWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.GLabel), FairyGUIGLabelWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.GButton), FairyGUIGButtonWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.GComboBox), FairyGUIGComboBoxWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.GProgressBar), FairyGUIGProgressBarWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.GSlider), FairyGUIGSliderWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.PopupMenu), FairyGUIPopupMenuWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.ScrollPane), FairyGUIScrollPaneWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.Transition), FairyGUITransitionWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.UIPackage), FairyGUIUIPackageWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.Window), FairyGUIWindowWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.GObjectPool), FairyGUIGObjectPoolWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.Relations), FairyGUIRelationsWrap.__Register);
				
				translator.DelayWrapLoader(typeof(FairyGUI.RelationType), FairyGUIRelationTypeWrap.__Register);
				
				
				
				translator.AddInterfaceBridgeCreator(typeof(System.Collections.IEnumerator), SystemCollectionsIEnumeratorBridge.__Create);
				
			});
		}
		
		
	}
	
}
namespace XLua
{
	public partial class ObjectTranslator
	{
		static XLua.CSObjectWrap.XLua_Gen_Initer_Register__ s_gen_reg_dumb_obj = new XLua.CSObjectWrap.XLua_Gen_Initer_Register__();
		static XLua.CSObjectWrap.XLua_Gen_Initer_Register__ gen_reg_dumb_obj {get{return s_gen_reg_dumb_obj;}}
	}
	
	internal partial class InternalGlobals
    {
	    
	    static InternalGlobals()
		{
		    extensionMethodMap = new Dictionary<Type, IEnumerable<MethodInfo>>()
			{
			    
			};
			
			genTryArrayGetPtr = StaticLuaCallbacks.__tryArrayGet;
            genTryArraySetPtr = StaticLuaCallbacks.__tryArraySet;
		}
	}
}
