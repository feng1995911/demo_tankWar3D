using FairyGUI;
using System;
using System.Collections.Generic;
using GameFramework;
using GameFramework.DataTable;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/FairyGui")]
    public class FairyGuiComponent : GameFrameworkComponent,ICustomComponent
    {
        private Dictionary<string, MyUIPackage> m_UIPackages = null;
        private Dictionary<int, string> m_LuaForms = null;

        public void Init()
        {
            m_UIPackages = new Dictionary<string, MyUIPackage>();
            m_LuaForms = new Dictionary<int, string>();
            RegisterItemExtension();
            RegisterCustomLoader();
        }

        public void Clear()
        {
            foreach (KeyValuePair<int, string> luaFormInfo in m_LuaForms)
            {
                IDataTable<DRUIForm> dt = GameEntry.DataTable.GetDataTable<DRUIForm>();
                string formGroup = dt.GetDataRow(luaFormInfo.Key).UIGroupName;
                FairyGuiLuaForm luaForm = GameEntry.UI.GetUIForm(luaFormInfo.Key, formGroup) as FairyGuiLuaForm;
                if (luaForm != null)
                {
                    luaForm.Clear();
                    GameEntry.UI.CloseUIForm(luaForm);
                }
            }

            BoardFormManager.Instance.Clear();

            m_LuaForms.Clear();
            m_UIPackages.Clear();
            UIPackage.RemoveAllPackages();
        }

        /// <summary>
        /// 添加FairyGUI的UIPackage
        /// </summary>
        /// <param name="packageAssetName">资源包名</param>
        public void AddPackage(string packagePath)
        {
            if (!m_UIPackages.ContainsKey(packagePath))
            {
                string packageAssetPath = AssetUtility.GetFairyGuiPackageAsset(packagePath);
                UIPackage package = UIPackage.AddPackage(packageAssetPath, LoadPackageAsset);
                if (package != null)
                {
                    MyUIPackage myUiPackage = new MyUIPackage(package, 0);
                }
                else
                {
                    Log.Error("AddPackage Failure,packagePath:{0}", packagePath);
                }
            }
            else
            {
                MyUIPackage myUiPackage;
                if (m_UIPackages.TryGetValue(packagePath,out myUiPackage))
                {
                    myUiPackage.ReferenceCount++;
                }
                else
                {
                    Log.Error("Can no get myUIpackage,package:{0}", packagePath);
                }
            }
            
        }

        /// <summary>
        /// 移除FairGUI的UIPackage,如果没有引用了就直接移除，否则移除引用计数
        /// </summary>
        /// <param name="packagePath"></param>
        public void RemovePackage(string packagePath)
        {
            MyUIPackage myUiPackage;
            if (m_UIPackages.TryGetValue(packagePath, out myUiPackage))
            {
                myUiPackage.ReferenceCount--;
                if (myUiPackage.ReferenceCount <= 0)
                {
                    string packageAssetPath = AssetUtility.GetFairyGuiPackageAsset(packagePath);
                    UIPackage.RemovePackage(packageAssetPath);
                }
                m_UIPackages.Remove(packagePath);
            }
        }

        /// <summary>
        /// 注册Lua界面
        /// </summary>
        public void RegisterLuaForm(int formId,string formName)
        {
            if(!m_LuaForms.ContainsKey(formId))
            {
                m_LuaForms.Add(formId, formName);
                //Log.Warning("Register luaform id: {0} name:{1}", formId, formName);
            }
            else
            {
                string errorMessage = string.Format("LuaForm {0} is Exist.ID:{1}", formName, formId);
               // throw new GameFrameworkException(errorMessage);
                Log.Warning(errorMessage);
            }
        }

        /// <summary>
        /// 重载Lua界面
        /// </summary>
        public void ReloadLuaForm()
        {
            foreach(KeyValuePair<int,string> luaFormInfo in m_LuaForms)
            {
                IDataTable<DRUIForm> dt = GameEntry.DataTable.GetDataTable<DRUIForm>();
                string formGroup = dt.GetDataRow(luaFormInfo.Key).UIGroupName;
                FairyGuiLuaForm luaForm = GameEntry.UI.GetUIForm(luaFormInfo.Key,formGroup) as FairyGuiLuaForm;
                if (luaForm == null)
                {
                    string errorMessage = string.Format("LuaForm not Exit, Please register first.ID:{1}",
                        luaFormInfo.Key);
                    Log.Error(errorMessage);
                    return;
                }

                luaForm.Reload();
            }
        }

        /// <summary>
        /// 获取Lua界面
        /// </summary>
        /// <param name="formId"></param>
        /// <returns></returns>
        public string GetLuaForm(int formId)
        {
            string luaForm;
            if (m_LuaForms.TryGetValue(formId, out luaForm))
            {
                return luaForm;
            }
            else
            {
                string errorMessage = string.Format("LuaForm not Exit, Please register first.ID:{1}", formId);
                throw new GameFrameworkException(errorMessage);
            }
        }

        private object LoadPackageAsset(string name, string extension, Type type)
        {
            return GameEntry.Resource.LoadAssetSync(name + extension);
        }

        private void RegisterItemExtension()
        {
            UIObjectFactory.SetPackageItemExtension("ui://Home/Buff", typeof (BuffTip));
            UIObjectFactory.SetPackageItemExtension("ui://Home/Button_Attack", typeof (SkillButton));
            UIObjectFactory.SetPackageItemExtension("ui://Level/ThreeStar", typeof (ThreeStar));
            UIObjectFactory.SetPackageItemExtension("ui://Level/LevelItem", typeof (LevelItem));
        }

        private void RegisterCustomLoader()
        {
            UIObjectFactory.SetLoaderExtension(typeof(CustomGLoader));
        }


        private class MyUIPackage
        {
            private UIPackage UIPackage { get; set; }
            public int ReferenceCount { get; set; }

            public MyUIPackage(UIPackage package, int reference)
            {
                UIPackage = package;
                ReferenceCount = reference;
            }
        }
    }
}
