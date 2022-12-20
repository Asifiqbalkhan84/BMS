using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yuan.Model
{
    public class Staff
    {
        public int StaffID { get; set; }        
        public string StaffName { get; set; }
        public int CompanyID { get; set; }
        public string ContactPerson { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Landline { get; set; }
        public string Extension { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string DateofJoining { get; set; }
        public bool Active { get; set; }
        public int UserId { get; set; }

    }
}