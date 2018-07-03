using GameFramework.Fsm;
using UnityEngine;

namespace GameMain
{
    public class ActorTurnFsm : ActorFsmStateBase
    {
        private TurnToCommand m_TurnToCommand;
        private float m_TurnSpeed = 10;

        public ActorTurnFsm(ActorFsmStateType state) : base(state)
        {
        }

        protected override void OnEnter(IFsm<ActorBase> fsm)
        {
            m_TurnToCommand = m_Command as TurnToCommand;
        }

        protected override void OnUpdate(IFsm<ActorBase> fsm, float elapseSeconds, float realElapseSeconds)
        {
            Quaternion rot = m_Owner.CachedTransform.localRotation;
            Quaternion toTarget = Quaternion.LookRotation(m_TurnToCommand.LookDirection);

            if (Quaternion.Angle(rot, toTarget) < 5)
            {
                m_TurnToCommand.OnFinish?.Invoke();
                m_TurnToCommand.OnFinish = null;
                return;
            }

            float rTime = GameEntry.Base.GameSpeed;
            if (rTime != 0)
            {
                rot = Quaternion.Slerp(rot, toTarget, m_TurnSpeed/rTime*Time.deltaTime);
            }

            Vector3 euler = rot.eulerAngles;
            euler.z = 0;
            euler.x = 0;
            m_Owner.CachedTransform.localRotation = Quaternion.Euler(euler);
        }

        protected override void OnLeave(IFsm<ActorBase> fsm, bool isShutdown)
        {
            base.OnLeave(fsm, isShutdown);
        }

    }
}
