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
    public class UnityGameFrameworkRuntimeDataTableComponentWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityGameFramework.Runtime.DataTableComponent);
			Utils.BeginObjectRegister(type, L, translator, 0, 6, 1, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LoadDataTable", _m_LoadDataTable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HasDataTable", _m_HasDataTable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetDataTable", _m_GetDataTable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAllDataTables", _m_GetAllDataTables);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CreateDataTable", _m_CreateDataTable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DestroyDataTable", _m_DestroyDataTable);
			
			
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
					
					UnityGameFramework.Runtime.DataTableComponent __cl_gen_ret = new UnityGameFramework.Runtime.DataTableComponent();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.DataTableComponent constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadDataTable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.DataTableComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.DataTableComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 4&& translator.Assignable<System.Type>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)) 
                {
                    System.Type dataRowType = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    string dataTableName = LuaAPI.lua_tostring(L, 3);
                    string dataTableAssetName = LuaAPI.lua_tostring(L, 4);
                    
                    __cl_gen_to_be_invoked.LoadDataTable( dataRowType, dataTableName, dataTableAssetName );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 5&& translator.Assignable<System.Type>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 5)) 
                {
                    System.Type dataRowType = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    string dataTableName = LuaAPI.lua_tostring(L, 3);
                    string dataTableAssetName = LuaAPI.lua_tostring(L, 4);
                    object userData = translator.GetObject(L, 5, typeof(object));
                    
                    __cl_gen_to_be_invoked.LoadDataTable( dataRowType, dataTableName, dataTableAssetName, userData );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 5&& translator.Assignable<System.Type>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 5) || LuaAPI.lua_type(L, 5) == LuaTypes.LUA_TSTRING)) 
                {
                    System.Type dataRowType = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    string dataTableName = LuaAPI.lua_tostring(L, 3);
                    string dataTableNameInType = LuaAPI.lua_tostring(L, 4);
                    string dataTableAssetName = LuaAPI.lua_tostring(L, 5);
                    
                    __cl_gen_to_be_invoked.LoadDataTable( dataRowType, dataTableName, dataTableNameInType, dataTableAssetName );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 6&& translator.Assignable<System.Type>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 5) || LuaAPI.lua_type(L, 5) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 6)) 
                {
                    System.Type dataRowType = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    string dataTableName = LuaAPI.lua_tostring(L, 3);
                    string dataTableNameInType = LuaAPI.lua_tostring(L, 4);
                    string dataTableAssetName = LuaAPI.lua_tostring(L, 5);
                    object userData = translator.GetObject(L, 6, typeof(object));
                    
                    __cl_gen_to_be_invoked.LoadDataTable( dataRowType, dataTableName, dataTableNameInType, dataTableAssetName, userData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.DataTableComponent.LoadDataTable!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasDataTable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.DataTableComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.DataTableComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& translator.Assignable<System.Type>(L, 2)) 
                {
                    System.Type dataRowType = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HasDataTable( dataRowType );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<System.Type>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    System.Type dataRowType = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    string name = LuaAPI.lua_tostring(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HasDataTable( dataRowType, name );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.DataTableComponent.HasDataTable!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDataTable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.DataTableComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.DataTableComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& translator.Assignable<System.Type>(L, 2)) 
                {
                    System.Type dataRowType = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        GameFramework.DataTable.DataTableBase __cl_gen_ret = __cl_gen_to_be_invoked.GetDataTable( dataRowType );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<System.Type>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    System.Type dataRowType = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    string name = LuaAPI.lua_tostring(L, 3);
                    
                        GameFramework.DataTable.DataTableBase __cl_gen_ret = __cl_gen_to_be_invoked.GetDataTable( dataRowType, name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.DataTableComponent.GetDataTable!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllDataTables(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.DataTableComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.DataTableComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        GameFramework.DataTable.DataTableBase[] __cl_gen_ret = __cl_gen_to_be_invoked.GetAllDataTables(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateDataTable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.DataTableComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.DataTableComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 3&& translator.Assignable<System.Type>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    System.Type dataRowType = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    string text = LuaAPI.lua_tostring(L, 3);
                    
                        GameFramework.DataTable.DataTableBase __cl_gen_ret = __cl_gen_to_be_invoked.CreateDataTable( dataRowType, text );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<System.Type>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)) 
                {
                    System.Type dataRowType = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    string name = LuaAPI.lua_tostring(L, 3);
                    string text = LuaAPI.lua_tostring(L, 4);
                    
                        GameFramework.DataTable.DataTableBase __cl_gen_ret = __cl_gen_to_be_invoked.CreateDataTable( dataRowType, name, text );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.DataTableComponent.CreateDataTable!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroyDataTable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.DataTableComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.DataTableComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& translator.Assignable<System.Type>(L, 2)) 
                {
                    System.Type dataRowType = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.DestroyDataTable( dataRowType );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<System.Type>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    System.Type dataRowType = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    string name = LuaAPI.lua_tostring(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.DestroyDataTable( dataRowType, name );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.DataTableComponent.DestroyDataTable!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Count(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityGameFramework.Runtime.DataTableComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.DataTableComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Count);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
