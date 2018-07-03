using System;
using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// 自动寻路接口
    /// </summary>
    public interface IAIPathFinding
    {
        /// <summary>
        /// 检查是否达到目标地点
        /// </summary>
        bool CheckReached();

        /// <summary>
        /// 设置寻路代理启用/禁用
        /// </summary>
        void SetAgentEnable(bool enable);

        /// <summary>
        /// 设置目标地点
        /// </summary>
        void SetDestPosition(Vector3 dest);

        /// <summary>
        /// 检查是否可以达到某个点
        /// </summary>
        bool CanReachPosition(Vector3 dest);

        /// <summary>
        /// 执行
        /// </summary>
        void Step();

        /// <summary>
        /// 停止寻路
        /// </summary>
        void StopPathFinding();

        /// <summary>
        /// 寻路完成回调
        /// </summary>
        void SetOnFinished(Action callback);
    }
}
