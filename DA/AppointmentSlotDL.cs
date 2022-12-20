using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Yuan.DA
{
    public class AppointmentSlotDL
    {
        static SqlDateTime sqlDateTimeNull = SqlDateTime.Null;
        public static DataTable InsertSlot(Model.Slots ObjSlot)
        {
            //string dov;
            //if (ObjService.SpOfferValidity != "")
            //    dov = GeneralFunctions.ValidateString(ObjService.SpOfferValidity);
            //else
            //{ dov = sqlDateTimeNull; }

            SqlParameter[] param =
            {
                
                //new SqlParameter("@ServiceID", ObjService.ServiceID),
                new SqlParameter("@CompanyID", ObjSlot.CompanyID),
                new SqlParameter("@SlotFromTime", Convert.ToDateTime(ObjSlot.FromTime)),
                new SqlParameter("@SlotToTime", Convert.ToDateTime(ObjSlot.ToTime)),
                new SqlParameter("@NoofSlots", ObjSlot.NoofSlots),
                new SqlParameter("@DayofWeek", ObjSlot.DayofWeek),
                new SqlParameter("@ServiceID", ObjSlot.ServiceID),
                new SqlParameter("@Date", ObjSlot.Date == "" ? sqlDateTimeNull : Convert.ToDateTime(ObjSlot.Date)),
                new SqlParameter("@IsActive", ObjSlot.Active),
                new SqlParameter("@CreatedBy", ObjSlot.userid)
            };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_insert_slot", param);
            return dt;
        }
        public static DataTable UpdateSlot(Model.Slots ObjSlot)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@SlotId", ObjSlot.SlotID),
                new SqlParameter("@CompanyID", ObjSlot.CompanyID),
                new SqlParameter("@SlotFromTime", Convert.ToDateTime(ObjSlot.FromTime)),
                new SqlParameter("@SlotToTime", Convert.ToDateTime(ObjSlot.ToTime)),
                new SqlParameter("@NoofSlots", ObjSlot.NoofSlots),
                new SqlParameter("@DayofWeek", ObjSlot.DayofWeek),
                new SqlParameter("@ServiceID", ObjSlot.ServiceID),
                new SqlParameter("@Date", ObjSlot.Date == "" ? sqlDateTimeNull : Convert.ToDateTime(ObjSlot.Date)),
                new SqlParameter("@IsActive", ObjSlot.Active),                
                new SqlParameter("@UpdatedBy", ObjSlot.userid)
            };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_update_slot", param);
            return dt;
        }

        public static DataTable GetSlots(int SlotId)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@SlotId",SlotId)
            };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_get_slot", param);
            return dt;
        }
        public static DataTable DeleteSlot(int SlotId)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@SlotId",SlotId)
            };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_delete_slot", param);
            return dt;
        }
    }
}