using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yuan.BL;
using System.Data;
using System.Web.Services;
using Yuan.DA;
using System.Data.SqlClient;

namespace Yuan
{
    public partial class AddSlot : System.Web.UI.Page
    {
        AppointmentSlotBL objSlot = null;
        string Message = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindOutlet();
                BindServices();
                if (Request.QueryString["ID"] != null)
                {
                    hdnSlot.Value = Request.QueryString["ID"].ToString();
                    LoadSlot();
                }
            }
        }


        #region Function
        void BindOutlet()
        {
            try
            {
                MasterDataBL ObjBL = new MasterDataBL();
                DataTable dt = ObjBL.GetMasterData("Outlet", 0);
                drpOutlet.DataSource = dt;
                drpOutlet.DataTextField = "OutletName";
                drpOutlet.DataValueField = "CompanyID";
                drpOutlet.DataBind();
                drpOutlet.Items.Insert(0, new ListItem("--Select--", ""));
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "msg", "NotifyError('" + Message + "');", true);
            }
        }

        void BindServices()
        {
            try
            {
                MasterDataBL ObjBL = new MasterDataBL();
                DataTable dt = ObjBL.GetMasterData("Service", 0);
                drpService.DataSource = dt;
                drpService.DataTextField = "ServiceName";
                drpService.DataValueField = "ServiceID";
                drpService.DataBind();
                drpService.Items.Insert(0, new ListItem("--Select--", ""));
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "msg", "NotifyError('" + Message + "');", true);
            }
        }
        void LoadSlot()
        {
            try
            {
                objSlot = new AppointmentSlotBL();
                int Id = hdnSlot.Value == "" ? 0 : GeneralFunctions.ValidateInt(hdnSlot.Value);
                DataTable dt = objSlot.getSlotDetails(Id);
                drpOutlet.SelectedValue = dt.Rows[0]["CompanyID"].ToString();
                drpService.SelectedValue = dt.Rows[0]["ServiceID"].ToString();
                txtFromTime.Value = dt.Rows[0]["SlotFromTime"].ToString();
                txtToTime.Value = dt.Rows[0]["SlotToTime"].ToString();
                txtDate.Value = dt.Rows[0]["SlotDate"].ToString();
                drpDayOfWeek.SelectedValue = dt.Rows[0]["DayofWeek"].ToString();
                drpSlot.SelectedValue = dt.Rows[0]["NoofSlots"].ToString();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "msg", "NotifyError('" + Message + "');", true);
            }
        }
        #endregion
        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            try
            {
                objSlot = new AppointmentSlotBL();
                Model.Slots Slot = new Model.Slots();

                Slot.SlotID = hdnSlot.Value != "" ? GeneralFunctions.ValidateInt(hdnSlot.Value) : 0;
                Slot.CompanyID = drpOutlet.SelectedValue != "" ? GeneralFunctions.ValidateInt(drpOutlet.SelectedValue.ToString()) : 0;
                Slot.ServiceID = drpService.SelectedValue != "" ? GeneralFunctions.ValidateInt(drpService.SelectedValue.ToString()) : 0;
                Slot.FromTime = GeneralFunctions.ValidateString(txtFromTime.Value);
                Slot.ToTime = GeneralFunctions.ValidateString(txtToTime.Value);
                Slot.NoofSlots = GeneralFunctions.ValidateInt(drpSlot.SelectedValue);
                Slot.DayofWeek = GeneralFunctions.ValidateString(drpDayOfWeek.SelectedValue);
                Slot.Date = GeneralFunctions.ValidateString(txtDate.Value);
                Slot.userid = GeneralFunctions.ValidateInt(Session["UserId"]);
                Slot.Active = GeneralFunctions.ValidateBool(drpActive.SelectedValue);
                string sql = "select COUNT(NoofSlots)SlotAlloted from AppointmentSlot where (CompanyID = @CompanyID or isnull(CompanyID,0) = 0) " +
                             "and convert(varchar(5), SlotFromTime, 108) = convert(varchar(5),@FromTime, 108) and convert(varchar(5),SlotToTime,108)= convert(varchar(5), @ToTime, 108) " +
                             "and[DayofWeek] in(0, @DayOfWeek) and isnull(IsActive,1) = 1 and ISNULL(IsDeleted,0) = 0 and isnull(SlotId,0) <> @SlotId ";

                SqlParameter[] param =
                    {
                        new SqlParameter("@SlotId",hdnSlot.Value),
                        new SqlParameter("@CompanyID",Slot.CompanyID),
                        new SqlParameter("@FromTime",Slot.FromTime),
                        new SqlParameter("@ToTime",Slot.ToTime),
                        new SqlParameter("@DayOfWeek",Slot.DayofWeek)
                    };
                SqlDataReader dr = DataAccessor.ExecuteQueryDataReader(sql, param);
                string sql1 = "select isnull(Slots,0)TotalSlot from Company where CompanyID =@CompanyID";
                SqlParameter[] param1 =
                {
                    new SqlParameter("@CompanyID",Slot.CompanyID)
                };
                SqlDataReader dr1 = DataAccessor.ExecuteQueryDataReader(sql1, param1);
                int SlotAlloted = 0;
                int TotSlot = 0;
                int AvailbleSlot = 0;
                while (dr.Read())
                {
                    SlotAlloted = Convert.ToInt32(dr["SlotAlloted"]);
                }
                while (dr1.Read())
                {
                    TotSlot = Convert.ToInt32(dr1["TotalSlot"]);
                }
                if (Slot.NoofSlots > TotSlot)
                {
                    Message = "Maximum " + TotSlot + " are allowed for " + drpOutlet.SelectedItem.Text;
                    goto Error;
                }
                //AvailbleSlot = TotSlot - SlotAlloted;
                if (TotSlot - SlotAlloted < Slot.NoofSlots)
                {
                    Message = "Only " + AvailbleSlot + " are available for " + drpOutlet.SelectedItem.Text;
                    goto Error;
                }
                string res = objSlot.InsertUpdateSlot(Slot);
                if (res == "Success")
                {
                    Message = "Slot saved successfully";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NotifySuccess('" + Message + "');window.location ='Slots.aspx';", true);
                }
                else
                {
                    Message = "Slot Not saved";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NotifyError('" + Message + "');", true);
                }


            }
            catch (Exception ex)
            {
                Message = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NotifyError('" + Message + "');", true);
            }
        Error:
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NotifyError('" + Message + "');", true);
            }

        }
    }
}