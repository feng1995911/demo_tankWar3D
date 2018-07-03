using System.Collections.Generic;

namespace GameMain
{
    /// <summary>
    /// 计算策略
    /// </summary>
    public interface IAttributeStrategy
    {
        /// <summary>
        /// 根据属性计算攻击结果
        /// </summary>
        AttackResultType CalcAttackResult(IAttribute attack, IAttribute defender);

        /// <summary>
        /// 根据等级计算英雄属性
        /// </summary>
        void CalcHeroLevel(Dictionary<PropertyType, int> curData, int level);

        /// <summary>
        /// 根据等级计算同伴属性
        /// </summary>
        void CalcPartner(Dictionary<PropertyType, int> curData, int id, int partnerLevel);

        /// <summary>
        /// 根据同伴进化等级计算属性
        /// </summary>
        void CalcPartnerAdvance(Dictionary<PropertyType, int> curData, int id, int advanceLevel);

        /// <summary>
        /// 根据装备强化等级计算属性
        /// </summary>
        void CalcEquipStrength(Dictionary<PropertyType, int> curData, int id, int strengthLevel);

        /// <summary>
        /// 根据装备进化等级计算属性
        /// </summary>
        void CalcEquipAdvance(Dictionary<PropertyType, int> curData, int id, int advanceLevel);

        /// <summary>
        /// 根据装备星级计算属性
        /// </summary>
        void CalcEquipStar(Dictionary<PropertyType, int> curData, int id, int starLevel);

        /// <summary>
        /// 根据宝石强化等级计算属性
        /// </summary>
        int CalcGemStrenthLevel(Dictionary<PropertyType, int> curData, int id, int strengthLevel);

        /// <summary>
        /// 计算所有穿戴的宝石属性
        /// </summary>
        void CalcAllDressGem(Dictionary<PropertyType, int> curData, int ownerId);

        /// <summary>
        /// 计算所有穿戴的装备属性
        /// </summary>
        void CalcAllDressEquip(Dictionary<PropertyType, int> curData,int ownerId);

        /// <summary>
        /// 计算最终伤害
        /// </summary>
        /// <param name="attackerAttr">攻击者属性</param>
        /// <param name="defenseAttr">防御者属性</param>
        int CalcFinalDamage(IAttribute attackerAttr,IAttribute defenseAttr);

  
    }
}
