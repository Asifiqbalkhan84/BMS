using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Yuan.DA;

namespace Yuan.BL
{
    public class BLOrders
    {
        public DataTable getOrders(int OrderID = 0)
        {
            DataTable dt;
            try
            {
                dt = OrdersDL.GetOrders(OrderID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public string DeleteOrder(int OrderID)
        {
            string res;
            try
            {
                DataTable dt = OrdersDL.DeleteOrder(OrderID);
                if (dt.Rows[0]["RETVAL"].ToString() == "DELETE")
                {
                    res = "Success";
                }
                else
                {
                    res = "error";
                }
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
            return res;
        }

        public DataTable GetOrderInfo(int OrderID)
        {
            return OrdersDL.GetOrders(GeneralFunctions.ValidateInt(OrderID));
        }

        public DataTable GetOrderDetails(int OrderID)
        {
            return OrdersDL.GetOrderDetails(GeneralFunctions.ValidateInt(OrderID));
        }

        public DataTable GetOrderPayments(int OrderID)
        {
            return OrdersDL.GetOrderPayments(GeneralFunctions.ValidateInt(OrderID));
        }

        public void AddOrderPayments(int OrderID, double AmountPaid, string ModeofPayment, int MemberID)
        {
            OrdersDL.AddOrderPayments(OrderID, AmountPaid, ModeofPayment, MemberID);
        }
    }
}