using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yuan.Model
{
    public class Appointments
    {
        public int AppointID { get; set; }
        public int OrderID { get; set; }
        public int GuestID { get; set; }
        public string GuestName { get; set; }
        public string GuestEmail { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int SlotID { get; set; }
        public int ServiceID { get; set; }
        public int StaffID { get; set; }
        public int UserID { get; set; }
        public string ServiceName { get; set; }
        public string DateofAppoint { get; set; }
        public string TimeofAppoint { get; set; }
        public string DayofAppoint { get; set; }
        public string Source { get; set; }
    }
}