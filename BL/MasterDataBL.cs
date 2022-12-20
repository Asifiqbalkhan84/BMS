using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Yuan.DA;
namespace Yuan.BL
{
    public class MasterDataBL
    {
        public DataTable GetMasterData(string Action, int ID)
        {
            return MasterDataDL.GetMasterData(GeneralFunctions.ValidateString(Action), GeneralFunctions.ValidateInt(ID));
        }
    }
}