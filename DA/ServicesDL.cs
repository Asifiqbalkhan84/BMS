using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace Yuan.DA
{
    public class ServicesDL
    {
        static SqlDateTime sqlDateTimeNull = SqlDateTime.Null;
        public static DataTable InsertService(Model.Service ObjService)
        {
            //string dov;
            //if (ObjService.SpOfferValidity != "")
            //    dov = GeneralFunctions.ValidateString(ObjService.SpOfferValidity);
            //else
            //{ dov = sqlDateTimeNull; }

            SqlParameter[] param =
            {
                
                //new SqlParameter("@ServiceID", ObjService.ServiceID),
                new SqlParameter("@ServiceName", ObjService.ServiceName),
                new SqlParameter("@CompanyID", ObjService.CompanyID),
                new SqlParameter("@CatID", ObjService.CatID),
                new SqlParameter("@ServiceDesc", ObjService.ServiceDesc),
                new SqlParameter("@ServiceHRs", ObjService.ServiceHRs),
                new SqlParameter("@Price", GeneralFunctions._parseStringToDouble(ObjService.Price)),
                new SqlParameter("@SpecialOfferPrice", GeneralFunctions._parseStringToDouble(ObjService.SpecialOfferPrice)),
                new SqlParameter("@SpOfferValidity", ObjService.SpOfferValidity),
                new SqlParameter("@OnlinePrice", GeneralFunctions._parseStringToDouble(ObjService.OnlinePrice)),
                new SqlParameter("@Active", ObjService.Active),
                new SqlParameter("@CreatedBy", ObjService.UserId)
            };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_insert_service", param);
            return dt;
        }
        public static DataTable UpdateService(Model.Service ObjService)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@ServiceID", ObjService.ServiceID),
                new SqlParameter("@ServiceName", ObjService.ServiceName),
                new SqlParameter("@CompanyID", ObjService.CompanyID),
                new SqlParameter("@CatID", ObjService.CatID),
                new SqlParameter("@ServiceDesc", ObjService.ServiceDesc),
                new SqlParameter("@ServiceHRs", ObjService.ServiceHRs),
                new SqlParameter("@Price", ObjService.Price),
                new SqlParameter("@SpecialOfferPrice", ObjService.SpecialOfferPrice),
                new SqlParameter("@SpOfferValidity", ObjService.SpOfferValidity),
                new SqlParameter("@OnlinePrice", ObjService.OnlinePrice),
                new SqlParameter("@Active", ObjService.Active),
                new SqlParameter("@UpdatedBy", ObjService.UserId)
            };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_update_service", param);
            return dt;
        }

        public static DataTable DeleteService(int ServiceId)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@ServiceId",ServiceId)
            };

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_delete_service", param);
            return dt;
        }

        public static DataTable GetServiceData(int ServiceId = 0)
        {
            DataTable dt = null;
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@ServiceId",ServiceId)
                };
                dt = DataAccessor.ExecuteProcDataTable("sp_select_service_list", param);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public static DataTable GetFiles(int Id,string Category)
        {
            DataTable dt = null;
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@FileID",Id),
                    new SqlParameter("@Type",Category)
                };
                dt = DataAccessor.ExecuteProcDataTable("sp_get_files", param);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
    }
}