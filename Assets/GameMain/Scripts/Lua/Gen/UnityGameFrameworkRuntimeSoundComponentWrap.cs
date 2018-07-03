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
    public class UnityGameFrameworkRuntimeSoundComponentWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityGameFramework.Runtime.SoundComponent);
			Utils.BeginObjectRegister(type, L, translator, 0, 12, 2, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HasSoundGroup", _m_HasSoundGroup);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSoundGroup", _m_GetSoundGroup);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAllSoundGroups", _m_GetAllSoundGroups);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddSoundGroup", _m_AddSoundGroup);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAllLoadingSoundSerialIds", _m_GetAllLoadingSoundSerialIds);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsLoadingSound", _m_IsLoadingSound);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PlaySound", _m_PlaySound);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StopSound", _m_StopSound);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StopAllLoadedSounds", _m_StopAllLoadedSounds);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StopAllLoadingSounds", _m_StopAllLoadingSounds);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PauseSound", _m_PauseSound);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ResumeSound", _m_ResumeSound);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "SoundGroupCount", _g_get_SoundGroupCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "AudioMixer", _g_get_AudioMixer);
            
			
			
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
					
					UnityGameFramework.Runtime.SoundComponent __cl_gen_ret = new UnityGameFramework.Runtime.SoundComponent();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.SoundComponent constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasSoundGroup(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.SoundComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.SoundComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string soundGroupName = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.HasSoundGroup( soundGroupName );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSoundGroup(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.SoundComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.SoundComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string soundGroupName = LuaAPI.lua_tostring(L, 2);
                    
                        GameFramework.Sound.ISoundGroup __cl_gen_ret = __cl_gen_to_be_invoked.GetSoundGroup( soundGroupName );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllSoundGroups(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.SoundComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.SoundComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        GameFramework.Sound.ISoundGroup[] __cl_gen_ret = __cl_gen_to_be_invoked.GetAllSoundGroups(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddSoundGroup(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.SoundComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.SoundComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    string soundGroupName = LuaAPI.lua_tostring(L, 2);
                    int soundAgentHelperCount = LuaAPI.xlua_tointeger(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.AddSoundGroup( soundGroupName, soundAgentHelperCount );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 6&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)) 
                {
                    string soundGroupName = LuaAPI.lua_tostring(L, 2);
                    bool soundGroupAvoidBeingReplacedBySamePriority = LuaAPI.lua_toboolean(L, 3);
                    bool soundGroupMute = LuaAPI.lua_toboolean(L, 4);
                    float soundGroupVolume = (float)LuaAPI.lua_tonumber(L, 5);
                    int soundAgentHelperCount = LuaAPI.xlua_tointeger(L, 6);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.AddSoundGroup( soundGroupName, soundGroupAvoidBeingReplacedBySamePriority, soundGroupMute, soundGroupVolume, soundAgentHelperCount );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.SoundComponent.AddSoundGroup!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllLoadingSoundSerialIds(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.SoundComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.SoundComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int[] __cl_gen_ret = __cl_gen_to_be_invoked.GetAllLoadingSoundSerialIds(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsLoadingSound(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.SoundComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.SoundComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int serialId = LuaAPI.xlua_tointeger(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsLoadingSound( serialId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlaySound(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.SoundComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.SoundComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    string soundAssetName = LuaAPI.lua_tostring(L, 2);
                    string soundGroupName = LuaAPI.lua_tostring(L, 3);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.PlaySound( soundAssetName, soundGroupName );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<GameFramework.Sound.PlaySoundParams>(L, 4)) 
                {
                    string soundAssetName = LuaAPI.lua_tostring(L, 2);
                    string soundGroupName = LuaAPI.lua_tostring(L, 3);
                    GameFramework.Sound.PlaySoundParams playSoundParams = (GameFramework.Sound.PlaySoundParams)translator.GetObject(L, 4, typeof(GameFramework.Sound.PlaySoundParams));
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.PlaySound( soundAssetName, soundGroupName, playSoundParams );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 4)) 
                {
                    string soundAssetName = LuaAPI.lua_tostring(L, 2);
                    string soundGroupName = LuaAPI.lua_tostring(L, 3);
                    UnityGameFramework.Runtime.Entity bindingEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 4, typeof(UnityGameFramework.Runtime.Entity));
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.PlaySound( soundAssetName, soundGroupName, bindingEntity );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 4)) 
                {
                    string soundAssetName = LuaAPI.lua_tostring(L, 2);
                    string soundGroupName = LuaAPI.lua_tostring(L, 3);
                    object userData = translator.GetObject(L, 4, typeof(object));
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.PlaySound( soundAssetName, soundGroupName, userData );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.Vector3>(L, 4)) 
                {
                    string soundAssetName = LuaAPI.lua_tostring(L, 2);
                    string soundGroupName = LuaAPI.lua_tostring(L, 3);
                    UnityEngine.Vector3 worldPosition;translator.Get(L, 4, out worldPosition);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.PlaySound( soundAssetName, soundGroupName, worldPosition );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<GameFramework.Sound.PlaySoundParams>(L, 4)&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 5)) 
                {
                    string soundAssetName = LuaAPI.lua_tostring(L, 2);
                    string soundGroupName = LuaAPI.lua_tostring(L, 3);
                    GameFramework.Sound.PlaySoundParams playSoundParams = (GameFramework.Sound.PlaySoundParams)translator.GetObject(L, 4, typeof(GameFramework.Sound.PlaySoundParams));
                    UnityGameFramework.Runtime.Entity bindingEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 5, typeof(UnityGameFramework.Runtime.Entity));
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.PlaySound( soundAssetName, soundGroupName, playSoundParams, bindingEntity );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<GameFramework.Sound.PlaySoundParams>(L, 4)&& translator.Assignable<object>(L, 5)) 
                {
                    string soundAssetName = LuaAPI.lua_tostring(L, 2);
                    string soundGroupName = LuaAPI.lua_tostring(L, 3);
                    GameFramework.Sound.PlaySoundParams playSoundParams = (GameFramework.Sound.PlaySoundParams)translator.GetObject(L, 4, typeof(GameFramework.Sound.PlaySoundParams));
                    object userData = translator.GetObject(L, 5, typeof(object));
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.PlaySound( soundAssetName, soundGroupName, playSoundParams, userData );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 4)&& translator.Assignable<object>(L, 5)) 
                {
                    string soundAssetName = LuaAPI.lua_tostring(L, 2);
                    string soundGroupName = LuaAPI.lua_tostring(L, 3);
                    UnityGameFramework.Runtime.Entity bindingEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 4, typeof(UnityGameFramework.Runtime.Entity));
                    object userData = translator.GetObject(L, 5, typeof(object));
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.PlaySound( soundAssetName, soundGroupName, bindingEntity, userData );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<GameFramework.Sound.PlaySoundParams>(L, 4)&& translator.Assignable<UnityEngine.Vector3>(L, 5)) 
                {
                    string soundAssetName = LuaAPI.lua_tostring(L, 2);
                    string soundGroupName = LuaAPI.lua_tostring(L, 3);
                    GameFramework.Sound.PlaySoundParams playSoundParams = (GameFramework.Sound.PlaySoundParams)translator.GetObject(L, 4, typeof(GameFramework.Sound.PlaySoundParams));
                    UnityEngine.Vector3 worldPosition;translator.Get(L, 5, out worldPosition);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.PlaySound( soundAssetName, soundGroupName, playSoundParams, worldPosition );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.Vector3>(L, 4)&& translator.Assignable<object>(L, 5)) 
                {
                    string soundAssetName = LuaAPI.lua_tostring(L, 2);
                    string soundGroupName = LuaAPI.lua_tostring(L, 3);
                    UnityEngine.Vector3 worldPosition;translator.Get(L, 4, out worldPosition);
                    object userData = translator.GetObject(L, 5, typeof(object));
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.PlaySound( soundAssetName, soundGroupName, worldPosition, userData );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 6&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<GameFramework.Sound.PlaySoundParams>(L, 4)&& translator.Assignable<UnityGameFramework.Runtime.Entity>(L, 5)&& translator.Assignable<object>(L, 6)) 
                {
                    string soundAssetName = LuaAPI.lua_tostring(L, 2);
                    string soundGroupName = LuaAPI.lua_tostring(L, 3);
                    GameFramework.Sound.PlaySoundParams playSoundParams = (GameFramework.Sound.PlaySoundParams)translator.GetObject(L, 4, typeof(GameFramework.Sound.PlaySoundParams));
                    UnityGameFramework.Runtime.Entity bindingEntity = (UnityGameFramework.Runtime.Entity)translator.GetObject(L, 5, typeof(UnityGameFramework.Runtime.Entity));
                    object userData = translator.GetObject(L, 6, typeof(object));
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.PlaySound( soundAssetName, soundGroupName, playSoundParams, bindingEntity, userData );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 6&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<GameFramework.Sound.PlaySoundParams>(L, 4)&& translator.Assignable<UnityEngine.Vector3>(L, 5)&& translator.Assignable<object>(L, 6)) 
                {
                    string soundAssetName = LuaAPI.lua_tostring(L, 2);
                    string soundGroupName = LuaAPI.lua_tostring(L, 3);
                    GameFramework.Sound.PlaySoundParams playSoundParams = (GameFramework.Sound.PlaySoundParams)translator.GetObject(L, 4, typeof(GameFramework.Sound.PlaySoundParams));
                    UnityEngine.Vector3 worldPosition;translator.Get(L, 5, out worldPosition);
                    object userData = translator.GetObject(L, 6, typeof(object));
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.PlaySound( soundAssetName, soundGroupName, playSoundParams, worldPosition, userData );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.SoundComponent.PlaySound!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopSound(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.SoundComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.SoundComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int serialId = LuaAPI.xlua_tointeger(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.StopSound( serialId );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    int serialId = LuaAPI.xlua_tointeger(L, 2);
                    float fadeOutSeconds = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.StopSound( serialId, fadeOutSeconds );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.SoundComponent.StopSound!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopAllLoadedSounds(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.SoundComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.SoundComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 1) 
                {
                    
                    __cl_gen_to_be_invoked.StopAllLoadedSounds(  );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float fadeOutSeconds = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    __cl_gen_to_be_invoked.StopAllLoadedSounds( fadeOutSeconds );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.SoundComponent.StopAllLoadedSounds!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopAllLoadingSounds(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.SoundComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.SoundComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.StopAllLoadingSounds(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PauseSound(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.SoundComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.SoundComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int serialId = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.PauseSound( serialId );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    int serialId = LuaAPI.xlua_tointeger(L, 2);
                    float fadeOutSeconds = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    __cl_gen_to_be_invoked.PauseSound( serialId, fadeOutSeconds );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.SoundComponent.PauseSound!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResumeSound(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityGameFramework.Runtime.SoundComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.SoundComponent)translator.FastGetCSObj(L, 1);
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int serialId = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.ResumeSound( serialId );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    int serialId = LuaAPI.xlua_tointeger(L, 2);
                    float fadeInSeconds = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    __cl_gen_to_be_invoked.ResumeSound( serialId, fadeInSeconds );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityGameFramework.Runtime.SoundComponent.ResumeSound!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SoundGroupCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityGameFramework.Runtime.SoundComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.SoundComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.SoundGroupCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AudioMixer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityGameFramework.Runtime.SoundComponent __cl_gen_to_be_invoked = (UnityGameFramework.Runtime.SoundComponent)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.AudioMixer);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
