using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yuan.BL;
using Yuan.Model;
using System.Data;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.IO;
using Yuan.DA;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json;

namespace Yuan
{
    public partial class TestDeals : System.Web.UI.Page
    {
        string json = "";
        DataTable dtData = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        [WebMethod]
        public static string FillDrpService()
        {
            TestDeals objDeals = new TestDeals();
            objDeals.FillServiceDropdown();
            objDeals.JsonCall(objDeals.dtData);

            return objDeals.json;
        }

        [WebMethod]
        public static string FillServiceData(string data)
        {
            TestDeals objdeal = new TestDeals();
            objdeal.GetServiceDataById(Convert.ToInt32(data));
            objdeal.JsonCall(objdeal.dtData);

            return objdeal.json;
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

        public DataTable GetServiceDataById(int Id)
        {
            try
            {
                DealsBL ObjDeals = new DealsBL();
                dtData = ObjDeals.GetServiceData(Id);

            }
            catch (Exception ex)
            {
                dtData = null;
                //Message = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "NotifyError('" + ex.Message + "')", true);
            }
            return dtData;
        }
        public DataTable FillServiceDropdown()
        {
            try
            {
                MasterDataBL objMasterData = new MasterDataBL();
                dtData = new DataTable();
                dtData = objMasterData.GetMasterData("Service", 0);
                //dtData.Tables.Add(dt);
            }
            catch (Exception ex)
            {
                dtData = null;
            }
            return dtData;
        }

        protected void submit(object sender,EventArgs e)
        {
            string ServiceJSON = Request.Form["hdnService"];
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(ServiceJSON);
        }
        //protected void btnSubmit_ServerClick(object sender, EventArgs e)
        //{
        //    string ServiceJSON = Request.Form["hdnService"];
        //    DataTable dt = JsonConvert.DeserializeObject<DataTable>(ServiceJSON);
        //}

        protected void drpOutlet2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void btnSubmit1_Click(object sender, EventArgs e)
        //{
        //    string ServiceJSON = Request.Form["hdnService"];
        //    DataTable dt = JsonConvert.DeserializeObject<DataTable>(ServiceJSON);
        //}

        protected void btnSubmit1_Click1(object sender, EventArgs e)
        {
            string ServiceJSON = Request.Form["hdnService"];
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(ServiceJSON);
        }
    }
}