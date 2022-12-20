using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yuan.Model
{
    public class Permission
    {
        public int PermID { get; set; }
        public int ModuleID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public bool FullPerm { get; set; }
        public bool AddPerm { get; set; }
        public bool EditPerm { get; set; }
        public bool ViewPerm { get; set; }
        public bool DeletePerm { get; set; }
        public bool ExportPerm { get; set; }
    }
}