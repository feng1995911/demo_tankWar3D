using GameFramework;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.WSA;
using Application = UnityEngine.Application;

namespace GameMain
{
    public class LevelPortal : LevelElement
    {
        public int     DestMapID;
        public Vector3 DestPos;
        public bool    DisplayText = false;
        public string  PortalName = string.Empty;
        public ConditionRelationType Relation = ConditionRelationType.And;
        public int OpenLevel;
        public int OpenItemID;
        public int OpenVIP;

        private int m_SerialId;

        public LevelRegion Region
        {
            get; set;
        }

        public int RegionID
        {
            get { return Region == null ? 0 : Region.Id; }
        }

        public int SerialId
        {
            get { return Id; }
            set { Id = value; }
        }

        public override void Build()
        {
            if (m_SerialId == 0)
            {
                if (Application.isPlaying)
                {
                    TransformParam param = new TransformParam();
                    param.Position = transform.position;
                    param.EulerAngles = transform.rotation.eulerAngles;
                    param.Scale = transform.localScale;

                    m_SerialId = GameEntry.Level.CreateLevelObject(Constant.Define.Portal, param);
                }
                else
                {
#if UNITY_EDITOR
                    GameObject portal = LevelComponent.CreateLevelEditorObject(MapHolderType.Portal);
                    portal.transform.parent = transform;
                    portal.transform.localPosition = Vector3.zero;
                    portal.transform.localEulerAngles = Vector3.zero;
                    portal.transform.localScale = Vector3.one;
#endif
                }
            }
        }

        public override void SetName()
        {
            gameObject.name = "Portal_" + Id.ToString();
        }

        public override XmlObject Export()
        {
            MapPortal data = new MapPortal
            {
                Id = Id,
                OpenItemID = OpenItemID,
                OpenLevel = OpenLevel,
                OpenVIP = OpenVIP,
                PortalName = PortalName,
                RegionID = RegionID,
                DestMapID = DestMapID,
                DestPos = DestPos,
                DisplayText = DisplayText,
                ConditionRelation = Relation,
                Center = Position,
                Euler = Euler
            };
            return data;
        }

        public override void Import(XmlObject pData,bool pBuild)
        {
            MapPortal data = pData as MapPortal;
            if (data == null)
            {
                return;
            }

            Id = data.Id;
            OpenItemID = data.OpenItemID;
            OpenLevel = data.OpenLevel;
            OpenVIP = data.OpenVIP;
            PortalName = data.PortalName;
            DestMapID = data.DestMapID;
            DestPos = data.DestPos;
            DisplayText = data.DisplayText;
            Relation = data.ConditionRelation;
            Position = data.Center;
            this.Build();
            this.SetName();

            if (Application.isPlaying)
            {
                HolderRegion pHolder = GameEntry.Level.GetHolder(MapHolderType.Region) as HolderRegion;

                if (pHolder != null)
                    this.Region = pHolder.FindElement(data.RegionID);

                if (Region != null)
                {
                    Position = data.Center;
                    Euler = data.Euler;
                    Region.onTriggerEnter = onTriggerEnter;
                }
            }
        }

        void onTriggerEnter(Collider other)
        {
            if (Region == null)
            {
                return;
            }

            if (other.gameObject.layer != Constant.Layer.PlayerId &&
                other.gameObject.layer != Constant.Layer.MountId)
            {
                return;
            }

            GameEntry.UI.OpenUIForm(UIFormId.LevelSelectForm);

        }
    }
}

