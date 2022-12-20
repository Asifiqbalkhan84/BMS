using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Yuan.DA
{
    public class MasterDataDL
    {
        public static DataTable GetMasterData(string Action, int ID)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Action", SqlDbType.VarChar);
            param[0].Value = Action;

            param[1] = new SqlParameter("@ID", SqlDbType.Int);
            param[1].Value = ID;

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_Select_MasterData", param);
            return dt;
        }
    }
}