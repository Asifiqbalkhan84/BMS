using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yuan.Model
{
    public class Guest
    {

        public int GuestID { get; set; }
        public string Title { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string MobileNo { get; set; }
        public string LandlineNo { get; set; }
        public string EmailID { get; set; }
        public string AlternateContactNo { get; set; }
        public string AddressLine1 { get; set; }        
        public string AddressLine2 { get; set; }
        public string Area { get; set; }
        public string Landmark { get; set; }
        public int City { get; set; }
        public int Postcode { get; set; }
        public bool IsActive { get; set; }
        public bool IsBlacklisted { get; set; }
        public string SourceDetails { get; set; }
        public string Source { get; set; }
        public string MemberNo { get; set; }
        public string ProfilePhoto { get; set; }
        public int UserId { get; set; }
        
    }
}