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
    public partial class Deals : System.Web.UI.Page
    {
        string Message = string.Empty;
        public DataTable dt = new DataTable();
        public DataTable dtView = new DataTable();
        string json;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetDealList()
        {
            Deals obj = new Deals();
            obj.GetDeals();
            obj.JsonCall(obj.dt);

            return obj.json;
        }

        public void GetDeals()
        {
            //int cid = Session[""]
            DealsBL ObjDeal = new DealsBL();
            dt = ObjDeal.GetDealsData(0);

        }

        [WebMethod]
        public static string DeleteDeal(int ID)
        {
            Deals obj = new Deals();
            obj.DeleteDealById(ID);
            return obj.json;
        }

        [WebMethod]
        public static string ViewDeal(int ID)
        {
            Deals obj = new Deals();
            obj.ViewDealDetails(ID);
            obj.JsonCall(obj.dtView);
            return obj.json;
        }
        public void ViewDealDetails(int id)
        {
            DealsBL objDealBl = new DealsBL();
            //Deals objDeal = new Deals();
            dtView = objDealBl.GetDealsInfo(id);
        }
        public void GetDealById(int id)
        {
            DealsBL objDealBl = new DealsBL();
            Deals obj = new Deals();
            obj.dt = objDealBl.GetDealsData(id);
        }
        public void DeleteDealById(int id)
        {
            DealsBL ObjDeal = new DealsBL();
            ObjDeal.DeleteDeals(id);
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