using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// 行动者接口
    /// </summary>
    public interface IActor
    {
        /// <summary>
        /// 实体ID
        /// </summary>
        int Id { get; }

        /// <summary>
        /// 游戏实体
        /// </summary>
        GameObject EntityGo { get; }

        /// <summary>
        /// 缓存Transform
        /// </summary>
        Transform CachedTransform { get; }

        /// <summary>
        /// 当前方向
        /// </summary>
        Vector3 Dir { get; }

        /// <summary>
        /// 欧拉角
        /// </summary>
        Vector3 Euler { get; }

        /// <summary>
        /// 位置
        /// </summary>
        Vector3 Pos { get; }

        /// <summary>
        /// 属性
        /// </summary>
        IAttribute Attrbute { get;}

        /// <summary>
        /// 所属阵营
        /// </summary>
        BattleCampType Camp { get; }

        /// <summary>
        /// 高度
        /// </summary>
        float Height { get; }

        /// <summary>
        /// 半径
        /// </summary>
        float Radius { get; }

        /// <summary>
        /// 是否死亡
        /// </summary>
        bool IsDead { get; }

        /// <summary>
        /// 初始化
        /// </summary>
        void Init();

        /// <summary>
        /// 执行
        /// </summary>
        void Step();

        /// <summary>
        /// 暂停/继续
        /// </summary>
        /// <param name="isPause"></param>
        void Pause(bool isPause);

        /// <summary>
        /// 销毁
        /// </summary>
        void Clear();

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <typeparam name="T">命令类型</typeparam>
        /// <param name="command">命令</param>
        /// <returns>返回命令执行结果</returns>
        CommandReplyType ExecuteCommand<T>(T command) where T :
            ICommand;

        /// <summary>
        /// 是否应用动画控制器
        /// </summary>
        void ApplyAnimator(bool enable);

        /// <summary>
        /// 是否应用根节点动画
        /// </summary>
        void ApplyRootMotion(bool enable);

        /// <summary>
        /// 是否启用控制
        /// </summary>
        void ApplyCharacterCtrl(bool enable);

        /// <summary>
        /// 瞬移到某个点
        /// </summary>
        /// <param name="destPosition">目标位置</param>
        /// <param name="idle">是否切换到空闲态</param>
        void TranslateTo(Vector3 destPosition, bool idle);

        /// <summary>
        /// 移动到某个点
        /// </summary>
        /// <param name="destPosition"></param>
        void MoveTo(Vector3 destPosition);

        /// <summary>
        /// 停止寻路SuckBlood
        /// </summary>
        void StopPathFinding();

        /// <summary>
        /// 攻击
        /// </summary>
        /// <param name="defender">目标</param>
        /// <param name="value">值</param>
        int Attack(IActor defender, int value);

        /// <summary>
        /// 受伤
        /// </summary>
        /// <param name="attacker">攻击值</param>
        /// <param name="damage">伤害值</param>
        /// <param name="strike">是否暴击</param>
        void TakeDamage(IActor attacker, int damage, bool strike);

        /// <summary>
        /// 是否在某个状态
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool CheckActorState(ActorStateType type);
    }
}
