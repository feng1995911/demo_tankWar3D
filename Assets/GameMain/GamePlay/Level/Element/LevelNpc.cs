using UnityEngine;
using System.Collections.Generic;

namespace GameMain
{
    public class LevelNpc: LevelElement
    {
        public LevelPathNodeSet PatrolPathNodeSet;
        [SerializeField]
        public List<string> Talks = new List<string>();

        private GameObject mBody;

        public override void Build()
        {
            if (mBody == null)
            {
                mBody = GameObject.CreatePrimitive(PrimitiveType.Cube);
                mBody.transform.parent = transform;
                mBody.transform.localPosition = Vector3.zero;
                mBody.transform.localEulerAngles = Vector3.zero;
                mBody.transform.localScale = Vector3.one;
            }
            MeshRenderer render = mBody.GetComponent<MeshRenderer>();
            if (render == null)
            {
                return;

            }
            if (render.sharedMaterial != null)
            {
                Shader shader = Shader.Find("Custom/TranspUnlit");
                render.sharedMaterial = new Material(shader) { hideFlags = HideFlags.HideAndDontSave };
            }
            render.sharedMaterial.color = Color.cyan;
        }

        public override void SetName()
        {
            gameObject.name = "Npc_" + Id.ToString();
        }

        public override void Import(XmlObject pData,bool pBuild)
        {
            MapNpc data = pData as MapNpc;
            Id = data.Id;

            Position = data.Position;
            Euler = data.Euler;
            Talks = data.Talks;
            Scale = data.Scale;

            if (data.PatrolPathNodeSet != null)
            {
                GameObject go = new GameObject();
                go.transform.parent = transform;
                go.transform.localPosition = Vector3.zero;
                go.transform.localEulerAngles = Vector3.zero;
                PatrolPathNodeSet = go.AddComponent<LevelPathNodeSet>();
                PatrolPathNodeSet.Import(data.PatrolPathNodeSet,pBuild);
            }
            
            this.Build();
            this.SetName();
        }

        public override XmlObject Export()
        {
            MapNpc data = new MapNpc
            {
                Id = Id,
                Position = Position,
                Euler = Euler,
                Talks = Talks,
                Scale = Scale
            };

            if (PatrolPathNodeSet != null)
            {
                data.PatrolPathNodeSet=(MapPathNodeSet)PatrolPathNodeSet.Export();
            }
            return data;
        }
    }
}
