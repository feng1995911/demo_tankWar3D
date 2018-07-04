using GameFramework.Resource;
using GameMain.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMain
{
    /// <summary>
    /// Splash动画流程
    /// </summary>
    public class ProcedureSplash : ProcedureBase
    {
        private string logoPrefabPath = "Logo/Logo";
        private GameObject logoGo = null;

        public override bool UseNativeDialog
        {
            get
            {
                return true;
            }
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            logoGo = GameObject.Instantiate(Resources.Load<GameObject>(logoPrefabPath));

            procedureOwner.SetData<VarGameObject>(Constant.ProcedureData.SplashGo, logoGo);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);       
            // 编辑器模式下，直接进入预加载流程；否则，检查版本
            if (GameEntry.Base.EditorResourceMode)
            {
                ChangeState<ProcedurePreload>(procedureOwner);
            }
            else
            {
                if (GameEntry.Resource.ResourceMode == ResourceMode.Updatable)
                {
                    ChangeState<ProcedureCheckVersion>(procedureOwner);
                }
                else if (GameEntry.Resource.ResourceMode == ResourceMode.Package)
                {
                    ChangeState<ProcedureInitResource>(procedureOwner);
                }
            }
        }

    }
}
