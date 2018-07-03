#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class UnityGameFrameworkRuntimeUIComponentWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityGameFramework.Runtime.UIComponent);
			Utils.BeginObjectRegister(type, L, translator, 0, 18, 5, 4);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HasUIGroup", _m_HasUIGroup);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetUIGroup", _m_GetUIGroup);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAllUIGroups", _m_GetAllUIGroups);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddUIGroup", _m_AddUIGroup);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HasUIForm", _m_HasUIForm);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetUIForm", _m_GetUIForm);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetUIForms", _m_GetUIForms);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAllLoadedUIForms", _m_GetAllLoadedUIForms);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAllLoadingUIFormSerialIds", _m_GetAllLoadingUIFormSerialIds);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsLoadingUIForm", _m_IsLoadingUIForm);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsValidUIForm", _m_IsValidUIForm);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OpenUIForm", _m_OpenUIForm);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CloseUIForm", _m_CloseUIForm);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CloseAllLoadedUIForms", _m_CloseAllLoadedUIForms);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CloseAllLoadingUIForms", _m_CloseAllLoadingUIForms);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RefocusUIForm", _m_RefocusUIForm);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetUIFormLocked", _m_SetUIFormLocked);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetUIFormPriority", _m_SetUIFormPriority);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "UIGroupCount", _g_get_UIGroupCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "InstanceAutoReleaseInterval", _g_get_InstanceAutoReleaseInterval);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "InstanceCapacity", _g_get_InstanceCapacity);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "InstanceExpireTime", _g_get_InstanceExpireTime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "InstancePriority", _g_get_InstancePriority);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "InstanceAutoReleaseInterval", _s_set_InstanceAutoReleaseInterval);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "InstanceCapacity", _s_set_InstanceCapacity);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "InstanceExpireTime", _s_set_InstanceExpireTime);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "InstancePriority", _s_set_InstancePriority);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UnityGameFramework.Runtime.UIComponent __cl_gen_ret = new UnityGameFramework.Runtime.UIComponent();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.UIComponent constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasUIGroup(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string uiGroupName = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HasUIGroup( uiGroupName );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUIGroup(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string uiGroupName = LuaAPI.lua_tostring(L, 2);
                    
                        GameFramework.UI.IUIGroup __cl_gen_ret = __cl_gen_to_be_invoked.GetUIGroup( uiGroupName );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllUIGroups(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        GameFramework.UI.IUIGroup[] __cl_gen_ret = __cl_gen_to_be_invoked.GetAllUIGroups(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddUIGroup(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string uiGroupName = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.AddUIGroup( uiGroupName );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    string uiGroupName = LuaAPI.lua_tostring(L, 2);
                    int depth = LuaAPI.xlua_tointeger(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.AddUIGroup( uiGroupName, depth );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.UIComponent.AddUIGroup!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasUIForm(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int serialId = LuaAPI.xlua_tointeger(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HasUIForm( serialId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string uiFormAssetName = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HasUIForm( uiFormAssetName );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.UIComponent.HasUIForm!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUIForm(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int serialId = LuaAPI.xlua_tointeger(L, 2);
                    
                        UnityGameFramework.Runtime.UIForm __cl_gen_ret = __cl_gen_to_be_invoked.GetUIForm( serialId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string uiFormAssetName = LuaAPI.lua_tostring(L, 2);
                    
                        UnityGameFramework.Runtime.UIForm __cl_gen_ret = __cl_gen_to_be_invoked.GetUIForm( uiFormAssetName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.UIComponent.GetUIForm!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUIForms(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string uiFormAssetName = LuaAPI.lua_tostring(L, 2);
                    
                        UnityGameFramework.Runtime.UIForm[] __cl_gen_ret = __cl_gen_to_be_invoked.GetUIForms( uiFormAssetName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllLoadedUIForms(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        UnityGameFramework.Runtime.UIForm[] __cl_gen_ret = __cl_gen_to_be_invoked.GetAllLoadedUIForms(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllLoadingUIFormSerialIds(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int[] __cl_gen_ret = __cl_gen_to_be_invoked.GetAllLoadingUIFormSerialIds(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsLoadingUIForm(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int serialId = LuaAPI.xlua_tointeger(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsLoadingUIForm( serialId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string uiFormAssetName = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsLoadingUIForm( uiFormAssetName );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.UIComponent.IsLoadingUIForm!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsValidUIForm(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityGameFramework.Runtime.UIForm uiForm = (UnityGameFramework.Runtime.UIForm)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.UIForm));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsValidUIForm( uiForm );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OpenUIForm(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    string uiFormAssetName = LuaAPI.lua_tostring(L, 2);
                    string uiGroupName = LuaAPI.lua_tostring(L, 3);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.OpenUIForm( uiFormAssetName, uiGroupName );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    string uiFormAssetName = LuaAPI.lua_tostring(L, 2);
                    string uiGroupName = LuaAPI.lua_tostring(L, 3);
                    bool pauseCoveredUIForm = LuaAPI.lua_toboolean(L, 4);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.OpenUIForm( uiFormAssetName, uiGroupName, pauseCoveredUIForm );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 4)) 
                {
                    string uiFormAssetName = LuaAPI.lua_tostring(L, 2);
                    string uiGroupName = LuaAPI.lua_tostring(L, 3);
                    object userData = translator.GetObject(L, 4, typeof(object));
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.OpenUIForm( uiFormAssetName, uiGroupName, userData );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)&& translator.Assignable<object>(L, 5)) 
                {
                    string uiFormAssetName = LuaAPI.lua_tostring(L, 2);
                    string uiGroupName = LuaAPI.lua_tostring(L, 3);
                    bool pauseCoveredUIForm = LuaAPI.lua_toboolean(L, 4);
                    object userData = translator.GetObject(L, 5, typeof(object));
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.OpenUIForm( uiFormAssetName, uiGroupName, pauseCoveredUIForm, userData );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.UIComponent.OpenUIForm!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloseUIForm(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int serialId = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.CloseUIForm( serialId );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityGameFramework.Runtime.UIForm>(L, 2)) 
                {
                    UnityGameFramework.Runtime.UIForm uiForm = (UnityGameFramework.Runtime.UIForm)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.UIForm));
                    
                    __cl_gen_to_be_invoked.CloseUIForm( uiForm );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<object>(L, 3)) 
                {
                    int serialId = LuaAPI.xlua_tointeger(L, 2);
                    object userData = translator.GetObject(L, 3, typeof(object));
                    
                    __cl_gen_to_be_invoked.CloseUIForm( serialId, userData );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<UnityGameFramework.Runtime.UIForm>(L, 2)&& translator.Assignable<object>(L, 3)) 
                {
                    UnityGameFramework.Runtime.UIForm uiForm = (UnityGameFramework.Runtime.UIForm)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.UIForm));
                    object userData = translator.GetObject(L, 3, typeof(object));
                    
                    __cl_gen_to_be_invoked.CloseUIForm( uiForm, userData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.UIComponent.CloseUIForm!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloseAllLoadedUIForms(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 1) 
                {
                    
                    __cl_gen_to_be_invoked.CloseAllLoadedUIForms(  );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<object>(L, 2)) 
                {
                    object userData = translator.GetObject(L, 2, typeof(object));
                    
                    __cl_gen_to_be_invoked.CloseAllLoadedUIForms( userData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.UIComponent.CloseAllLoadedUIForms!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloseAllLoadingUIForms(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.CloseAllLoadingUIForms(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RefocusUIForm(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& translator.Assignable<UnityGameFramework.Runtime.UIForm>(L, 2)) 
                {
                    UnityGameFramework.Runtime.UIForm uiForm = (UnityGameFramework.Runtime.UIForm)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.UIForm));
                    
                    __cl_gen_to_be_invoked.RefocusUIForm( uiForm );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<UnityGameFramework.Runtime.UIForm>(L, 2)&& translator.Assignable<object>(L, 3)) 
                {
                    UnityGameFramework.Runtime.UIForm uiForm = (UnityGameFramework.Runtime.UIForm)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.UIForm));
                    object userData = translator.GetObject(L, 3, typeof(object));
                    
                    __cl_gen_to_be_invoked.RefocusUIForm( uiForm, userData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.UIComponent.RefocusUIForm!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetUIFormLocked(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityGameFramework.Runtime.UIForm uiForm = (UnityGameFramework.Runtime.UIForm)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.UIForm));
                    bool locked = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.SetUIFormLocked( uiForm, locked );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetUIFormPriority(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityGameFramework.Runtime.UIForm uiForm = (UnityGameFramework.Runtime.UIForm)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.UIForm));
                    int priority = LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.SetUIFormPriority( uiForm, priority );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UIGroupCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.UIGroupCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstanceAutoReleaseInterval(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.InstanceAutoReleaseInterval);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstanceCapacity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.InstanceCapacity);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstanceExpireTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.InstanceExpireTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InstancePriority(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.InstancePriority);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InstanceAutoReleaseInterval(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InstanceAutoReleaseInterval = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InstanceCapacity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InstanceCapacity = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InstanceExpireTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InstanceExpireTime = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InstancePriority(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityGameFramework.Runtime.UIComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.UIComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InstancePriority = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
