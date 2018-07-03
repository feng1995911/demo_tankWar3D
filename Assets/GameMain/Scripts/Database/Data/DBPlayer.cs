using System;
using GameFramework;

namespace GameMain
{
    [DatabaseRow]
    public class DBPlayer : DBRowBase
    {
        public DBPlayer(int id, int userId) : base(id,userId)
        {

        }

        public int EntityTypeId { get; set; } = 0;
        public string Name      { get; set; } = string.Empty;
        public int Level        { get; set; } = 0;
        public int Exp          { get; set; } = 0;
        public int VipLevel     { get; set; } = 0;
        public int MountId      { get; set; } = 0;
        public int RelicId      { get; set; } = 0;
        public int PetId        { get; set; } = 0;
        public int Partner1Id   { get; set; } = 0;
        public int Partner2Id   { get; set; } = 0;
        public int Partner3Id   { get; set; } = 0;
        public int TalentMask   { get; set; } = 0;
    }
}
