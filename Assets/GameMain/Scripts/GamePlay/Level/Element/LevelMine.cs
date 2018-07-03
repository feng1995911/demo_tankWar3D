#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace GameMain
{
    public class LevelMine:LevelElement
    {
        public float RebornCD = 5;
        public int DropItemCount = 1;

        private int m_SerialId;

        
        public override void Import(XmlObject pData, bool pBuild)
        {
            MapMine data = pData as MapMine;
            if (data != null)
            {
                Id = data.Id;
                Position = data.Position;
                Euler = data.EulerAngles;
                RebornCD = data.RebornCD;
                DropItemCount = data.DropItemCount;
            }
            this.Build();
            this.SetName();
        }

        public override XmlObject Export()
        {
            MapMine data = new MapMine
            {
                Id = Id,
                Position = Position,
                EulerAngles = Euler,
                RebornCD = RebornCD,
                DropItemCount = DropItemCount
            };
            return data;
        }

        public override void SetName()
        {
            gameObject.name = "Mine_" + Id.ToString();
        }

        public override void Build()
        {
            transform.DestroyChildren();
            if (Application.isPlaying)
            {
                TransformParam param = new TransformParam();
                param.Position = transform.position;
                param.EulerAngles = transform.rotation.eulerAngles;
                param.Scale = transform.localScale;

                m_SerialId = GameEntry.Level.CreateLevelObject(Id, param);
            }
            else
            {
#if UNITY_EDITOR
                GameObject mine = LevelComponent.CreateLevelEditorObject(MapHolderType.MineGroup);
                mine.transform.SetParent(transform, false);
                mine.transform.localPosition = Vector3.zero;
                mine.transform.localScale = Vector3.one;
                mine.transform.localRotation = Quaternion.identity;
#endif
            }

        }
    }
}