using System;
using System.Collections.Generic;

namespace GameMain
{
    /// <summary>
    /// 属性接口
    /// </summary>
    public interface IAttribute
    {
        /// <summary>
        /// 初始化属性值
        /// </summary>
        void InitAttribute();

        /// <summary>
        /// 获取属性值
        /// </summary>
        int GetValue(AttributeType type);

        /// <summary>
        /// 更新属性值
        /// </summary>
        void UpdateValue(AttributeType type, int value);

        /// <summary>
        /// 拷贝属性
        /// </summary>
        /// <param name="dict"></param>
        void CopyFrom(Dictionary<PropertyType, int> dict);

        /// <summary>
        /// 获取最终承受的伤害
        /// </summary>
        /// <param name="attackerAttrbute">攻击者属性</param>
        int GetFinalDamage(IAttribute attackerAttrbute);
    }
}
