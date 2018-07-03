namespace GameMain
{
    public enum CameraEffectType
    {
        /// <summary>
        /// 默认，无效果
        /// </summary>
        Deafault = 0,

        /// <summary>
        /// 模糊电影效果
        /// </summary>
        BlurMovie = 1,

        /// <summary>
        /// 高速模糊效果
        /// </summary>
        BlurRadial = 2,

        /// <summary>
        /// 滴水波纹效果
        /// </summary>
        WaterDrop = 3,

        /// <summary>
        /// 灰屏效果
        /// </summary>
        ScreenGray = 4,

        /// <summary>
        /// 油画效果
        /// </summary>
        OilPaint = 5,

        /// <summary>
        /// 屏幕过度效果
        /// </summary>
        ScreenFade = 6,

        /// <summary>
        /// 屏幕震动效果
        /// </summary>
        ScreenShake = 7,
    }
}
