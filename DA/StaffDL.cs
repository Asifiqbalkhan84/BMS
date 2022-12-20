using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Yuan.DA
{
    public class StaffDL
    {
        static SqlDateTime sqlDateTimeNull = SqlDateTime.Null;
        public static DataTable GetStafflist(int SID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@SID", SID)
            };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_select_staffdetails", param);
            return dt;
        }
                
        public static DataTable insertStaff(Model.Staff ObjStaff)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@StaffName", ObjStaff.StaffName),
                new SqlParameter("@CompanyID", ObjStaff.CompanyID),
                new SqlParameter("@Department", ObjStaff.Department),
                new SqlParameter("@ContactPerson", ObjStaff.ContactPerson),
                new SqlParameter("@Landline", ObjStaff.Landline),
                new SqlParameter("@MobileNo", ObjStaff.MobileNo),
                new SqlParameter("@Designation", ObjStaff.Designation),
                new SqlParameter("@DateofJoining", ObjStaff.DateofJoining == "" ? sqlDateTimeNull : Convert.ToDateTime(ObjStaff.DateofJoining)),
                new SqlParameter("@EmailID", ObjStaff.EmailID),
                new SqlParameter("@Extension", ObjStaff.Extension),
                new SqlParameter("@Active", ObjStaff.Active),
                new SqlParameter("@CreatedBy", ObjStaff.UserId)
            };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_insert_staff", param);
            return dt;
        }

        public static DataTable UpdateStaff(Model.Staff ObjStaff)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@StaffID", ObjStaff.StaffID),
                new SqlParameter("@StaffName", ObjStaff.StaffName),
                new SqlParameter("@CompanyID", ObjStaff.CompanyID),
                new SqlParameter("@Department", ObjStaff.Department),
                new SqlParameter("@Designation", ObjStaff.Designation),
                new SqlParameter("@ContactPerson", ObjStaff.ContactPerson),
                new SqlParameter("@Landline", ObjStaff.Landline),
                new SqlParameter("@MobileNo", ObjStaff.MobileNo),
                new SqlParameter("@DateofJoining", ObjStaff.DateofJoining == "" ? sqlDateTimeNull : Convert.ToDateTime(ObjStaff.DateofJoining)),
                new SqlParameter("@EmailID", ObjStaff.EmailID),
                new SqlParameter("@Extension", ObjStaff.Extension),
                new SqlParameter("@Active", ObjStaff.Active),
                new SqlParameter("@UpdatedBy", ObjStaff.UserId)
            };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_update_staff", param);
            return dt;
        }

        public static DataTable DeleteStaff(int SId)
        {
            DataTable dt = null;
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@SId",SId)
                };
                dt = new DataTable();
                dt = DataAccessor.ExecuteProcDataTable("sp_delete_staff", param);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
    }
}