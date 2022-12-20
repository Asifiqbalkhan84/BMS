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
using System.Configuration;
using System.Data.SqlClient;

namespace Yuan
{
    public partial class AddUser : System.Web.UI.Page
    {
        UserRoleBL objUser = null;
        string Message = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getRoles();
                getStaff();
                if (Session["UserId"] != null)
                {
                    if (Request.QueryString["ID"] != null)
                    {
                        hdnUserId.Value = Request.QueryString["ID"].ToString().Trim();
                        getUserDetails();
                        CreateGridview("GetPermissionsByID", Convert.ToInt32(hdnUserId.Value));
                    }
                    else
                    {
                        hdnUserId.Value = "0";
                        CreateGridview("GetPermissionsByPage", Convert.ToInt32(hdnUserId.Value));
                    }
                }
                else
                {
                    Response.Redirect("login.aspx");
                }

            }
        }

        #region FUNCTION

        public void GetRolePermissions(int RoleID)
        {
            UserRoleBL ObjBL = new UserRoleBL();
            try
            {
                DataTable dt = ObjBL.GetRolePermissions("GetPermissionsByID", RoleID);
                gvPerm.DataSource = dt;
                gvPerm.DataBind();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NotifyError('" + Message + "')", true);
            }
        }

        void getUserDetails()
        {
            try
            {
                objUser = new UserRoleBL();
                int UserId = Convert.ToInt32(hdnUserId.Value);
                DataTable dt = objUser.GetUserList(UserId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtName.Value = dt.Rows[0]["Name"].ToString();
                    txtUserName.Value = dt.Rows[0]["UName"].ToString();
                    drpRole.SelectedValue = dt.Rows[0]["LevelID"].ToString() == "0" ? "" : dt.Rows[0]["LevelID"].ToString();
                    drpUserType.SelectedValue = dt.Rows[0]["UType"].ToString() == "0" ? "" : dt.Rows[0]["UType"].ToString();
                    drpStaff.SelectedValue = dt.Rows[0]["StaffID"].ToString() == "0" ? "" : dt.Rows[0]["StaffID"].ToString();
                    //txtCnfPassword.Attributes["value"] = dt.Rows[0]["Pass"].ToString();                    
                    drpActive.SelectedValue = dt.Rows[0]["Active"].ToString() == "Yes" ? "1" : "0";

                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "setPass('" + dt.Rows[0]["Pass"].ToString() + "');", true);
                }
                else
                {
                    Message = "User not found";
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "NotifyError('" + Message + "');", true);
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "NotifyError('" + Message + "');", true);
            }
        }
        void getRoles()
        {
            MasterDataBL objMaster = new MasterDataBL();
            DataTable dt = objMaster.GetMasterData("GetUserLevels", 0);
            drpRole.Items.Clear();
            drpRole.DataSource = dt;
            drpRole.DataTextField = "LevelName";
            drpRole.DataValueField = "levelID";
            drpRole.DataBind();
            drpRole.Items.Insert(0, new ListItem("--Select--", ""));
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
        void CreateGridview(string mode, int UserId = 0)
        {
            string str = "";
            try
            {
                updGrid.Update();
                DataTable dt = new DataTable(); //CreateDt();
                objUser = new UserRoleBL();
                dt = objUser.GetUserPermissions(mode, UserId);

                gvPerm.DataSource = dt;
                gvPerm.DataBind();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "NotifySuccess('" + Message + "');", true);
            }
        }

        //For Bulk upload
        DataTable fnGenerateGridView(int uid)
        {
            DataTable dtUser = CreateDt();

            foreach (GridViewRow row in gvPerm.Rows)
            {
                //Label UserPermId = (Label)row.FindControl("lblUserPermID");
                Label lblUser = (Label)row.FindControl("lblUserId");
                Label lblRole = (Label)row.FindControl("lblRoleId");
                HiddenField lblParentModule = (HiddenField)row.FindControl("hdnModID");
                HiddenField lblSubModule = (HiddenField)row.FindControl("hdnSubModID");
                CheckBox chkFullPerm = (CheckBox)row.FindControl("chkFull");
                CheckBox chkAddPerm = (CheckBox)row.FindControl("chkAdd");
                CheckBox chkEditPerm = (CheckBox)row.FindControl("chkEdit");
                CheckBox chkDeletePerm = (CheckBox)row.FindControl("chkDelete");
                CheckBox chkViewPerm = (CheckBox)row.FindControl("chkView");
                CheckBox chkExportPerm = (CheckBox)row.FindControl("chkExport");
                //CheckBox chkApprovePerm = (CheckBox)row.FindControl("chkApprove");
                DataRow dr = dtUser.NewRow();

                dr["ModuleID"] = lblParentModule.Value == "" ? 0 : Convert.ToInt32(lblParentModule.Value);
                dr["SubModule"] = lblSubModule.Value == "" ? 0 : Convert.ToInt32(lblSubModule.Value);
                dr["FullP"] = chkFullPerm.Checked;
                dr["AddP"] = chkAddPerm.Checked;// ? 1 : 0;
                dr["EditP"] = chkEditPerm.Checked;//? 1:0;
                dr["DelP"] = chkDeletePerm.Checked;// ? 1 : 0;
                dr["ViewP"] = chkViewPerm.Checked;//? 1 : 0;
                dr["ExportP"] = chkExportPerm.Checked;// ? 1 : 0;
                //dr["ApproveP"] = chkApprovePerm.Checked;//? 1 : 0;                
                dr["UserID"] = uid;
                dr["LevelID"] = drpRole.SelectedValue;
                if (hdnUserId.Value == "0")
                {
                    dr["CreatedBy"] = Session["UserId"];
                    dr["DateCreated"] = DateTime.Today;
                    dr["UpdatedBy"] = DBNull.Value;
                    //dr["DateUpdated"] = DateTime.MinValue;
                }
                else
                {
                    dr["CreatedBy"] = DBNull.Value;
                    //dr["DateCreated"] = DateTime.MinValue;
                    dr["UpdatedBy"] = Session["UserId"];
                    dr["DateUpdated"] = DateTime.Today;
                }
                dtUser.Rows.Add(dr);
                dtUser.AcceptChanges();
            }
            return dtUser;
        }
        DataTable CreateDt()
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                DataColumn[] dc = new DataColumn[]
                {
                    new DataColumn("UserID",typeof(int)),
                    new DataColumn("LevelID",typeof(int)),
                    new DataColumn("ModuleId",typeof(int)),
                    new DataColumn("SubModule",typeof(int)),
                    new DataColumn("FullP",typeof(bool)),
                    new DataColumn("AddP",typeof(bool)),
                    new DataColumn("EditP",typeof(bool)),
                    new DataColumn("DelP", typeof(bool)),
                    new DataColumn("ViewP",typeof(bool)),
                    //new DataColumn("ApproveP",typeof(bool)),
                    new DataColumn("ExportP",typeof(bool)),
                    new DataColumn("CreatedBy",typeof(int)),
                    new DataColumn("UpdatedBy",typeof(int)),
                    new DataColumn("DateCreated",typeof(DateTime)),
                    new DataColumn("DateUpdated",typeof(DateTime))
                };

                if (dt.Columns.Count <= 0)
                {
                    dt.Columns.AddRange(dc);
                    if (hdnUserId.Value == "0")
                    {
                        //dt.Columns.Remove("UpdatedBy");
                        dt.Columns.Remove("DateUpdated");
                    }
                    else
                    {
                        //dt.Columns.Remove("CreatedBy");
                        dt.Columns.Remove("DateCreated");
                    }
                }
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }

        private bool BulkInsertToDataBase(DataTable Dt, int uid)
        {
            bool res = false;
            DataTable dtPermission = Dt;
            string conn = ConfigurationManager.ConnectionStrings["constr"].ToString();
            SqlConnection con = new SqlConnection(conn);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //creating object of SqlBulkCopy  
                SqlBulkCopy objbulk = new SqlBulkCopy(con);
                //assigning Destination table name  
                objbulk.DestinationTableName = "UserPermissions";
                //Mapping Table column
                objbulk.ColumnMappings.Add("UserID", "UserID");
                objbulk.ColumnMappings.Add("LevelID", "LevelID");
                objbulk.ColumnMappings.Add("ModuleId", "ModuleId");
                objbulk.ColumnMappings.Add("SubModule", "SubModule");
                objbulk.ColumnMappings.Add("FullP", "FullP");
                objbulk.ColumnMappings.Add("AddP", "AddP");
                objbulk.ColumnMappings.Add("EditP", "EditP");
                objbulk.ColumnMappings.Add("DelP", "DelP");
                objbulk.ColumnMappings.Add("ViewP", "ViewP");
                objbulk.ColumnMappings.Add("ExportP", "ExportP");
                objbulk.ColumnMappings.Add("CreatedBy", "CreatedBy");
                objbulk.ColumnMappings.Add("UpdatedBy", "UpdatedBy");
                //objbulk.ColumnMappings.Add("ApproveP", "ApproveP");
                //objbulk.ColumnMappings.Add("Active", "Active");  

                if (hdnUserId.Value == "0")
                {
                    objbulk.ColumnMappings.Add("DateCreated", "DateCreated");
                }
                else
                {
                    objbulk.ColumnMappings.Add("DateUpdated", "DateUpdated");
                }
                //inserting bulk Records into DataBase

                objbulk.WriteToServer(dtPermission);
                objbulk = null;
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
                throw;
            }
            finally
            {
                con.Close();
                Dt.Dispose();
                dtPermission.Dispose();

            }
            return res;
        }

        string fnDeletePrevilages(int UserId)
        {
            string res;
            try
            {
                objUser = new UserRoleBL();
                res = objUser.deleteUserPermission(UserId);
            }
            catch (Exception ex)
            {
                res = "error";
            }
            return res;
        }
        bool IsValidate()
        {
            bool Valid = true;
            try
            {
                if (txtName.Value == "")
                {
                    Valid = false;
                    Message = "Name is required";
                    txtName.Focus();
                }
                if (txtUserName.Value == "")
                {
                    Valid = false;
                    Message = "User name is required";
                    txtUserName.Focus();
                }
                if (drpRole.SelectedIndex == 0)
                {
                    Valid = false;
                    Message = "Role is required";
                    drpRole.Focus();
                }
                if (drpUserType.SelectedIndex == 0)
                {
                    Valid = false;
                    Message = "User type is required";
                    drpUserType.Focus();
                }

            }
            catch (Exception ex)
            {
                Valid = false;
                Message = ex.Message;
            }
            return Valid;
        }

        #endregion
        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (IsValidate())
                    {
                        UserAndRole _objUser = new UserAndRole();

                        objUser = new UserRoleBL();
                        //_objUser.UserID = Convert.ToInt32(hdnUserId.Value);
                        _objUser.Name = GeneralFunctions.ValidateString(txtName.Value);

                        _objUser.Pass = GeneralFunctions.ValidateString(txtPassword.Value);
                        _objUser.LevelID = drpRole.SelectedValue != "" ? GeneralFunctions.ValidateInt(drpRole.SelectedValue) : 0;
                        _objUser.UType = GeneralFunctions.ValidateString(drpUserType.SelectedValue);
                        _objUser.StaffID = GeneralFunctions.ValidateInt(drpStaff.SelectedValue);
                        //Session["UserId"] == null ? 0:Convert.ToInt32(Session["UserId"]);                        
                        _objUser.Active = drpActive.SelectedValue == "1" ? true : false;
                        if (hdnUserId.Value == "0")
                        {
                            _objUser.UName = GeneralFunctions.ValidateString(txtUserName.Value);
                            _objUser.UserId = 0;
                            _objUser.CreatedBy = Convert.ToInt32(Session["UserId"]);
                            _objUser.UpdatedBy = 0;
                        }
                        else
                        {
                            _objUser.UserId = Convert.ToInt32(hdnUserId.Value);
                            _objUser.CreatedBy = 0;
                            _objUser.UpdatedBy = Convert.ToInt32(Session["UserId"]);
                        }

                        string str = "";
                        int uid = 0;
                        str = objUser.insertupdateUser(_objUser, ref uid);

                        _objUser = null;

                        if (str.ToLower() == "success")
                        {
                            //hdnUserId.Value = uid.ToString();
                            DataTable dtGrid = fnGenerateGridView(uid);
                            if (dtGrid != null && dtGrid.Rows.Count > 0)
                            {
                                fnDeletePrevilages(uid);

                                if (BulkInsertToDataBase(dtGrid, uid))
                                {
                                    //updUser.Update();
                                    Message = "User details submitted successfully";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(),Guid.NewGuid().ToString(), "NotifySuccess('" + Message + "');window.location='Users.aspx';", true);
                                }
                                else
                                {
                                    Message = "User details not submitted";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NotifySuccess('" + Message + "');", true);
                                }
                            }
                        }
                        else
                        {
                            Message = str;//"User details not submitted";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "NotifySuccess('" + Message + "');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, Page.GetType(), "msg", "NotifySuccess('" + Message + "');", true);
                    }
                    //btnSubmit.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                Message = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "NotifyError('" + Message + "');", true);
            }
        }

        protected void gvPerm_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkFull = (CheckBox)e.Row.FindControl("chkFull");
                    CheckBox chkAdd = (CheckBox)e.Row.FindControl("chkAdd");
                    CheckBox chkEdit = (CheckBox)e.Row.FindControl("chkEdit");
                    CheckBox chkDelete = (CheckBox)e.Row.FindControl("chkDelete");
                    CheckBox chkView = (CheckBox)e.Row.FindControl("chkView");
                    CheckBox chkExport = (CheckBox)e.Row.FindControl("chkExport");
                    //CheckBox chkApprove = (CheckBox)e.Row.FindControl("chkApprove");
                    if (chkFull.Checked)
                    {
                        chkFull.Checked = true;
                        chkAdd.Checked = true;
                        chkEdit.Checked = true;
                        chkDelete.Checked = true;
                        chkView.Checked = true;
                        chkExport.Checked = true;
                        //chkApprove.Checked = true;

                    }
                    else
                    {
                        chkFull.Checked = false;

                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "msg", "NotifyError('" + Message + "')", true);
            }
        }

        protected void chkFull_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvPerm.Rows.Count; i++)
                {
                    updGrid.Update();

                    CheckBox chkFull = (CheckBox)gvPerm.Rows[i].FindControl("chkFull");
                    CheckBox chkAdd = (CheckBox)gvPerm.Rows[i].FindControl("chkAdd");
                    CheckBox chkEdit = (CheckBox)gvPerm.Rows[i].FindControl("chkEdit");
                    CheckBox chkView = (CheckBox)gvPerm.Rows[i].FindControl("chkView");
                    CheckBox chkDelete = (CheckBox)gvPerm.Rows[i].FindControl("chkDelete");
                    CheckBox chkExport = (CheckBox)gvPerm.Rows[i].FindControl("chkExport");
                    //CheckBox chkApprove = (CheckBox)gvPerm.Rows[i].FindControl("chkApprove");
                    if (chkFull.Checked)
                    {
                        chkAdd.Checked = true;
                        chkEdit.Checked = true;
                        chkView.Checked = true;
                        chkDelete.Checked = true;
                        chkExport.Checked = true;
                        //chkApprove.Checked = true;
                    }
                    else
                    {
                        //chkAdd.Checked = false;
                        //chkEdit.Checked = false;
                        //chkView.Checked = false;
                        //chkDelete.Checked = false;
                        //chkExport.Checked = false;
                        //chkApprove.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "msg", "NotifyError('" + Message + "')", true);
            }

        }      

        protected void drpRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRolePermissions(GeneralFunctions.ValidateInt(drpRole.SelectedValue));
        }
    }
}