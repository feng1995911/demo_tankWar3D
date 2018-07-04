using UnityEngine;

namespace GameMain
{
    public class LevelBorn : LevelElement
    {
        public BattleCampType Camp = BattleCampType.Ally;
        private GameObject m_Body;

        public override void Build()
        {
            if (m_Body == null)
            {
                m_Body = GameObject.CreatePrimitive(PrimitiveType.Cube);
                m_Body.transform.parent = transform;
                m_Body.transform.localPosition = Vector3.zero;
                m_Body.transform.localEulerAngles = Vector3.zero;
                m_Body.transform.localScale = Vector3.one;
            }

            MeshRenderer render = m_Body.GetComponent<MeshRenderer>();
            if (render?.sharedMaterial == null)
            {
                return;
            }

            Shader shader = Shader.Find("Custom/TranspUnlit");
            render.sharedMaterial = new Material(shader) {hideFlags = HideFlags.HideAndDontSave};

            switch (Camp)
            {
                case BattleCampType.Ally:
                    render.sharedMaterial.color = Color.green;
                    break;
                case BattleCampType.Enemy:
                    render.sharedMaterial.color = Color.red;
                    break;
                case BattleCampType.Neutral:
                    render.sharedMaterial.color = Color.yellow;
                    break;
                default:
                    render.sharedMaterial.color = Color.white;
                    break;
            }
        }

        public override void SetName()
        {
            gameObject.name = "Born_" + Camp.ToString();
        }

        public override XmlObject Export()
        {
            MapBorn data = new MapBorn
            {
                Camp = Camp,
                TransParam = new MapTransform
                {
                    Position = Position,
                    Scale = Scale,
                    EulerAngles = Euler
                }
            };
            return data;
        }

        public override void Import(XmlObject pData,bool pBuild)
        {
            MapBorn data = pData as MapBorn;
            if (data != null)
            {
                Camp = data.Camp;
                Position = data.TransParam.Position;
                Scale = data.TransParam.Scale;
                Euler = data.TransParam.EulerAngles;
            }
            this.Build();
            this.SetName();
        }
    }
}
