using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yuan.Model
{
    public class UserAndRole
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int LevelID { get; set; }
        public string LevelName { get; set; }
        public string AccountType { get; set; }        
        public string LastloggedIn { get; set; }        
        public int StaffID { get; set; }
        public string UType { get; set; }
        public string UName { get; set; }
        public string Pass { get; set; }       
        public int CreatedBy{ get; set; }
        public int UpdatedBy { get; set; }
        public bool Active { get; set; }
    }
}