using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yuan.DA;
using System.Data;

namespace Yuan.BL
{
    public class GuestBL
    {
        public string InsertUpdateGuest(Model.Guest objGuest)
        {
            //objCompayDL = new CompanyDL();
            DataTable dt;
            string res = "";
            if (objGuest.GuestID > 0)
            {
                dt = GuestDL.UpdateGuest(objGuest);
                if (dt.Rows[0]["RETVAL"].ToString() == "UPDATE")
                {
                    res = "Success";
                }
            }
            else
            {
                dt = GuestDL.InsertGuest(objGuest);
                if (dt.Rows[0]["RETVAL"].ToString() == "INSERT")
                {
                    res = "Success";                    
                }
            }

            return res;
        }

        public string DeleteGuest(int GID)
        {
            string res = "";
            DataTable dt = GuestDL.DeleteGuest(GID);
            if (dt.Rows[0]["RETVAL"].ToString() == "DELETE")
            {
                res = "Success";
            }
            return res;
        }

        public DataTable GetGuestData(int gid = 0)
        {
            DataTable dt = null;
            try
            {
                dt = GuestDL.GetGuestData(gid);
            }
            catch (Exception ex)
            {
                
            }
            return dt;
        }
    }
}