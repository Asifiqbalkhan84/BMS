using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Yuan.DA;

namespace Yuan.BL
{
    public class CompanyBL
    {
        CompanyDL objCompayDL = null;
        public string InsertUpdateCompany(Model.Company objCompany)
        {
            objCompayDL = new CompanyDL();
            DataTable dt;
            string res = "";
            if (objCompany.CompanyID >0)
            {
                dt = CompanyDL.UpdateCompany(objCompany);
                if (dt.Rows[0]["RETVAL"].ToString() == "UPDATE")
                {
                    res = "Success";
                }
                
            }
            else
            {
                dt = CompanyDL.insertCompany(objCompany);
                if (dt.Rows[0]["RETVAL"].ToString() == "INSERT")
                {
                    res = "Success";
                }
            }

            return res;
        }

        public DataTable GetCompanyData(int cid = 0)
        {
            DataTable dt = null;
            try
            {
                dt = CompanyDL.GetCompanyDet(cid);
            }
            catch (Exception ex)
            {

            }            
            return dt;
        }

        public string DeleteCompany(ref string str,int CompanyId)
        {
            string res = "";
            try
            {
                DataTable dt = CompanyDL.DeleteCompany(ref str, CompanyId);
                if (dt.Rows[0]["RETVAL"].ToString() == "DELETE")
                {
                    res = "Success";
                }
            }
            catch (Exception ex)
            {
                str = ex.Message;
            }
           
            return res;
        }
    }


}