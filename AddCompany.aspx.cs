using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yuan.BL;
using Yuan.Model;
using System.Data;
using Yuan.DA;

namespace Yuan
{
    public partial class AddCompany : System.Web.UI.Page
    {
        CompanyBL objCompanyBl = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCity();
                if (Request.QueryString["ID"] != null)
                {
                    hdnCompanyId.Value = Request.QueryString["ID"].ToString();
                    loadCompany(Convert.ToInt32(hdnCompanyId.Value));
                }
            }
        }

        #region Function
        void loadCompany(int CompanyId)
        {
            objCompanyBl = new CompanyBL();
            DataTable dt = objCompanyBl.GetCompanyData(CompanyId);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtComapanyName.Value = dt.Rows[0]["CompanyName"].ToString();
                txtOutletName.Value = dt.Rows[0]["OutletName"].ToString();
                txtLocation.Value = dt.Rows[0]["Location"].ToString();
                txtAdd.Value = dt.Rows[0]["AddressLine1"].ToString();
                txtAdd2.Value = dt.Rows[0]["AddressLine2"].ToString();
                txtArea.Value = dt.Rows[0]["Area"].ToString();
                txtLandmark.Value = dt.Rows[0]["Landmark"].ToString();
                drpCity.SelectedValue = dt.Rows[0]["City"].ToString();
                txtPincode.Value = dt.Rows[0]["Postcode"].ToString();
                txtContactPerson.Value = dt.Rows[0]["ContactPerson"].ToString();
                txtContactNo.Value = dt.Rows[0]["ContactNo"].ToString();
                txtSupContactPerson.Value = dt.Rows[0]["SupportContact"].ToString();
                txtSupContactNo.Value = dt.Rows[0]["SupportContactNo"].ToString();
                txtTaxApplicable.Value = dt.Rows[0]["TaxApplicable"].ToString();
                txtGSTNo.Value = dt.Rows[0]["GSTNo"].ToString();
                txtTaxRate.Value = dt.Rows[0]["TaxRate"].ToString();
                drpOnlyOffice.SelectedValue = dt.Rows[0]["IsOnlyOffice"].ToString() == "True" ? "1" : "0";
            }
        }

        public void BindCity()
        {
            MasterDataBL ObjBL = new MasterDataBL();
            DataTable dt = ObjBL.GetMasterData("GetCity", 0);
            drpCity.DataSource = dt;
            drpCity.DataTextField = "CityName";
            drpCity.DataValueField = "CityID";
            drpCity.DataBind();
            drpCity.Items.Insert(0, new ListItem("--Select--", ""));
            //drpChild.Items.FindByText("Mumbai").Selected = true;

        }
        void fnClear(ControlCollection ctrls, string type)
        {
            if (type == "")
            {
                foreach (Control ctrl in ctrls)
                {
                    if (ctrl is TextBox)
                        ((TextBox)ctrl).Text = string.Empty;
                    else if (ctrl is DropDownList)
                        ((DropDownList)ctrl).ClearSelection();
                    else if (ctrl is HiddenField)
                        ((HiddenField)ctrl).Value = string.Empty;

                    fnClear(ctrl.Controls, "");
                }
            }
        }

        #endregion
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {

                    Model.Company obj = new Company();
                    obj.CompanyID = hdnCompanyId.Value != "" ? GeneralFunctions.ValidateInt(hdnCompanyId.Value) : 0;
                    obj.CompanyName = GeneralFunctions.ValidateString(txtComapanyName.Value.Trim());
                    obj.OutletName = GeneralFunctions.ValidateString(txtOutletName.Value.Trim());
                    obj.Location = GeneralFunctions.ValidateString(txtLocation.Value.Trim());
                    obj.AddressLine1 = GeneralFunctions.ValidateString(txtAdd.Value.Trim());
                    obj.AddressLine2 = GeneralFunctions.ValidateString(txtAdd2.Value.Trim());
                    obj.Area = GeneralFunctions.ValidateString(txtArea.Value.Trim());
                    obj.Landmark = GeneralFunctions.ValidateString(txtLandmark.Value.Trim());
                    obj.City = GeneralFunctions.ValidateInt(drpCity.SelectedValue);
                    obj.Postcode = GeneralFunctions.ValidateInt(txtPincode.Value);
                    obj.ContactPerson = GeneralFunctions.ValidateString(txtContactPerson.Value.Trim());
                    obj.ContactNo = GeneralFunctions.ValidateString(txtContactNo.Value.Trim());
                    obj.SupportContact = GeneralFunctions.ValidateString(txtSupContactPerson.Value.Trim());
                    obj.SupportContactNo = GeneralFunctions.ValidateString(txtSupContactNo.Value);
                    obj.TotalSlot = GeneralFunctions.ValidateInt(txtSlot.Value);
                    obj.TaxApplicable = GeneralFunctions.ValidateBool(txtTaxApplicable.Checked);
                    obj.GSTNo = GeneralFunctions.ValidateString(txtGSTNo.Value.Trim());
                    obj.TaxRate = txtTaxRate.Value.Trim() == "" ? "0" : GeneralFunctions.ValidateString(txtTaxRate.Value.Trim());
                    obj.IsOnlyOffice = drpOnlyOffice.SelectedValue == "0" ? false : true;
                    obj.CreatedBy = GeneralFunctions.ValidateInt(Session["UserId"].ToString());
                    obj.UpdatedBy = GeneralFunctions.ValidateInt(Session["UserId"].ToString());

                    objCompanyBl = new CompanyBL();
                    string res = objCompanyBl.InsertUpdateCompany(obj);

                    if (res == "Success")
                    {
                        //Message = err;
                        ClientScript.RegisterStartupScript(GetType(), "msg", "NotifySuccess('Company details saved');window.location.href='CompanyDet.aspx';", true);
                        fnClear(this.Page.Controls, "");
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "NotifySuccess('Company details not saved');" + res, true);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "NotifySuccess('" + ex.Message + "');", true);
                    fnClear(this.Page.Controls, "");
                }
            }
        }
    }
}