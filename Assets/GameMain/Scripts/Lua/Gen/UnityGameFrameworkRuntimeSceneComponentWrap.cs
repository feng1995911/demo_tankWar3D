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
    public class UnityGameFrameworkRuntimeSceneComponentWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityGameFramework.Runtime.SceneComponent);
			Utils.BeginObjectRegister(type, L, translator, 0, 8, 1, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SceneIsLoaded", _m_SceneIsLoaded);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetLoadedSceneAssetNames", _m_GetLoadedSceneAssetNames);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SceneIsLoading", _m_SceneIsLoading);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetLoadingSceneAssetNames", _m_GetLoadingSceneAssetNames);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SceneIsUnloading", _m_SceneIsUnloading);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetUnloadingSceneAssetNames", _m_GetUnloadingSceneAssetNames);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LoadScene", _m_LoadScene);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UnloadScene", _m_UnloadScene);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "MainCamera", _g_get_MainCamera);
            
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetSceneName", _m_GetSceneName_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UnityGameFramework.Runtime.SceneComponent __cl_gen_ret = new UnityGameFramework.Runtime.SceneComponent();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.SceneComponent constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SceneIsLoaded(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.SceneComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.SceneComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string sceneAssetName = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.SceneIsLoaded( sceneAssetName );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLoadedSceneAssetNames(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.SceneComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.SceneComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        string[] __cl_gen_ret = __cl_gen_to_be_invoked.GetLoadedSceneAssetNames(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SceneIsLoading(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.SceneComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.SceneComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string sceneAssetName = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.SceneIsLoading( sceneAssetName );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLoadingSceneAssetNames(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.SceneComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.SceneComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        string[] __cl_gen_ret = __cl_gen_to_be_invoked.GetLoadingSceneAssetNames(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SceneIsUnloading(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.SceneComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.SceneComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string sceneAssetName = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.SceneIsUnloading( sceneAssetName );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUnloadingSceneAssetNames(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.SceneComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.SceneComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        string[] __cl_gen_ret = __cl_gen_to_be_invoked.GetUnloadingSceneAssetNames(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadScene(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.SceneComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.SceneComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string sceneAssetName = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.LoadScene( sceneAssetName );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 3)) 
                {
                    string sceneAssetName = LuaAPI.lua_tostring(L, 2);
                    object userData = translator.GetObject(L, 3, typeof(object));
                    
                    __cl_gen_to_be_invoked.LoadScene( sceneAssetName, userData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.SceneComponent.LoadScene!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnloadScene(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.SceneComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.SceneComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string sceneAssetName = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.UnloadScene( sceneAssetName );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 3)) 
                {
                    string sceneAssetName = LuaAPI.lua_tostring(L, 2);
                    object userData = translator.GetObject(L, 3, typeof(object));
                    
                    __cl_gen_to_be_invoked.UnloadScene( sceneAssetName, userData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.SceneComponent.UnloadScene!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSceneName_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string sceneAssetName = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = UnityGameFramework.Runtime.SceneComponent.GetSceneName( sceneAssetName );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MainCamera(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityGameFramework.Runtime.SceneComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.SceneComponent)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MainCamera);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
