namespace GameMain
{
    public class VersionInfo
    {
        /// <summary>
        /// 是否强制更新
        /// </summary>
        public bool ForceGameUpdate
        {
            get;
            set;
        }

        /// <summary>
        /// 最新游戏版本
        /// </summary>
        public string LatestGameVersion
        {
            get;
            set;
        }

        /// <summary>
        /// 应用程序内部版本号。
        /// </summary>
        public int InternalApplicationVersion
        {
            get;
            set;
        }

        /// <summary>
        /// 内部资源版本号
        /// </summary>
        public int InternalResourceVersion
        {
            get;
            set;
        }

        /// <summary>
        /// 游戏更新URL
        /// </summary>
        public string GameUpdateUrl
        {
            get;
            set;
        }

        public int VersionListLength
        {
            get;
            set;
        }

        public int VersionListHashCode
        {
            get;
            set;
        }

        public int VersionListZipLength
        {
            get;
            set;
        }

        public int VersionListZipHashCode
        {
            get;
            set;
        }
    }
}
