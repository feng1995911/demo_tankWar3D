using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameMain
{
    public class LevelRegion : LevelElement
    {
        public bool AllowRide = true;
        public bool AllowPK = true;
        public bool AllowTrade = true;
        public bool AllowFight = true;
        public bool StartActive = false;
        public Vector3 Size = Vector3.one;

        public Color color = new Color(1, 0.92f, 0.016f, 0.35f);
        public Action<Collider> onTriggerEnter;
        public Action<Collider> onTriggerStay;
        public Action<Collider> onTriggerExit;

        private MapRegion m_Data = null;
        private Mesh m_Mesh;
        private Material m_Material;
        private static MeshFilter m_MeshFilter;
        private BoxCollider m_Collider;
        private HashSet<MapEvent> m_HasActiveEvents = new HashSet<MapEvent>();

        public List<LevelEvent> Events
        {
            get
            {
                List<LevelEvent> pList = new List<LevelEvent>();
                GetAllComponents<LevelEvent>(transform, pList);
                return pList;
            }
        }

        public LevelEvent AddElement()
        {
            LevelEvent pElem = new GameObject().AddComponent<LevelEvent>();
            pElem.transform.parent = transform;
            pElem.transform.localPosition = Vector3.zero;
            pElem.Build();
            pElem.SetName();
            return pElem;
        }

        public override void Init()
        {
            ActiveEventsByCondition(TriggerConditionType.InitRegion);
        }

        void OnTriggerEnter(Collider other)
        {
            onTriggerEnter?.Invoke(other);

            if (other.gameObject.layer == Constant.Layer.PlayerId || other.gameObject.layer == Constant.Layer.MountId)
            {
                ActiveEventsByCondition(TriggerConditionType.EnterRegion);
            }
        }

        void OnTriggerStay(Collider other)
        {
            onTriggerStay?.Invoke(other);
        }

        void OnTriggerExit(Collider other)
        {
            if (onTriggerExit != null)
            {
                onTriggerExit(other);
            }


            if (other.gameObject.layer == Constant.Layer.PlayerId || other.gameObject.layer == Constant.Layer.MountId)
            {
                ActiveEventsByCondition(TriggerConditionType.LeaveRegion);
            }
        }

        public override void Build()
        {
            m_Collider = gameObject.GetOrAddComponent<BoxCollider>();
            if (Size.x <= 0) Size.x = 1;
            if (Size.y <= 0) Size.y = 1;
            if (Size.z <= 0) Size.z = 1;
            m_Collider.size = Size;
            m_Collider.isTrigger = true;
        }

        public override void SetName()
        {
            this.name = "Region_" + Id.ToString();
        }

        private MeshFilter RegionMeshFilter
        {
            get
            {
                if (m_MeshFilter != null)
                {
                    return m_MeshFilter;
                }
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                if (go != null)
                {
                    m_MeshFilter = go.GetComponent<MeshFilter>();
                }
                go.transform.parent = GameEntry.Level.transform;
                go.SetActive(false);
                return m_MeshFilter;
            }
        }

        private int[] Triangles
        {
            get
            {
                if (RegionMeshFilter == null)
                {
                    return null;
                }
                return RegionMeshFilter.sharedMesh.triangles;
            }
        }

        private Vector3[] Vertices
        {
            get
            {
                Vector3[] data = RegionMeshFilter.sharedMesh.vertices;
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = new Vector3(data[i].x * Size.x, data[i].y * Size.y, data[i].z * Size.z);
                }
                return data;
            }
        }

        public override XmlObject Export()
        {
            MapRegion data = new MapRegion
            {
                Id = Id,
                Size = Size,
                Center = Position,
                EulerAngles = Euler,
                AllowFight = AllowFight,
                AllowPK = AllowPK,
                AllowRide = AllowRide,
                AllowTrade = AllowTrade,
                StartActive = StartActive
            };
            List<LevelEvent> pList = Events;
            for (int i = 0; i < pList.Count; i++)
            {
                data.Events.Add(pList[i].Export() as MapEvent);
            }
            return data;
        }

        public override void Import(XmlObject pData, bool pBuild)
        {
           MapRegion data = pData as MapRegion;
            if (data != null)
            {
                Id = data.Id;
                Size = data.Size;
                Position = data.Center;
                Euler = data.EulerAngles;
                AllowFight = data.AllowFight;
                AllowPK = data.AllowPK;
                AllowRide = data.AllowRide;
                AllowTrade = data.AllowTrade;
                StartActive = data.StartActive;
                this.m_Data = data;
                this.Build();
                this.SetName();
                if (pBuild)
                {
                    for (int i = 0; i < data.Events.Count; i++)
                    {
                        GameObject go = gameObject.AddChild();
                        LevelEvent pEvent = go.AddComponent<LevelEvent>();
                        pEvent.Import(data.Events[i], pBuild);
                    }
                }
            }
        }

        public bool CheckCondition(MapEventCondition data, MapEvent pEventData, TriggerConditionType except, params object[] args)
        {
            switch (data.Type)
            {
                case TriggerConditionType.EnterRegion:
                case TriggerConditionType.InitRegion:
                case TriggerConditionType.LeaveRegion:
                    {
                        return data.Type == except;
                    }
                case TriggerConditionType.WaveIndex:
                case TriggerConditionType.WavesetEnd:
                    {
                        if (except == data.Type)
                        {
                            return (int)args[0] == data.Args.ToInt32();
                        }
                        else
                        {
                            return false;
                        }
                    }
                default:
                    return false;
            }
        }

        public void ActiveEventsByCondition(TriggerConditionType type, params object[] args)
        {
            for (int i = 0; i < m_Data.Events.Count; i++)
            {
                MapEvent data = m_Data.Events[i];
                if (m_HasActiveEvents.Contains(data) && data.Conditions2 == null)
                {
                    continue;
                }

                int num = 0;
                for (int k = 0; k < data.Conditions1.Count; k++)
                {
                    MapEventCondition pChild = data.Conditions1[k];
                    bool isTrigger = CheckCondition(pChild, data, type, args);
                    if (isTrigger)
                    {
                        num++;
                    }
                }

                bool active = false;
                switch (data.Relation1)
                {
                    case ConditionRelationType.And:
                        active = num >= data.Conditions1.Count;
                        break;
                    case ConditionRelationType.Or:
                        active = num > 0;
                        break;
                }

                if (active)
                {
                    GameEntry.Level.StartMapEvent(data, this);
                    if (!m_HasActiveEvents.Contains(data))
                    {
                        m_HasActiveEvents.Add(data);
                    }
                }
            }
        }
        private void DrawMeshNow()
        {
            if (null == m_Mesh)
            {
                m_Mesh = new Mesh { hideFlags = HideFlags.HideAndDontSave };
            }
            if (null == m_Material)
            {
                Shader shader = Shader.Find("Custom/TranspUnlit");
                m_Material = new Material(shader) { hideFlags = HideFlags.HideAndDontSave };
            }
            m_Material.color = color;
            m_Mesh.vertices = Vertices;
            m_Mesh.triangles = Triangles;
            Vector3[] vertices = m_Mesh.vertices;
            Vector2[] uvs = new Vector2[vertices.Length];
            int j = 0;
            while (j < uvs.Length)
            {
                uvs[j] = new Vector2(vertices[j].x, vertices[j].z);
                j++;
            }

            m_Mesh.uv = uvs;
            m_Mesh.RecalculateNormals();
            for (int i = 0; i < m_Material.passCount; i++)
            {
                if (m_Material.SetPass(i))
                {
                    Graphics.DrawMeshNow(m_Mesh, Position, Quaternion.Euler(Euler));
                }
            }
        }

        private void OnDrawGizmos()
        {
            DrawMeshNow();
        }

        private Vector3 RotateAroundPoint(Vector3 point, Vector3 pivot, Quaternion rotation)
        {
            return rotation * (point - pivot) + pivot;
        }
    }
}
