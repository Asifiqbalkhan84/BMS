using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yuan.BL;
using Yuan.DA;
using Yuan.Model;
using System.Data;

namespace Yuan
{
    public partial class AddCategory : System.Web.UI.Page
    {
        string Message = "";
        BLCategory objCategory = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategory();
                if (Request.QueryString["ID"] != null)
                {
                    hdnCategoryId.Value = Request.QueryString["ID"].ToString();
                    LoadCategory(Convert.ToInt32(hdnCategoryId.Value));
                }
            }
        }

        #region Functions
        public void BindCategory()
        {
            objCategory = new BLCategory();
            DataTable dt = objCategory.GetCategoryData(0);
            drpParent.DataSource = dt;
            drpParent.DataTextField = "CatName";
            drpParent.DataValueField = "CatID";
            drpParent.DataBind();
            drpParent.Items.Insert(0, new ListItem("--Select--", ""));
        }

        void LoadCategory(int id)
        {
            try
            {
                DataTable dt = objCategory.GetCategoryData(id);
                if (dt != null && dt.Rows.Count > 0)
                {
                    hdnCategoryId.Value = dt.Rows[0]["CatID"].ToString();
                    txtCategory.Value = dt.Rows[0]["CatName"].ToString();
                    ListItem lst = drpParent.Items.FindByValue(dt.Rows[0]["ParentID"].ToString());
                    if (lst != null)
                    {
                        drpParent.SelectedValue = lst.Value;
                    }

                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "NotifyError('" + ex.Message + "');", true);
            }
        }
        #endregion
        protected void btnsubmit_ServerClick(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {

                    Model.Category obj = new Model.Category();
                    obj.CatID = hdnCategoryId.Value != "" ? GeneralFunctions.ValidateInt(hdnCategoryId.Value) : 0;
                    obj.CatName = GeneralFunctions.ValidateString(txtCategory.Value.Trim());
                    obj.ParentID = drpParent.SelectedIndex > 0 ? GeneralFunctions.ValidateInt(drpParent.SelectedValue) : 0;
                    obj.Active = drpActive.SelectedValue == "1" ? true : false;
                    obj.CreatedBy = Convert.ToInt32(Session["Uid"]);
                    objCategory = new BLCategory();
                    string res = objCategory.InsertUpdateCategory(obj);

                    if (res == "Success")
                    {
                        Message = "Category details saved";
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "msg", "NotifySuccess('" + Message + "') ;window.location.href='Category.aspx';", true);
                        //fnClear(this.Page.Controls, "");
                    }
                    else
                    {
                        Message = "Category details not saved";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "NotifySuccess('" + Message + " " + res + "');", true);
                    }
                }
                catch (Exception ex)
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", ex.Message, true);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "NotifySuccess('" + ex.Message + " ');", true);
                    //fnClear(this.Page.Controls, "");
                }
            }
        }
    }
}