using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Yuan.DA
{
    public class AppointmentDL
    {
        static SqlDateTime sqlDateTimeNull = SqlDateTime.Null;

        public static DataTable GetBookedAppointments(int AppointmentID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@AppointmentID", SqlDbType.Int);
            param[0].Value = AppointmentID;

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_select_Appointments", param);
            return dt;
        }

        public static DataTable CancelAppointment(int AppointmentID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@AppointmentID", SqlDbType.Int);
            param[0].Value = AppointmentID;

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_delete_Appointment", param);
            return dt;
        }

        public static DataTable GetAppointmentSlots(int CompanyID, string Date, int ServiceID)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Date", SqlDbType.DateTime);
            if (Date != null)
            { param[0].Value = GeneralFunctions.Formated_StringDate(Date); }
            else
            { param[0].Value = sqlDateTimeNull; }

            param[1] = new SqlParameter("@CompanyID", SqlDbType.Int);
            param[1].Value = GeneralFunctions.ValidateInt(CompanyID);

            param[2] = new SqlParameter("@ServiceID", SqlDbType.Int);
            param[2].Value = GeneralFunctions.ValidateInt(ServiceID);

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_Web_select_AppointmentSlot", param);

            return dt;
        }

        public static DataTable AddAppointment(int GuestID, int OrderID, int SlotID, int CompanyID, string Date, string Source, string Remark, int StaffID, int UserID)
        {
            SqlParameter[] param = new SqlParameter[9];

            param[0] = new SqlParameter("@GuestID", SqlDbType.Int);
            param[0].Value = GeneralFunctions.ValidateInt(GuestID);

            param[1] = new SqlParameter("@OrderID", SqlDbType.Int);
            param[1].Value = GeneralFunctions.ValidateInt(OrderID);

            param[2] = new SqlParameter("@SlotID", SqlDbType.Int);
            param[2].Value = GeneralFunctions.ValidateInt(SlotID);

            param[3] = new SqlParameter("@CompanyID", SqlDbType.Int);
            param[3].Value = GeneralFunctions.ValidateInt(CompanyID);

            param[4] = new SqlParameter("@Date", SqlDbType.DateTime);
            if (Date != null)
            { param[4].Value = GeneralFunctions.Formated_StringDate(Date); }
            else
            { param[4].Value = sqlDateTimeNull; }

            param[5] = new SqlParameter("@Source", SqlDbType.VarChar);
            param[5].Value = GeneralFunctions.ValidateString(Source);

            param[6] = new SqlParameter("@Remarks", SqlDbType.VarChar);
            param[6].Value = GeneralFunctions.ValidateString(Remark);

            param[7] = new SqlParameter("@StaffID", SqlDbType.Int);
            param[7].Value = GeneralFunctions.ValidateInt(StaffID);

            param[8] = new SqlParameter("@UserID", SqlDbType.Int);
            param[8].Value = GeneralFunctions.ValidateInt(UserID);

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_insert_Appointment", param);

            return dt;
        }

        public static DataTable UpdateAppointment(int AppointmentD, int GuestID, int OrderID, int SlotID, int CompanyID, string Date, string Source, string Remark, int StaffID, int UserID)
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@AppointmentD", SqlDbType.Int);
            param[0].Value = GeneralFunctions.ValidateInt(AppointmentD);

            param[1] = new SqlParameter("@GuestID", SqlDbType.Int);
            param[1].Value = GeneralFunctions.ValidateInt(GuestID);

            param[2] = new SqlParameter("@OrderID", SqlDbType.Int);
            param[2].Value = GeneralFunctions.ValidateInt(OrderID);

            param[3] = new SqlParameter("@SlotID", SqlDbType.Int);
            param[3].Value = GeneralFunctions.ValidateInt(SlotID);

            param[4] = new SqlParameter("@CompanyID", SqlDbType.Int);
            param[4].Value = GeneralFunctions.ValidateInt(CompanyID);

            param[5] = new SqlParameter("@Date", SqlDbType.DateTime);
            if (Date != null)
            { param[5].Value = GeneralFunctions.Formated_StringDate(Date); }
            else
            { param[5].Value = sqlDateTimeNull; }

            param[6] = new SqlParameter("@Source", SqlDbType.VarChar);
            param[6].Value = GeneralFunctions.ValidateString(Source);

            param[7] = new SqlParameter("@Remarks", SqlDbType.VarChar);
            param[7].Value = GeneralFunctions.ValidateString(Remark);

            param[8] = new SqlParameter("@StaffID", SqlDbType.Int);
            param[8].Value = GeneralFunctions.ValidateInt(StaffID);

            param[9] = new SqlParameter("@UserID", SqlDbType.Int);
            param[9].Value = GeneralFunctions.ValidateInt(UserID);

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_update_Appointment", param);

            return dt;
        }

        public static DataTable GetAppointmentDetails(int AppointmentID, int SlotID)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@AppointmentID", SqlDbType.Int);
            param[0].Value = AppointmentID;

            param[1] = new SqlParameter("@SlotID", SqlDbType.Int);
            param[1].Value = SlotID;

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_select_AppointmentDetails", param);
            return dt;
        }

        public static DataTable AssignStaff(int AppointmentID, int StaffID , string Remark, int UserID)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@AppointmentID", SqlDbType.Int);
            param[0].Value = AppointmentID;

            param[1] = new SqlParameter("@StaffID", SqlDbType.Int);
            param[1].Value = StaffID;

            param[2] = new SqlParameter("@Remark", SqlDbType.VarChar);
            param[2].Value = Remark;

            param[3] = new SqlParameter("@UserID", SqlDbType.Int);
            param[3].Value = UserID;

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_update_Appointment", param);
            return dt;
        }
    }
}