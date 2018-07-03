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
    public class UnityGameFrameworkRuntimeEventComponentWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityGameFramework.Runtime.EventComponent);
			Utils.BeginObjectRegister(type, L, translator, 0, 5, 1, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Check", _m_Check);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Subscribe", _m_Subscribe);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Unsubscribe", _m_Unsubscribe);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Fire", _m_Fire);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FireNow", _m_FireNow);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Count", _g_get_Count);
            
			
			
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
					
					UnityGameFramework.Runtime.EventComponent __cl_gen_ret = new UnityGameFramework.Runtime.EventComponent();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.EventComponent constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Check(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EventComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EventComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    System.EventHandler<GameFramework.Event.GameEventArgs> handler = translator.GetDelegate<System.EventHandler<GameFramework.Event.GameEventArgs>>(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Check( id, handler );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Subscribe(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EventComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EventComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    System.EventHandler<GameFramework.Event.GameEventArgs> handler = translator.GetDelegate<System.EventHandler<GameFramework.Event.GameEventArgs>>(L, 3);
                    
                    __cl_gen_to_be_invoked.Subscribe( id, handler );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Unsubscribe(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EventComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EventComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int id = LuaAPI.xlua_tointeger(L, 2);
                    System.EventHandler<GameFramework.Event.GameEventArgs> handler = translator.GetDelegate<System.EventHandler<GameFramework.Event.GameEventArgs>>(L, 3);
                    
                    __cl_gen_to_be_invoked.Unsubscribe( id, handler );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Fire(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EventComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EventComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object sender = translator.GetObject(L, 2, typeof(object));
                    GameFramework.Event.GameEventArgs e = (GameFramework.Event.GameEventArgs)translator.GetObject(L, 3, typeof(GameFramework.Event.GameEventArgs));
                    
                    __cl_gen_to_be_invoked.Fire( sender, e );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FireNow(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EventComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EventComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object sender = translator.GetObject(L, 2, typeof(object));
                    GameFramework.Event.GameEventArgs e = (GameFramework.Event.GameEventArgs)translator.GetObject(L, 3, typeof(GameFramework.Event.GameEventArgs));
                    
                    __cl_gen_to_be_invoked.FireNow( sender, e );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Count(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityGameFramework.Runtime.EventComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EventComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Count);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
