using GameFramework.Fsm;

namespace GameMain
{
    /// <summary>
    /// 行动者AI
    /// </summary>
    public interface IActorAI
    {
        /// <summary>
        /// 拥有者
        /// </summary>
        IActor Owner { get; }

        /// <summary>
        /// AI状态
        /// </summary>
        AIStateType AIStateType { get; }

        /// <summary>
        /// AI模式
        /// </summary>
        AIModeType AIMode { get; }

        /// <summary>
        /// 警告距离
        /// </summary>
        float WaringDist { get; }

        /// <summary>
        /// 攻击距离
        /// </summary>
        float AttackDist { get; }

        /// <summary>
        /// 跟随距离
        /// </summary>
        float FollowDist { get; }

        /// <summary>
        /// 寻敌间隔
        /// </summary>
        float FindEnemyInterval { get; }

        /// <summary>
        /// 寻敌计时
        /// </summary>
        float FindEnemyTimer { get; set; }

        /// <summary>
        /// 开始
        /// </summary>
        void Start();

        /// <summary>
        /// 执行
        /// </summary>
        void Step();

        /// <summary>
        /// 停止
        /// </summary>
        void Stop();

        /// <summary>
        /// 清空
        /// </summary>
        void Clear();

        /// <summary>
        /// 切换AI状态
        /// </summary>
        void ChangeAIState(AIStateType stateType);

        /// <summary>
        /// 切换AI模式
        /// </summary>
        void ChangeAIMode(AIModeType mode);

    }
}
