using GameFramework;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// 角色技能
    /// </summary>
    public class ActorSkill : IActorSkill
    {
        protected ActorBase m_Owner = null;
        protected List<SkillTree> m_SkillPool = null;
        protected SkillTree m_CurrSkillTree;
        protected SkillTree m_MinCastDistSkillTree;
        protected List<SkillTree> m_ComboSkills =  new List<SkillTree>();
        protected int m_ComboIndex = 0;
        protected float m_StartTime = 0;
        protected float m_currTime = 0;
        protected float m_ComboValidTime = 1;


        public ActorSkill(ActorBase owner)
        {
            m_Owner = owner;
            m_SkillPool = new List<SkillTree>();
            LoadSkill();

            float dist = 100000;
            for (int i = 0; i < m_SkillPool.Count; i++)
            {
                SkillTree skill = m_SkillPool[i];
                if (skill.CastDistance < dist && skill.CastDistance > 0)
                {
                    m_MinCastDistSkillTree = skill;
                    dist = skill.CastDistance;
                }

                if (skill.Pos == SkillPosType.Skill_0)
                {
                    m_ComboSkills.Add(skill);
                }
            }
        }

        public void Step()
        {
            if(m_Owner.IsDead)
                return;

            if (Time.realtimeSinceStartup - m_StartTime >= m_ComboValidTime)
            {
                m_ComboIndex = 0;
            }
        }

        public bool UseSkill(int id)
        {
            SkillTree skillTree = GetSkill(id);
            if (skillTree == null)
            {
                return false;
            }
            m_CurrSkillTree = skillTree;
            m_CurrSkillTree.Start();
            return true;
        }

        public bool UseSkill(SkillPosType pos)
        {
            SkillTree skillTree = GetSkill(pos);
            if (skillTree == null)
            {
                return false;
            }
            m_CurrSkillTree = skillTree;
            m_CurrSkillTree.Start();
            if (pos == SkillPosType.Skill_0)
            {
                m_ComboIndex = m_ComboIndex >= m_ComboSkills.Count - 1 ? 0 : ++m_ComboIndex;
                m_StartTime = Time.realtimeSinceStartup;
            }

            return true;
        }

        public SkillTree GetSkill(SkillPosType pos)
        {
            for (int i = 0; i < m_SkillPool.Count; i++)
            {
                SkillTree skillTree = m_SkillPool[i];
                if (skillTree.Pos == pos)
                {
                    if (pos == SkillPosType.Skill_0)
                    {
                        return m_ComboSkills[m_ComboIndex];
                    }
                    return skillTree;
                }
            }
            return null;
        }

        public SkillTree GetSkill(int id)
        {
            for (int i = 0; i < m_SkillPool.Count; i++)
            {
                SkillTree skillTree = m_SkillPool[i];
                if (skillTree.Id == id)
                {
                    return skillTree;
                }
            }
            return null;
        }

        public List<SkillTree> GetAllSkill()
        {
            return m_SkillPool;
        }

        public float GetMinCastDistance()
        {
            return m_MinCastDistSkillTree == null ? 0 : m_MinCastDistSkillTree.CastDistance;
        }

        public SkillTree FindNextSkillByDist(float dist)
        {
            List<SkillTree> validSkills = new List<SkillTree>();
            for (int i = 0; i < m_SkillPool.Count; i++)
            {
                SkillTree skillTree = m_SkillPool[i];
                if (skillTree.IsInCD())
                {
                    continue;
                }

                if (skillTree.CastDistance < 0)
                {
                    continue;
                }

                if (dist < skillTree.CastDistance)
                {
                    validSkills.Add(skillTree);
                }
            }

            if (validSkills.Count == 0)
            {
                return null;
            }
            else
            {
                if (validSkills.Count == 1)
                {
                    return validSkills[0];
                }
                else
                {
                    int index = Random.Range(0, validSkills.Count);
                    return validSkills[index];
                }
            }
        }

        public SkillTree FindNextSkillByDist(Vector3 dest)
        {
            float dist = GlobalTools.GetHorizontalDistance(dest, m_Owner.Pos);
            return FindNextSkillByDist(dist);
        }

        public void Clear()
        {
            m_ComboIndex = 0;
            if (m_CurrSkillTree == null)
            {
                return;
            }
            m_CurrSkillTree.Break();
            m_CurrSkillTree = null;
        }

        private void LoadSkill()
        {
            string scriptName = m_Owner.Id.ToString();
            string assetName = AssetUtility.GetSkillScriptAsset(scriptName);
            string data = string.Empty;

            TextAsset asset = GameEntry.Resource.LoadAssetSync(assetName) as TextAsset;
            if (asset == null)
            {
                Log.Error("Skill script file is empty. file:{0}", m_Owner.Id.ToString());
                return;
            }
            data = asset.text;
            
            if (string.IsNullOrEmpty(data))
            {
                Log.Error("File content is null. file:{0}", assetName);
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data);

            XmlNode root = doc.FirstChild;
            if (root.Name.Equals("Actor") == false)
            {
                return;
            }
            XmlNode child = root.FirstChild;
            while (child != null)
            {
                if (child.Name.Equals("Skill"))
                {
                    XmlElement xe = child as XmlElement;
                    int id = XmlObject.ReadInt32(xe, "Id");
                    if (id > 0)
                    {
                        SkillTree skillTree = new SkillTree(id, m_Owner);
                        m_SkillPool.Add(skillTree);
                        skillTree.Load(xe);
                    }
                }
                child = child.NextSibling;
            }

            GameEntry.Resource.UnloadAsset(asset);
        }
    
    }
}
