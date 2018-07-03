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
    public class GameFrameworkLogWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(GameFramework.Log);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 7, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "SetLogHelper", _m_SetLogHelper_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Debug", _m_Debug_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Info", _m_Info_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Warning", _m_Warning_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Error", _m_Error_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Fatal", _m_Fatal_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "GameFramework.Log does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLogHelper_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    GameFramework.Log.ILogHelper logHelper = (GameFramework.Log.ILogHelper)translator.GetObject(L, 1, typeof(GameFramework.Log.ILogHelper));
                    
                    GameFramework.Log.SetLogHelper( logHelper );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Debug_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object message = translator.GetObject(L, 1, typeof(object));
                    
                    GameFramework.Log.Debug( message );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string message = LuaAPI.lua_tostring(L, 1);
                    
                    GameFramework.Log.Debug( message );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 2)) 
                {
                    string format = LuaAPI.lua_tostring(L, 1);
                    object arg0 = translator.GetObject(L, 2, typeof(object));
                    
                    GameFramework.Log.Debug( format, arg0 );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count >= 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 2) || translator.Assignable<object>(L, 2))) 
                {
                    string format = LuaAPI.lua_tostring(L, 1);
                    object[] args = translator.GetParams<object>(L, 2);
                    
                    GameFramework.Log.Debug( format, args );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 2)&& translator.Assignable<object>(L, 3)) 
                {
                    string format = LuaAPI.lua_tostring(L, 1);
                    object arg0 = translator.GetObject(L, 2, typeof(object));
                    object arg1 = translator.GetObject(L, 3, typeof(object));
                    
                    GameFramework.Log.Debug( format, arg0, arg1 );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 2)&& translator.Assignable<object>(L, 3)&& translator.Assignable<object>(L, 4)) 
                {
                    string format = LuaAPI.lua_tostring(L, 1);
                    object arg0 = translator.GetObject(L, 2, typeof(object));
                    object arg1 = translator.GetObject(L, 3, typeof(object));
                    object arg2 = translator.GetObject(L, 4, typeof(object));
                    
                    GameFramework.Log.Debug( format, arg0, arg1, arg2 );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to GameFramework.Log.Debug!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Info_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object message = translator.GetObject(L, 1, typeof(object));
                    
                    GameFramework.Log.Info( message );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string message = LuaAPI.lua_tostring(L, 1);
                    
                    GameFramework.Log.Info( message );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 2)) 
                {
                    string format = LuaAPI.lua_tostring(L, 1);
                    object arg0 = translator.GetObject(L, 2, typeof(object));
                    
                    GameFramework.Log.Info( format, arg0 );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count >= 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 2) || translator.Assignable<object>(L, 2))) 
                {
                    string format = LuaAPI.lua_tostring(L, 1);
                    object[] args = translator.GetParams<object>(L, 2);
                    
                    GameFramework.Log.Info( format, args );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 2)&& translator.Assignable<object>(L, 3)) 
                {
                    string format = LuaAPI.lua_tostring(L, 1);
                    object arg0 = translator.GetObject(L, 2, typeof(object));
                    object arg1 = translator.GetObject(L, 3, typeof(object));
                    
                    GameFramework.Log.Info( format, arg0, arg1 );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 2)&& translator.Assignable<object>(L, 3)&& translator.Assignable<object>(L, 4)) 
                {
                    string format = LuaAPI.lua_tostring(L, 1);
                    object arg0 = translator.GetObject(L, 2, typeof(object));
                    object arg1 = translator.GetObject(L, 3, typeof(object));
                    object arg2 = translator.GetObject(L, 4, typeof(object));
                    
                    GameFramework.Log.Info( format, arg0, arg1, arg2 );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to GameFramework.Log.Info!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Warning_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object message = translator.GetObject(L, 1, typeof(object));
                    
                    GameFramework.Log.Warning( message );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string message = LuaAPI.lua_tostring(L, 1);
                    
                    GameFramework.Log.Warning( message );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 2)) 
                {
                    string format = LuaAPI.lua_tostring(L, 1);
                    object arg0 = translator.GetObject(L, 2, typeof(object));
                    
                    GameFramework.Log.Warning( format, arg0 );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count >= 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 2) || translator.Assignable<object>(L, 2))) 
                {
                    string format = LuaAPI.lua_tostring(L, 1);
                    object[] args = translator.GetParams<object>(L, 2);
                    
                    GameFramework.Log.Warning( format, args );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 2)&& translator.Assignable<object>(L, 3)) 
                {
                    string format = LuaAPI.lua_tostring(L, 1);
                    object arg0 = translator.GetObject(L, 2, typeof(object));
                    object arg1 = translator.GetObject(L, 3, typeof(object));
                    
                    GameFramework.Log.Warning( format, arg0, arg1 );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 2)&& translator.Assignable<object>(L, 3)&& translator.Assignable<object>(L, 4)) 
                {
                    string format = LuaAPI.lua_tostring(L, 1);
                    object arg0 = translator.GetObject(L, 2, typeof(object));
                    object arg1 = translator.GetObject(L, 3, typeof(object));
                    object arg2 = translator.GetObject(L, 4, typeof(object));
                    
                    GameFramework.Log.Warning( format, arg0, arg1, arg2 );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to GameFramework.Log.Warning!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Error_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object message = translator.GetObject(L, 1, typeof(object));
                    
                    GameFramework.Log.Error( message );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string message = LuaAPI.lua_tostring(L, 1);
                    
                    GameFramework.Log.Error( message );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 2)) 
                {
                    string format = LuaAPI.lua_tostring(L, 1);
                    object arg0 = translator.GetObject(L, 2, typeof(object));
                    
                    GameFramework.Log.Error( format, arg0 );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count >= 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 2) || translator.Assignable<object>(L, 2))) 
                {
                    string format = LuaAPI.lua_tostring(L, 1);
                    object[] args = translator.GetParams<object>(L, 2);
                    
                    GameFramework.Log.Error( format, args );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 2)&& translator.Assignable<object>(L, 3)) 
                {
                    string format = LuaAPI.lua_tostring(L, 1);
                    object arg0 = translator.GetObject(L, 2, typeof(object));
                    object arg1 = translator.GetObject(L, 3, typeof(object));
                    
                    GameFramework.Log.Error( format, arg0, arg1 );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 2)&& translator.Assignable<object>(L, 3)&& translator.Assignable<object>(L, 4)) 
                {
                    string format = LuaAPI.lua_tostring(L, 1);
                    object arg0 = translator.GetObject(L, 2, typeof(object));
                    object arg1 = translator.GetObject(L, 3, typeof(object));
                    object arg2 = translator.GetObject(L, 4, typeof(object));
                    
                    GameFramework.Log.Error( format, arg0, arg1, arg2 );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to GameFramework.Log.Error!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Fatal_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object message = translator.GetObject(L, 1, typeof(object));
                    
                    GameFramework.Log.Fatal( message );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string message = LuaAPI.lua_tostring(L, 1);
                    
                    GameFramework.Log.Fatal( message );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 2)) 
                {
                    string format = LuaAPI.lua_tostring(L, 1);
                    object arg0 = translator.GetObject(L, 2, typeof(object));
                    
                    GameFramework.Log.Fatal( format, arg0 );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count >= 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 2) || translator.Assignable<object>(L, 2))) 
                {
                    string format = LuaAPI.lua_tostring(L, 1);
                    object[] args = translator.GetParams<object>(L, 2);
                    
                    GameFramework.Log.Fatal( format, args );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 2)&& translator.Assignable<object>(L, 3)) 
                {
                    string format = LuaAPI.lua_tostring(L, 1);
                    object arg0 = translator.GetObject(L, 2, typeof(object));
                    object arg1 = translator.GetObject(L, 3, typeof(object));
                    
                    GameFramework.Log.Fatal( format, arg0, arg1 );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 2)&& translator.Assignable<object>(L, 3)&& translator.Assignable<object>(L, 4)) 
                {
                    string format = LuaAPI.lua_tostring(L, 1);
                    object arg0 = translator.GetObject(L, 2, typeof(object));
                    object arg1 = translator.GetObject(L, 3, typeof(object));
                    object arg2 = translator.GetObject(L, 4, typeof(object));
                    
                    GameFramework.Log.Fatal( format, arg0, arg1, arg2 );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to GameFramework.Log.Fatal!");
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
