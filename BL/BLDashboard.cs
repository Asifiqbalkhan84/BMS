using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Yuan.DA;

namespace Yuan.BL
{
    public class BLDashboard
    {

        public DataTable GetDashboardData(string Action)
        {
            DataTable dt;
            try
            {
                dt = DADashboard.GetDashboardData(Action);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
    }
}