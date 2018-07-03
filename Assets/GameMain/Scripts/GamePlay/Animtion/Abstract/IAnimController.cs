using System;
using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// 动作控制接口
    /// </summary>
    public interface IAnimController
    {
        /// <summary>
        /// 设置动画控制启用或禁用
        /// </summary>
        void SetEnable(bool enable);

        /// <summary>
        /// 设置根节点动画是否启用
        /// </summary>
        void SetRootMotionEnable(bool enable);

        /// <summary>
        /// 播放动画
        /// </summary>
        /// <param name="animName">动画名称</param>
        /// <param name="onFinish">播完回调</param>
        /// <param name="isLoop">是否循环</param>
        /// <param name="speed">播放速度</param>
        /// <param name="lastTime">结束时间</param>
        void Play(string animName, Action onFinish = null, bool isLoop = false, float speed = 1, float lastTime = 0);

        /// <summary>
        /// 打断当前动画
        /// </summary>
        void Break();

        /// <summary>
        /// 轮询
        /// </summary>
        void Step();

        /// <summary>
        /// 重置
        /// </summary>
        void Reset();

        /// <summary>
        /// 设置速度
        /// </summary>
        /// <param name="speed">速度</param>
        void SetSpeed(float speed);

        /// <summary>
        /// 获取速度
        /// </summary>
        float GetSpeed();

        /// <summary>
        /// 设置过度事件
        /// </summary>
        /// <param name="speed">过度时间</param>
        void SetFadeTime(float speed);

        /// <summary>
        /// 获取动画长度
        /// </summary>
        /// <param name="animName">动画名</param>
        float GetAnimLength(string animName);

        /// <summary>
        /// 获取当前动画名
        /// </summary>
        string GetCurrentAnimName();

    }
}
