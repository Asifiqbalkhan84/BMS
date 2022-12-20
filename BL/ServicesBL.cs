using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Yuan.DA;

namespace Yuan.BL
{
    public class ServicesBL
    {
        public string InsertUpdateService(Model.Service objService,ref int ServiceID)
        {
            //objCompayDL = new CompanyDL();
            DataTable dt;
            string res = "";
            if (objService.ServiceID > 0)
            {
                dt = ServicesDL.UpdateService(objService);
                if (dt.Rows[0]["RETVAL"].ToString() == "UPDATE")
                {                   
                    res = "Success";
                    ServiceID = 0;
                }
            }
            else
            {
                dt = ServicesDL.InsertService(objService);
                if (dt.Rows[0]["RETVAL"].ToString() == "INSERT")
                {
                    res = "Success";
                    ServiceID = Convert.ToInt32(dt.Rows[0]["ServiceID"].ToString());
                }
            }

            return res;
        }

        public string DeleteService(int SID)
        {
            string res = "";
            DataTable dt = ServicesDL.DeleteService(SID);
            if (dt.Rows[0]["RETVAL"].ToString() == "DELETE")
            {
                res = "Success";
            }
            return res;
        }

        public DataTable GetServiceData(int sid = 0)
        {
            DataTable dt = null;
            try
            {
                dt = ServicesDL.GetServiceData(sid);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public DataTable GetFiles(int Id, string Category)
        {
            DataTable dt = ServicesDL.GetFiles(Id,Category);
            return dt;
        }
    }
}