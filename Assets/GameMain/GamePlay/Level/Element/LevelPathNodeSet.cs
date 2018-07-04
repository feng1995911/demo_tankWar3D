using UnityEngine;

namespace GameMain
{
    public class LevelPathNodeSet : LevelContainerBase<LevelPathNode>
    {
        public PathType Type = PathType.Linear;
        public bool CloseLoop = true;
        private static Texture2D mBezierTexture2D;

        public override void Import(XmlObject pData,bool pBuild)
        {
            MapPathNodeSet data = pData as MapPathNodeSet;
            if (data != null)
            {
                Type = data.Type;
                for(int i=0;i<data.PathNodes.Count;i++)
                {
                    GameObject go = new GameObject();
                    go.name = i.ToString();
                    go.transform.parent = transform;
                    LevelPathNode p=go.AddComponent<LevelPathNode>();
                    p.Import(data.PathNodes[i],pBuild);
                }
            }
        }

        public override XmlObject Export()
        {
            MapPathNodeSet data = new MapPathNodeSet();
            data.Type = Type;

            for (int i = 0; i < Elements.Count; i++)
            {
                MapPathNode node =(MapPathNode) Elements[i].Export();
                data.PathNodes.Add(node);
            }
            return data;
        }

        public override void Build()
        {
            gameObject.name = "Set";
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (Elements.Count < 2) return;
            LevelPathNode pNode = null;
            LevelPathNode nNode = null;
            for (int i = 0; i < Elements.Count; i++)
            {
                pNode = Elements[i];
                if (i < Elements.Count - 1)
                {
                    nNode = Elements[i + 1];
                }
                else
                {
                    pNode = CloseLoop ? Elements[0] : null;
                }
                if (pNode == null || nNode == null)
                {
                    continue;
                }
                switch (Type)
                {
                    case PathType.Linear:
                        UnityEditor.Handles.DrawLine(pNode.transform.position, nNode.transform.position);
                        break;
                    case PathType.Bezier:
                        Vector3 offset = nNode.transform.position - pNode.transform.position;
                        if (mBezierTexture2D == null)
                        {
                            mBezierTexture2D = new Texture2D(4, 4);
                        }
                        Vector3 pStartPos = pNode.transform.position;
                        Vector3 pEndPos = nNode.transform.position;
                        Vector3 pStartTangent = pNode.transform.position + offset * 0.333f;
                        Vector3 pEndTangent = pNode.transform.position * 0.666f;
                        UnityEditor.Handles.DrawBezier(pStartPos, pEndPos, pStartTangent, pEndTangent, Color.green, mBezierTexture2D, 4);
                        break;
                }
            }
        }
#endif
    }

}
