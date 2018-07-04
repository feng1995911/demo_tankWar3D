using GameFramework;
using GameFramework.DataTable;
using System.Collections.Generic;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMain
{
    public class ProcedureCreateRole : ProcedureBase
    {
        public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }

        private ProcedureOwner m_ProcedureOwner = null;

        private PoseRoleData m_WarriorData = null;
        private PoseRoleData m_MasterData = null;
        private PoseRoleData m_ShooterData = null;

        private int m_WarriorTypeId = 10001;
        private int m_MasterTypeId  = 10002;
        private int m_ShooterTypeId = 10003;
        private int m_SelectRoleTypeId = 0;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            m_ProcedureOwner = procedureOwner;

            //初始化数据
            InitData();

            //显示第一个职业
            GameEntry.Entity.ShowPoseRole(m_WarriorData);
            m_SelectRoleTypeId = m_WarriorTypeId;

            //打开创建角色界面
            RoleCreateFormData data = new RoleCreateFormData();
            IDataTable<DRRoleName> nameDt = GameEntry.DataTable.GetDataTable<DRRoleName>() ;
            DRRoleName[] allNames = nameDt.GetAllDataRows();
            Queue<string> namesQueue = new Queue<string>();
            for (int i = 0; i < allNames.Length; i++)
            {
                namesQueue.Enqueue(allNames[i].RoleName);
            }
            data.RandomNameQueue = namesQueue;
            data.OnClickRoleType = OnClickRoleType;
            data.OnClickCreateRole = OnClickCreateRole;
            GameEntry.UI.OpenUIForm(UIFormId.CreateRoleForm, data);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
            GameEntry.UI.CloseUIForm(UIFormId.CreateRoleForm);
        }

        private void InitData()
        {
            m_WarriorData = new PoseRoleData(GameEntry.Entity.GenerateTempSerialId(), m_WarriorTypeId);
            m_MasterData = new PoseRoleData(GameEntry.Entity.GenerateTempSerialId(), m_MasterTypeId);
            m_ShooterData = new PoseRoleData(GameEntry.Entity.GenerateTempSerialId(), m_ShooterTypeId);
        }

        private void OnClickRoleType(int type)
        {
            ProfessionType pfType = (ProfessionType)type;
            switch (pfType)
            {
                case ProfessionType.Warrior:
                    GameEntry.Entity.ShowPoseRole(m_WarriorData);
                    m_SelectRoleTypeId = m_WarriorTypeId;
                    GameEntry.Entity.CheckHideEntity(m_MasterData.Id);             
                    GameEntry.Entity.CheckHideEntity(m_ShooterData.Id);
                    break;
                case ProfessionType.Master:
                    GameEntry.Entity.ShowPoseRole(m_MasterData);
                    m_SelectRoleTypeId = m_MasterTypeId;
                    GameEntry.Entity.CheckHideEntity(m_WarriorData.Id);
                    GameEntry.Entity.CheckHideEntity(m_ShooterData.Id);
                    break;
                case ProfessionType.Shoooter:
                    GameEntry.Entity.ShowPoseRole(m_ShooterData);
                    m_SelectRoleTypeId = m_ShooterTypeId;
                    GameEntry.Entity.CheckHideEntity(m_MasterData.Id);
                    GameEntry.Entity.CheckHideEntity(m_WarriorData.Id);
                    break;
            }
        }

        private void OnClickCreateRole(string roleName)
        {
            Log.Info("create role ,name : " + roleName);

            if (m_ProcedureOwner != null)
            {
                //创建角色数据
                int userId = m_ProcedureOwner.GetData<VarInt>(Constant.ProcedureData.UserId);
                int playerId = GameEntry.Entity.GenerateSerialId();

                DBPlayer dbPlayer = new DBPlayer(playerId, userId);
                dbPlayer.EntityTypeId = m_SelectRoleTypeId;
                dbPlayer.Name = roleName;
                dbPlayer.Level = 1;
                dbPlayer.Insert();
                GameEntry.Database.AddDBRow<DBPlayer>(dbPlayer.Id, dbPlayer);

                DBUser dbUser = GameEntry.Database.GetDBRow<DBUser>(userId);
                dbUser.Player = dbPlayer.Id;

                m_ProcedureOwner.SetData<VarInt>(Constant.ProcedureData.PlayerId, dbUser.Player);
                m_ProcedureOwner.SetData<VarInt>(Constant.ProcedureData.NextSceneId, (int) SceneId.MainCity);
                ChangeState<ProcedureChangeScene>(m_ProcedureOwner);
            }
        }

    }

}
