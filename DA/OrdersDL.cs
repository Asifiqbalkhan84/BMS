using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace Yuan.DA
{
    public class OrdersDL
    {
        public static DataTable GetOrders(int OrderID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@OrderID", SqlDbType.Int);
            param[0].Value = OrderID;

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_select_Orders", param);
            return dt;
        }

        public static DataTable DeleteOrder(int OrderID)
        {
            SqlParameter[] param =
                {
                    new SqlParameter("@OrderID",OrderID)
                };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_delete_Order", param);

            return dt;
        }

        public static DataTable GetOrderDetails(int OrderID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@OrderID", SqlDbType.Int);
            param[0].Value = OrderID;

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_select_OrderDetails", param);
            return dt;

        }

        public static DataTable GetOrderPayments(int OrderID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@OrderID", SqlDbType.Int);
            param[0].Value = OrderID;

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_select_OrderPayments", param);
            return dt;
        }

        public static void AddOrderPayments(int OrderID, double AmountPaid, string ModeofPayment, int MemberID)
        {
            SqlParameter[] param =
                {
                new SqlParameter("@OrderID", OrderID),
                new SqlParameter("@AmountPaid", AmountPaid),
                new SqlParameter("@ModeofPayment", ModeofPayment),
                new SqlParameter("@PaymentBy", MemberID)
            };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_Web_insert_OrderPayments", param);
        }
    }
}