using System;
using GameFramework;

namespace GameMain
{
    public class DBUser : DBRowBase
    {
        public DBUser() : base(0,0)
        {
            
        }

        public DBUser(int id, int userId) : base(id, userId)
        {
 
        }

        public int Account  { get; set; } = 0;
        public int Password { get; set; } = 0;
        public int Player   { get; set; } = 0;
    }
}
