using System;
using GameFramework;
using GameFramework.DataTable;
using GameFramework.Event;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using FairyGUI;
using UnityEngine;

namespace GameMain
{
    public class ProcedureChangeScene : ProcedureBase
    {
        private SceneId m_CurLoadedSceneId = SceneId.Undefined;

        private bool m_IsChangeSceneComplete = false;
        private int m_BackgroundMusicId = 0;    
        private string m_SceneName = String.Empty;
        private Vector3 m_PlayerPos = Vector3.zero;

        public override bool UseNativeDialog
        {
            get { return false; }
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            m_IsChangeSceneComplete = false;

            GameEntry.Event.Subscribe(LoadSceneSuccessEventArgs.EventId, OnLoadSceneSuccess);
            GameEntry.Event.Subscribe(LoadSceneFailureEventArgs.EventId, OnLoadSceneFailure);
            GameEntry.Event.Subscribe(LoadSceneUpdateEventArgs.EventId, OnLoadSceneUpdate);
            GameEntry.Event.Subscribe(LoadSceneDependencyAssetEventArgs.EventId, OnLoadSceneDependencyAsset);

            // 停止所有声音
            GameEntry.Sound.StopAllLoadingSounds();
            GameEntry.Sound.StopAllLoadedSounds();

            // 隐藏所有实体
            GameEntry.Entity.HideAllLoadingEntities();
            GameEntry.Entity.HideAllLoadedEntities();

            //卸载所有场景
            string[] loadedSceneAssetNames = GameEntry.Scene.GetLoadedSceneAssetNames();
            for (int i = 0; i < loadedSceneAssetNames.Length; i++)
            {
                GameEntry.Scene.UnloadScene(loadedSceneAssetNames[i]);
            }
            
            //还原游戏速度
            GameEntry.Base.ResetNormalGameSpeed();

            int sceneId = procedureOwner.GetData<VarInt>(Constant.ProcedureData.NextSceneId).Value;
            m_CurLoadedSceneId = (SceneId) sceneId;
            IDataTable<DRScene> dtScene = GameEntry.DataTable.GetDataTable<DRScene>();
            DRScene drScene = dtScene.GetDataRow(sceneId);
            if (drScene == null)
            {
                Log.Warning("Can no load scene '{0}' from data table.", sceneId.ToString());
                return;
            }

            //打开加载进度界面
            GameEntry.UI.OpenUIForm(UIFormId.LoadingForm, sceneId);

            GameEntry.Scene.LoadScene(AssetUtility.GetSceneAsset(drScene.AssetName), sceneId);

            m_BackgroundMusicId = drScene.BackgroundMusicId;
            m_SceneName = drScene.SceneName;
            m_PlayerPos = drScene.PlayerSpawn;
            GameEntry.Scene.SetCurSceneSpawnPos(m_PlayerPos);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            GameEntry.Event.Unsubscribe(LoadSceneSuccessEventArgs.EventId, OnLoadSceneSuccess);
            GameEntry.Event.Unsubscribe(LoadSceneFailureEventArgs.EventId, OnLoadSceneFailure);
            GameEntry.Event.Unsubscribe(LoadSceneUpdateEventArgs.EventId, OnLoadSceneUpdate);
            GameEntry.Event.Unsubscribe(LoadSceneDependencyAssetEventArgs.EventId, OnLoadSceneDependencyAsset);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (!m_IsChangeSceneComplete)
            {
                return;
            }

            if (m_CurLoadedSceneId == SceneId.Undefined)
            {
                return;
            }

            switch (m_CurLoadedSceneId)
            {
                case SceneId.Login:
                    ChangeState<ProcedureLogin>(procedureOwner);
                    break;
                case SceneId.CreateRole:
                    ChangeState<ProcedureCreateRole>(procedureOwner);
                    break;
                case SceneId.MainCity:
                    ChangeState<ProcedureMainCity>(procedureOwner);
                    break;
                case SceneId.Level01:
                case SceneId.Level02:
                case SceneId.Level03:
                case SceneId.Level04:
                case SceneId.Level05:
                    ChangeState<ProcedureLevel>(procedureOwner);
                    break;
            }
        }

        private void OnLoadSceneSuccess(object sender, GameEventArgs e)
        {
            LoadSceneSuccessEventArgs ne = e as LoadSceneSuccessEventArgs;

            Log.Info("Load scene '{0}' OK.",ne.SceneAssetName);

            if (m_BackgroundMusicId > 0)
            {
                GameEntry.Sound.PlayMusic(m_BackgroundMusicId);
            }

            m_IsChangeSceneComplete = true;

            //加载场景成功，手动清理资源，确保场景资源卸载干净
            GameEntry.Resource.UnloadUnusedAssets(true);

            GameEntry.UI.CloseUIForm(UIFormId.LoadingForm);
        }

        private void OnLoadSceneFailure(object sender, GameEventArgs e)
        {
            LoadSceneFailureEventArgs ne = (LoadSceneFailureEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            Log.Error("Load scene '{0}' failure, error message '{1}'.", ne.SceneAssetName, ne.ErrorMessage);
        }

        private void OnLoadSceneUpdate(object sender, GameEventArgs e)
        {
            LoadSceneUpdateEventArgs ne = (LoadSceneUpdateEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            Log.Info("Load scene '{0}' update, progress '{1}'.", ne.SceneAssetName, ne.Progress.ToString("P2"));

            string description = string.Format("正在加载场景：[{0}],加载进度：[{1}]。", m_SceneName, ne.Progress.ToString("P2"));
            float progress = ne.Progress * 100;

            LoadingFormUpdateProgressEventArgs uiArgs = ReferencePool.Acquire<LoadingFormUpdateProgressEventArgs>().Fill(description, progress, null);
            GameEntry.Event.Fire(this, uiArgs);
        }

        private void OnLoadSceneDependencyAsset(object sender, GameEventArgs e)
        {
            LoadSceneDependencyAssetEventArgs ne = (LoadSceneDependencyAssetEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            Log.Info("Load scene '{0}' dependency asset '{1}', count '{2}/{3}'.", ne.SceneAssetName, ne.DependencyAssetName, ne.LoadedCount.ToString(), ne.TotalCount.ToString());
        }

    }
}
