using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Yuan.BL;
using Yuan.DA;
using System.Data;
using System.Web.Script.Serialization;

namespace Yuan
{
    public partial class Orders : System.Web.UI.Page
    {
        string Message = string.Empty;
        public DataTable dt = new DataTable();
        string json;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindStaff();
            }
        }
        [WebMethod]
        public static string GetOrderList()
        {
            Orders obj = new Orders();
            obj.GetOrder();
            obj.JsonCall(obj.dt);

            return obj.json;
        }

        public void GetOrder()
        {
            //int cid = Session[""]
            BLOrders ObjBL = new BLOrders();
            dt = ObjBL.getOrders(0);

        }

        [WebMethod]
        public static string GetOrderInfo(string OrderID)
        {
            Orders obj = new Orders();
            obj.BindOrderInfo(OrderID);
            obj.JsonCall(obj.dt);
            return obj.json;
        }

        public void BindOrderInfo(string OrderID)
        {
            BLOrders ObjBL = new BLOrders();
            try
            {
                dt = ObjBL.GetOrderInfo(GeneralFunctions.ValidateInt(OrderID));
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        [WebMethod]
        public static string GetOrderDetails(string OrderID)
        {
            Orders obj = new Orders();
            obj.BindOrderDetails(OrderID);
            obj.JsonCall(obj.dt);
            return obj.json;
        }

        public void BindOrderDetails(string OrderID)
        {
            BLOrders ObjBL = new BLOrders();
            try
            {
                dt = ObjBL.GetOrderDetails(GeneralFunctions.ValidateInt(OrderID));
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        [WebMethod]
        public static string GetOrderPayments(string OrderID)
        {
            Orders obj = new Orders();
            obj.BindOrderPayments(OrderID);
            obj.JsonCall(obj.dt);
            return obj.json;
        }

        public void BindOrderPayments(string OrderID)
        {
            BLOrders ObjBL = new BLOrders();
            try
            {
                dt = ObjBL.GetOrderPayments(GeneralFunctions.ValidateInt(OrderID));
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }


        [WebMethod]
        public string DeleteOrder(int ID)
        {
            Orders obj = new Orders();
            obj.DeleteOrderById(ID);
            return obj.json;
        }

        public void DeleteOrderById(int id)
        {
            BLOrders ObjBL = new BLOrders();
            json = ObjBL.DeleteOrder(id);
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

        protected void btnPay_Click(object sender, EventArgs e)
        {
            BLOrders ObjBL = new BLOrders();
            try
            {
                ObjBL.AddOrderPayments(GeneralFunctions.ValidateInt(hdnOrderID.Value), GeneralFunctions._parseStringToDouble(txtAmount.Value), ddlModeofPay.SelectedValue, GeneralFunctions.ValidateInt(Session["UserID"]));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "msg", "NotifyError('" + ex.Message + "');", true);
            }
        }

        private void BindStaff()
        {
            MasterDataBL ObjBL = new MasterDataBL();
            DataTable dt = ObjBL.GetMasterData("GetServiceStaff", 0);
            ddlStaff.DataSource = dt;
            ddlStaff.DataTextField = "StaffName";
            ddlStaff.DataValueField = "StaffID";
            ddlStaff.DataBind();
            ddlStaff.Items.Insert(0, new ListItem("--Select--", ""));
            ddlStaff.SelectedIndex = 1;
        }
    }
}