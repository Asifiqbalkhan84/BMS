using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yuan.Model
{
    public class Slots
    {
        public int SlotID { get; set; }
        public int CompanyID { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public int NoofSlots { get; set; }
        public string DayofWeek { get; set; }
        public string Date { get; set; }
        public int ServiceID { get; set; }
        public int userid { get; set; }
        public bool Active { get; set; }
    }
}