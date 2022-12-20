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
    public partial class CompanyDet : System.Web.UI.Page
    {
        string Message = string.Empty;
        public DataTable dt = new DataTable();
        string json;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string GetCompanyList()
        {
            CompanyDet obj = new CompanyDet();
            obj.GetCompany();
            obj.JsonCall(obj.dt);
            
            return obj.json;
        }

        public void GetCompany()
        {
            //int cid = Session[""]
            CompanyBL objCompany = new CompanyBL();
            dt = objCompany.GetCompanyData(0);
            
        }

        [WebMethod]
        public static string DeleteCompany(int ID)
        {
            CompanyDet obj = new CompanyDet();
            obj.DeleteCompanyById(ID);
            return obj.json;
        }

        public void DeleteCompanyById(int id)
        {
            CompanyBL objCmpy = new CompanyBL();
            string str = "";
            objCmpy.DeleteCompany(ref str, id);
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