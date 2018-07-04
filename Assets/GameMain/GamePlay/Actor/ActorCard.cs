namespace GameMain
{
    /// <summary>
    /// 行动者名片
    /// </summary>
    public class ActorCard
    {
        public ActorRaceType Race { get; protected set; }
        public BattleCampType Camp { get; protected set; }
        public ActorSexType Sex { get; protected set; }
        public string Title { get; protected set; } 
        public string Name { get; protected set; }
        public int Group { get; protected set; }
        public int Level { get; protected set; }
        public int MountID { get; protected set; }
        public int[] Partners { get; protected set; } = { 0, 0, 0 };
        public ActorBase Owner { get; protected set; }

        private readonly DBPlayer m_Role = null;
        private readonly DRActorEntity m_Data = null;

        public ActorCard(ActorBase pOwner)
        {
            Owner = pOwner;
            this.SetName();
            this.SetLevel();
            if (Owner is ActorPlayer)
            {
                int playerId = GameEntry.Database.GetPlayerId();
                m_Role = GameEntry.Database.GetDBRow<DBPlayer>(playerId);

                this.SetPartnerByPos(1, m_Role.Partner1Id);
                this.SetPartnerByPos(2, m_Role.Partner2Id);
                this.SetPartnerByPos(3, m_Role.Partner3Id);
            }

            m_Data = GameEntry.DataTable.GetDataTable<DRActorEntity>().GetDataRow(Owner.Id);
        }

        public void SetName(string pName = null)
        {
            if (!string.IsNullOrEmpty(pName))
            {
                this.Name = pName;
                return;
            }

            if (m_Data == null)
            {
                return;
            }

            if (Owner is ActorPlayer)
            {
                this.Name = (m_Role == null) ? string.Empty : m_Role.Name;
            }
            else
            {
                this.Name = m_Data.Name;
            }
        }

        public void SetLevel(int pLevel = -1)
        {
            if (m_Data == null)
            {
                return;
            }

            if (pLevel > 0)
            {
                this.Level = pLevel;
                return;
            }
            if (Owner is ActorPlayer)
            {
                this.Level = m_Role?.Level ?? 1;
            }
            else
            {
                this.Level = m_Data.Level;
            }
        }

        public void SetMount(int pMountID)
        {
            MountID = pMountID;
        }

        public void SetPartnerByPos(int pos, int id)
        {
            Partners[pos - 1] = id;
        }

        public void SetTitle(string pTitle)
        {
            Title = pTitle;
        }

        public int GetMountID()
        {
            if (Owner is ActorPlayer)
            {
                MountID = m_Role.MountId;
            }
            else
            {
                MountID = UnityEngine.Random.Range(100001, 100012);
            }
            return MountID;
        }
    }
}
