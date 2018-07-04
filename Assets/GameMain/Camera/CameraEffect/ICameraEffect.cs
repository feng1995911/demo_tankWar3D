using System;

namespace GameMain
{
    public interface ICameraEffect
    {
        /// <summary>
        /// 初始化
        /// </summary>
        void Init();

        /// <summary>
        /// 显示相机效果
        /// </summary>
        void Show();

        /// <summary>
        /// 隐藏相机效果
        /// </summary>
        void Hide();

        /// <summary>
        /// 渐入效果
        /// </summary>
        void FadeIn(float fadeTime, Action callback = null);

        /// <summary>
        /// 渐出效果
        /// </summary>
        /// <param name="fadeTime"></param>
        void FadeOut(float fadeTime, Action callback = null);

        /// <summary>
        /// 清理
        /// </summary>
        void Dispose();
    }
}
