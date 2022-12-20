using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Yuan.DA
{
    public class GuestDL
    {
        static SqlDateTime? Sqldt = new SqlDateTime();
        public static DataTable InsertGuest(Model.Guest ObjGuest)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@Title", ObjGuest.Title),
                new SqlParameter("@FName", ObjGuest.FName),
                new SqlParameter("@LName", ObjGuest.LName),
                new SqlParameter("@MobileNo", ObjGuest.MobileNo),
                new SqlParameter("@LandlineNo", ObjGuest.LandlineNo),
                new SqlParameter("@EmailID", ObjGuest.EmailID),
                new SqlParameter("@AlternateContactNo", ObjGuest.AlternateContactNo),
                new SqlParameter("@AddressLine1", ObjGuest.AddressLine1),
                new SqlParameter("@AddressLine2", ObjGuest.AddressLine2),
                new SqlParameter("@Area", ObjGuest.Area),
                //new SqlParameter("@LandlineNo", ObjGuest.LandlineNo),
                new SqlParameter("@City", ObjGuest.City),
                new SqlParameter("@Postcode", ObjGuest.Postcode),                
                new SqlParameter("@IsActive", ObjGuest.IsActive),
                new SqlParameter("@IsBlacklisted", ObjGuest.IsBlacklisted),
                new SqlParameter("@Source", ObjGuest.Source),
                new SqlParameter("@SourceDetails", ObjGuest.SourceDetails),
                new SqlParameter("@MemberNo", ObjGuest.MemberNo),
                new SqlParameter("@ProfilePhoto", ObjGuest.ProfilePhoto),
                new SqlParameter("@CreatedBy", ObjGuest.UserId)
            };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_insert_guest", param);
            return dt;
        }

        public static DataTable UpdateGuest(Model.Guest ObjGuest)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@GuestID", ObjGuest.GuestID),
                new SqlParameter("@Title", ObjGuest.Title),
                new SqlParameter("@FName", ObjGuest.FName),
                new SqlParameter("@LName", ObjGuest.LName),
                new SqlParameter("@MobileNo", ObjGuest.MobileNo),
                new SqlParameter("@LandlineNo", ObjGuest.LandlineNo),
                new SqlParameter("@EmailID", ObjGuest.EmailID),
                new SqlParameter("@AlternateContactNo", ObjGuest.AlternateContactNo),
                new SqlParameter("@AddressLine1", ObjGuest.AddressLine1),
                new SqlParameter("@AddressLine2", ObjGuest.AddressLine2),
                new SqlParameter("@Area", ObjGuest.Area),                
                new SqlParameter("@City", ObjGuest.City),
                new SqlParameter("@Postcode", ObjGuest.Postcode),
                new SqlParameter("@IsActive", ObjGuest.IsActive),
                new SqlParameter("@IsBlacklisted", ObjGuest.IsBlacklisted),
                new SqlParameter("@Source", ObjGuest.Source),
                new SqlParameter("@SourceDetails", ObjGuest.SourceDetails),
                new SqlParameter("@MemberNo", ObjGuest.MemberNo),
                new SqlParameter("@ProfilePhoto", ObjGuest.ProfilePhoto),
                new SqlParameter("@UpdatedBy", ObjGuest.UserId)
            };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_update_guest", param);
            return dt;
        }

        public static DataTable DeleteGuest(int GuestId)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@GuestId",GuestId)
            };

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_delete_guest", param);
            return dt;
        }

        public static DataTable GetGuestData(int GuestId = 0)
        {
            DataTable dt = null;
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@GuestId",GuestId)
                };
                dt = DataAccessor.ExecuteProcDataTable("sp_select_guest_list", param);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

    }
}