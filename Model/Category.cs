using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yuan.Model
{
    public class Category
    {
        public int CatID { get; set; }
        public string CatName { get; set; }
        public int ParentID { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public bool Active { get; set; }


    }
}