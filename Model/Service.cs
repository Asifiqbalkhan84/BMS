using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yuan.Model
{
    public class Service
    {
        public int ServiceID { get; set; }
        public int CompanyID { get; set; }
        public int CatID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceImg { get; set; }
        public string ServiceDesc { get; set; }
        public int ServiceHRs { get; set; }
        public string Price { get; set; }
        public string SpecialOfferPrice { get; set; }
        public string SpOfferValidity { get; set; }
        public string OnlinePrice { get; set; }
        public bool Active { get; set; }
        public int UserId { get; set; }
        

    }
}