using System;
using UnityEngine;

namespace GameMain
{
    [ExecuteInEditMode]
    public class CameraSmartLook : AbstractTargetFollowerCamera,ICameraBehaviour
    {
        public CameraBehaviourType Type { get; } = CameraBehaviourType.SmartLook;

        [SerializeField]
        private float m_MoveSpeed = 4;
        [SerializeField]
        private float m_TurnSpeed = 8; 
        [SerializeField]
        private float m_RollSpeed = 0.2f;
        [SerializeField]
        private bool m_FollowVelocity = false;
        [SerializeField]
        private bool m_FollowTilt = true; 
        [SerializeField]
        private float m_SpinTurnLimit = 180;
        [SerializeField]
        private float m_TargetVelocityLowerLimit = 4f;
        [SerializeField]
        private float m_SmoothTurnTime = 0.2f; 

        private float m_LastFlatAngle; 
        private float m_CurrentTurnAmount; 
        private float m_TurnSpeedVelocityChange; 
        private Vector3 m_RollUp = Vector3.up;

        protected override void FollowTarget(float deltaTime)
        {
            if (!(deltaTime > 0) || m_Target == null)
            {
                return;
            }

            var targetForward = m_Target.forward;
            var targetUp = m_Target.up;

            if (m_FollowVelocity && Application.isPlaying)
            {

                if (targetRigidbody.velocity.magnitude > m_TargetVelocityLowerLimit)
                {
                    targetForward = targetRigidbody.velocity.normalized;
                    targetUp = Vector3.up;
                }
                else
                {
                    targetUp = Vector3.up;
                }
                m_CurrentTurnAmount = Mathf.SmoothDamp(m_CurrentTurnAmount, 1, ref m_TurnSpeedVelocityChange, m_SmoothTurnTime);
            }
            else
            {              
                var currentFlatAngle = Mathf.Atan2(targetForward.x, targetForward.z) * Mathf.Rad2Deg;
                if (m_SpinTurnLimit > 0)
                {
                    var targetSpinSpeed = Mathf.Abs(Mathf.DeltaAngle(m_LastFlatAngle, currentFlatAngle)) / deltaTime;
                    var desiredTurnAmount = Mathf.InverseLerp(m_SpinTurnLimit, m_SpinTurnLimit * 0.75f, targetSpinSpeed);
                    var turnReactSpeed = (m_CurrentTurnAmount > desiredTurnAmount ? .1f : 1f);
                    if (Application.isPlaying)
                    {
                        m_CurrentTurnAmount = Mathf.SmoothDamp(m_CurrentTurnAmount, desiredTurnAmount,
                                                             ref m_TurnSpeedVelocityChange, turnReactSpeed);
                    }
                    else
                    {
                        m_CurrentTurnAmount = desiredTurnAmount;
                    }
                }
                else
                {
                    m_CurrentTurnAmount = 1;
                }
                m_LastFlatAngle = currentFlatAngle;
            }

            transform.position = Vector3.Lerp(transform.position, m_Target.position, deltaTime * m_MoveSpeed);

            if (!m_FollowTilt)
            {
                targetForward.y = 0;
                if (targetForward.sqrMagnitude < float.Epsilon)
                {
                    targetForward = transform.forward;
                }
            }
            var rollRotation = Quaternion.LookRotation(targetForward, m_RollUp);

            m_RollUp = m_RollSpeed > 0 ? Vector3.Slerp(m_RollUp, targetUp, m_RollSpeed * deltaTime) : Vector3.up;
            transform.rotation = Quaternion.Lerp(transform.rotation, rollRotation, m_TurnSpeed * m_CurrentTurnAmount * deltaTime);
        }

        public void Disable()
        {
            enabled = false;
        }

        public void Enable()
        {
            enabled = true;
        }

    }
}
