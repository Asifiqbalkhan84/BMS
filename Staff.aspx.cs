using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Yuan.BL;
using System.Data;
using System.Web.Script.Serialization;

namespace Yuan
{
    public partial class Staff : System.Web.UI.Page
    {
        string Message = string.Empty;
        public DataTable dt = new DataTable();
        string json;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetStaffList()
        {
            Staff obj = new Staff();
            obj.GetStaff();
            obj.JsonCall(obj.dt);

            return obj.json;
        }

        public void GetStaff()
        {
            //int cid = Session[""]
            StaffBL ObjStaff = new StaffBL();
            dt = ObjStaff.getStaffDetails();

        }

        [WebMethod]
        public static string DeleteStaff(int ID)
        {
            Staff obj = new Staff();
            obj.DeleteStaffById(ID);
            return obj.json;
        }

        public void DeleteStaffById(int id)
        {
            StaffBL ObjStaff = new StaffBL();
            ObjStaff.DeleteStaffbyID(id);
        }
        public void JsonCall(DataTable dt)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            json = js.Serialize(rows);
        }
    }
}