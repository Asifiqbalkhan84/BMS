using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yuan.Model
{
    public class Enquiry
    {
        public int EnquiryID { get; set; }
        public string EnquiryData { get; set; }
        public string Source { get; set; }
        public string SourceDetails { get; set; }
        public string NameofGuest { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string Location { get; set; }
        public string OtherLocationDetails { get; set; }
        public int InterestedIn { get; set; }
        public string Comments { get; set; }
        public int OutletID { get; set; }
        public bool IsRead { get; set; }
        public int StaffID { get; set; }

        public bool Active { get; set; }
        public int ByUser { get; set; }
    }
}