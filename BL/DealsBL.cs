using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yuan.DA;
using System.Data;

namespace Yuan.BL
{
    public class DealsBL
    {
        public string InsertUpdateDeal(Model.Deals objDeal,ref string DealId)
        {
            //objCompayDL = new CompanyDL();
            DataTable dt;
            string res = "";
            if (objDeal.DealID > 0)
            {
                dt = DealsDL.UpdateDeal(objDeal);
                if (dt.Rows[0]["RETVAL"].ToString() == "UPDATE")
                {
                    res = "Success";
                    DealId = dt.Rows[0]["DealId"].ToString();
                }
            }
            else
            {
                dt = DealsDL.InsertDeal(objDeal);
                if (dt.Rows[0]["RETVAL"].ToString() == "INSERT")
                {
                    res = "Success";
                    DealId = dt.Rows[0]["DealId"].ToString();
                }
            }

            return res;
        }

        public string DeleteDeals(int DID)
        {
            string res = "";
            DataTable dt = DealsDL.DeleteDeal(DID);
            if (dt.Rows[0]["RETVAL"].ToString() == "DELETE")
            {
                res = "Success";
            }
            return res;
        }

        public DataTable GetDealsData(int did = 0)
        {
            DataTable dt = null;
            try
            {                
                dt = DealsDL.GetDealsList(did);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        public DataTable GetDealsById(int did = 0)
        {
            DataTable dt = null;
            try
            {                
                dt = DealsDL.GetDealData(did);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        public DataTable GetServicesByCID(int CID)
        {
            DataTable dt = DealsDL.GetServicesByCid(CID);
            return dt;
        }
        public DataTable GetServiceData(int Sid =0)
        {
            DataTable dt = DealsDL.GetServiceData(Sid);
            return dt;
        }
        public DataTable GetDealsInfo(int did = 0)
        {
            DataTable dt = null;
            try
            {
                dt = DealsDL.GetDealsInfo(did);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public DataTable getDeals(int DealID)
        {
            return DealsDL.selectDealsByType(DealID, "");
        }

        public DataTable getDealDetails(int DealID)
        {
            return DealsDL.selectDealDetails(DealID);
        }
        public DataTable GetServiceDetByDeal(int DealId)
        {
            DataTable dt = DealsDL.GetServiceByDealId(DealId);
            return dt;
        }



    }
}