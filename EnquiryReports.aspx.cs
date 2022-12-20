using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using Yuan.BL;
using System.Data;
using System.Data.SqlClient;
using Yuan.DA;

namespace Yuan
{
    public partial class EnquiryReports : System.Web.UI.Page
    {

        string Message = string.Empty;
        public DataTable dt = new DataTable();
        string json;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UserID"] as string))
            {
                if (!IsPostBack)
                {
                    loadenquiryreport();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
                
        }

        [WebMethod]
        public static string GetEnquryList()
        {
            EnquiryReports obj = new EnquiryReports();
            obj.GetEnquiry();
            obj.JsonCall(obj.dt);

            return obj.json;
        }

        public void GetEnquiry()
        {
            //int cid = Session[""]
            BLEnquiry ObjEnquiry = new BLEnquiry();
            dt = ObjEnquiry.GetEnquiryReportList(0);
        }

        [WebMethod]
        public static string DeleteEnquiry(int ID)
        {
            EnquiryReports obj = new EnquiryReports();
            obj.DeleteEnquiryById(ID);
            return obj.json;
        }

        public void DeleteEnquiryById(int id)
        {
            int uid = Convert.ToInt32(Session["UserId"]);
            BLEnquiry ObjEnquiry = new BLEnquiry();
            ObjEnquiry.DeleteEnquiry(id, uid);
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

        protected void loadenquiryreport()
        {

            try
            {
                int id = 0;
                string companyID = HttpContext.Current.Session["CompanyID"].ToString();

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ID", SqlDbType.NVarChar, 50);
                param[0].Value = id;

                param[1] = new SqlParameter("@CompanyID", SqlDbType.NVarChar);
                param[1].Value = companyID;

                string strSQL = @"select FORMAT(Enquiries.Datecreated,'MMM dd yyyy')as EnquiryDate,ISNULL(c.OutletName,'All') Outlet,COUNT(Enquiry)Count,Source
                                from Enquiries 
                                left join Company c 
                                on c.CompanyID = Enquiries.OutletID  
                                left join StaffDetails sd 
                                on sd.StaffID = Enquiries.StaffID 
                                where ISNULL(Enquiries.IsActive,1) = 1 and ISNULL(Enquiries.IsDeleted,0) = 0 and (EnquiryID = @ID OR ISNULL(@ID,0) = 0)";
                               

                if (HttpContext.Current.Session["CompanyID"].ToString() != null && HttpContext.Current.Session["CompanyID"].ToString() != String.Empty)
                {
                    strSQL += " and (c.CompanyID = @CompanyID OR ISNULL(@CompanyID,0)= 0 )";
                }

                strSQL += " Group by FORMAT(Enquiries.Datecreated,'MMM dd yyyy'),c.OutletName,Enquiries.Source,Enquiries.EnquiryID";

                strSQL += " order by Enquiries.EnquiryID desc";

                DataTable dtGetMasterData = DataAccessor.ExecuteQueryDataTable(strSQL, param);

                if (dtGetMasterData.Rows.Count > 0)
                {
                    gvEnquiryReport.DataSource = dtGetMasterData;
                    gvEnquiryReport.DataBind();

                    //Calculate Sum and display in Footer Row
                    //double total = dtGetMasterData.AsEnumerable().Sum(row => row.Field<double>("Count"));
                    //gvEnquiryReport.FooterRow.Cells[1].Text = "Total";
                    //gvEnquiryReport.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    //gvEnquiryReport.FooterRow.Cells[2].Text = total.ToString("N2");
                    //gvEnquiryReport.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                }
                else
                {
                    gvEnquiryReport.DataSource = null;
                    gvEnquiryReport.DataBind();
                }
                //Required for jQuery DataTables to work.
                gvEnquiryReport.UseAccessibleHeader = true;
                gvEnquiryReport.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

      
    }
}