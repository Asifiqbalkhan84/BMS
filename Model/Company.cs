using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yuan.Model
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string OutletName { get; set; }
        public string Location { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Area { get; set; }
        public string Landmark { get; set; }
        public int City { get; set; }
        public int Postcode { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNo { get; set; }
        public string SupportContact { get; set; }
        public string SupportContactNo { get; set; }
        public bool TaxApplicable { get; set; }
        public string GSTNo { get; set; }
        public string TaxRate { get; set; }
        public bool IsOnlyOffice { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int TotalSlot { get; set; }

    }
}