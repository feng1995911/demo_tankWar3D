#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// 关卡编辑器
    /// </summary>
    public class LevelEditor:UnityEditor.Editor
    {
        [MenuItem("MMORPG Demo/Add LevelEditor")]
        static void OpenLevelEditor()
        {
            GameEntry.Level.InitHolder();
        }

        [MenuItem("MMORPG Demo/GetSelectGOMeshData")]
        static void GetMeshData()
        {
            if (Selection.activeObject == null)
            {
                return;
            }
            GameObject go = Selection.activeObject as GameObject;
            if (go == null)
                return;
            MeshFilter filter = go.GetComponent<MeshFilter>();
            if (filter == null || filter.sharedMesh == null)
            {
                return;
            }
            string s = string.Empty;
            for (int i = 0; i < filter.sharedMesh.triangles.Length; i++)
            {
                s += filter.sharedMesh.triangles[i] + ",";
            }
            Debug.Log("triangles:" + s);

            string m = string.Empty;
            for (int i = 0; i < filter.sharedMesh.vertices.Length; i++)
            {
                m += filter.sharedMesh.vertices[i].ToString() + ",";
            }
            Debug.Log("vertices:" + m);
        }
    }
}

#endif