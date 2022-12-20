using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yuan.BL;
using Yuan.DA;

namespace Yuan
{
    public partial class ViewConsumption : System.Web.UI.Page
    {
        string Message = string.Empty;
        public DataTable dt = new DataTable();
        string json;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UserID"] as string))
            {
                if (!IsPostBack)
                {
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }

        }

        [WebMethod]
        public static string GetConsumption()
        {
            ViewConsumption obj = new ViewConsumption();
            obj.BindConsumption();
            obj.JsonCall(obj.dt);
            return obj.json;
        }

        public void BindConsumption()
        {
            BLConsumption ObjBL = new BLConsumption();
            try
            {
                dt = ObjBL.SelectConsumption(GeneralFunctions.ValidateInt(Session["CompanyID"]));
               
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
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