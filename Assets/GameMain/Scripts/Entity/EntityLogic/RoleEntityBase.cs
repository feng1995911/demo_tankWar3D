using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// 角色基类
    /// </summary>
    public class RoleEntityBase : EntityBase
    {
        public ActorBase Actor { get; protected set; }

        protected CharacterController m_CharacterController;
        protected Animator m_Animator;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            m_Animator = gameObject.GetComponent<Animator>();
            m_CharacterController = gameObject.GetOrAddComponent<CharacterController>();
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            Actor?.Step();
        }

        protected override void OnHide(object userData)
        {
            base.OnHide(userData);

            Actor.Clear();
            Actor = null;
        }

        public void UpdateTransform(TransformParam param)
        {
            CachedTransform.position = param.Position;
            CachedTransform.eulerAngles = param.EulerAngles;
            CachedTransform.localScale = param.Scale;
        }
    }
}
