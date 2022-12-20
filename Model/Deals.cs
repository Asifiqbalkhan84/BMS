using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yuan.Model
{
    public class Deals
    {
        public int DealID { get; set; }
        public int CompanyID { get; set; }
        public string DealName { get; set; }
        public string Description { get; set; }
        public string Validity { get; set; }
        public string DiscountPer { get; set; }
        public string DiscountFlat { get; set; }
        public string DiscountVoucher { get; set; }
        public bool IsMemberOnly { get; set; }
        public string MemberType { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string DealType { get; set; }
        public int DealDetailID { get; set; }
        public string ServiceID { get; set; }
        public bool IsFree { get; set; }
        public string Price { get; set; }
        public bool Active { get; set; }
        public string Remark { get; set; }
    }
}