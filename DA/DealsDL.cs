using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Yuan.DA
{
    public class DealsDL
    {
       static SqlDateTime? Sqldt = new SqlDateTime();
        public static DataTable InsertDeal(Model.Deals ObjDeal)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@DealName", ObjDeal.DealName),
                new SqlParameter("@Description", ObjDeal.Description),
                new SqlParameter("@Validity", ObjDeal.Validity== "" ? Sqldt : Convert.ToDateTime(ObjDeal.Validity)),
                new SqlParameter("@DiscountPer", GeneralFunctions._parseStringToDecimal(ObjDeal.DiscountPer)),
                new SqlParameter("@DiscountFlat", GeneralFunctions._parseStringToDecimal(ObjDeal.DiscountFlat)),
                new SqlParameter("@DiscountVoucher", ObjDeal.DiscountVoucher),
                new SqlParameter("@IsMemberOnly", ObjDeal.IsMemberOnly),
                new SqlParameter("@MemberType", ObjDeal.MemberType),
                new SqlParameter("@DealType", ObjDeal.DealType),
                new SqlParameter("@Active", ObjDeal.Active),
                new SqlParameter("@Remark", ObjDeal.Remark),
                new SqlParameter("@CreatedBy", ObjDeal.CreatedBy)
            };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_insert_deal", param);
            return dt;
        }

        public static DataTable UpdateDeal(Model.Deals ObjDeal)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@DealID", ObjDeal.DealID),
                //new SqlParameter("@DealDetailID", ObjDeal.DealDetailID),
                new SqlParameter("@DealName", ObjDeal.DealName),
                new SqlParameter("@Description", ObjDeal.Description),
                new SqlParameter("@Validity", ObjDeal.Validity),
                new SqlParameter("@DiscountPer", GeneralFunctions._parseStringToDecimal(ObjDeal.DiscountPer)),
                new SqlParameter("@DiscountFlat", GeneralFunctions._parseStringToDecimal(ObjDeal.DiscountFlat)),
                new SqlParameter("@DiscountVoucher", ObjDeal.DiscountVoucher),
                new SqlParameter("@IsMemberOnly", ObjDeal.IsMemberOnly),
                new SqlParameter("@MemberType", ObjDeal.MemberType),
                new SqlParameter("@DealType", ObjDeal.DealType),
                new SqlParameter("@ServiceID", ObjDeal.ServiceID),
                new SqlParameter("@IsFree", ObjDeal.IsFree),                
                new SqlParameter("@Active", ObjDeal.Active),
                new SqlParameter("@Remark", ObjDeal.Remark),
                new SqlParameter("@UpdatedBy", ObjDeal.UpdatedBy)
            };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_update_deal", param);
            return dt;
        }

        public static DataTable DeleteDeal(int DealId)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@DealID",DealId)
            };

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_delete_deal", param);
            return dt;
        }

        public static DataTable GetDealData(int DealId = 0)
        {
            DataTable dt = null;
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@DealId",DealId)
                };
                 dt= DataAccessor.ExecuteProcDataTable("sp_select_deals_byId", param);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        public static DataTable GetDealsList(int DealId = 0)
        {
            DataTable dt = null;
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@DealId",DealId)
                };
                dt = DataAccessor.ExecuteProcDataTable("sp_select_deals", param);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        public static DataTable GetServicesByCid(int CID)
        {
            try
            {
                SqlParameter[] param =
                    {new SqlParameter("@CID",CID)};
                return DataAccessor.ExecuteProcDataTable("sp_get_service_by_Outlet", param);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GetServiceData(int SID)
        {
            try
            {
                SqlParameter[] param =
                    {new SqlParameter("@SID",SID)};
                return DataAccessor.ExecuteProcDataTable("sp_get_service_data_byId", param);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetDealsInfo(int DealId = 0)
        {
            DataTable dt = null;
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@DealId",DealId)
                };
                dt = DataAccessor.ExecuteProcDataTable("sp_get_Deal_info", param);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        public static DataTable GetServiceByDealId(int DealID)
        {
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@DealId", SqlDbType.Int);
            param[0].Value = GeneralFunctions.ValidateInt(DealID);

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_get_service_by_did", param);

            return dt;
        }

        public static DataTable selectDealsByType(int DealID, string DealType)
        {
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@DealID", SqlDbType.Int);
            param[0].Value = GeneralFunctions.ValidateInt(DealID);

            param[1] = new SqlParameter("@DealType", SqlDbType.VarChar);
            param[1].Value = GeneralFunctions.ValidateString(DealType);

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_Web_select_Deals", param);

            return dt;
        }

        public static DataTable selectDealDetails(int DealID)
        {
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@DealID", SqlDbType.Int);
            param[0].Value = GeneralFunctions.ValidateInt(DealID);

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_select_DealServiceDetails", param);

            return dt;
        }

    }
}