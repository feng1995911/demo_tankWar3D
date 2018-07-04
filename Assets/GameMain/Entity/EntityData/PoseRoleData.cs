using System;
using UnityEngine;
using GameFramework.DataTable;
namespace GameMain
{
    [Serializable]
    public class PoseRoleData : EntityData
    {
        [SerializeField]
        private ProfessionType m_ProfessionType;

        [SerializeField]
        private int m_SoundId;

        [SerializeField]
        private float m_SoundDelay;

        private EffectData m_Effect01Data;

        private EffectData m_Effect02Data;


        public PoseRoleData(int entityId, int typeId)
            : base(entityId, typeId)
        {
            IDataTable<DRPoseRole> dtPoseRole = GameEntry.DataTable.GetDataTable<DRPoseRole>();
            DRPoseRole drPoseRole = dtPoseRole.GetDataRow(TypeId);
            if (drPoseRole == null)
            {
                return;
            }

            m_ProfessionType = (ProfessionType) drPoseRole.ProfessionType;
            m_Effect01Data = new EffectData(GameEntry.Entity.GenerateTempSerialId(), drPoseRole.Effect01)
            {
                KeepTime = drPoseRole.Effect01Duration,
                DelayTime = drPoseRole.Effect01Delay
            };

            m_Effect02Data = new EffectData(GameEntry.Entity.GenerateTempSerialId(), drPoseRole.Effect02)
            {
                KeepTime = drPoseRole.Effect02Duration,
                DelayTime = drPoseRole.Effect02Delay
            };

            m_SoundId = drPoseRole.SoundId;
            m_SoundDelay = drPoseRole.SoundDelay;
        }

        /// <summary>
        /// 职业类型
        /// </summary>
        public ProfessionType PrefessionTyoe => m_ProfessionType;

        /// <summary>
        /// 特效01数据
        /// </summary>
        public EffectData Effect01Data => m_Effect01Data;

        /// <summary>
        /// 特效02数据
        /// </summary>
        public EffectData Effect02Data => m_Effect02Data;

        /// <summary>
        /// 音效id
        /// </summary>
        public int SoundId => m_SoundId;

        /// <summary>
        /// 音效延迟
        /// </summary>
        public float SoundDelay => m_SoundDelay;
    }
}
