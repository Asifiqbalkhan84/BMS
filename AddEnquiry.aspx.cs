using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yuan.BL;
using Yuan.DA;
using Yuan.Model;

namespace Yuan
{
    public partial class AddEnquiry : System.Web.UI.Page
    {
        string Message = "";
        BLEnquiry objBl = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                FillOutlet();
                getStaff();
                FillServices();
                if (Request.QueryString["ID"] != null)
                {
                    hdnEnquiry.Value = Request.QueryString["ID"].ToString();
                    fnLoadEnquiry();
                }
            }
        }

        #region Functions
        void fnLoadEnquiry()
        {
            try
            {
                ListItem lst = null;
                int EnqID = Convert.ToInt32(hdnEnquiry.Value);
                objBl = new BLEnquiry();
                DataTable dt = objBl.GetEnquiryList(EnqID);
                if (dt.Rows.Count > 0)
                {
                    txtEnquiry.Value = dt.Rows[0]["Enquiry"].ToString();
                    lst = new ListItem();
                    lst = drpSource.Items.FindByValue(dt.Rows[0]["Source"].ToString());
                    if (lst != null)
                    {
                        drpSource.SelectedItem.Text = dt.Rows[0]["Source"].ToString();
                    }
                    txtSourceDet.Value = dt.Rows[0]["SourceDetails"].ToString();
                    txtGuest.Value = dt.Rows[0]["NameofGuest"].ToString();
                    txtMobile.Value = dt.Rows[0]["MobileNo"].ToString();
                    txtEmail.Value = dt.Rows[0]["EmailID"].ToString();
                    txtLocation.Value = dt.Rows[0]["Location"].ToString();
                    txtLocationDet.Value = dt.Rows[0]["OtherLocationDetails"].ToString();
                    lst = new ListItem();
                    lst = drpServices.Items.FindByValue(dt.Rows[0]["InterestedIn"].ToString());
                    if (lst != null)
                    {
                        drpServices.SelectedValue = dt.Rows[0]["InterestedIn"].ToString();
                    }

                    txtcomment.Value = dt.Rows[0]["Comments"].ToString();
                    lst = new ListItem();
                    lst = drpStaff.Items.FindByValue(dt.Rows[0]["StaffID"].ToString());
                    if (lst != null)
                    {
                        drpStaff.SelectedValue = dt.Rows[0]["StaffID"].ToString();
                    }
                    lst = new ListItem();
                    lst = drpOutlet.Items.FindByValue(dt.Rows[0]["OutletID"].ToString());
                    if (lst != null)
                    {
                        drpOutlet.SelectedValue = dt.Rows[0]["OutletID"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        void getStaff()
        {
            MasterDataBL objMaster = new MasterDataBL();
            DataTable dt = objMaster.GetMasterData("GetStaff", 0);
            drpStaff.Items.Clear();
            drpStaff.DataSource = dt;
            drpStaff.DataTextField = "StaffName";
            drpStaff.DataValueField = "StaffID";
            drpStaff.DataBind();
            drpStaff.Items.Insert(0, new ListItem("--Select--", ""));
        }
        public void FillOutlet()
        {
            MasterDataBL objMaster = new MasterDataBL();
            DataTable dt = objMaster.GetMasterData("Outlet", 0);
            drpOutlet.DataSource = dt;
            drpOutlet.DataTextField = "OutletName";
            drpOutlet.DataValueField = "CompanyId";
            drpOutlet.DataBind();
            drpOutlet.Items.Insert(0, new ListItem("All", "0"));

        }
        public void FillServices()
        {
            MasterDataBL objMaster = new MasterDataBL();
            DataTable dt = objMaster.GetMasterData("Service", 0);
            drpServices.DataSource = dt;
            drpServices.DataTextField = "ServiceName";
            drpServices.DataValueField = "ServiceID";
            drpServices.DataBind();
            drpServices.Items.Insert(0, new ListItem("--Select--", "0"));

        }
        #endregion
        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            string retVal = "";
            try
            {
                if (Page.IsValid)
                {
                    Enquiry objEnq = new Enquiry();
                    objBl = new BLEnquiry();
                    objEnq.EnquiryID = GeneralFunctions.ValidateInt(hdnEnquiry.Value);
                    objEnq.EnquiryData = GeneralFunctions.ValidateString(txtEnquiry.Value);
                    objEnq.Source = GeneralFunctions.ValidateString(drpSource.SelectedItem.Text);
                    objEnq.SourceDetails = GeneralFunctions.ValidateString(txtSourceDet.Value);
                    objEnq.NameofGuest = GeneralFunctions.ValidateString(txtGuest.Value);
                    objEnq.MobileNo = GeneralFunctions.ValidateString(txtMobile.Value);
                    objEnq.EmailID = GeneralFunctions.ValidateString(txtEmail.Value);
                    objEnq.Location = GeneralFunctions.ValidateString(txtLocation.Value);
                    objEnq.OtherLocationDetails = GeneralFunctions.ValidateString(txtLocationDet.Value);
                    objEnq.InterestedIn = drpServices.SelectedValue != "" ? GeneralFunctions.ValidateInt(drpServices.SelectedValue) : 0;
                    objEnq.OutletID = GeneralFunctions.ValidateInt(drpOutlet.SelectedValue);
                    objEnq.StaffID = drpStaff.SelectedValue != "" ? GeneralFunctions.ValidateInt(drpStaff.SelectedValue) : 0;
                    objEnq.Comments = GeneralFunctions.ValidateString(txtcomment.Value);
                    objEnq.ByUser = Convert.ToInt32(Session["UserId"]);

                    retVal = objBl.InsertUpdateEnquiry(objEnq);

                    if (retVal == "success")
                    {
                        if (hdnEnquiry.Value == "0")
                        {
                            Message = "Enquiry created successfully";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NotifySuccess('" + Message + "');window.location='Enquiries.aspx';", true);
                        }
                        else
                        {
                            Message = "Enquiry updated successfully";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NotifySuccess('" + Message + "');window.location='Enquiries.aspx';", true);
                        }
                    }
                    else
                    {
                        Message = retVal;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NotifyError('" + Message + "');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NotifyError('" + Message + "');", true);
            }
        }
    }
}