using UnityEngine;
using System.Collections;
using GameMain;

namespace BT
{
    public class Effect : BTTask
    {
        public string JudgeName = string.Empty;
        public EffectData Data = null;

        private int m_EffectTypeId = 0;
        private Transform  m_CacheTransform = null;
        private int m_EffectEntinyId = 0;

        protected override void ReadAttribute(string key, string value)
        {
            switch (key)
            {
                case "Id":
                    Data = new EffectData(GameEntry.Entity.GenerateTempSerialId(), value.ToInt32());
                    break;
                case "LastTime":
                    this.Data.KeepTime = value.ToFloat();
                    break;
                case "Bind":
                    this.Data.BindType = (EffectBindType)value.ToInt32();
                    break;
                case "Fly":
                    this.Data.FlyType = (FlyObjFlyType)value.ToInt32();
                    break;
                case "SetParent":
                    this.Data.SetParent = value.ToInt32() == 1;
                    break;
                case "Dead":
                    this.Data.DeadType = (FlyObjDeadType)value.ToInt32();
                    break;
                case "Offset":
                    this.Data.PosOffset = GlobalTools.ToVector3(value, true);
                    break;
                case "Euler":
                    this.Data.EulerOffset = GlobalTools.ToVector3(value, true);
                    break;
                case "Sound":
                    this.Data.SoundId = value.ToInt32();
                    break;
                case "FlySpeed":
                    this.Data.FlySpeed = value.ToFloat();
                    break;
                case "Delay":
                    this.Data.DelayTime = value.ToFloat();
                    break;
                case "JudgeName":
                    this.JudgeName = value;
                    break;

            }
        }

        protected override bool Enter()
        {
            base.Enter();
            if (Owner == null)
            {
                return false;
            }
                       
            this.m_EffectEntinyId = Data.Id;

            Data.Owner = Owner;
            Data.Target = Owner.Target;
            Data.Parent = Owner.CachedTransform;
            GameEntry.Entity.ShowEffect(Data);

            if (Data.SoundId != 0)
                GameEntry.Sound.PlaySound(Data.SoundId);
            return true;
        }

        protected override BTStatus Execute()
        {
            if (m_EffectEntinyId == 0)
            {
                return BTStatus.Failure;
            }

            EffectBase effect = GameEntry.Entity.GetEntity(m_EffectEntinyId)?.Logic as EffectBase;

            if (effect == null)
            {
                return BTStatus.Failure;
            }

            EffectStateType pState = effect.State;
            switch (pState)
            {
                case EffectStateType.Error:
                {
                    return BTStatus.Failure;
                }
                case EffectStateType.Update:
                {
                    if (m_CacheTransform == null && effect.CachedTransform != null)
                    {
                        m_CacheTransform = effect.CachedTransform;
                        GameEntry.BT.SaveData(this, JudgeName, m_CacheTransform);
                    }

                    object var = GameEntry.BT.GetData(this, Constant.Define.BTJudgeList);
                    if (var != null && Data.DeadType == FlyObjDeadType.UntilColliderTar)
                    {
                        effect.SwitchState(EffectStateType.Dead);
                    }
                    return BTStatus.Running;
                }
                case EffectStateType.Wait:
                {
                    return BTStatus.Running;
                }
                case EffectStateType.Dead:
                {
                    Clear();
                    return BTStatus.Success;
                }
                default:
                {
                    return BTStatus.Failure;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            GameEntry.Entity.CheckHideEntity(m_EffectEntinyId);
            m_CacheTransform = null;
        }

        public override BTNode DeepClone()
        {
            Effect effect = new Effect();
            effect.Data = this.Data;
            effect.JudgeName = this.JudgeName;
            effect.Owner = GameEntry.BT.GetOwnerByNode(this);
            effect.CloneChildren(this);
            return effect;
        }
    }
}

