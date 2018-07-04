using System.IO;
using System.Text;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{
    public static class ResourceComponentExtension
    {
        /// <summary>
        /// 编辑器下加载Unity无法识别的文本文件，如.lua
        /// </summary>
        public static string LoadTextAsset(this ResourceComponent editorResourceComponent, string assetName)
        {
            string path = Application.dataPath.Replace("Assets", "") + assetName;
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            return sr.ReadToEnd();
        }

    }
}
