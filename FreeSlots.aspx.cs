using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yuan.DA;

namespace Yuan
{
    public partial class FreeSlots : System.Web.UI.Page
    {
        string CID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["CID"]!=null)
                {
                    CID= Request.QueryString["CID"].ToString();
                }
                loadfreeslots();
            }
        }

        protected void loadfreeslots()
        {
            //
            try
            {
                

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ID", SqlDbType.NVarChar, 50);
                param[0].Value = CID;


                string strSQL = @"SELECT    
								Company.OutletName CompanyName,
                                FORMAT(AR.DateofAppoint ,'MMM/dd/yyyy')DateofAppoint, 
                                CONVERT(varchar(15),APS.SlotFromTime,100)+' - '+CONVERT(varchar(15),APS.SlotToTime,100) Slots, 
                                (company.slots - APS.NoofSlots) as NoofSlots
                                 FROM AppointmentRegister AR  
                                 LEFT JOIN AppointmentSlot APS   
                                 ON AR.SlotID = APS.SlotID  
                                 LEFT JOIN Guest  
                                ON AR.GuestID = Guest.GuestID  
                                LEFT JOIN Company   
                                ON AR.CompanyID = Company.CompanyID  
                                LEFT JOIN StaffDetails SD   
                                ON AR.ServicedBy = SD.StaffID  
                                WHERE (Company.CompanyID = @ID OR ISNULL(@ID,0)= 0 )  
                                ORDER BY AppointID DESC";


                DataTable dtGetMasterData = DataAccessor.ExecuteQueryDataTable(strSQL, param);

                if (dtGetMasterData.Rows.Count > 0)
                {
                    gvfreeslots.DataSource = dtGetMasterData;
                    gvfreeslots.DataBind();
                }
                //Required for jQuery DataTables to work.
                gvfreeslots.UseAccessibleHeader = true;
                gvfreeslots.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (Exception ex)
            {
                //
            }
        }
    }
}