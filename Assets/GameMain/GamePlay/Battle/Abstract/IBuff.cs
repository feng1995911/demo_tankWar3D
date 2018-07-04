namespace GameMain
{
    /// <summary>
    /// Buff接口
    /// </summary>
    public interface IBuff
    {
        /// <summary>
        /// 编号
        /// </summary>
        int Id { get; }

        /// <summary>
        /// 进入Buff
        /// </summary>
        void Enter();

        /// <summary>
        /// 离开Buff
        /// </summary>
        void Exit();

        /// <summary>
        /// 轮询
        /// </summary>
        void Update();

        /// <summary>
        /// 刷新
        /// </summary>
        void Refresh();

        /// <summary>
        /// 覆盖
        /// </summary>
        void Overlay();

        /// <summary>
        /// 获取剩余时间
        /// </summary>
        float GetLeftTime();

        /// <summary>
        /// 设置是否启用特效效果
        /// </summary>
        void SetEffectEnable(bool enable);
    }
}
