using GameFramework;
using UnityEngine;

namespace GameMain
{
    public class ActorEnemy : ActorBase
    {
        public MonsterType MonsterType { get; private set; }

        public ActorEnemy(RoleEntityBase entity, ActorType type, BattleCampType camp, CharacterController cc, Animator anim) : base(entity, type, camp, cc, anim)
        {
            MonsterType = (MonsterType) m_ActorData.MonsterType;

        }

        public bool IsBoss()
        {
            return MonsterType == MonsterType.Boss || MonsterType == MonsterType.World;
        }

        public bool IsChest()
        {
            return MonsterType == MonsterType.Chest;
        }

        public override void OnDead(DeadCommand ev)
        {
            base.OnDead(ev);

            KillMonsterEventArgs args = ReferencePool.Acquire<KillMonsterEventArgs>().Fill(Id, EntityId);
            GameEntry.Event.Fire(this, args);
        }
    }
}
