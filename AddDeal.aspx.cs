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
using System.Web.UI.HtmlControls;
using Newtonsoft.Json;
using System.Net;

namespace Yuan
{
    public partial class AddDeal : System.Web.UI.Page
    {
        DealsBL ObjDeals = null;
        string Message = "";
        string json = "";
        DataTable dtData = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                FillOutlet();
                BindStaff();
                //BindCity();
                if (Request.QueryString["ID"] != null)
                {
                    hdnDealId.Value = Request.QueryString["ID"].ToString();
                    LoadDealById();
                }
            }
        }

        #region Function
        [WebMethod]
        public static string FillDrpService()
        {
            AddDeal objDeal = new AddDeal();
            objDeal.FillServiceDropdown();
            objDeal.JsonCall(objDeal.dtData);
            objDeal.dtData = null;
            return objDeal.json;
        }

        [WebMethod]
        public static string FillServiceData(string data)
        {
            AddDeal objdeal = new AddDeal();
            objdeal.GetServiceDataById(Convert.ToInt32(data));
            objdeal.JsonCall(objdeal.dtData);

            return objdeal.json;
        }

        [WebMethod]
        public static string GetServicesByOutlet(string data)
        {
            AddDeal obj = new AddDeal();
            obj.GetServiceByOutlet(Convert.ToInt32(data));
            obj.JsonCall(obj.dtData);

            return obj.json;
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
        public DataTable FillServiceDropdown()
        {
            try
            {
                MasterDataBL objMasterData = new MasterDataBL();
                dtData = new DataTable();
                dtData = objMasterData.GetMasterData("Service", 0);
                //dtData.Tables.Add(dt);
            }
            catch (Exception ex)
            {
                dtData = null;
            }
            return dtData;
        }

        public DataTable GetServiceDataById(int Id)
        {
            try
            {
                ObjDeals = new DealsBL();
                dtData = ObjDeals.GetServiceData(Id);

            }
            catch (Exception ex)
            {
                dtData = null;
                Message = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "NotifyError('" + Message + "')", true);
            }
            return dtData;
        }

        void FileDownload(string fileName, string ftpUID, string ftpPassword, string outputName)
        {
            using (var client = new WebClient())
            {

                client.Credentials = new NetworkCredential(ftpUID, ftpPassword);

                string ftpPath = Path.Combine("ftp://91.109.247.108/YuanMobileApp/YuanMobileApp/ImgDeals/", hdnImage1.Value);
                byte[] fileByte = client.DownloadData(ftpPath);
                //string fileString = Convert.ToBase64String( fileByte);

                using (FileStream file = File.Create(Server.MapPath(outputName)))
                {
                    file.Write(fileByte, 0, fileByte.Length);
                }

                //Console.WriteLine()
            }
        }
        void LoadDealById()
        {
            int Did = Convert.ToInt32(hdnDealId.Value);
            ObjDeals = new DealsBL();
            DataTable dt = ObjDeals.GetDealsById(Did);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtDealname.Value = dt.Rows[0]["DealName"].ToString();
                txtDesc.Value = Convert.ToString(dt.Rows[0]["DealName"]);
                txtValidity.Value = Convert.ToString(dt.Rows[0]["Validity"]);
                txtDiscountAmt.Value = dt.Rows[0]["DiscountFlat"].ToString();
                txtDiscountper.Value = dt.Rows[0]["DiscountPer"].ToString();
                txtDiscVoucher.Value = dt.Rows[0]["DiscountVoucher"].ToString();
                drpOutlet.SelectedValue = dt.Rows[0]["CompanyId"].ToString();
                drpDealType.SelectedValue = dt.Rows[0]["DealType"].ToString();
                drpMember.SelectedItem.Text = dt.Rows[0]["MemberOnly"].ToString();
                drpMemberType.SelectedValue = dt.Rows[0]["MemberType"].ToString();
                //FuimgFile1.HasAttributes= "yes";
                drpActive.SelectedValue = dt.Rows[0]["Active"].ToString() == "True" ? "1" : "0";
                txtRemark.Value = dt.Rows[0]["Remark"].ToString();
                imgName1.Value = dt.Rows[0]["FileName"].ToString();
                txtDisplayOrd1.Value = dt.Rows[0]["DisplayOrder"].ToString();
                hdnImage1.Value = dt.Rows[0]["FPath"].ToString();
                if (hdnImage1.Value != "")
                {
                    //FileLoc = @"http$\\echofeel.com\YuanMobileApp\YuanMobileApp\ImgServices\";//@"C:\Users\kasif\Downloads\ImgServices\"; 
                    string ftpUsername = "FTPEchofeel";
                    string ftpPassword = "C0Rem789Gt";
                    FileDownload(hdnImage1.Value, ftpUsername, ftpPassword, "/DealsImage.jpg");
                    ImgDealView.Src = "/DealsImage.jpg";
                    ImgDealView.Attributes.Add("style", "display:block");
                }
                else
                {
                    ImgDealView.Attributes.Add("style", "display:none");
                }
                //if (ds.Tables[1].Rows.Count > 0)
                //{
                  //  chkIsFree.Checked = ds.Tables[1].Rows[0]["IsFree"].ToString() == "0" ? false : true;

                    //for (int i = 1; i < ds.Tables[1].Rows.Count; i++)
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "insRow();", true);
                    //}

                    //DataTable dt = new DataTable();
                    //dt = ds.Tables[1];
                    //JsonCall(dt);
                    //hdnJson.Value = JsonConvert.ToString(json);
                    //ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "BindServices();", true);
                //}

            }
        }

        string fnFileName(string filename, string fileExt)
        {
            string FlName = "";
            try
            {
                FlName = GlobalFunctions.GenerateRandomNo();
                FlName += DateTime.Now.ToString("dd-MM-yyyy:hh:mm:ss") + filename + fileExt;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NotifyError('" + Message + "');", true);
            }
            return FlName;
        }
        string SaveImagesToPath(FileUpload fu, string imgpath, string imgName)
        {
            string filename = "";
            try
            {
                //Random rnd = new Random();
                //long no = rnd.Next(9999999);
                //byte[] bt = Convert.FromBase64String(imgpath);

                string Path = HttpContext.Current.Server.MapPath(string.Format(imgpath));
                filename = imgName;

                DirectoryInfo folderInfo = new DirectoryInfo(Path);

                fu.SaveAs(Path + filename);

            }
            catch (Exception ex)
            {
                throw;
            }
            return filename;
        }

        bool DeleteFile(string FilePath, string filename)
        {
            bool IsDelete = false;
            try
            {
                string Path = HttpContext.Current.Server.MapPath(string.Format(FilePath));
                DirectoryInfo FileInfo = new DirectoryInfo(Path);
                foreach (var file in FileInfo.GetFiles())
                {
                    if (file.Name == filename)
                    {
                        file.Delete();
                        IsDelete = true;
                    }
                }
            }
            catch (Exception ex)
            {
                IsDelete = false;
            }
            return IsDelete;
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

            drpOutlet2.DataSource = dt;
            drpOutlet2.DataTextField = "OutletName";
            drpOutlet2.DataValueField = "CompanyId";
            drpOutlet2.DataBind();
            drpOutlet2.Items.Insert(0, new ListItem("All", "0"));
        }

        [WebMethod]
        public static string GetStaff()
        {
            AddDeal objDeal = new AddDeal();
            objDeal.BindStaff();
            objDeal.JsonCall(objDeal.dtData);
            return objDeal.json;
        }

        [WebMethod]
        public static string GetServiceById(int cid)
        {
            AddDeal objDeal = new AddDeal();
            objDeal.GetServiceByOutlet(cid);
            objDeal.JsonCall(objDeal.dtData);
            return objDeal.json;
        }

        [WebMethod]
        public static string BindServiceData(int did)
        {
            AddDeal objDeal = new AddDeal();
            objDeal.GetServiceDataByDealId(did);
            objDeal.JsonCall(objDeal.dtData);
            return objDeal.json;
        }
        public void GetServiceDataByDealId(int Id)
        {
            ObjDeals = new DealsBL();
           dtData = ObjDeals.GetServiceDetByDeal(Id);
        }
        public void BindStaff()
        {
            MasterDataBL obj = new MasterDataBL();
            dtData = obj.GetMasterData("GetStaff", 0);
            //drpServiceBy.DataSource = dt;
            //drpServiceBy.DataTextField = "StaffName";
            //drpServiceBy.DataValueField = "StaffID";
            //drpServiceBy.DataBind();
            //drpServiceBy.Items.Insert(0, new ListItem("--Select", "0"));
        }
        public void GetServiceByOutlet(int cid = 0)
        {
            ObjDeals = new DealsBL();
            DataTable dt = ObjDeals.GetServicesByCID(cid);
            //drpService.DataSource = dt;
            //drpService.DataTextField = "ServiceName";
            //drpService.DataValueField = "ServiceId";
            //drpService.DataBind();
            //drpService.Items.Insert(0, new ListItem("All", "0"));

        }
        public void StoreFile(string Fname, string Fpath, string FileType, string desc, string Category, int DealId, int displayOrder, int userId)
        {
            string sql = "insert into FileStore ([FileName], [FPath], [TypeofFile], [Description], [Category], [ReferenceID], [DisplayOrder], [CreatedBy], [Datecreated]) " +
                "values(@FileName,@FPath,@FileType,@Description,@Category,@ReferenceID,@DisplayOrder,@CreatedBy,@DateCreated)";
            string dt = DateTime.Today.ToString("dd/MM/yyyy hh:mm:ss");
            SqlParameter[] param1 =
            {
                new SqlParameter("@FileName",Fname),
                new SqlParameter("@FPath",Fpath),
                new SqlParameter("@FileType",FileType),
                new SqlParameter("@Description",desc),
                new SqlParameter("@Category",Category),
                new SqlParameter("@ReferenceID",DealId),
                new SqlParameter("@DisplayOrder",displayOrder),
                new SqlParameter("@CreatedBy",userId),
                new SqlParameter("@DateCreated",dt)

            };

            DataAccessor.ExecuteQuery(sql, param1);
        }

        bool FnValidate()
        {
            bool IsValid = false;
            try
            {
                if (hdnImage1.Value != "")
                {
                    if (FuimgFile1.HasFile)
                    {
                        string extn = System.IO.Path.GetExtension(FuimgFile1.FileName);
                        if (extn != ".jpg" && extn != ".jpeg" && extn != ".bmp" && extn != ".png")
                        {
                            Message = "Invalid file, Please upload only .jpg, .jpeg, .bmp or .png file";
                            //goto Error;

                        }
                        else
                        {
                            Message = "";
                            IsValid = true;
                        }
                    }
                    else
                    {
                        IsValid = true;
                    }
                }
                else
                {
                    if (FuimgFile1.HasFile)
                    {
                        string extn = System.IO.Path.GetExtension(FuimgFile1.FileName);
                        if (extn != ".jpg" && extn != ".jpeg" && extn != ".bmp" && extn != ".png")
                        {
                            Message = "Invalid file, Please upload only .jpg, .jpeg, .bmp or .png file";
                            //goto Error;

                        }
                        else
                        {
                            Message = "";
                            IsValid = true;
                        }
                        //if (FuimgFile1.PostedFile.ContentLength > 2024)
                        //{
                        //    lblImgSize.InnerText = "Please upload only 200kb size file";
                        //    lblImgSize.Visible = true;
                        //    //goto Error;
                        //}
                    }
                    else
                    {
                        Message = "Please upload file for Deal";
                    }
                }

            }
            catch (Exception ex)
            {
                IsValid = false;
                Message = ex.Message;
            }
            return IsValid;
        }

        public string InsertDealDetails(DataTable Dt, int DealId)
        {
            string Outpt = "";
            try
            {
                if (Dt.Rows.Count > 0)
                {
                    int ServiceId = 0;
                    int ServiceBy = 0;
                    int Qty = 0;
                    string Price = "";
                    int userid = Convert.ToInt32(Session["UserId"]);
                    string sql = "delete from DealDetails where DealId=@DealID ";
                    SqlParameter[] param =
                        {
                            new SqlParameter("@DealID",DealId)
                        };
                    DataAccessor.ExecuteQuery(sql, param);

                    foreach (DataRow r in Dt.Rows)
                    {
                        ServiceId = GeneralFunctions.ValidateInt(r["ServiceId"].ToString());
                        ServiceBy = GeneralFunctions.ValidateInt(r["ServiceBy"]);
                        Qty = GeneralFunctions.ValidateInt(r["Qty"]);
                        Price = GeneralFunctions.ValidateString(r["Price"].ToString());

                        sql = " insert into DealDetails (DealID, ServiceId, ServiceBy,IsFree,[Price],Qty,[CreatedBy], [Datecreated]) " +
                                      "values(@DealID,@ServiceID,@ServiceBy,@IsFree,@Price,@Qty,@CreatedBy,GETDATE())";
                        //string dt = DateTime.Today.ToString("dd/MM/yyyy hh:mm:ss");
                        SqlParameter[] param1 =
                        {
                            new SqlParameter("@DealID",DealId),
                            new SqlParameter("@ServiceID",ServiceId),
                            new SqlParameter("@ServiceBy",ServiceBy),
                            new SqlParameter("@IsFree",chkIsFree.Checked),
                            new SqlParameter("@Price",Price),
                            new SqlParameter("@Qty",Qty),
                            new SqlParameter("@CreatedBy",userid)

                        };

                        DataAccessor.ExecuteQuery(sql, param1);
                    }
                    Outpt = "success";
                }
            }
            catch (Exception ex)
            {
                Outpt = "error";
                Message = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "NotifyError('" + Message + "');", true);
            }
            return Outpt;
        }

        #endregion
        protected void drpOutlet2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpOutlet2.SelectedIndex == 0)
                {
                    GetServiceByOutlet(0);
                }
                else
                {
                    GetServiceByOutlet(Convert.ToInt32(drpOutlet2.SelectedValue));
                }
                updOutlet.Update();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NotifyError('" + Message + "');", true);
            }
        }
        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    DataTable dtService = null;
                    if (dtService != null && dtService.Rows.Count > 0)
                    {

                        Model.Deals obj = new Model.Deals();
                        ObjDeals = new DealsBL();
                        obj.DealName = GeneralFunctions.ValidateString(txtDealname.Value.ToString().Trim());
                        obj.DealType = GeneralFunctions.ValidateString(drpDealType.SelectedValue);
                        obj.DealID = hdnDealId.Value == "" ? 0 : GeneralFunctions.ValidateInt(hdnDealId.Value);
                        obj.Validity = GeneralFunctions.ValidateString(txtValidity.Value.ToString().Trim());
                        obj.Description = GeneralFunctions.ValidateString(txtDesc.Value.ToString().Trim());
                        obj.DiscountFlat = GeneralFunctions.ValidateString(txtDiscountAmt.Value.Trim());
                        obj.DiscountPer = GeneralFunctions.ValidateString(txtDiscountper.Value.Trim());
                        obj.DiscountVoucher = GeneralFunctions.ValidateString(txtDiscVoucher.Value.ToString().Trim());
                        obj.IsMemberOnly = drpMember.SelectedValue == "0" ? false : true;
                        obj.CreatedBy = Convert.ToInt32(Session["UserId"]);
                        string DealId = "";
                        string res = ObjDeals.InsertUpdateDeal(obj, ref DealId);


                        if (res == "Success")
                        {
                            if (DealId != "")
                            {
                                //foreach (DataRow r in dtService.Rows)
                                //{
                                InsertDealDetails(dtService, Convert.ToInt32(DealId));
                                //}

                                string FilePath = "ImgDeals/";
                                string ImgName = "";
                                string fileName = "";
                                string ImgPath = "";
                                int DispOrd = 0;
                                string extn = "";
                                if (FuimgFile1.HasFile)
                                {
                                    extn = System.IO.Path.GetExtension(FuimgFile1.FileName);
                                    if (extn != ".jpg" || extn != ".jpeg" || extn != ".bmp" || extn != ".png")
                                    {
                                        Message = "Invalid file, Please upload only .jpg, .jpeg, .bmp or .png file";
                                        goto Error;
                                    }
                                    if (FuimgFile1.PostedFile.ContentLength > 2024)
                                    {
                                        lblImgSize.InnerText = "Please upload only 200kb size file";
                                        lblImgSize.Visible = true;
                                        goto Error;
                                    }
                                    ImgName = fnFileName("_Deals", System.IO.Path.GetExtension(FuimgFile1.FileName));
                                    ImgPath = SaveImagesToPath(FuimgFile1, FilePath, ImgName);
                                    fileName = imgName1.Value; //dtService.Rows[0]["FileName"].ToString();
                                    DispOrd = txtDisplayOrd1.Value == "" ? 0 : Convert.ToInt32(txtDisplayOrd1.Value);
                                    StoreFile(fileName, ImgPath, extn, "Image1", "Deals", Convert.ToInt32(DealId), DispOrd, Convert.ToInt32(Session["UserId"]));
                                }
                                //if (FuimgFile2.HasFile)
                                //{
                                //    extn = System.IO.Path.GetExtension(FuimgFile2.FileName);
                                //    if (extn != "jpg" || extn != "jpeg" || extn != "bmp" || extn != "png")
                                //    {
                                //        Message = "Invalid file, Please upload only .jpg,.jpeg,bmp file";
                                //        goto Error;
                                //    }
                                //    ImgName = fnFileName("_Deals", System.IO.Path.GetExtension(FuimgFile2.FileName));
                                //    ImgPath = SaveImagesToPath(FuimgFile2, FilePath, ImgName);
                                //    fileName = imgName2.Value; //dtService.Rows[0]["FileName"].ToString();
                                //    DispOrd = txtDisplayOrd2.Value == "" ? 0 : Convert.ToInt32(txtDisplayOrd2.Value);
                                //    StoreFile(fileName, ImgPath, extn, "Image1", "Deals", Convert.ToInt32(DealId), DispOrd, Convert.ToInt32(Session["UserId"]));
                                //}
                                //if (FuimgFile3.HasFile)
                                //{
                                //    extn = System.IO.Path.GetExtension(FuimgFile3.FileName);
                                //    if (extn != "jpg" || extn != "jpeg" || extn != "bmp" || extn != "png")
                                //    {
                                //        Message = "Invalid file, Please upload only .jpg,.jpeg,bmp file";
                                //        goto Error;
                                //    }
                                //    ImgName = fnFileName("_Deals", System.IO.Path.GetExtension(FuimgFile3.FileName));
                                //    ImgPath = SaveImagesToPath(FuimgFile3, FilePath, ImgName);
                                //    fileName = imgName3.Value; //dtService.Rows[0]["FileName"].ToString();
                                //    DispOrd = txtDisplayOrd3.Value == "" ? 0 : Convert.ToInt32(txtDisplayOrd3.Value);
                                //    StoreFile(fileName, ImgPath, extn, "Image1", "Deals", Convert.ToInt32(DealId), DispOrd, Convert.ToInt32(Session["UserId"]));
                                //}
                                //if (FuImgFile4.HasFile)
                                //{
                                //    extn = System.IO.Path.GetExtension(FuImgFile4.FileName);
                                //    if (extn != "jpg" || extn != "jpeg" || extn != "bmp" || extn != "png")
                                //    {
                                //        Message = "Invalid file, Please upload only .jpg,.jpeg,bmp file";
                                //        goto Error;
                                //    }
                                //    ImgName = fnFileName("_Deals", System.IO.Path.GetExtension(FuImgFile4.FileName));
                                //    ImgPath = SaveImagesToPath(FuImgFile4, FilePath, ImgName);
                                //    fileName = imgName4.Value; //dtService.Rows[0]["FileName"].ToString();
                                //    DispOrd = txtDisplayOrd4.Value == "" ? 0 : Convert.ToInt32(txtDisplayOrd4.Value);
                                //    StoreFile(fileName, ImgPath, extn, "Image1", "Deals", Convert.ToInt32(DealId), DispOrd, Convert.ToInt32(Session["UserId"]));
                                //}
                                //if (FuImgFile5.HasFile)
                                //{
                                //    extn = System.IO.Path.GetExtension(FuImgFile5.FileName);
                                //    if (extn != "jpg" || extn != "jpeg" || extn != "bmp" || extn != "png")
                                //    {
                                //        Message = "Invalid file, Please upload only .jpg,.jpeg,bmp file";
                                //        goto Error;
                                //    }
                                //    ImgName = fnFileName("_Deals", System.IO.Path.GetExtension(FuImgFile5.FileName));
                                //    ImgPath = SaveImagesToPath(FuImgFile5, FilePath, ImgName);
                                //    fileName = imgName5.Value; //dtService.Rows[0]["FileName"].ToString();
                                //    DispOrd = txtDisplayOrd5.Value == "" ? 0 : Convert.ToInt32(txtDisplayOrd5.Value);
                                //    StoreFile(fileName, ImgPath, extn, "Image1", "Deals", Convert.ToInt32(DealId), DispOrd, Convert.ToInt32(Session["UserId"]));
                                //}
                                //if (FuImgFile6.HasFile)
                                //{
                                //    extn = System.IO.Path.GetExtension(FuImgFile6.FileName);
                                //    if (extn != "jpg" || extn != "jpeg" || extn != "bmp" || extn != "png")
                                //    {
                                //        Message = "Invalid file, Please upload only .jpg,.jpeg,bmp file";
                                //        goto Error;
                                //    }
                                //    ImgName = fnFileName("_Deals", System.IO.Path.GetExtension(FuImgFile6.FileName));
                                //    ImgPath = SaveImagesToPath(FuImgFile6, FilePath, ImgName);
                                //    fileName = imgName6.Value; //dtService.Rows[0]["FileName"].ToString();
                                //    DispOrd = txtDisplayOrd6.Value == "" ? 0 : Convert.ToInt32(txtDisplayOrd6.Value);
                                //    StoreFile(fileName, ImgPath, extn, "Image1", "Deals", Convert.ToInt32(DealId), DispOrd, Convert.ToInt32(Session["UserId"]));
                                //}
                            }
                            else
                            {
                                //Update deal
                            }
                            //Message = "Category details saved";
                            //ScriptManager.RegisterClientScriptBlock(this, GetType(), "msg", "NotifySuccess('" + Message + "') ;window.location.href='Category.aspx';", true);
                        }
                    }
                    else
                    {
                        Message = "Please select services for deal";
                        goto Error;
                    }

                Error:
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NotifyError('" + Message + "');", true);

                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "NotifyError('" + Message + "');", true);
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (IsValid)
            {
                try
                {
                    if (FnValidate())
                    {
                        string ServiceJSON = Request.Form["hdnServiceJson"];
                        DataTable dtService = JsonConvert.DeserializeObject<DataTable>(ServiceJSON);
                        //DataTable dtService = GetServiceData();
                        if (dtService != null && dtService.Rows.Count > 0)
                        {
                            Model.Deals obj = new Model.Deals();
                            ObjDeals = new DealsBL();
                            obj.DealName = GeneralFunctions.ValidateString(txtDealname.Value.ToString().Trim());
                            obj.DealType = GeneralFunctions.ValidateString(drpDealType.SelectedValue);
                            obj.CompanyID = drpOutlet.SelectedValue == "" ? 0 : GeneralFunctions.ValidateInt(drpOutlet.SelectedValue);
                            obj.DealID = hdnDealId.Value == "" ? 0 : GeneralFunctions.ValidateInt(hdnDealId.Value);
                            obj.Validity = GeneralFunctions.ValidateString(txtValidity.Value.ToString().Trim());
                            obj.Description = GeneralFunctions.ValidateString(txtDesc.Value.ToString().Trim());
                            obj.DiscountFlat = GeneralFunctions.ValidateString(txtDiscountAmt.Value.Trim());
                            obj.DiscountPer = GeneralFunctions.ValidateString(txtDiscountper.Value.Trim());
                            obj.DiscountVoucher = GeneralFunctions.ValidateString(txtDiscVoucher.Value.ToString().Trim());
                            obj.MemberType = GeneralFunctions.ValidateString(drpMemberType.SelectedValue);
                            obj.IsMemberOnly = drpMember.SelectedValue == "0" ? false : true;
                            obj.Active = drpActive.SelectedValue == "0" ? false : true;
                            obj.CreatedBy = Convert.ToInt32(Session["UserId"]);
                            obj.Remark = GeneralFunctions.ValidateString(txtRemark.Value.Trim());
                            string extn = "";
                            string DealId = ""; int DispOrd = 0;
                            string res = ObjDeals.InsertUpdateDeal(obj, ref DealId);
                            string ImgPath = "";
                            if (res == "Success")
                            {
                                string date = string.Format("{0:ddMMyyyyhhmmss}", DateTime.Now);
                                string FileLoc = @"ImgDeals"; //@"C:\Users\kasif\Downloads\ImgServices\"; //@"http$//echofeel.com/yuanver02/ImgServices/";
                                if (DealId != "")
                                {
                                    foreach (DataRow r in dtService.Rows)
                                    {
                                        InsertDealDetails(dtService, Convert.ToInt32(DealId));
                                    }
                                    if (hdnDealId.Value == "")
                                    {
                                        if (FuimgFile1.HasFile)
                                        {
                                            extn = System.IO.Path.GetExtension(FuimgFile1.FileName);
                                            if (extn != ".jpg" && extn != ".jpeg" && extn != ".bmp" && extn != ".png")
                                            {
                                                Message = "Invalid file, Please upload only .jpg, .jpeg, .bmp or .png file";
                                                goto Error;
                                            }
                                            //if (FuimgFile1.PostedFile.ContentLength > 2024)
                                            //{
                                            //    lblImgSize.InnerText = "Please upload only 200kb size file";
                                            //    lblImgSize.Visible = true;
                                            //    goto Error;
                                            //}
                                            DispOrd = txtDisplayOrd1.Value == "" ? 0 : Convert.ToInt32(txtDisplayOrd1.Value);

                                            ImgPath = "Service -" + date;
                                            string ImgExt = System.IO.Path.GetExtension(FuimgFile1.PostedFile.FileName);
                                            byte[] imgSave;
                                            imgSave = GeneralFunctions._ImageResize(751, 503, FuimgFile1.PostedFile.InputStream, ImgPath, FileLoc);
                                            ImgPath = ImgPath + ImgExt;
                                            string path = string.Format(HttpContext.Current.Server.MapPath("~/{0}/"), FileLoc);
                                            //System.IO.File.WriteAllBytes(Path.Combine(FileLoc,ImgPath), imgSave);
                                            using (var client = new WebClient())
                                            {
                                                string ftpUsername = "FTPEchofeel";
                                                string ftpPassword = "C0Rem789Gt";
                                                client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                                                string LocalPath = Path.Combine(path, ImgPath);
                                                string ftpPath = Path.Combine("ftp://91.109.247.108/YuanMobileApp/YuanMobileApp/ImgDeals/", ImgPath);
                                                client.UploadFile(ftpPath, WebRequestMethods.Ftp.UploadFile, LocalPath);
                                            }
                                            StoreFile(imgName1.Value, ImgPath, extn, "Deals Image", "Deals", Convert.ToInt32(DealId), DispOrd, Convert.ToInt32(Session["UserId"]));
                                        }
                                        Message = "Deal saved successfully";
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NotifySuccess('" + Message + "');window.location ='Deals.aspx'", true);
                                    }
                                    else if (hdnDealId.Value != "")
                                    {
                                        if (FuimgFile1.HasFile)
                                        {
                                            ImgPath = "Service -" + date;
                                            string ImgExt = System.IO.Path.GetExtension(FuimgFile1.PostedFile.FileName);
                                            byte[] imgSave;
                                            imgSave = GeneralFunctions._ImageResize(751, 503, FuimgFile1.PostedFile.InputStream, ImgPath, FileLoc);
                                            ImgPath = ImgPath + ImgExt;
                                            string path = string.Format(HttpContext.Current.Server.MapPath("~/{0}/"), FileLoc);
                                            extn = System.IO.Path.GetExtension(FuimgFile1.FileName);
                                            using (var client = new WebClient())
                                            {
                                                string ftpUsername = "FTPEchofeel";
                                                string ftpPassword = "C0Rem789Gt";
                                                client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                                                string LocalPath = Path.Combine(path, ImgPath);
                                                string ftpPath = Path.Combine("ftp://91.109.247.108/YuanMobileApp/YuanMobileApp/ImgDeals/", ImgPath);
                                                client.UploadFile(ftpPath, WebRequestMethods.Ftp.UploadFile, LocalPath);
                                            }
                                            StoreFile(imgName1.Value, ImgPath, extn, "Deals Image", "Deals", Convert.ToInt32(DealId), DispOrd, Convert.ToInt32(Session["UserId"]));
                                        }
                                        else
                                        {
                                            if (hdnImage1.Value != "")
                                            {
                                                ImgPath = hdnImage1.Value;
                                            }
                                        }
                                        Message = "Deal updated successfully";
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NotifySuccess('" + Message + "');window.location='Deals.aspx';", true);
                                        //ScriptManager.RegisterClientScriptBlock(this, GetType(), Guid.NewGuid().ToString(), "NotifySuccess('" + Message + "') ;window.location.href='Deals.aspx';", true);
                                    }


                                    //if (FuimgFile2.HasFile)
                                    //{
                                    //    extn = System.IO.Path.GetExtension(FuimgFile2.FileName);
                                    //    if (extn != "jpg" || extn != "jpeg" || extn != "bmp" || extn != "png")
                                    //    {
                                    //        Message = "Invalid file, Please upload only .jpg,.jpeg,bmp file";
                                    //        goto Error;
                                    //    }
                                    //    ImgName = fnFileName("_Deals", System.IO.Path.GetExtension(FuimgFile2.FileName));
                                    //    ImgPath = SaveImagesToPath(FuimgFile2, FilePath, ImgName);
                                    //    fileName = imgName2.Value; //dtService.Rows[0]["FileName"].ToString();
                                    //    DispOrd = txtDisplayOrd2.Value == "" ? 0 : Convert.ToInt32(txtDisplayOrd2.Value);
                                    //    StoreFile(fileName, ImgPath, extn, "Image1", "Deals", Convert.ToInt32(DealId), DispOrd, Convert.ToInt32(Session["UserId"]));
                                    //}
                                    //if (FuimgFile3.HasFile)
                                    //{
                                    //    extn = System.IO.Path.GetExtension(FuimgFile3.FileName);
                                    //    if (extn != "jpg" || extn != "jpeg" || extn != "bmp" || extn != "png")
                                    //    {
                                    //        Message = "Invalid file, Please upload only .jpg,.jpeg,bmp file";
                                    //        goto Error;
                                    //    }
                                    //    ImgName = fnFileName("_Deals", System.IO.Path.GetExtension(FuimgFile3.FileName));
                                    //    ImgPath = SaveImagesToPath(FuimgFile3, FilePath, ImgName);
                                    //    fileName = imgName3.Value; //dtService.Rows[0]["FileName"].ToString();
                                    //    DispOrd = txtDisplayOrd3.Value == "" ? 0 : Convert.ToInt32(txtDisplayOrd3.Value);
                                    //    StoreFile(fileName, ImgPath, extn, "Image1", "Deals", Convert.ToInt32(DealId), DispOrd, Convert.ToInt32(Session["UserId"]));
                                    //}
                                    //if (FuImgFile4.HasFile)
                                    //{
                                    //    extn = System.IO.Path.GetExtension(FuImgFile4.FileName);
                                    //    if (extn != "jpg" || extn != "jpeg" || extn != "bmp" || extn != "png")
                                    //    {
                                    //        Message = "Invalid file, Please upload only .jpg,.jpeg,bmp file";
                                    //        goto Error;
                                    //    }
                                    //    ImgName = fnFileName("_Deals", System.IO.Path.GetExtension(FuImgFile4.FileName));
                                    //    ImgPath = SaveImagesToPath(FuImgFile4, FilePath, ImgName);
                                    //    fileName = imgName4.Value; //dtService.Rows[0]["FileName"].ToString();
                                    //    DispOrd = txtDisplayOrd4.Value == "" ? 0 : Convert.ToInt32(txtDisplayOrd4.Value);
                                    //    StoreFile(fileName, ImgPath, extn, "Image1", "Deals", Convert.ToInt32(DealId), DispOrd, Convert.ToInt32(Session["UserId"]));
                                    //}
                                    //if (FuImgFile5.HasFile)
                                    //{
                                    //    extn = System.IO.Path.GetExtension(FuImgFile5.FileName);
                                    //    if (extn != "jpg" || extn != "jpeg" || extn != "bmp" || extn != "png")
                                    //    {
                                    //        Message = "Invalid file, Please upload only .jpg,.jpeg,bmp file";
                                    //        goto Error;
                                    //    }
                                    //    ImgName = fnFileName("_Deals", System.IO.Path.GetExtension(FuImgFile5.FileName));
                                    //    ImgPath = SaveImagesToPath(FuImgFile5, FilePath, ImgName);
                                    //    fileName = imgName5.Value; //dtService.Rows[0]["FileName"].ToString();
                                    //    DispOrd = txtDisplayOrd5.Value == "" ? 0 : Convert.ToInt32(txtDisplayOrd5.Value);
                                    //    StoreFile(fileName, ImgPath, extn, "Image1", "Deals", Convert.ToInt32(DealId), DispOrd, Convert.ToInt32(Session["UserId"]));
                                    //}
                                    //if (FuImgFile6.HasFile)
                                    //{
                                    //    extn = System.IO.Path.GetExtension(FuImgFile6.FileName);
                                    //    if (extn != "jpg" || extn != "jpeg" || extn != "bmp" || extn != "png")
                                    //    {
                                    //        Message = "Invalid file, Please upload only .jpg,.jpeg,bmp file";
                                    //        goto Error;
                                    //    }
                                    //    ImgName = fnFileName("_Deals", System.IO.Path.GetExtension(FuImgFile6.FileName));
                                    //    ImgPath = SaveImagesToPath(FuImgFile6, FilePath, ImgName);
                                    //    fileName = imgName6.Value; //dtService.Rows[0]["FileName"].ToString();
                                    //    DispOrd = txtDisplayOrd6.Value == "" ? 0 : Convert.ToInt32(txtDisplayOrd6.Value);
                                    //    StoreFile(fileName, ImgPath, extn, "Image1", "Deals", Convert.ToInt32(DealId), DispOrd, Convert.ToInt32(Session["UserId"]));
                                    //}
                                }
                                else
                                {
                                    //deal not created
                                    Message = res;
                                    ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "NotifySuccess('" + Message + "') ;window.location.href='Deals.aspx';", true);
                                }
                            }

                            //Message = "Category details saved";
                            //ScriptManager.RegisterClientScriptBlock(this, GetType(), Guid.NewGuid().ToString(), "NotifySuccess('" + Message + "') ;window.location.href='Category.aspx';", true);
                        }
                        else
                        {
                            Message = "Please select services for deal";
                            goto Error;
                        }
                    }
                    else
                    {
                        goto Error;
                    }

                Error:
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NotifyError('" + Message + "');", true);

                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "NotifyError('" + Message + "');", true);
                }

            }
        }
    }
}