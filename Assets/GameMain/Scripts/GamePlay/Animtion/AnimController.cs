using System;
using System.Collections.Generic;
using GameFramework;
using UnityEngine;

namespace GameMain
{
    public class AnimController : IAnimController
    {
        private readonly Animator m_Animator;
        private string m_CurAnimName = "";
        private float m_PlaySpeed = 1f;
        private float m_PlayTimer = 0f;
        private float m_CrossFadeSpeed = 0.3f;

        public Action callback;
        public Action m_OnFinish;
        public float m_Length;
        public bool m_IsSatrt = false;
        public bool m_IsLoop;

        private AnimatorStateInfo m_AnimatorState;
        private Map<string,AnimationClip> m_AnimClips = new Map<string, AnimationClip>();
        private static HashSet<string> m_NoFadeList = new HashSet<string>()
        {
            "idle",
            "run",
            "walk"
        }; 


        public AnimController(Animator anim)
        {
            m_Animator = anim;
            if (m_Animator == null || m_Animator.runtimeAnimatorController == null)
            {
                Log.Error("Anmator is invalid.");
                return;
            }

            m_IsSatrt = false;
            for (int i = 0; i < m_Animator.runtimeAnimatorController.animationClips.Length; i++)
            {
                AnimationClip clip = m_Animator.runtimeAnimatorController.animationClips[i];
                if(!m_AnimClips.ContainsKey(clip.name))
                    m_AnimClips.Add(clip.name, clip);
            }
        }

        public void Play(string animName, Action onFinish = null, bool isLoop = false, float speed = 1, float lastTime = 0)
        {
            if (m_CurAnimName == animName)
                return;

            if (m_Animator == null || !m_Animator.enabled || string.IsNullOrEmpty(animName))
            {
                Log.Error("Play anim Failure.");
                return;
            }

            if (!string.IsNullOrEmpty(m_CurAnimName))
            {
                m_Animator.SetBool(m_CurAnimName, false);
            }
            m_Animator.SetBool(animName,true);

            if (!m_NoFadeList.Contains(m_CurAnimName) && isLoop == false)
            {
                m_Animator.CrossFade(animName,m_CrossFadeSpeed);
            }

            m_PlayTimer = Time.realtimeSinceStartup;
            m_PlaySpeed = speed;
            m_CurAnimName = animName;
            m_OnFinish = onFinish;
            m_IsSatrt = false;
            m_IsLoop = isLoop;
            m_Length = lastTime > 0 ? lastTime : GetAnimLength(m_CurAnimName);

            m_Animator.speed = m_PlaySpeed;
        }

        public void Break()
        {
            if (string.IsNullOrEmpty(m_CurAnimName))
            {
                Log.Error("Please play anim first.");
                return;
            }

            m_Animator.SetBool(m_CurAnimName,false);
            m_OnFinish = null;
            Reset();
        }

        public void Step()
        {
            if (!m_Animator.enabled)
            {
                return;
            }

            m_AnimatorState = m_Animator.GetNextAnimatorStateInfo(0);

            if (!m_IsSatrt)
            {
                if (m_AnimatorState.IsName(m_CurAnimName))
                {
                    m_Animator.SetBool(m_CurAnimName,false);
                    m_IsSatrt = true;
                }
            }

            if(m_OnFinish == null)
                return;

            if (Time.realtimeSinceStartup - m_PlayTimer > m_Length*m_PlaySpeed)
            {
                m_OnFinish.Invoke();
            }
        }

        public void SetEnable(bool enable)
        {
            m_Animator.enabled = enable;
        }

        public float GetAnimLength(string animName)
        {
            if (m_AnimClips.ContainsKey(animName))
            {
                return m_AnimClips[animName].length;
            }
            return 0;
        }

        public string GetCurrentAnimName()
        {
            return m_CurAnimName;
        }

        public float GetSpeed()
        {
            return m_PlaySpeed;
        }

        public void Reset()
        {
            m_CurAnimName = string.Empty;
            m_PlaySpeed = 1f;
            m_CrossFadeSpeed = 0.3f;
        }

        public void SetRootMotionEnable(bool enable)
        {
            m_Animator.applyRootMotion = enable;
        }

        public void SetSpeed(float speed)
        {
            m_PlaySpeed = speed;
            m_Animator.speed = m_PlaySpeed;
        }

        public void SetFadeTime(float speed)
        {
            m_CrossFadeSpeed = speed;
        }
    }
}
