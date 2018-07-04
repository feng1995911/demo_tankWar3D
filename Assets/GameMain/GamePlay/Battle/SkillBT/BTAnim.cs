using UnityEngine;
using GameMain;

namespace BT
{
    public class Anim : BTTask
    {
        public string JudgeName = string.Empty;
        public string AnimName = string.Empty;
        public bool IsLoop = false;
        public float Delay = 0;
        public int Sound = 0;

        private bool  m_MChildFinished = false;
        private float m_UpdateTimer;
        private float m_LastTime;

        protected override void ReadAttribute(string key, string value)
        {
            switch (key)
            {
                case "AnimName":
                    this.AnimName = value;
                    break;
                case "IsLoop":
                    this.IsLoop = value.ToInt32() == 0 ? false : true;
                    break;
                case "Delay":
                    this.Delay = value.ToFloat();
                    break;
                case "JudgeName":
                    this.JudgeName = value;
                    break;
                case "Sound":
                    this.Sound = value.ToInt32();
                    break;
            }
        }

        protected override bool Enter()
        {
            base.Enter();
            Owner.GetAnimController().Play(AnimName, null, IsLoop);
            m_UpdateTimer = Time.realtimeSinceStartup;
            m_LastTime = Owner.GetAnimController().GetAnimLength(AnimName);

            GameEntry.BT.SaveData(this, JudgeName, Owner.CachedTransform);

            if (Sound != 0)
                GameEntry.Sound.PlaySound(Sound);
            return true;
        }

        protected override BTStatus Execute()
        {
            if (Time.realtimeSinceStartup - m_UpdateTimer > m_LastTime)
            {
                return BTStatus.Success;
            }
            else
            {
                return BTStatus.Running;
            }
        }

        public override void Clear()
        {
            base.Clear();
            m_UpdateTimer = 0;
            m_MChildFinished = false;
        }

        public override BTNode DeepClone()
        {
            Anim anim = new Anim();
            anim.IsLoop = this.IsLoop;
            anim.Delay = this.Delay;
            anim.AnimName = this.AnimName;
            anim.JudgeName = this.JudgeName;
            anim.Sound = this.Sound;
            return anim;
        }
    }
}