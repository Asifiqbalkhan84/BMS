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
    public partial class AddStaff : System.Web.UI.Page
    {
        StaffBL objStaff = null;
        string Message = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindOutlet();
                if (Request.QueryString["ID"] != null)
                {
                    hdnStaffId.Value = Request.QueryString["ID"].ToString();
                    LoadStaff();
                }
                
            }
        }

        #region Functions
        public void BindOutlet()
        {
            
            MasterDataBL ObjBL = new MasterDataBL();
            DataTable dt = ObjBL.GetMasterData("Outlet", 0);
            drpOutlet.DataSource = dt;
            drpOutlet.DataTextField = "OutletName";
            drpOutlet.DataValueField = "CompanyID";
            drpOutlet.DataBind();
            drpOutlet.Items.Insert(0, new ListItem("--Select--", ""));
        }

        void LoadStaff()
        {
            try
            {
                int id =Convert.ToInt32(hdnStaffId.Value);
                objStaff = new StaffBL();
                DataTable dt = objStaff.getStaffDetails(id);
                if (dt != null && dt.Rows.Count > 0)
                {
                    hdnStaffId.Value = dt.Rows[0]["StaffID"].ToString();
                    txtStaffName.Value = dt.Rows[0]["StaffName"].ToString();
                    ListItem lst = drpOutlet.Items.FindByValue(dt.Rows[0]["CompanyID"].ToString());
                    if (lst != null)
                    {
                        drpOutlet.SelectedValue = lst.Value;
                    }
                    txtContactPerson.Value = dt.Rows[0]["ContactPerson"].ToString();                    
                    txtDesignation.Value = dt.Rows[0]["Designation"].ToString();
                    drpDepartment.SelectedValue = dt.Rows[0]["Department"].ToString();
                    txtEmail.Value = dt.Rows[0]["EmailID"].ToString();
                    txtMobileNo.Value = dt.Rows[0]["MobileNo"].ToString();
                    txtLandline.Value = dt.Rows[0]["Landline"].ToString();
                    txtExtension.Value = dt.Rows[0]["Extension"].ToString();
                    txtJoiningDate.Value = dt.Rows[0]["JoiningDate"].ToString();
                    drpActive.SelectedValue = dt.Rows[0]["Active"].ToString();
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), "NotifyError('" + ex.Message + "');", true);
            }
            finally
            {
                objStaff = null;
            }

        }
        #endregion

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            try
            {
                objStaff = new StaffBL();
                Model.Staff obj = new Model.Staff();
                obj.StaffID = hdnStaffId.Value == "" ? 0 :Convert.ToInt32(GeneralFunctions.ValidateInt(hdnStaffId.Value));
                obj.StaffName = GeneralFunctions.ValidateString(txtStaffName.Value.Trim());
                obj.CompanyID = Convert.ToInt32(GeneralFunctions.ValidateString(drpOutlet.SelectedValue));
                obj.ContactPerson = GeneralFunctions.ValidateString(txtContactPerson.Value.Trim());
                obj.Department = GeneralFunctions.ValidateString(drpDepartment.SelectedValue);
                obj.Designation = GeneralFunctions.ValidateString(txtDesignation.Value.Trim());
                obj.EmailID = GeneralFunctions.ValidateString(txtEmail.Value.Trim());
                obj.Extension =GeneralFunctions.ValidateString(txtExtension.Value.Trim());
                obj.MobileNo = GeneralFunctions.ValidateString(txtMobileNo.Value.Trim());
                obj.Landline = GeneralFunctions.ValidateString(txtLandline.Value.Trim());
                obj.DateofJoining = GeneralFunctions.ValidateString(txtJoiningDate.Value);
                obj.Active = GeneralFunctions.ValidateBool(drpActive.SelectedValue.Trim());
                obj.UserId = Convert.ToInt32(GeneralFunctions._ChkSession("UserId"));
                string res = objStaff.InsertUpdateStaff(obj);
                if (res.ToLower() == "success")
                {
                    if (obj.StaffID >0)
                    {
                        Message = "Staff details updated successfully";
                    }
                    else
                        Message = "Staff details saved successfully";

                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NotifySuccess('" + Message + "');window.location ='Staff.aspx'", true);
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NotifyError('" + ex.Message + "');", true);
            }
            finally
            {
                objStaff = null;
            }
        }
    }
}