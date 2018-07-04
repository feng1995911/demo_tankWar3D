using GameFramework.Event;

namespace GameMain
{
    /// <summary>
    /// 更换装备事件
    /// </summary>
    public class ChangeEquipEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(ChangeEquipEventArgs).GetHashCode();

        public override int Id => EventId;

        public int EquipPos
        {
            get;
            private set;
        }

        public override void Clear()
        {
            EquipPos = 0;
        }

        public ChangeEquipEventArgs Fill(int equipPos)
        {
            this.EquipPos = equipPos;
            return this;
        }
    }
}
