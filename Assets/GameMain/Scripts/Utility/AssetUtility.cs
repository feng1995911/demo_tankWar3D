using UnityEngine;

namespace GameMain
{
    public static class AssetUtility
    {

        public static string GetDataTableAsset(string assetName)
        {
            return GlobalTools.Format("Assets/GameMain/DataTables/{0}.txt", assetName);
        }

        public static string GetDictionaryAsset(string assetName)
        {
            return GlobalTools.Format("Assets/GameMain/Localization/{0}/Dictionaries/{1}.xml", GameEntry.Localization.Language.ToString(), assetName);
        }

        public static string GetFontAsset(string assetName)
        {
            return GlobalTools.Format("Assets/GameMain/Localization/{0}/Fonts/{1}.ttf", GameEntry.Localization.Language.ToString(), assetName);
        }

        public static string GetSceneAsset(string assetName)
        {
            return GlobalTools.Format("Assets/GameMain/Scenes/{0}.unity", assetName);
        }

        public static string GetMusicAsset(string assetName)
        {
            return GlobalTools.Format("Assets/GameMain/Music/{0}.mp3", assetName);
        }

        public static string GetSoundAsset(string assetName)
        {
            return GlobalTools.Format("Assets/GameMain/Sounds/{0}.wav", assetName);
        }

        public static string GetEntityAsset(string assetName)
        {
            return GlobalTools.Format("Assets/GameMain/Entities/{0}.prefab", assetName);
        }

        public static string GetUIFormAsset(string assetName)
        {
            return GlobalTools.Format("Assets/GameMain/UI/UIForms/{0}.prefab", assetName);
        }

        public static string GetFairyGuiPackageAsset(string packageName)
        {
            return GlobalTools.Format("Assets/GameMain/UI/UIPackage/{0}", packageName);
        }

        public static string GetSkillIconAsset(int id)
        {
            return GlobalTools.Format("Assets/GameMain/Textures/Skill/{0}.png", id);
        }

        public static string GetBuffIconAsset(int id)
        {
            return GlobalTools.Format("Assets/GameMain/Textures/Buff/{0}.png", id);
        }

        public static string GetLuaAsset(string assetName)
        {
            return GlobalTools.Format("Assets/GameMain/Lua/{0}.txt", assetName);
        }

        public static string GetSkillScriptAsset(string assetName)
        {
            return GlobalTools.Format("Assets/GameMain/Configs/ActorSkill/{0}.xml", assetName);
        }

        public static string GetLevelConfigAsset(string assetName)
        {
            return GlobalTools.Format("Assets/GameMain/Configs/Level/{0}.xml", assetName);
        }

        public static string GetLevelConfigPath()
        {
            return Application.dataPath + "/GameMain/Configs/Level";
        }

        public static string GetLevelObjectAsset(string assetName)
        {
            return GlobalTools.Format("Assets/GameMain/Entities/Level/{0}.prefab", assetName);
        }

    }
}
