using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yuan.BL;
using Yuan.DA;

namespace Yuan
{
    public partial class AddRole : System.Web.UI.Page
    {
        string Message = "";
        private UserRoleBL objRole;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {     
                
                //getStaff();
                if (Session["UserId"] != null)
                {
                    if (Request.QueryString["ID"] != null)
                    {
                        hdnRoleId.Value = Request.QueryString["ID"].ToString().Trim();
                        getRoleDetails();
                        CreateGridview("GetPermissionsByID", Convert.ToInt32(hdnRoleId.Value));
                    }
                    else
                    {
                        hdnRoleId.Value = "0";
                        CreateGridview("GetPermissionsByPage", Convert.ToInt32(hdnRoleId.Value));
                    }
                }
                else
                {
                    Response.Redirect("login.aspx");
                }

            }
        }

        #region FUNCTION

        void getRoleDetails()
        {
            try
            {
                objRole = new UserRoleBL();
                int RId = Convert.ToInt32(hdnRoleId.Value);
                DataTable dt = objRole.GetRoleList(RId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtRole.Value = dt.Rows[0]["LevelName"].ToString();
                    drpAccountType.SelectedValue = dt.Rows[0]["AccountType"].ToString();
                    drpActive.SelectedValue = dt.Rows[0]["Active"].ToString() == "True" ? "1":"0";
                }
                else
                {
                    Message = "Role not found";
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "NotifyError('" + Message + "');", true);
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "NotifyError('" + Message + "');", true);
            }
        }        
        void CreateGridview(string mode, int RoleId = 0)
        {            
            try
            {
                updGrid.Update();
                DataTable dt = new DataTable(); //CreateDt();
                objRole = new UserRoleBL();
                dt = objRole.GetRolePermissions(mode, RoleId);
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
        DataTable fnGenerateGridView(int Rid)
        {
            DataTable dtUser = CreateDt();

            foreach (GridViewRow row in gvPerm.Rows)
            {
                //Label UserPermId = (Label)row.FindControl("lblUserPermID");
                
                //Label lblRole = (Label)row.FindControl("lblRoleId");
                HiddenField lblModule = (HiddenField)row.FindControl("hdnModuleId");
                HiddenField lblParentModule = (HiddenField)row.FindControl("hdnParentMId");
                CheckBox chkFullPerm = (CheckBox)row.FindControl("chkFull");
                CheckBox chkAddPerm = (CheckBox)row.FindControl("chkAdd");
                CheckBox chkEditPerm = (CheckBox)row.FindControl("chkEdit");
                CheckBox chkDeletePerm = (CheckBox)row.FindControl("chkDelete");
                CheckBox chkViewPerm = (CheckBox)row.FindControl("chkView");
                CheckBox chkExportPerm = (CheckBox)row.FindControl("chkExport");
                //CheckBox chkApprovePerm = (CheckBox)row.FindControl("chkApprove");
                DataRow dr = dtUser.NewRow();
                dr["LevelID"] = Rid == 0 ? GeneralFunctions.ValidateInt(hdnRoleId.Value) : Rid;
                dr["ModuleId"] = lblModule.Value == "" ? 0 : Convert.ToInt32(lblModule.Value);
                dr["ParentmoduleId"] = lblParentModule.Value == "" ? 0 : Convert.ToInt32(lblParentModule.Value);
                dr["FullP"] = chkFullPerm.Checked;
                dr["AddP"] = chkAddPerm.Checked;// ? 1 : 0;
                dr["EditP"] = chkEditPerm.Checked;//? 1:0;
                dr["DelP"] = chkDeletePerm.Checked;// ? 1 : 0;
                dr["ViewP"] = chkViewPerm.Checked;//? 1 : 0;
                dr["ExportP"] = chkExportPerm.Checked;// ? 1 : 0;
                dr["LevelID"] = hdnRoleId.Value;
                if (hdnRoleId.Value == "0")
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
                    //new DataColumn("UserID",typeof(int)),
                    new DataColumn("LevelID",typeof(int)),
                    new DataColumn("ModuleId",typeof(int)),
                    new DataColumn("ParentmoduleId",typeof(int)),
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
                    if (hdnRoleId.Value == "0")
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

        private bool BulkInsertToDataBase(DataTable Dt, int Rid)
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
                objbulk.DestinationTableName = "RolePermissions";
                //Mapping Table column
                //objbulk.ColumnMappings.Add("UserID", "UserID");
                objbulk.ColumnMappings.Add("LevelID", "LevelID");
                objbulk.ColumnMappings.Add("ModuleId", "ModuleId");
                objbulk.ColumnMappings.Add("ParentmoduleId", "ParentmoduleId");
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

                if (hdnRoleId.Value == "0")
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
                objRole = new UserRoleBL();
                res = objRole.deleteUserPermission(UserId);
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
                if (txtRole.Value == "")
                {
                    Valid = false;
                    Message = "Role is required";
                    txtRole.Focus();
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
                        objRole = new UserRoleBL();
                        Model.UserAndRole objModel = new Model.UserAndRole();
                        objModel.LevelName = GeneralFunctions.ValidateString(txtRole.Value.Trim());
                        objModel.AccountType = GeneralFunctions.ValidateString(drpAccountType.SelectedItem.Text);
                        objModel.Active = drpActive.SelectedValue == "1" ? true : false;
                         
                        if (hdnRoleId.Value == "0")
                        {
                            //objModel.UName = GeneralFunctions.ValidateString(txtUserName.Value);
                            objModel.LevelID = 0;
                            objModel.CreatedBy = Convert.ToInt32(Session["UserId"]);
                            objModel.UpdatedBy = 0;
                        }
                        else
                        {
                            objModel.LevelID = Convert.ToInt32(hdnRoleId.Value);
                            objModel.CreatedBy = 0;
                            objModel.UpdatedBy = Convert.ToInt32(Session["UserId"]);
                        }

                        string str = "";
                        int rid = 0;
                        str= objRole.InsertUpdateRole(objModel,ref rid);
                        if (str.ToLower() == "success")
                        {
                            //hdnUserId.Value = uid.ToString();
                            DataTable dtGrid = fnGenerateGridView(rid);
                            if (dtGrid != null && dtGrid.Rows.Count > 0)
                            {
                                //fnDeletePrevilages(rid);
                                string sql = "delete from RolePermissions where LevelID = @LevelId";
                                SqlParameter[] param =
                                {
                                    new SqlParameter("@LevelId",rid)
                                };
                                DataAccessor.ExecuteQuery(sql, param);

                                if (BulkInsertToDataBase(dtGrid, rid))
                                {
                                    //updUser.Update();
                                    Message = "Role submitted successfully";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "NotifySuccess('" + Message + "');window.location='Roles.aspx';", true);
                                }
                                else
                                {
                                    Message = "Role not submitted";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "NotifySuccess('" + Message + "');", true);
                                }
                            }
                        }
                        else
                        {
                            Message = str;//"User details not submitted";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "NotifySuccess('" + Message + "');", true);
                        }
                    }
                }
                        
            }
            catch (Exception ex)
            {
                throw;
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

                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "NotifyError('" + Message +"');",true);
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

            }
        }
    }
}