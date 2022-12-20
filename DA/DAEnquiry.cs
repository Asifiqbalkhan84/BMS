using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Yuan.Model;

namespace Yuan.DA
{
    public class DAEnquiry
    {
        public static DataTable selectEnquiry(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_select_enquiry", param);
            return dt;
        }

        public static DataTable insertEnquiry(Enquiry Obj)
        {
            SqlParameter[] param =
            {
            //new SqlParameter("@UserID",Obj.UserId),
            new SqlParameter("@Enquiry",Obj.EnquiryData),
            new SqlParameter("@Source",Obj.Source),
            new SqlParameter("@SourceDetails",GeneralFunctions.ValidateString(Obj.SourceDetails)),
            new SqlParameter("@NameofGuest",Obj.NameofGuest),
            new SqlParameter("@MobileNo",Obj.MobileNo),
            new SqlParameter("@EmailID",Obj.EmailID),
            new SqlParameter("@OutletID",Obj.OutletID),
            new SqlParameter("@StaffID",Obj.StaffID),
            new SqlParameter("@Location",Obj.Location),
            new SqlParameter("@OtherLocationDetails",Obj.OtherLocationDetails),
            new SqlParameter("@InterestedIn",Obj.InterestedIn),
            new SqlParameter("@Comments",Obj.Comments)
            //new SqlParameter("@Active",Obj.Active),
            
        };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_insert_Enquiry", param);
            return dt;
        }

        public static DataTable updateEnquiry(Enquiry Obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@EnquiryId",Obj.EnquiryID),
                new SqlParameter("@Enquiry",Obj.EnquiryData),
                new SqlParameter("@Source",Obj.Source),
                new SqlParameter("@SourceDetails",GeneralFunctions.ValidateString(Obj.SourceDetails)),
                new SqlParameter("@NameofGuest",Obj.NameofGuest),
                new SqlParameter("@MobileNo",Obj.MobileNo),
                new SqlParameter("@EmailID",Obj.EmailID),
                new SqlParameter("@OutletID",Obj.OutletID),
                new SqlParameter("@StaffID",Obj.StaffID),
                new SqlParameter("@Location",Obj.Location),
                new SqlParameter("@OtherLocationDetails",Obj.OtherLocationDetails),
                new SqlParameter("@InterestedIn",Obj.InterestedIn),
                new SqlParameter("@Comments",Obj.Comments)
                //new SqlParameter("@Active",Obj.Active),           

            };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_update_enquiry", param);
            return dt;
        }

        public static DataTable deleteEnquiry(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EID", SqlDbType.Int);
            param[0].Value = ID;

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_delete_enquiry", param);
            return dt;
        }

    }
}