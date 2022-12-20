using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Yuan.DA;

namespace Yuan.BL
{
    public class StaffBL
    {
        public string InsertUpdateStaff(Model.Staff objStaff)
        {
            //objCompayDL = new CompanyDL();
            DataTable dt;
            string res = "";
            if (objStaff.StaffID > 0)
            {
                dt = StaffDL.UpdateStaff(objStaff);
                if (dt.Rows[0]["RETVAL"].ToString() == "UPDATE")
                {
                    res = "Success";
                    //ServiceID = 0;
                }
            }
            else
            {
                dt = StaffDL.insertStaff(objStaff);
                if (dt.Rows[0]["RETVAL"].ToString() == "INSERT")
                {
                    res = "Success";
                }
            }

            return res;
        }

        public DataTable getStaffDetails(int SId = 0)
        {
            DataTable dt;
            try
            {
                dt = StaffDL.GetStafflist(SId);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
        public string DeleteStaffbyID(int Staffid)
        {
            string res;
            try
            {
                DataTable dt = StaffDL.DeleteStaff(Staffid);
                if (dt.Rows[0]["RETVAL"].ToString() == "delete")
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
                res = "error";
                throw new Exception(ex.Message);
            }
            return res;
        }
    }
}