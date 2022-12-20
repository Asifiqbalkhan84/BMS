using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Yuan.BL;
using System.Data;
using System.Web.Services;
using System.Web.Script.Serialization;
using Yuan.DA;
using System.Data.SqlClient;
using System.Net;
using System.Drawing;

namespace Yuan
{
    public partial class AddServices : System.Web.UI.Page
    {
        ServicesBL objServ = null;
        string Message = "";
        string ImgPath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindOutlet();
                BindCategory();
                if (Request.QueryString["ID"] != null)
                {
                    hdnServiceId.Value = Request.QueryString["ID"].ToString();
                    LoadService();
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

        void BindCategory()
        {
            try
            {
                MasterDataBL ObjBL = new MasterDataBL();
                DataTable dt = ObjBL.GetMasterData("Category", 0);
                drpCategory.DataSource = dt;
                drpCategory.DataTextField = "CatName";
                drpCategory.DataValueField = "CatID";
                drpCategory.DataBind();
                drpCategory.Items.Insert(0, new ListItem("--Select--", ""));
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "msg", "NotifyError('" + Message + "');", true);
            }
        }
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        void FileDownload(string fileName, string ftpUID, string ftpPassword, string outputName)
        {
            using (var client = new WebClient())
            {
                
                client.Credentials = new NetworkCredential(ftpUID, ftpPassword);

                string ftpPath = Path.Combine("ftp://91.109.247.108/YuanMobileApp/YuanMobileApp/ImgServices/", hdnImage1.Value);
                byte[] fileByte = client.DownloadData(ftpPath);
                //string fileString = Convert.ToBase64String( fileByte);

                using (FileStream file = File.Create(Server.MapPath(outputName)))
                {
                    file.Write(fileByte, 0, fileByte.Length);
                }  
                
                //Console.WriteLine()
            }
        }
        void LoadService()
        {
            try
            {
                int sid = Convert.ToInt32(hdnServiceId.Value);
                objServ = new ServicesBL();
                DataTable dt = objServ.GetServiceData(sid);

                if (dt != null && dt.Rows.Count > 0)
                {
                    hdnServiceId.Value = dt.Rows[0]["ServiceID"].ToString();
                    drpOutlet.SelectedValue = dt.Rows[0]["CompanyID"].ToString();
                    drpCategory.SelectedValue = dt.Rows[0]["CatID"].ToString();
                    txtService.Value = dt.Rows[0]["ServiceName"].ToString();
                    drpServiceHrs.SelectedValue = dt.Rows[0]["ServiceHR"].ToString();//
                    txtServDesc.Value = dt.Rows[0]["ServiceDesc"].ToString();
                    txtPrice.Value = dt.Rows[0]["Price"].ToString();
                    txtSpecialOffValidity.Value = dt.Rows[0]["SpOfferVal"].ToString();
                    txtSpecialPrice.Value = dt.Rows[0]["SpecialOfferPrice"].ToString();
                    txtOnlinePrice.Value = dt.Rows[0]["OnlinePrice"].ToString();

                    DataTable dtFile = objServ.GetFiles(sid, "Service");
                    if (dtFile != null && dtFile.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtFile.Rows.Count; i++)
                        {
                            hdnImage1.Value = dtFile.Rows[i]["FPath"].ToString();
                            txtImageName.Value = dtFile.Rows[i]["FileName"].ToString();
                            txtDisplayOrder.Value = dtFile.Rows[i]["DisplayOrder"].ToString();
                        }
                    }

                    if (hdnImage1.Value != "")
                    {
                        string FileLoc = @"http$\\echofeel.com\YuanMobileApp\YuanMobileApp\ImgServices\";//@"C:\Users\kasif\Downloads\ImgServices\"; 
                        string ftpUsername = "FTPEchofeel";
                        string ftpPassword = "C0Rem789Gt";
                        FileDownload(hdnImage1.Value, ftpUsername, ftpPassword, "/ServiceImage.jpg");
                        ServiceView.Src = "/ServiceImage.jpg";
                        ServiceView.Attributes.Add("style", "display:block");
                    }
                    else
                    {
                        ServiceView.Attributes.Add("style", "display:none");
                    }
                }

            }
            catch (Exception ex)
            {
                Message = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NotifyError('" + Message + "');", true);
            }
        }
        public void StoreFile(string Fname, string Fpath, string FileType, string desc, string Category, int DealId, int displayOrder, int userId)
        {
            string sql = "insert into FileStore ([FileName], [FPath], [TypeofFile], [Description], [Category], [ReferenceID], [DisplayOrder], [CreatedBy], [Datecreated]) " +
                "values(@FileName,@FPath,@FileType,@Description,@Category,@ReferenceID,@DisplayOrder,@CreatedBy,GETDATE())";
            //string dt = DateTime.Today.ToString("dd/MM/yyyy hh:mm:ss");
            SqlParameter[] param1 =
            {
                new SqlParameter("@FileName",Fname),
                new SqlParameter("@FPath",Fpath),
                new SqlParameter("@FileType",FileType),
                new SqlParameter("@Description",desc),
                new SqlParameter("@Category",Category),
                new SqlParameter("@ReferenceID",DealId),
                new SqlParameter("@DisplayOrder",displayOrder),
                new SqlParameter("@CreatedBy",userId)
                //new SqlParameter("@DateCreated",dt)

            };

            DataAccessor.ExecuteQuery(sql, param1);
        }

        public bool fnRemoveFile(string path, string filename)
        {
            bool IsDel = false;
            try
            {
                DirectoryInfo folderInfo = new DirectoryInfo(path);
                {
                    FileInfo file = new FileInfo(path);
                    if (file.Exists)
                    {
                        file.Delete();
                        IsDel = true;

                    }
                    else
                    {
                        IsDel = false;
                    }
                }
            }
            catch (Exception ex)
            {
                IsDel = false;
                Message = ex.Message.Replace("'", "");
                ClientScript.RegisterStartupScript(GetType(), "msg", "NotifySuccess('" + Message + "');", true);

            }
            return IsDel;
        }

        string fnFileName(string filename, string fileExt)
        {
            string FlName = "";
            try
            {
                FlName = GlobalFunctions.GenerateRandomNo();
                FlName += Session["UserID"] + "_" + string.Format("{0:ddMMyyyyhhmmss}", DateTime.Now) + filename + fileExt;
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

                string path = Path.Combine(Server.MapPath("ImgServices/"), filename);
                fu.PostedFile.SaveAs(path);

            }
            catch (Exception ex)
            {
                throw;
            }
            return filename;
        }

        bool CheckFileType(string extn)
        {

            bool valid = false;
            try
            {
                string extension = extn.ToLower();
                switch (extension)
                {
                    case ".jpg":
                        valid = true;
                        break;
                    case ".png":
                        valid = true;
                        break;
                    case ".jpeg":
                        valid = true;
                        break;
                    case ".bmp":
                    default:
                        valid = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                valid = false;
                Message = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "NotifySuccess('" + Message + "')", true);
            }
            return valid;
        }

        #endregion
        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            try
            {
                Model.Service obj = new Model.Service();
                objServ = new ServicesBL();
                obj.ServiceID = hdnServiceId.Value == "" ? 0 : GeneralFunctions.ValidateInt(hdnServiceId.Value);
                obj.ServiceName = GeneralFunctions.ValidateString(txtService.Value.ToString().Trim());
                obj.ServiceDesc = GeneralFunctions.ValidateString(txtServDesc.Value);
                obj.CompanyID = GeneralFunctions.ValidateInt(drpOutlet.SelectedValue);
                obj.CatID = GeneralFunctions.ValidateInt(drpCategory.SelectedValue);
                obj.ServiceHRs = GeneralFunctions.ValidateInt(drpServiceHrs.SelectedValue);
                obj.Price = GeneralFunctions.ValidateString(txtPrice.Value.ToString().Trim());
                obj.SpecialOfferPrice = GeneralFunctions.ValidateString(txtSpecialPrice.Value.ToString().Trim());
                obj.SpOfferValidity = GeneralFunctions.ValidateString(txtSpecialOffValidity.Value.Trim());
                obj.OnlinePrice = GeneralFunctions.ValidateString(txtOnlinePrice.Value.ToString().Trim());
                obj.Active = GeneralFunctions.ValidateBool(drpActive.SelectedValue);
                obj.UserId = Convert.ToInt32(Session["UserId"]);
                int ServiceId = 0;
                string res = objServ.InsertUpdateService(obj, ref ServiceId);


                if (res == "Success")
                {
                    string date = string.Format("{0:ddMMyyyyhhmmss}", DateTime.Now);
                    string FileLoc = @"ImgServices"; //@"C:\Users\kasif\Downloads\ImgServices\"; //@"http$//echofeel.com/yuanver02/ImgServices/";

                    if (FuImage1.HasFile)
                    {
                        bool validfile = CheckFileType(System.IO.Path.GetExtension(FuImage1.PostedFile.FileName));
                        if (validfile == true)
                        {
                            ImgPath = "Service -" + date;
                            string ImgExt = System.IO.Path.GetExtension(FuImage1.PostedFile.FileName);
                            byte[] imgSave;
                            imgSave = GeneralFunctions._ImageResize(751, 503, FuImage1.PostedFile.InputStream, ImgPath, FileLoc);
                            ImgPath = ImgPath + ImgExt;
                            string path =string.Format(HttpContext.Current.Server.MapPath("~/{0}/"), FileLoc);
                            //System.IO.File.WriteAllBytes(Path.Combine(FileLoc,ImgPath), imgSave);
                            using (var client = new WebClient())
                            {
                                string ftpUsername = "FTPEchofeel";
                                string ftpPassword = "C0Rem789Gt";
                                client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                                string LocalPath = Path.Combine(path, ImgPath);
                                string ftpPath =Path.Combine("ftp://91.109.247.108/YuanMobileApp/YuanMobileApp/ImgServices/", ImgPath);                                
                                client.UploadFile(ftpPath, WebRequestMethods.Ftp.UploadFile, LocalPath);
                            }

                            int DispOrd = Convert.ToInt32(txtDisplayOrder.Value);
                            StoreFile(txtImageName.Value, ImgPath, ImgExt, "Image1", "Service", Convert.ToInt32(obj.ServiceID == 0 ? ServiceId : obj.ServiceID), DispOrd, Convert.ToInt32(Session["UserId"]));
                        }
                    }
                    else
                    {
                        if (hdnImage1.Value !="")
                        {
                            ImgPath = hdnImage1.Value;
                        }
                        
                    }
                    if (ServiceId != 0)
                    {
                        Message = "Service saved successfully";
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "msg", "NotifySuccess('" + Message + "') ;window.location.href='Services.aspx';", true);
                    }
                    else
                    {
                        Message = "Service updated successfully";
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "msg", "NotifySuccess('" + Message + "') ;window.location.href='Services.aspx';", true);
                    }
                }
                else
                {
                    Message = res;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NotifyError('" + Message + "');", true);
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NotifyError('" + Message + "');", true);
            }
        }

        protected void lnkRemoveImage1_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo folderInfo = new DirectoryInfo("ServiceImg/");
                if (hdnImage1.Value != "")
                {
                    string ExctPath = Path.Combine("ServiceImg/" + hdnImage1.Value);
                    if (fnRemoveFile(ExctPath, hdnImage1.Value))
                    {
                        hdnImage1.Value = "";
                        ClientScript.RegisterStartupScript(GetType(), "msg", "NotifySuccess('file deleted successfully');", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "msg", "NotifySuccess('No file to delete');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message.Replace("'", "");
                ClientScript.RegisterStartupScript(GetType(), "msg", "NotifySuccess('" + Message + "');", true);
            }
        }

        protected void reqfileupload1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            if (hdnServiceId.Value != "")
            {
                args.IsValid = true;
            }
            else if(FuImage1.HasFile)
            {
                args.IsValid = true;
            }
            else
                args.IsValid = false;
        }
    }
}