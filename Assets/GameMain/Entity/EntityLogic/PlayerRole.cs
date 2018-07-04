using GameFramework;
using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// 玩家
    /// </summary>
    public class PlayerRole : RoleEntityBase
    {
        private PlayerEntityData m_EntityData;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_EntityData = userData as PlayerEntityData;
            if (m_EntityData == null)
            {
                Log.Error("playerEntityData is null");
                return;
            }

            //创建Actor
            ActorType actorType = m_EntityData.ActorType;
            BattleCampType campType = m_EntityData.CampType;
            Actor = new ActorPlayer(this, actorType, campType, m_CharacterController,
                m_Animator);
            Actor.Init();
            ((ActorPlayer) Actor).BattleState = m_EntityData.BattleState;

            GameEntry.Camera.SwitchCameraBehaviour(CameraBehaviourType.LockLook);

            AddEventListener();
        }

        protected override void OnHide(object userData)
        {
            base.OnHide(userData);

            RemoveEventListener();

            GameEntry.Camera.SwitchCameraBehaviour(CameraBehaviourType.Default);
        }

        private void AddEventListener()
        {
            GameEntry.Input.OnAxisInput += OnPlayerMove;
            GameEntry.Input.OnAxisInputEnd += OnPlayerIdle;
        }

        private void RemoveEventListener()
        {
            GameEntry.Input.OnAxisInput -= OnPlayerMove;
            GameEntry.Input.OnAxisInputEnd -= OnPlayerIdle;
        }

        private void OnPlayerMove(Vector2 delta)
        {
            Actor.ExecuteCommand(new MoveCommand(delta));
        }

        private void OnPlayerIdle()
        {
            Actor.ExecuteCommand(new IdleCommand());
        }
    }
}
