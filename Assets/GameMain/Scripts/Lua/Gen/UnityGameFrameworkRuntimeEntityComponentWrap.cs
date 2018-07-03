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
    public class UnityGameFrameworkRuntimeEntityComponentWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityGameFramework.Runtime.EntityComponent);
			Utils.BeginObjectRegister(type, L, translator, 0, 22, 2, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HasEntityGroup", _m_HasEntityGroup);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetEntityGroup", _m_GetEntityGroup);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAllEntityGroups", _m_GetAllEntityGroups);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddEntityGroup", _m_AddEntityGroup);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HasEntity", _m_HasEntity);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetEntity", _m_GetEntity);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetEntities", _m_GetEntities);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAllLoadedEntities", _m_GetAllLoadedEntities);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAllLoadingEntityIds", _m_GetAllLoadingEntityIds);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsLoadingEntity", _m_IsLoadingEntity);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsValidEntity", _m_IsValidEntity);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ShowEntity", _m_ShowEntity);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HideEntity", _m_HideEntity);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HideAllLoadedEntities", _m_HideAllLoadedEntities);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HideAllLoadingEntities", _m_HideAllLoadingEntities);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetParentEntity", _m_GetParentEntity);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetChildEntities", _m_GetChildEntities);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AttachEntity", _m_AttachEntity);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DetachEntity", _m_DetachEntity);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DetachChildEntities", _m_DetachChildEntities);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetInstanceLocked", _m_SetInstanceLocked);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetInstancePriority", _m_SetInstancePriority);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "EntityCount", _g_get_EntityCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EntityGroupCount", _g_get_EntityGroupCount);
            
			
			
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
					
					UnityGameFramework.Runtime.EntityComponent __cl_gen_ret = new UnityGameFramework.Runtime.EntityComponent();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.EntityComponent constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasEntityGroup(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string entityGroupName = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HasEntityGroup( entityGroupName );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEntityGroup(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string entityGroupName = LuaAPI.lua_tostring(L, 2);
                    
                        GameFramework.Entity.IEntityGroup __cl_gen_ret = __cl_gen_to_be_invoked.GetEntityGroup( entityGroupName );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllEntityGroups(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        GameFramework.Entity.IEntityGroup[] __cl_gen_ret = __cl_gen_to_be_invoked.GetAllEntityGroups(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddEntityGroup(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string entityGroupName = LuaAPI.lua_tostring(L, 2);
                    float instanceAutoReleaseInterval = (float)LuaAPI.lua_tonumber(L, 3);
                    int instanceCapacity = LuaAPI.xlua_tointeger(L, 4);
                    float instanceExpireTime = (float)LuaAPI.lua_tonumber(L, 5);
                    int instancePriority = LuaAPI.xlua_tointeger(L, 6);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.AddEntityGroup( entityGroupName, instanceAutoReleaseInterval, instanceCapacity, instanceExpireTime, instancePriority );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasEntity(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int entityId = LuaAPI.xlua_tointeger(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HasEntity( entityId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string entityAssetName = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HasEntity( entityAssetName );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.EntityComponent.HasEntity!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEntity(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int entityId = LuaAPI.xlua_tointeger(L, 2);
                    
                        UnityGameFramework.Runtime.Entity __cl_gen_ret = __cl_gen_to_be_invoked.GetEntity( entityId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string entityAssetName = LuaAPI.lua_tostring(L, 2);
                    
                        UnityGameFramework.Runtime.Entity __cl_gen_ret = __cl_gen_to_be_invoked.GetEntity( entityAssetName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.EntityComponent.GetEntity!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEntities(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string entityAssetName = LuaAPI.lua_tostring(L, 2);
                    
                        UnityGameFramework.Runtime.Entity[] __cl_gen_ret = __cl_gen_to_be_invoked.GetEntities( entityAssetName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllLoadedEntities(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        UnityGameFramework.Runtime.Entity[] __cl_gen_ret = __cl_gen_to_be_invoked.GetAllLoadedEntities(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllLoadingEntityIds(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int[] __cl_gen_ret = __cl_gen_to_be_invoked.GetAllLoadingEntityIds(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsLoadingEntity(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int entityId = LuaAPI.xlua_tointeger(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsLoadingEntity( entityId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsValidEntity(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityGameFramework.Runtime.Entity entity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.Entity));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsValidEntity( entity );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowEntity(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<System.Type>(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 5) || LuaAPI.lua_type(L, 5) == LuaTypes.LUA_TSTRING)) 
                {
                    int entityId = LuaAPI.xlua_tointeger(L, 2);
                    System.Type entityLogicType = (System.Type)translator.GetObject(L, 3, typeof(System.Type));
                    string entityAssetName = LuaAPI.lua_tostring(L, 4);
                    string entityGroupName = LuaAPI.lua_tostring(L, 5);
                    
                    __cl_gen_to_be_invoked.ShowEntity( entityId, entityLogicType, entityAssetName, entityGroupName );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 6&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<System.Type>(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 5) || LuaAPI.lua_type(L, 5) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 6)) 
                {
                    int entityId = LuaAPI.xlua_tointeger(L, 2);
                    System.Type entityLogicType = (System.Type)translator.GetObject(L, 3, typeof(System.Type));
                    string entityAssetName = LuaAPI.lua_tostring(L, 4);
                    string entityGroupName = LuaAPI.lua_tostring(L, 5);
                    object userData = translator.GetObject(L, 6, typeof(object));
                    
                    __cl_gen_to_be_invoked.ShowEntity( entityId, entityLogicType, entityAssetName, entityGroupName, userData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.EntityComponent.ShowEntity!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HideEntity(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int entityId = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.HideEntity( entityId );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 2)) 
                {
                    UnityGameFramework.Runtime.Entity entity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.Entity));
                    
                    __cl_gen_to_be_invoked.HideEntity( entity );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<object>(L, 3)) 
                {
                    int entityId = LuaAPI.xlua_tointeger(L, 2);
                    object userData = translator.GetObject(L, 3, typeof(object));
                    
                    __cl_gen_to_be_invoked.HideEntity( entityId, userData );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 2)&& translator.Assignable<object>(L, 3)) 
                {
                    UnityGameFramework.Runtime.Entity entity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.Entity));
                    object userData = translator.GetObject(L, 3, typeof(object));
                    
                    __cl_gen_to_be_invoked.HideEntity( entity, userData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.EntityComponent.HideEntity!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HideAllLoadedEntities(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 1) 
                {
                    
                    __cl_gen_to_be_invoked.HideAllLoadedEntities(  );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<object>(L, 2)) 
                {
                    object userData = translator.GetObject(L, 2, typeof(object));
                    
                    __cl_gen_to_be_invoked.HideAllLoadedEntities( userData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.EntityComponent.HideAllLoadedEntities!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HideAllLoadingEntities(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.HideAllLoadingEntities(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetParentEntity(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int childEntityId = LuaAPI.xlua_tointeger(L, 2);
                    
                        UnityGameFramework.Runtime.Entity __cl_gen_ret = __cl_gen_to_be_invoked.GetParentEntity( childEntityId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 2)) 
                {
                    UnityGameFramework.Runtime.Entity childEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.Entity));
                    
                        UnityGameFramework.Runtime.Entity __cl_gen_ret = __cl_gen_to_be_invoked.GetParentEntity( childEntity );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.EntityComponent.GetParentEntity!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetChildEntities(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int parentEntityId = LuaAPI.xlua_tointeger(L, 2);
                    
                        UnityGameFramework.Runtime.Entity[] __cl_gen_ret = __cl_gen_to_be_invoked.GetChildEntities( parentEntityId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 2)) 
                {
                    UnityGameFramework.Runtime.Entity parentEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.Entity));
                    
                        UnityGameFramework.Runtime.Entity[] __cl_gen_ret = __cl_gen_to_be_invoked.GetChildEntities( parentEntity );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.EntityComponent.GetChildEntities!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AttachEntity(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    int childEntityId = LuaAPI.xlua_tointeger(L, 2);
                    int parentEntityId = LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntityId, parentEntityId );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 3)) 
                {
                    int childEntityId = LuaAPI.xlua_tointeger(L, 2);
                    UnityGameFramework.Runtime.Entity parentEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 3, typeof(UnityGameFramework.Runtime.Entity));
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntityId, parentEntity );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityGameFramework.Runtime.Entity childEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.Entity));
                    int parentEntityId = LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntity, parentEntityId );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)) 
                {
                    int childEntityId = LuaAPI.xlua_tointeger(L, 2);
                    int parentEntityId = LuaAPI.xlua_tointeger(L, 3);
                    string parentTransformPath = LuaAPI.lua_tostring(L, 4);
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntityId, parentEntityId, parentTransformPath );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Transform>(L, 4)) 
                {
                    int childEntityId = LuaAPI.xlua_tointeger(L, 2);
                    int parentEntityId = LuaAPI.xlua_tointeger(L, 3);
                    UnityEngine.Transform parentTransform = (UnityEngine.Transform)translator.GetObject(L, 4, typeof(UnityEngine.Transform));
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntityId, parentEntityId, parentTransform );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<object>(L, 4)) 
                {
                    int childEntityId = LuaAPI.xlua_tointeger(L, 2);
                    int parentEntityId = LuaAPI.xlua_tointeger(L, 3);
                    object userData = translator.GetObject(L, 4, typeof(object));
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntityId, parentEntityId, userData );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 2)&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 3)) 
                {
                    UnityGameFramework.Runtime.Entity childEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.Entity));
                    UnityGameFramework.Runtime.Entity parentEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 3, typeof(UnityGameFramework.Runtime.Entity));
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntity, parentEntity );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)) 
                {
                    int childEntityId = LuaAPI.xlua_tointeger(L, 2);
                    UnityGameFramework.Runtime.Entity parentEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 3, typeof(UnityGameFramework.Runtime.Entity));
                    string parentTransformPath = LuaAPI.lua_tostring(L, 4);
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntityId, parentEntity, parentTransformPath );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)) 
                {
                    UnityGameFramework.Runtime.Entity childEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.Entity));
                    int parentEntityId = LuaAPI.xlua_tointeger(L, 3);
                    string parentTransformPath = LuaAPI.lua_tostring(L, 4);
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntity, parentEntityId, parentTransformPath );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 3)&& translator.Assignable<UnityEngine.Transform>(L, 4)) 
                {
                    int childEntityId = LuaAPI.xlua_tointeger(L, 2);
                    UnityGameFramework.Runtime.Entity parentEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 3, typeof(UnityGameFramework.Runtime.Entity));
                    UnityEngine.Transform parentTransform = (UnityEngine.Transform)translator.GetObject(L, 4, typeof(UnityEngine.Transform));
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntityId, parentEntity, parentTransform );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Transform>(L, 4)) 
                {
                    UnityGameFramework.Runtime.Entity childEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.Entity));
                    int parentEntityId = LuaAPI.xlua_tointeger(L, 3);
                    UnityEngine.Transform parentTransform = (UnityEngine.Transform)translator.GetObject(L, 4, typeof(UnityEngine.Transform));
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntity, parentEntityId, parentTransform );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 3)&& translator.Assignable<object>(L, 4)) 
                {
                    int childEntityId = LuaAPI.xlua_tointeger(L, 2);
                    UnityGameFramework.Runtime.Entity parentEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 3, typeof(UnityGameFramework.Runtime.Entity));
                    object userData = translator.GetObject(L, 4, typeof(object));
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntityId, parentEntity, userData );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<object>(L, 4)) 
                {
                    UnityGameFramework.Runtime.Entity childEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.Entity));
                    int parentEntityId = LuaAPI.xlua_tointeger(L, 3);
                    object userData = translator.GetObject(L, 4, typeof(object));
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntity, parentEntityId, userData );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 5)) 
                {
                    int childEntityId = LuaAPI.xlua_tointeger(L, 2);
                    int parentEntityId = LuaAPI.xlua_tointeger(L, 3);
                    string parentTransformPath = LuaAPI.lua_tostring(L, 4);
                    object userData = translator.GetObject(L, 5, typeof(object));
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntityId, parentEntityId, parentTransformPath, userData );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Transform>(L, 4)&& translator.Assignable<object>(L, 5)) 
                {
                    int childEntityId = LuaAPI.xlua_tointeger(L, 2);
                    int parentEntityId = LuaAPI.xlua_tointeger(L, 3);
                    UnityEngine.Transform parentTransform = (UnityEngine.Transform)translator.GetObject(L, 4, typeof(UnityEngine.Transform));
                    object userData = translator.GetObject(L, 5, typeof(object));
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntityId, parentEntityId, parentTransform, userData );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 2)&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)) 
                {
                    UnityGameFramework.Runtime.Entity childEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.Entity));
                    UnityGameFramework.Runtime.Entity parentEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 3, typeof(UnityGameFramework.Runtime.Entity));
                    string parentTransformPath = LuaAPI.lua_tostring(L, 4);
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntity, parentEntity, parentTransformPath );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 2)&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 3)&& translator.Assignable<UnityEngine.Transform>(L, 4)) 
                {
                    UnityGameFramework.Runtime.Entity childEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.Entity));
                    UnityGameFramework.Runtime.Entity parentEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 3, typeof(UnityGameFramework.Runtime.Entity));
                    UnityEngine.Transform parentTransform = (UnityEngine.Transform)translator.GetObject(L, 4, typeof(UnityEngine.Transform));
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntity, parentEntity, parentTransform );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 2)&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 3)&& translator.Assignable<object>(L, 4)) 
                {
                    UnityGameFramework.Runtime.Entity childEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.Entity));
                    UnityGameFramework.Runtime.Entity parentEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 3, typeof(UnityGameFramework.Runtime.Entity));
                    object userData = translator.GetObject(L, 4, typeof(object));
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntity, parentEntity, userData );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 5)) 
                {
                    int childEntityId = LuaAPI.xlua_tointeger(L, 2);
                    UnityGameFramework.Runtime.Entity parentEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 3, typeof(UnityGameFramework.Runtime.Entity));
                    string parentTransformPath = LuaAPI.lua_tostring(L, 4);
                    object userData = translator.GetObject(L, 5, typeof(object));
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntityId, parentEntity, parentTransformPath, userData );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 5&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 5)) 
                {
                    UnityGameFramework.Runtime.Entity childEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.Entity));
                    int parentEntityId = LuaAPI.xlua_tointeger(L, 3);
                    string parentTransformPath = LuaAPI.lua_tostring(L, 4);
                    object userData = translator.GetObject(L, 5, typeof(object));
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntity, parentEntityId, parentTransformPath, userData );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 3)&& translator.Assignable<UnityEngine.Transform>(L, 4)&& translator.Assignable<object>(L, 5)) 
                {
                    int childEntityId = LuaAPI.xlua_tointeger(L, 2);
                    UnityGameFramework.Runtime.Entity parentEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 3, typeof(UnityGameFramework.Runtime.Entity));
                    UnityEngine.Transform parentTransform = (UnityEngine.Transform)translator.GetObject(L, 4, typeof(UnityEngine.Transform));
                    object userData = translator.GetObject(L, 5, typeof(object));
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntityId, parentEntity, parentTransform, userData );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 5&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Transform>(L, 4)&& translator.Assignable<object>(L, 5)) 
                {
                    UnityGameFramework.Runtime.Entity childEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.Entity));
                    int parentEntityId = LuaAPI.xlua_tointeger(L, 3);
                    UnityEngine.Transform parentTransform = (UnityEngine.Transform)translator.GetObject(L, 4, typeof(UnityEngine.Transform));
                    object userData = translator.GetObject(L, 5, typeof(object));
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntity, parentEntityId, parentTransform, userData );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 5&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 2)&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 5)) 
                {
                    UnityGameFramework.Runtime.Entity childEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.Entity));
                    UnityGameFramework.Runtime.Entity parentEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 3, typeof(UnityGameFramework.Runtime.Entity));
                    string parentTransformPath = LuaAPI.lua_tostring(L, 4);
                    object userData = translator.GetObject(L, 5, typeof(object));
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntity, parentEntity, parentTransformPath, userData );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 5&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 2)&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 3)&& translator.Assignable<UnityEngine.Transform>(L, 4)&& translator.Assignable<object>(L, 5)) 
                {
                    UnityGameFramework.Runtime.Entity childEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.Entity));
                    UnityGameFramework.Runtime.Entity parentEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 3, typeof(UnityGameFramework.Runtime.Entity));
                    UnityEngine.Transform parentTransform = (UnityEngine.Transform)translator.GetObject(L, 4, typeof(UnityEngine.Transform));
                    object userData = translator.GetObject(L, 5, typeof(object));
                    
                    __cl_gen_to_be_invoked.AttachEntity( childEntity, parentEntity, parentTransform, userData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.EntityComponent.AttachEntity!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DetachEntity(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int childEntityId = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.DetachEntity( childEntityId );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 2)) 
                {
                    UnityGameFramework.Runtime.Entity childEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.Entity));
                    
                    __cl_gen_to_be_invoked.DetachEntity( childEntity );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<object>(L, 3)) 
                {
                    int childEntityId = LuaAPI.xlua_tointeger(L, 2);
                    object userData = translator.GetObject(L, 3, typeof(object));
                    
                    __cl_gen_to_be_invoked.DetachEntity( childEntityId, userData );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 2)&& translator.Assignable<object>(L, 3)) 
                {
                    UnityGameFramework.Runtime.Entity childEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.Entity));
                    object userData = translator.GetObject(L, 3, typeof(object));
                    
                    __cl_gen_to_be_invoked.DetachEntity( childEntity, userData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.EntityComponent.DetachEntity!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DetachChildEntities(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int parentEntityId = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.DetachChildEntities( parentEntityId );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 2)) 
                {
                    UnityGameFramework.Runtime.Entity parentEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.Entity));
                    
                    __cl_gen_to_be_invoked.DetachChildEntities( parentEntity );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<object>(L, 3)) 
                {
                    int parentEntityId = LuaAPI.xlua_tointeger(L, 2);
                    object userData = translator.GetObject(L, 3, typeof(object));
                    
                    __cl_gen_to_be_invoked.DetachChildEntities( parentEntityId, userData );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 2)&& translator.Assignable<object>(L, 3)) 
                {
                    UnityGameFramework.Runtime.Entity parentEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.Entity));
                    object userData = translator.GetObject(L, 3, typeof(object));
                    
                    __cl_gen_to_be_invoked.DetachChildEntities( parentEntity, userData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.EntityComponent.DetachChildEntities!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetInstanceLocked(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityGameFramework.Runtime.Entity entity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.Entity));
                    bool locked = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.SetInstanceLocked( entity, locked );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetInstancePriority(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityGameFramework.Runtime.Entity entity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 2, typeof(UnityGameFramework.Runtime.Entity));
                    int priority = LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.SetInstancePriority( entity, priority );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EntityCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.EntityCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EntityGroupCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityGameFramework.Runtime.EntityComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.EntityComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.EntityGroupCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
