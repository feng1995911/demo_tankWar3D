using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{
    public static class SceneComponentExtension
    {
        private static Vector3 m_CurSceneSpawnPos = Vector3.zero;

        public static void SetCurSceneSpawnPos(this SceneComponent sceneComponent, Vector3 spawnPos)
        {
            m_CurSceneSpawnPos = spawnPos;
        }

        public static Vector3 GetCurSceneSpawnPos(this SceneComponent sceneComponent)
        {
            return m_CurSceneSpawnPos;
        }

        public static SceneType GetSceneTypeBySceneId(this SceneComponent sceneComponent,SceneId sceneId)
        {
            int id = (int) sceneId;
            DRScene drScene = GameEntry.DataTable.GetDataTable<DRScene>().GetDataRow(id);
            return (SceneType)drScene.SceneType;
        }
    }
}
