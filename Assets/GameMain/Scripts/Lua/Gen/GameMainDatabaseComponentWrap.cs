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
    public class GameMainDatabaseComponentWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(GameMain.DatabaseComponent);
			Utils.BeginObjectRegister(type, L, translator, 0, 20, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Init", _m_Init);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Clear", _m_Clear);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "TryLogin", _m_TryLogin);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "TryRegister", _m_TryRegister);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SaveDatabase", _m_SaveDatabase);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetUserId", _m_GetUserId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPlayerId", _m_GetPlayerId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OpenDB", _m_OpenDB);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CloseSqlConnection", _m_CloseSqlConnection);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ExecuteQuery", _m_ExecuteQuery);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadFullTable", _m_ReadFullTable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InsertInto", _m_InsertInto);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateInto", _m_UpdateInto);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Delete", _m_Delete);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InsertIntoSpecific", _m_InsertIntoSpecific);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DeleteContents", _m_DeleteContents);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CreateTable", _m_CreateTable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SelectWhere", _m_SelectWhere);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SelectWhereEqual", _m_SelectWhereEqual);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CheckTable", _m_CheckTable);
			
			
			
			
			
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
					
					GameMain.DatabaseComponent __cl_gen_ret = new GameMain.DatabaseComponent();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to GameMain.DatabaseComponent constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameMain.DatabaseComponent __cl_gen_to_be_invoked = (GameMain.DatabaseComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.Init(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameMain.DatabaseComponent __cl_gen_to_be_invoked = (GameMain.DatabaseComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryLogin(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameMain.DatabaseComponent __cl_gen_to_be_invoked = (GameMain.DatabaseComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int account = LuaAPI.xlua_tointeger(L, 2);
                    int password = LuaAPI.xlua_tointeger(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TryLogin( account, password );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryRegister(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameMain.DatabaseComponent __cl_gen_to_be_invoked = (GameMain.DatabaseComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int account = LuaAPI.xlua_tointeger(L, 2);
                    int password = LuaAPI.xlua_tointeger(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TryRegister( account, password );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SaveDatabase(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameMain.DatabaseComponent __cl_gen_to_be_invoked = (GameMain.DatabaseComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.SaveDatabase(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUserId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameMain.DatabaseComponent __cl_gen_to_be_invoked = (GameMain.DatabaseComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetUserId(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPlayerId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameMain.DatabaseComponent __cl_gen_to_be_invoked = (GameMain.DatabaseComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetPlayerId(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OpenDB(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameMain.DatabaseComponent __cl_gen_to_be_invoked = (GameMain.DatabaseComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string connectionString = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.OpenDB( connectionString );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloseSqlConnection(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameMain.DatabaseComponent __cl_gen_to_be_invoked = (GameMain.DatabaseComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.CloseSqlConnection(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExecuteQuery(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameMain.DatabaseComponent __cl_gen_to_be_invoked = (GameMain.DatabaseComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string sqlQuery = LuaAPI.lua_tostring(L, 2);
                    
                        Mono.Data.Sqlite.SqliteDataReader __cl_gen_ret = __cl_gen_to_be_invoked.ExecuteQuery( sqlQuery );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadFullTable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameMain.DatabaseComponent __cl_gen_to_be_invoked = (GameMain.DatabaseComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string tableName = LuaAPI.lua_tostring(L, 2);
                    
                        Mono.Data.Sqlite.SqliteDataReader __cl_gen_ret = __cl_gen_to_be_invoked.ReadFullTable( tableName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InsertInto(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameMain.DatabaseComponent __cl_gen_to_be_invoked = (GameMain.DatabaseComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string tableName = LuaAPI.lua_tostring(L, 2);
                    string[] values = (string[])translator.GetObject(L, 3, typeof(string[]));
                    
                        Mono.Data.Sqlite.SqliteDataReader __cl_gen_ret = __cl_gen_to_be_invoked.InsertInto( tableName, values );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateInto(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameMain.DatabaseComponent __cl_gen_to_be_invoked = (GameMain.DatabaseComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string tableName = LuaAPI.lua_tostring(L, 2);
                    string[] cols = (string[])translator.GetObject(L, 3, typeof(string[]));
                    string[] colsvalues = (string[])translator.GetObject(L, 4, typeof(string[]));
                    string[] selectkey = (string[])translator.GetObject(L, 5, typeof(string[]));
                    string[] selectvalue = (string[])translator.GetObject(L, 6, typeof(string[]));
                    
                        Mono.Data.Sqlite.SqliteDataReader __cl_gen_ret = __cl_gen_to_be_invoked.UpdateInto( tableName, cols, colsvalues, selectkey, selectvalue );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Delete(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameMain.DatabaseComponent __cl_gen_to_be_invoked = (GameMain.DatabaseComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string tableName = LuaAPI.lua_tostring(L, 2);
                    string[] cols = (string[])translator.GetObject(L, 3, typeof(string[]));
                    string[] colsvalues = (string[])translator.GetObject(L, 4, typeof(string[]));
                    
                        Mono.Data.Sqlite.SqliteDataReader __cl_gen_ret = __cl_gen_to_be_invoked.Delete( tableName, cols, colsvalues );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InsertIntoSpecific(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameMain.DatabaseComponent __cl_gen_to_be_invoked = (GameMain.DatabaseComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string tableName = LuaAPI.lua_tostring(L, 2);
                    string[] cols = (string[])translator.GetObject(L, 3, typeof(string[]));
                    string[] values = (string[])translator.GetObject(L, 4, typeof(string[]));
                    
                        Mono.Data.Sqlite.SqliteDataReader __cl_gen_ret = __cl_gen_to_be_invoked.InsertIntoSpecific( tableName, cols, values );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeleteContents(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameMain.DatabaseComponent __cl_gen_to_be_invoked = (GameMain.DatabaseComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string tableName = LuaAPI.lua_tostring(L, 2);
                    
                        Mono.Data.Sqlite.SqliteDataReader __cl_gen_ret = __cl_gen_to_be_invoked.DeleteContents( tableName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateTable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameMain.DatabaseComponent __cl_gen_to_be_invoked = (GameMain.DatabaseComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    string[] col = (string[])translator.GetObject(L, 3, typeof(string[]));
                    string[] colType = (string[])translator.GetObject(L, 4, typeof(string[]));
                    
                        Mono.Data.Sqlite.SqliteDataReader __cl_gen_ret = __cl_gen_to_be_invoked.CreateTable( name, col, colType );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SelectWhere(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameMain.DatabaseComponent __cl_gen_to_be_invoked = (GameMain.DatabaseComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string tableName = LuaAPI.lua_tostring(L, 2);
                    string[] items = (string[])translator.GetObject(L, 3, typeof(string[]));
                    string[] col = (string[])translator.GetObject(L, 4, typeof(string[]));
                    string[] operation = (string[])translator.GetObject(L, 5, typeof(string[]));
                    string[] values = (string[])translator.GetObject(L, 6, typeof(string[]));
                    
                        Mono.Data.Sqlite.SqliteDataReader __cl_gen_ret = __cl_gen_to_be_invoked.SelectWhere( tableName, items, col, operation, values );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SelectWhereEqual(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameMain.DatabaseComponent __cl_gen_to_be_invoked = (GameMain.DatabaseComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string tableName = LuaAPI.lua_tostring(L, 2);
                    string[] items = (string[])translator.GetObject(L, 3, typeof(string[]));
                    string[] col = (string[])translator.GetObject(L, 4, typeof(string[]));
                    string[] values = (string[])translator.GetObject(L, 5, typeof(string[]));
                    
                        Mono.Data.Sqlite.SqliteDataReader __cl_gen_ret = __cl_gen_to_be_invoked.SelectWhereEqual( tableName, items, col, values );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckTable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                GameMain.DatabaseComponent __cl_gen_to_be_invoked = (GameMain.DatabaseComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string tableName = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CheckTable( tableName );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
