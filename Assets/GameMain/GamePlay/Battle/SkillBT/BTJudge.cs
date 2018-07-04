using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;
using GameMain;

namespace BT
{
    public class Judge : BTTask
    {
        public SkillRegionType Region = SkillRegionType.None;
        public AffectType Affect = AffectType.None;
        public float LifeTime;
        public int   MaxCount;
        public string JudgeName = string.Empty;
        public BTScopeShape Scope;

        protected Transform mJudgeTrans;
        protected int       mCurCount = 0;

        protected override bool Enter()
        {
            base.Enter();
            if(Scope==null)
            {
                return false;
            }
            if(string.IsNullOrEmpty(JudgeName))
            {
                Debug.LogError(Owner.Id+"判断Transform Key为空");
                return false;
            }
            return FindJudgeTrans();
        }

        private bool FindJudgeTrans()
        {
            mJudgeTrans = GameEntry.BT.GetData(this, JudgeName) as Transform;
            if (mJudgeTrans == null)
            {
              //  Debug.LogError(Owner.Id + "找不到参照物");
                return false;
            }
            Scope.Center = mJudgeTrans;
            return true;
        }

        private bool CheckHitLimit()
        {
            return MaxCount > 0 && mCurCount >= MaxCount;
        }

        protected override BTStatus Execute()
        {
            if (FindJudgeTrans()==false)
            {
                return BTStatus.Failure;
            }
            List<ActorBase> list = Owner.GetActorsByAffectType(Affect);
            List<ActorBase> hits = new List<ActorBase>();
            for (int i = 0; i < list.Count; i++)
            {
                ActorBase actor = list[i];
                if (Scope.IsTouch(actor))
                {
                    mCurCount++;
                    hits.Add(actor);
                }
                if(CheckHitLimit())
                {
                    break;
                }
            }

            if (hits.Count > 0)
            {
                GameEntry.BT.SaveData(this, Constant.Define.BTJudgeList, hits);
                GameEntry.BT.SaveData(this, Constant.Define.BTJudgeSuccess, string.Empty);
                if (m_Children.Count>0) 
                {
                    BTNode pNode = m_Children[0];
                    pNode.Step();
                }
            }

            if(LifeTime>0)
            {
                return CheckHitLimit() ? BTStatus.Success : BTStatus.Running;
            }
            else
            {
                return mCurCount > 0 ? BTStatus.Success : BTStatus.Failure;
            }
        }

        public override void Load(XmlElement xe)
        {
            base.Load(xe);
            switch (this.Region)
            {
                case SkillRegionType.Sphere:
                    {
                        Scope = new ScopeSphere();
                        ScopeSphere v = Scope as ScopeSphere;
                        v.Offset = XmlObject.ReadVector3(xe, "Offset");
                        v.Euler = XmlObject.ReadVector3(xe, "Euler");
                        v.Radius = XmlObject.ReadFloat(xe, "Radius");
                    }
                    break;
                case SkillRegionType.Box:
                    {
                        Scope = new ScopeBox();
                        ScopeBox v = Scope as ScopeBox;
                        v.Offset = XmlObject.ReadVector3(xe, "Offset");
                        v.Euler = XmlObject.ReadVector3(xe, "Euler");
                        v.H = XmlObject.ReadFloat(xe, "H");
                        v.L = XmlObject.ReadFloat(xe, "L");
                        v.W = XmlObject.ReadFloat(xe, "W");
                    }
                    break;
                case SkillRegionType.Cylinder:
                    {
                        Scope = new ScopeCylinder();
                        ScopeCylinder v = Scope as ScopeCylinder;
                        v.Offset = XmlObject.ReadVector3(xe, "Offset");
                        v.Euler = XmlObject.ReadVector3(xe, "Euler");
                        v.MaxDis = XmlObject.ReadFloat(xe, "MaxDis");
                        v.HAngle = XmlObject.ReadFloat(xe, "HAngle");
                        v.Height = XmlObject.ReadFloat(xe, "Height");
                    }
                    break;
            }
        }

        protected override void ReadAttribute(string key, string value)
        {
            switch (key)
            {
                case "Region":
                    this.Region = (SkillRegionType)value.ToInt32();
                    break;
                case "Affect":
                    this.Affect = (AffectType)value.ToInt32();
                    break;
                case "LifeTime":
                    this.LifeTime = value.ToFloat();
                    break;
                case "MaxCount":
                    this.MaxCount = value.ToInt32();
                    break;
                case "JudgeName":
                    this.JudgeName = value;
                    break;
            }
        }

        public override BTNode DeepClone()
        {
            Judge scope = new Judge();
            scope.Region = this.Region;
            scope.Scope = this.Scope;
            scope.Owner = this.Owner;
            scope.Affect = this.Affect;
            scope.LifeTime = this.LifeTime;
            scope.MaxCount = this.MaxCount;
            scope.JudgeName = this.JudgeName;
            scope.CloneChildren(this);
            return scope;
        }

        public override void Clear()
        {
            base.Clear();
            mJudgeTrans = null;
            mCurCount = 0;
        }
    }
}
