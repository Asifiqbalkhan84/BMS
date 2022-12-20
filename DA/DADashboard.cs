using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Yuan.DA
{
    public class DADashboard
    {
        public static DataTable GetDashboardData(string Action)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@Action", Action)
            };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_select_Dashboard", param);
            return dt;
        }
    }
}