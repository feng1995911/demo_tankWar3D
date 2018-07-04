using System.Collections.Generic;

namespace GameMain
{
    /// <summary>
    /// buff接口
    /// </summary>
    public interface IActorBuff
    {
        /// <summary>
        /// 添加Buff
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="caster">作用者</param>
        void AddBuff(int id, ActorBase caster);

        /// <summary>
        /// 移除Buff
        /// </summary>
        /// <param name="id">编号</param>
        void RemoveBuff(int id);

        /// <summary>
        /// 移除所有Buff
        /// </summary>
        void RemoveAllBuff();

        /// <summary>
        /// 移除所有负面效果Buff
        /// </summary>
        void RemoveAllDebuff();

        /// <summary>
        /// 移除所有控制Buff
        /// </summary>
        void RemoveAllControl();

        /// <summary>
        /// 执行
        /// </summary>
        void Step();

        /// <summary>
        /// 清空
        /// </summary>
        void Clear();

        /// <summary>
        /// 获取所有buff
        /// </summary>
        Map<int, BuffBase> GetAllBuff();

        /// <summary>
        /// 设置特效是否显示
        /// </summary>
        /// <param name="enable"></param>
        void SetAllEffectEnable(bool enable);
    }
}
