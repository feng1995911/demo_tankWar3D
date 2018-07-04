namespace GameMain
{
    public partial class ActorBase
    {
        //空闲
        protected virtual CommandReplyType CheckIdle(IdleCommand cmd)
        {
            if (CachedTransform == null)
            {
                return CommandReplyType.NO;
            }
            if (CannotControlSelf())
            {
                return CommandReplyType.NO;
            }
            if (CurFsmStateType == ActorFsmStateType.FSM_SKILL)
            {
                return CommandReplyType.NO;
            }

            ChangeState<ActorIdleFsm>(cmd);
            return CommandReplyType.YES;
        }

        //寻路至
        protected virtual CommandReplyType CheckRunTo(AutoMoveCommand cmd)
        {
            if (CannotControlSelf())
            {
                return CommandReplyType.NO;
            }
            if (CurFsmStateType == ActorFsmStateType.FSM_SKILL)
            {
                return CommandReplyType.NO;
            }
            if (GetAIFeature(AIFeatureType.CanMove) == false)
            {
                return CommandReplyType.NO;
            }

            m_ActorAI.ChangeAIMode(AIModeType.Auto);
            ChangeState<ActorRunFsm>(cmd);
            return CommandReplyType.YES; ;
        }

        //使用技能
        protected virtual CommandReplyType CheckUseSkill(UseSkillCommand cmd)
        {
            if (CachedTransform == null)
            {
                return CommandReplyType.NO;
            }
            if (CannotControlSelf())
            {
                ShowWarning("100012");
                return CommandReplyType.NO;
            }
            if (CurFsmStateType == ActorFsmStateType.FSM_SKILL)
            {
                return CommandReplyType.NO;
            }
            if (GetActorState(ActorStateType.IsRide))
            {
                ShowWarning("100011");
                return CommandReplyType.NO;
            }

            SkillTree skill = m_ActorSkill.GetSkill(cmd.SkillPos);
            if (skill == null) return CommandReplyType.NO;
            if (skill.IsInCD()) return CommandReplyType.NO;
            switch (skill.CostType)
            {
                case SkillCostType.Hp:
                    {
                        bool success = UseHp(skill.CostNum);
                        if (!success)
                        {
                            return CommandReplyType.NO;
                        }
                    }
                    break;
                case SkillCostType.Mp:
                    {
                        bool success = UseMp(skill.CostNum);
                        if (!success)
                        {
                            return CommandReplyType.NO;
                        }
                    }
                    break;
            }

            cmd.LastTime = skill.StateTime;
            ChangeState<ActorSkillFsm>(cmd);
            return CommandReplyType.YES;
        }

        //死亡
        protected virtual CommandReplyType CheckDead(DeadCommand cmd)
        {
            m_ActorSkill.Clear();
            if (GetActorState(ActorStateType.IsRide))
            {
                OnEndRide();
            }

            ChangeState<ActorDeadFsm>(cmd);
            return CommandReplyType.YES;
        }

        //转向
        protected virtual CommandReplyType CheckTurnTo(TurnToCommand cmd)
        {
            if (GetAIFeature(AIFeatureType.CanTurn) == false)
            {
                return CommandReplyType.NO;
            }
            if (CannotControlSelf())
            {
                return CommandReplyType.NO;
            }

            ChangeState<ActorTurnFsm>(cmd);
            return CommandReplyType.YES;
        }

        //强制移动
        protected virtual CommandReplyType CheckMoveTo(MoveCommand cmd)
        {
            if (CannotControlSelf())
            {
                return CommandReplyType.NO;
            }
            if (CurFsmStateType == ActorFsmStateType.FSM_SKILL)
            {
                return CommandReplyType.NO;
            }
            if (GetAIFeature(AIFeatureType.CanMove) == false)
            {
                return CommandReplyType.NO;
            }
            if (this is ActorPlayer)
            {
                m_ActorAI.ChangeAIMode(AIModeType.Hand);
                ChangeState<ActorRunFsm>(cmd);

                OnPlayerAiModeChangeEventArgs eventArgs = new OnPlayerAiModeChangeEventArgs().Fill(AIModeType.Hand);
                GameEntry.Event.Fire(this, eventArgs);

                return CommandReplyType.YES;
            }
            return CommandReplyType.NO;
        }

        //交谈
        protected virtual CommandReplyType CheckTalk(TalkCommand cmd)
        {
            ChangeState<ActorTalkFsm>(cmd);
            return CommandReplyType.YES;
        }

        //冰冻
        protected virtual CommandReplyType CheckFrost(FrostCommand cmd)
        {
            if (CannotControlSelf())
            {
                return CommandReplyType.NO;
            }
            if (GetActorState(ActorStateType.IsDivine) == true)
            {
                return CommandReplyType.NO;
            }

            m_ActorSkill.Clear();
            ChangeState<ActorFrostFsm>(cmd);
            return CommandReplyType.YES;
        }

        //昏迷
        protected virtual CommandReplyType CheckStun(StunCommand cmd)
        {
            if (CannotControlSelf())
            {
                return CommandReplyType.NO;
            }
            if (GetActorState(ActorStateType.IsDivine))
            {
                return CommandReplyType.NO;
            }

            m_ActorSkill.Clear();
            ChangeState<ActorStunFsm>(cmd);
            return CommandReplyType.YES;
        }

        //麻痹
        protected virtual CommandReplyType CheckPalsy(PalsyCommand cmd)
        {
            if (CannotControlSelf())
            {
                return CommandReplyType.NO;
            }
            if (GetActorState(ActorStateType.IsDivine))
            {
                return CommandReplyType.NO;
            }

            m_ActorSkill.Clear();
            ChangeState<ActorStunFsm>(cmd);
            return CommandReplyType.YES;
        }

        //睡眠
        protected virtual CommandReplyType CheckSleep(SleepCommand cmd)
        {
            if (CannotControlSelf())
            {
                return CommandReplyType.NO;
            }
            if (GetActorState(ActorStateType.IsDivine))
            {
                return CommandReplyType.NO;
            }

            m_ActorSkill.Clear();
            ChangeState<ActorSleepFsm>(cmd);
            return CommandReplyType.YES;
        }

        //致盲
        protected virtual CommandReplyType CheckBlind(BlindCommand cmd)
        {
            if (CannotControlSelf())
            {
                return CommandReplyType.NO;
            }
            if (GetActorState(ActorStateType.IsDivine))
            {
                return CommandReplyType.NO;
            }

            m_ActorSkill.Clear();
            ChangeState<ActorBlindFsm>(cmd);
            return CommandReplyType.YES;
        }

        //恐惧
        protected virtual CommandReplyType CheckFear(FearCommand cmd)
        {
            if (CannotControlSelf())
            {
                return CommandReplyType.NO;
            }
            if (GetActorState(ActorStateType.IsDivine))
            {
                return CommandReplyType.NO;
            }

            m_ActorSkill.Clear();
            ChangeState<ActorFearFsm>(cmd);
            return CommandReplyType.YES;
        }

        //定身
        protected virtual CommandReplyType CheckFixBody(FixBodyCommand cmd)
        {
            if (CannotControlSelf())
            {
                return CommandReplyType.NO;
            }
            if (GetActorState(ActorStateType.IsDivine))
            {
                return CommandReplyType.NO;
            }

            ChangeState<ActorFixBodyFsm>(cmd);
            return CommandReplyType.YES;
        }

        //受击
        protected virtual CommandReplyType CheckWound(WoundCommand cmd)
        {
            if (CannotControlSelf())
            {
                return CommandReplyType.NO;
            }
            if (GetActorState(ActorStateType.IsDivine))
            {
                return CommandReplyType.NO;
            }

            m_ActorSkill.Clear();
            cmd.LastTime = m_AnimController.GetAnimLength("hit");
            ChangeState<ActorWoundFsm>(cmd);
            return CommandReplyType.YES;
        }

        //击退
        protected virtual CommandReplyType CheckBeatBack(BeatBackCommand cmd)
        {
            if (CannotControlSelf())
            {
                return CommandReplyType.NO;
            }
            if (GetActorState(ActorStateType.IsDivine))
            {
                return CommandReplyType.NO;
            }
            m_ActorSkill.Clear();
            ChangeState<ActorBeatBackFsm>(cmd);
            return CommandReplyType.YES;
        }

        //击飞
        protected virtual CommandReplyType CheckBeatFly(BeatFlyCommand cmd)
        {
            if (CannotControlSelf())
            {
                return CommandReplyType.NO;
            }
            if (GetActorState(ActorStateType.IsDivine))
            {
                return CommandReplyType.NO;
            }
            m_ActorSkill.Clear();
            cmd.LastTime = m_AnimController.GetAnimLength("fly");
            ChangeState<ActorBeatFlyFsm>(cmd);
            return CommandReplyType.YES;
        }

        //击倒
        protected virtual CommandReplyType CheckBeatDown(BeatDownCommand cmd)
        {
            if (CannotControlSelf())
            {
                return CommandReplyType.NO;
            }
            if (GetActorState(ActorStateType.IsDivine))
            {
                return CommandReplyType.NO;
            }
            m_ActorSkill.Clear();
            cmd.LastTime = m_AnimController.GetAnimLength("down");
            ChangeState<ActorBeatDownFsm>();
            return CommandReplyType.YES;
        }

        //浮空
        protected virtual CommandReplyType CheckFly(FlyCommand cmd)
        {
            if (CannotControlSelf())
            {
                return CommandReplyType.NO;
            }
            if (GetActorState(ActorStateType.IsDivine))
            {
                return CommandReplyType.NO;
            }
            m_ActorSkill.Clear();
            ChangeState<ActorFlyFsm>();
            return CommandReplyType.YES;
        }

        //被勾取
        protected virtual CommandReplyType CheckHook(HookCommand cmd)
        {
            if (CannotControlSelf())
            {
                return CommandReplyType.NO;
            }
            if (GetActorState(ActorStateType.IsDivine))
            {
                return CommandReplyType.NO;
            }
            m_ActorSkill.Clear();
            ChangeState<ActorHookFsm>();
            return CommandReplyType.YES;
        }

        //被抓取
        protected virtual CommandReplyType CheckGrab(GrabCommand cmd)
        {
            if (CannotControlSelf())
            {
                return CommandReplyType.NO;
            }
            if (GetActorState(ActorStateType.IsDivine))
            {
                return CommandReplyType.NO;
            }
            m_ActorSkill.Clear();
            ChangeState<ActorGrabFsm>();
            return CommandReplyType.YES;
        }

        //变形
        protected virtual CommandReplyType CheckVariation(VariationCommand cmd)
        {
            if (CannotControlSelf())
            {
                return CommandReplyType.NO;
            }
            if (GetActorState(ActorStateType.IsDivine))
            {
                return CommandReplyType.NO;
            }

            m_ActorSkill.Clear();
            ChangeState<ActorVariationFsm>();
            return CommandReplyType.YES;
        }

        //骑乘
        protected virtual CommandReplyType CheckRide(RideCommand cmd)
        {
            if (CannotControlSelf())
            {
                return CommandReplyType.NO;
            }
            if (CurFsmStateType == ActorFsmStateType.FSM_RUN || CurFsmStateType == ActorFsmStateType.FSM_WALK || CurFsmStateType == ActorFsmStateType.FSM_SKILL)
            {
                ShowWarning("300003");
                return CommandReplyType.NO;
            }

            OnBeginRide();
            return CommandReplyType.YES;
        }

        //重生
        protected CommandReplyType CheckReborn(RebornCommand cmd)
        {
            cmd.LastTime = m_AnimController.GetAnimLength("fuhuo");
            ChangeState<ActorRebornFsm>();
            return CommandReplyType.YES;
        }

        //跳跃
        protected virtual CommandReplyType CheckJump(JumpCommand cmd)
        {
            if (CannotControlSelf())
            {
                return CommandReplyType.NO;
            }
            if (GetActorState(ActorStateType.IsRide))
            {
                ShowWarning("100011");
                return CommandReplyType.NO;
            }

            ChangeState<ActorJumpFsm>();
            return CommandReplyType.YES;
        }

        //隐身
        protected virtual CommandReplyType CheckStealth(StealthCommand cmd)
        {
            if (CurFsmStateType != ActorFsmStateType.FSM_IDLE ||
                CurFsmStateType != ActorFsmStateType.FSM_RUN ||
                CurFsmStateType != ActorFsmStateType.FSM_WALK)
            {
                return CommandReplyType.NO;
            }
            this.OnBeginStealth(cmd.LastTime);
            ChangeState<ActorStealthFsm>();
            return CommandReplyType.YES;
        }

        //交互
        private CommandReplyType CheckInteractive(InteractiveCommand cmd)
        {
            if (CannotControlSelf())
            {
                return CommandReplyType.NO;
            }
            if (CurFsmStateType == ActorFsmStateType.FSM_DEAD)
            {
                return CommandReplyType.NO;
            }
            if (cmd.AnimName == "idle")
            {
                cmd.LastTime = 1;
            }
            else
            {
                cmd.LastTime = m_AnimController.GetAnimLength(cmd.AnimName);
            }

            ChangeState<ActorInteractiveFsm>();
            return CommandReplyType.YES;
        }

        private CommandReplyType CheckMine(CollectMineCommand cmd)
        {
            if (CannotControlSelf())
            {
                return CommandReplyType.NO;
            }
            if (CurFsmStateType == ActorFsmStateType.FSM_DEAD)
            {
                return CommandReplyType.NO;
            }

            cmd.LastTime = m_AnimController.GetAnimLength("miss");
            ChangeState<ActorInteractiveFsm>();
            return CommandReplyType.YES;
        }
    }
}
