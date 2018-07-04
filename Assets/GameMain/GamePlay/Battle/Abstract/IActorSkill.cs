using System.Collections.Generic;
using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// 技能接口
    /// </summary>
    public interface IActorSkill
    {
        /// <summary>
        /// 执行
        /// </summary>
        void Step();

        /// <summary>
        /// 使用技能
        /// </summary>
        /// <param name="id">技能ID</param>
        /// <returns>返回是否技能使用成功</returns>
        bool UseSkill(int id);

        /// <summary>
        /// 使用技能
        /// </summary>
        /// <param name="pos">技能索引</param>
        /// <returns>返回是否技能使用成功</returns>
        bool UseSkill(SkillPosType pos);

        /// <summary>
        /// 获取技能
        /// </summary>
        /// <param name="id">技能ID</param>
        /// <returns>返回技能树</returns>
        SkillTree GetSkill(int id);

        /// <summary>
        /// 获取技能
        /// </summary>
        /// <param name="pos">技能索引</param>
        /// <returns>返回技能树</returns>
        SkillTree GetSkill(SkillPosType pos);

        /// <summary>
        /// 获取所有技能
        /// </summary>
        /// <returns></returns>
        List<SkillTree> GetAllSkill();

            /// <summary>
        /// 根据距离获取下一个技能
        /// </summary>
        /// <param name="dist">距离</param>
        /// <returns>返回技能树</returns>
        SkillTree FindNextSkillByDist(float dist);

        /// <summary>
        /// 根据距离获取下一个技能
        /// </summary>
        /// <param name="dist">距离</param>
        /// <returns>返回技能树</returns>
        SkillTree FindNextSkillByDist(Vector3 dist);

        /// <summary>
        /// 获取最小施法距离
        /// </summary>
        float GetMinCastDistance();

        /// <summary>
        /// 清空
        /// </summary>
        void Clear();
    }
}
