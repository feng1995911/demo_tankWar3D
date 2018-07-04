﻿using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/AppConfig")]
    public class AppConfigComponent : GameFrameworkComponent,ICustomComponent
    {
        [SerializeField]
        private DeviceModelConfig m_DeviceModelConfig = null;

        [SerializeField]
        private TextAsset m_BuildInfoTextAsset = null;

        [SerializeField]
        private TextAsset m_DefaultDictionaryTextAsset = null;

        [SerializeField]
        private UpdateResourceForm m_UpdateResourceFormTemplate = null;

        [SerializeField] private NativeDialogForm m_NativeDialogFormTemplate = null;

        private BuildInfo m_BuildInfo = null;

        public DeviceModelConfig DeviceModelConfig
        {
            get
            {
                return m_DeviceModelConfig;
            }
        }

        public BuildInfo BuildInfo
        {
            get
            {
                return m_BuildInfo;
            }
        }

        public UpdateResourceForm UpdateResourceFormTemplate
        {
            get
            {
                return m_UpdateResourceFormTemplate;               
            }
        }

        public NativeDialogForm NativeDialogFormTemplate
        {
            get
            {
                return m_NativeDialogFormTemplate;
            }
        }

        public void InitBuildInfo()
        {
            if (m_BuildInfoTextAsset == null || string.IsNullOrEmpty(m_BuildInfoTextAsset.text))
            {
                Log.Info("Build info can not be found or empty.");
                return;
            }

            m_BuildInfo = Utility.Json.ToObject<BuildInfo>(m_BuildInfoTextAsset.text);
            if (m_BuildInfo == null)
            {
                Log.Warning("Parse build info failure.");
                return;
            }

            GameEntry.Base.GameVersion = m_BuildInfo.GameVersion;
            GameEntry.Base.InternalApplicationVersion = m_BuildInfo.InternalApplicationVersion;
        }

        public void InitDefaultDictionary()
        {
            if (m_DefaultDictionaryTextAsset == null || string.IsNullOrEmpty(m_DefaultDictionaryTextAsset.text))
            {
                Log.Info("Default dictionary can not be found or empty.");
                return;
            }

            if (!GameEntry.Localization.ParseDictionary(m_DefaultDictionaryTextAsset.text))
            {
                Log.Warning("Parse default dictionary failure.");
                return;
            }
        }

        public void Init()
        {
            
        }

        public void Clear()
        {
           
        }
    }
}
