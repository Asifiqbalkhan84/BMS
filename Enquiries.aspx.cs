using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using Yuan.BL;
using System.Data;

namespace Yuan
{
    public partial class Enquiries : System.Web.UI.Page
    {
        string Message = string.Empty;
        public DataTable dt = new DataTable();
        string json;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetEnquryList()
        {
            Enquiries obj = new Enquiries();
            obj.GetEnquiry();
            obj.JsonCall(obj.dt);

            return obj.json;
        }

        public void GetEnquiry()
        {
            //int cid = Session[""]
            BLEnquiry ObjEnquiry = new BLEnquiry();
            dt = ObjEnquiry.GetEnquiryList(0);
        }

        [WebMethod]
        public static string DeleteEnquiry(int ID)
        {
            Enquiries obj = new Enquiries();
            obj.DeleteEnquiryById(ID);            
            return obj.json;
        }

        public void DeleteEnquiryById(int id)
        {
            //int uid = Convert.ToInt32(Session["UserId"]);
            BLEnquiry ObjEnquiry = new BLEnquiry();
            ObjEnquiry.deleteEnquiry(id);
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