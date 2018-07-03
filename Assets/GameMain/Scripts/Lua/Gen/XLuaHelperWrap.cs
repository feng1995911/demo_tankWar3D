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
    public class XLuaHelperWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(XLuaHelper);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 6, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateArrayInstance", _m_CreateArrayInstance_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateListInstance", _m_CreateListInstance_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateDictionaryInstance", _m_CreateDictionaryInstance_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateActionEventHandler", _m_CreateActionEventHandler_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateGameFrameworkActionEventHandler", _m_CreateGameFrameworkActionEventHandler_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "XLuaHelper does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateArrayInstance_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Type itemType = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    int itemCount = LuaAPI.xlua_tointeger(L, 2);
                    
                        System.Array __cl_gen_ret = XLuaHelper.CreateArrayInstance( itemType, itemCount );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateListInstance_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Type itemType = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    
                        System.Collections.IList __cl_gen_ret = XLuaHelper.CreateListInstance( itemType );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateDictionaryInstance_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Type keyType = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    System.Type valueType = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        System.Collections.IDictionary __cl_gen_ret = XLuaHelper.CreateDictionaryInstance( keyType, valueType );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateActionEventHandler_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count >= 2&& translator.Assignable<System.Type>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 3) || translator.Assignable<System.Type>(L, 3))) 
                {
                    System.Type type = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    string methodName = LuaAPI.lua_tostring(L, 2);
                    System.Type[] paramTypes = translator.GetParams<System.Type>(L, 3);
                    
                        System.EventHandler __cl_gen_ret = XLuaHelper.CreateActionEventHandler( type, methodName, paramTypes );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count >= 2&& translator.Assignable<object>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 3) || translator.Assignable<System.Type>(L, 3))) 
                {
                    object target = translator.GetObject(L, 1, typeof(object));
                    string methodName = LuaAPI.lua_tostring(L, 2);
                    System.Type[] paramTypes = translator.GetParams<System.Type>(L, 3);
                    
                        System.EventHandler __cl_gen_ret = XLuaHelper.CreateActionEventHandler( target, methodName, paramTypes );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to XLuaHelper.CreateActionEventHandler!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateGameFrameworkActionEventHandler_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count >= 2&& translator.Assignable<System.Type>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 3) || translator.Assignable<System.Type>(L, 3))) 
                {
                    System.Type type = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    string methodName = LuaAPI.lua_tostring(L, 2);
                    System.Type[] paramTypes = translator.GetParams<System.Type>(L, 3);
                    
                        System.EventHandler __cl_gen_ret = XLuaHelper.CreateGameFrameworkActionEventHandler( type, methodName, paramTypes );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count >= 2&& translator.Assignable<object>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 3) || translator.Assignable<System.Type>(L, 3))) 
                {
                    object target = translator.GetObject(L, 1, typeof(object));
                    string methodName = LuaAPI.lua_tostring(L, 2);
                    System.Type[] paramTypes = translator.GetParams<System.Type>(L, 3);
                    
                        System.EventHandler __cl_gen_ret = XLuaHelper.CreateGameFrameworkActionEventHandler( target, methodName, paramTypes );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to XLuaHelper.CreateGameFrameworkActionEventHandler!");
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
