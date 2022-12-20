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

namespace Yuan
{
    public partial class AddGuest : System.Web.UI.Page
    {
        GuestBL ObjGuest = null;
        string Message = "";
        string json = "", folderPath = "ProfileImg/Guest/";
        DataTable dtData = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] == null)
                {
                    Response.Redirect("Login.aspx");
                }

                BindCity();
                if (Request.QueryString["ID"] != null)
                {
                    hdnGuestId.Value = Request.QueryString["ID"].ToString();
                    LoadGuest();
                }
            }
        }

        #region Function

        public void BindCity()
        {
            MasterDataBL ObjBL = new MasterDataBL();
            DataTable dt = ObjBL.GetMasterData("GetCity", 0);
            drpCity.DataSource = dt;
            drpCity.DataTextField = "CityName";
            drpCity.DataValueField = "CityID";
            drpCity.DataBind();
            drpCity.Items.Insert(0, new ListItem("--Select--", ""));
        }
        void LoadGuest()
        {
            int Gid = Convert.ToInt32(hdnGuestId.Value);
            ObjGuest = new GuestBL();
            DataTable dt = ObjGuest.GetGuestData(Gid);
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    hdnGuestId.Value = dt.Rows[0]["GuestID"].ToString();
                    drpTitle.SelectedValue = dt.Rows[0]["Title"].ToString();
                    txtFirstName.Value = dt.Rows[0]["FName"].ToString();
                    txtLastName.Value = dt.Rows[0]["LName"].ToString();
                    txtMobile.Value = dt.Rows[0]["MobileNo"].ToString();
                    txtLandline.Value = dt.Rows[0]["LandlineNo"].ToString();
                    txtEmailId.Value = dt.Rows[0]["EmailID"].ToString();
                    txtAltContactNo.Value = dt.Rows[0]["AlternateContactNo"].ToString();
                    txtAddress.Value = dt.Rows[0]["AddressLine1"].ToString();
                    txtAddress2.Value = dt.Rows[0]["AddressLine2"].ToString();
                    txtArea.Value = dt.Rows[0]["Area"].ToString();
                    txtLandmark.Value = dt.Rows[0]["Landmark"].ToString();
                    txtPostCode.Value = dt.Rows[0]["Postcode"].ToString();
                    drpActive.SelectedValue = dt.Rows[0]["IsActive"].ToString() == "Yes" ? "1" : "0";
                    drpBlacklisted.SelectedValue = dt.Rows[0]["IsBlacklisted"].ToString() == "Yes" ? "1" : "0";
                    drpCity.SelectedValue = dt.Rows[0]["City"].ToString();
                    txtSourceDet.Value = dt.Rows[0]["SourceDetails"].ToString();
                    drpSource.SelectedValue = dt.Rows[0]["Source"].ToString();
                    txtMemberNo.Value = dt.Rows[0]["MemberNo"].ToString();
                    hdnProfile.Value = dt.Rows[0]["ProfilePhoto"].ToString();
                    if (hdnProfile.Value != "")
                    {
                        dvProfile.Visible = true;
                        lnkprofile.NavigateUrl = "ProfileImg/Guest/" + hdnProfile.Value;
                    }
                    else
                    {
                        dvProfile.Visible = false;
                        lnkprofile.NavigateUrl = "";
                    }
                    //
                }
            }
            catch (Exception ex)
            {
            }

        }

        public DataTable GetGuestData()
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                DataColumn[] dc = new DataColumn[]
                {
                    new DataColumn("ServiceId",typeof(string)),
                    new DataColumn("Qty",typeof(int)),
                    new DataColumn("ServiceBy",typeof(string)),
                    new DataColumn("Price",typeof(string))
                };
                if (dt.Columns.Count <= 0)
                {
                    dt.Columns.AddRange(dc);
                }

            }
            catch (Exception ex)
            {
                Message = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "msg", "NotifySuccess('" + Message + "');", true);
            }
            return dt;
        }
        string fnFileName(string filename, string fileExt)
        {
            string FlName = "";
            try
            {
                FlName = GlobalFunctions.GenerateRandomNo();
                FlName += string.Format("{0:ddMMyyyyhhmmss}", DateTime.Now) + filename + fileExt;

            }
            catch (Exception ex)
            {
                Message = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NotifyError('" + Message + "');", true);
            }
            return FlName;
        }
        string SaveImagesToPath(FileUpload fu, string imgName)
        {
            string filename = "";
            try
            {
                filename = imgName;

                string path = Path.Combine(Server.MapPath("ProfileImg/Guest/"), filename);
                fu.PostedFile.SaveAs(path);

            }
            catch (Exception ex)
            {
                throw;
            }
            return filename;
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
        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {

                    string ImgName = "";
                    if (fuProfile.HasFile)
                    {
                        string extn = System.IO.Path.GetExtension(fuProfile.FileName);
                        if (extn.ToLower() == ".jpg" || extn == ".jpeg" || extn == ".bmp" || extn == ".png")
                        {
                            if (fuProfile.PostedFile.ContentLength > 200240)
                            {
                                lblImgSize.InnerText = "Please upload only 200kb size file";
                                lblImgSize.Attributes.Add("Display", "block");
                                goto Error;
                            }
                            ImgName = fnFileName("_Guest", extn);
                        }
                        else
                        {
                            Message = "Invalid file, Please upload only .jpg, .jpeg, .bmp or .png file";
                            goto Error;
                        }

                    }
                    Guest obj = new Guest();
                    ObjGuest = new GuestBL();
                    obj.Title = GeneralFunctions.ValidateString(drpTitle.SelectedValue.ToString().Trim());
                    obj.FName = GeneralFunctions.ValidateString(txtFirstName.Value);
                    obj.LName = GeneralFunctions.ValidateString(txtLastName.Value);
                    obj.GuestID = hdnGuestId.Value == "" ? 0 : GeneralFunctions.ValidateInt(hdnGuestId.Value);
                    obj.MobileNo = GeneralFunctions.ValidateString(txtMobile.Value.ToString().Trim());
                    obj.LandlineNo = GeneralFunctions.ValidateString(txtLandline.Value.ToString().Trim());
                    obj.EmailID = GeneralFunctions.ValidateString(txtEmailId.Value.Trim());
                    obj.AddressLine1 = GeneralFunctions.ValidateString(txtAddress.Value.Trim());
                    obj.AddressLine2 = GeneralFunctions.ValidateString(txtAddress2.Value.ToString().Trim());
                    obj.AlternateContactNo = GeneralFunctions.ValidateString(txtAltContactNo.Value.ToString().Trim());
                    obj.Area = GeneralFunctions.ValidateString(txtArea.Value.ToString().Trim());
                    obj.Landmark = GeneralFunctions.ValidateString(txtLandmark.Value.ToString().Trim());
                    obj.City = drpCity.SelectedValue != "" ? Convert.ToInt32(drpCity.SelectedValue) : 0;
                    obj.Postcode = GeneralFunctions.ValidateInt(txtPostCode.Value.ToString().Trim());
                    obj.IsActive = drpActive.SelectedValue == "1" ? true : false;
                    obj.IsBlacklisted = drpBlacklisted.SelectedValue == "1" ? true : false;
                    obj.SourceDetails = GeneralFunctions.ValidateString(txtSourceDet.Value.ToString().Trim());
                    obj.Source = drpSource.SelectedValue != "" ? GeneralFunctions.ValidateString(drpSource.SelectedValue.ToString().Trim()) : "";
                    obj.MemberNo = GeneralFunctions.ValidateString(txtMemberNo.Value.ToString().Trim());
                    obj.ProfilePhoto = ImgName;
                    obj.UserId = Convert.ToInt32(Session["UserId"]);
                    // string DealId = "";
                    string res = ObjGuest.InsertUpdateGuest(obj);

                    if (res == "Success")
                    {
                        if (fuProfile.HasFile)
                        {
                            SaveImagesToPath(fuProfile, ImgName);
                        }
                        Message = "Guest Added Successully";
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "msg", "NotifySuccess('" + Message + "');", true);
                        fnClear(Page.Controls, "");
                    }
                    else
                    {
                        Message = "Guest Not Added";
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "msg", "NotifyError('" + Message + "');", true);
                    }
                Error:
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "msg", "NotifyError('" + Message + "');", true);
                }

                catch (Exception ex)
                {
                    Message = ex.Message;
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "msg", "NotifyError('" + Message + "');", true);
                }

            }
        }

        protected void lnkRemove_Click(object sender, EventArgs e)
        {
            try
            {
                //DirectoryInfo folderInfo = new DirectoryInfo(folderPath);
                if (hdnProfile.Value != "")
                {
                    string ExctPath = Path.Combine(folderPath, hdnProfile.Value);
                    DirectoryInfo folderInfo = new DirectoryInfo(ExctPath);
                    {
                        FileInfo file = new FileInfo(ExctPath);
                        if (file.Exists)
                        {
                            file.Delete();
                            dvProfile.Visible = false;
                            hdnProfile.Value = "";
                            ClientScript.RegisterStartupScript(GetType(), "msg", "NotifySuccess('file deleted successfully');", true);
                        }
                        else
                        {
                            dvProfile.Visible = true;
                            ClientScript.RegisterStartupScript(GetType(), "msg", "NotifySuccess('No file to delete');", true);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Message = ex.Message.Replace("'", "");
                ClientScript.RegisterStartupScript(GetType(), "msg", "NotifySuccess('" + Message + "');", true);
            }
        }
    }
}