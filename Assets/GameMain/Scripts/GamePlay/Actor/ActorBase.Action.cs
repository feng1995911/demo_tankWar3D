using System;
using UnityEngine;

namespace GameMain
{
    public partial class ActorBase
    {
        /// <summary>
        /// 强制移动
        /// </summary>
        public virtual void OnForceToMove(MoveCommand ev)
        {
            StopPathFinding();
            Vector3 delta = ev.Delta;
            int speed = Attrbute.GetValue(AttributeType.Speed);

            CachedTransform.LookAt(new Vector3(CachedTransform.position.x + delta.x, CachedTransform.position.y,
            CachedTransform.position.z + delta.y));
            m_CharacterController.SimpleMove(m_CharacterController.transform.forward * speed);
            this.m_AnimController.Play("run", null, true);
        }

        /// <summary>
        /// 自动寻路
        /// </summary>
        public virtual void OnPursue(AutoMoveCommand ev)
        {
            this.m_ActorPathFinding.SetOnFinished(ev.Callback);
            MoveTo(ev.DestPosition);
            this.m_AnimController.Play("run", null, true);
        }

        /// <summary>
        /// 到达目标地
        /// </summary>
        public virtual void OnArrive()
        {
            ChangeState<ActorEmptyFsm>();
            if (m_Host != null && m_Host.GetActorState(ActorStateType.IsRide))
            {
                m_Host.OnArrive();
            }
        }

        /// <summary>
        /// 休闲
        /// </summary>
        public virtual void OnIdle()
        {
            StopPathFinding();
            this.m_AnimController.Play("idle", null, true);
        }

        /// <summary>
        /// 交谈
        /// </summary>
        public virtual void OnTalk(TalkCommand ev)
        {
            this.m_AnimController.Play("talk", null, true);
        }

        /// <summary>
        /// 死亡
        /// </summary>
        public virtual void OnDead(DeadCommand ev)
        {
            StopPathFinding();         
            this.m_AnimController.Play("die");
            Attrbute.UpdateValue(AttributeType.Hp, 0);
            Attrbute.UpdateValue(AttributeType.Mp, 0);
            this.ApplyCharacterCtrl(false);

            //播放死亡动画后删除
            GameEntry.Timer.Register(3f, () =>
            {
                GameEntry.Level.DelRole(this.Camp, this.EntityId);
            });
        }

        /// <summary>
        /// 使用技能
        /// </summary>
        public virtual void OnUseSkill(UseSkillCommand ev)
        {
            StopPathFinding();
            LookAtEnemy();
            m_ActorSkill.UseSkill(ev.SkillPos);
        }

        /// <summary>
        /// 转向
        /// </summary>
        public virtual void OnTurnTo(TurnToCommand ev)
        {
            Vector3 pos = new Vector3(ev.LookDirection.x, CachedTransform.position.y, ev.LookDirection.z);
            CachedTransform.LookAt(pos);
        }

        /// <summary>
        /// 击退
        /// </summary>
        public virtual void OnBeatBack(BeatBackCommand ev)
        {
            StopPathFinding();
            m_AnimController.Play("hit", GotoEmptyFsm, false);
        }

        /// <summary>
        /// 击倒
        /// </summary>
        public virtual void OnBeatDown()
        {
            StopPathFinding();
            m_AnimController.Play("down", GotoEmptyFsm, false);
        }

        /// <summary>
        /// 击飞
        /// </summary>
        public virtual void OnBeatFly()
        {
            StopPathFinding();
            m_AnimController.Play("fly", GotoEmptyFsm, false);
        }

        /// <summary>
        /// 受伤
        /// </summary>
        public virtual void OnWound()
        {
            StopPathFinding();
            m_AnimController.Play("hit", GotoEmptyFsm, false);
        }

        /// <summary>
        /// 行走
        /// </summary>
        public virtual void OnWalk()
        {
            StopPathFinding();
            m_AnimController.Play("walk", GotoEmptyFsm, true);
        }

        /// <summary>
        /// 晕眩
        /// </summary>
        public virtual void OnStun(float lastTime)
        {
            StopPathFinding();
            m_AnimController.Play("yun", GotoEmptyFsm, true, 1, lastTime);
        }

        /// <summary>
        /// 跳
        /// </summary>
        public void OnJump()
        {
            StopPathFinding();
            m_AnimController.Play("jump", GotoEmptyFsm, false);
        }

        /// <summary>
        /// 重生
        /// </summary>
        public void OnReborn()
        {
            AddHp(Attrbute.GetValue(AttributeType.MaxHp), false);
            AddMp(Attrbute.GetValue(AttributeType.MaxMp), false);
            m_CharacterController.enabled = true;
            m_AnimController.Play("fuhuo", GotoEmptyFsm, false);
        }

        /// <summary>
        /// 开始骑坐骑
        /// </summary>
        public virtual void OnBeginRide()
        {

        }

        /// <summary>
        /// 结束骑坐骑
        /// </summary>
        public virtual void OnEndRide()
        {

        }

        /// <summary>
        /// 采矿
        /// </summary>
        /// <param name="ev"></param>
        public void OnCollectMine(CollectMineCommand ev)
        {
            StopPathFinding();
            Action callback = delegate ()
            {
                GotoEmptyFsm();
                ev.OnFinish?.Invoke();
            };
            m_AnimController.Play("miss", callback, false);
        }

        /// <summary>
        /// 交互
        /// </summary>
        /// <param name="ev"></param>
        public void OnInteractive(InteractiveCommand ev)
        {
            StopPathFinding();
            Action callback = delegate ()
            {
                GotoEmptyFsm();
                ev.OnFinish?.Invoke();
            };
            m_AnimController.Play(ev.AnimName, callback, false);
        }

        protected void OnBeginStealth(float lifeTime)
        {
            SetActorState(ActorStateType.IsStealth, true);
            OnFadeOut();
        }

        protected void OnEndStealth()
        {
            SetActorState(ActorStateType.IsStealth, false);
            OnFadeIn();
        }

        protected void OnFadeOut()
        {
            SetAlphaVertexColorOff(0.1f);
            m_ActorBuff.SetAllEffectEnable(false);
        }

        protected void OnFadeIn()
        {
            SetAlphaVertexColorOn(0.1f);
            m_ActorBuff.SetAllEffectEnable(true);

        }

        protected void OnDeadEnd()
        {
            m_ActorAI.Clear();
            GameEntry.Entity.CheckHideEntity(EntityId);
        }

    }
}
