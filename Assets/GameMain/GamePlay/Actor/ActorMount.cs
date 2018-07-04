using UnityEngine;

namespace GameMain
{
    public class ActorMount : ActorBase
    {
        public ActorMount(RoleEntityBase entity, ActorType type, BattleCampType camp, CharacterController cc, Animator anim) : base(entity, type, camp, cc, anim)
        {

        }

        public override void Init()
        {
            InitAttribute(true);
            InitLayer();
            InitCommands();
            InitAnim();
            InitAi();
            InitFeature();
            InitState();
            InitFsm();

            CreateBoard();
            ApplyCharacterCtrl(true);
        }

        protected override void InitAttribute(bool init = false)
        {
            m_CurAttribute = new ActorAttribute();
            m_CurAttribute.UpdateValue(AttributeType.Speed, (int)m_ActorData.Speed);
        }

        protected override void CreateBoard()
        {
            BoardFormData data = new BoardFormData
            {
                OwnerId = EntityId,
                ActorType = ActorType,
                CacheTransform = CachedTransform,
                Name = m_ActorData.Name,
                Level = m_ActorData.Level,
                Height = Height
            };
            BoardFormManager.Instance.Create(data);
        }

        public Transform GetRidePoint()
        {
            return GlobalTools.GetBone(CachedTransform, "Bone026");
        }
    }
}
