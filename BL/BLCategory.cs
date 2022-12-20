using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yuan.DA;
using System.Data;
namespace Yuan.BL
{
    public class BLCategory
    {
        public string DeleteCategory(int CID)
        {
            string res = "";
            DataTable dt = CategoryDL.DeleteCategory(CID);
            if (dt.Rows[0]["RETVAL"].ToString()=="DELETE")
            {
                res = "Success";
            }
            return res;
        }

        public DataTable GetCategoryData(int cid = 0)
        {
            DataTable dt = null;
            try
            {   
                dt = CategoryDL.GetCategorylist(cid);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        //For Grid View
        public DataTable GetCategorylist(int cid = 0)
        {
            DataTable dt = null;
            try
            {
                dt = CategoryDL.GetCategory(cid);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        public string InsertUpdateCategory(Model.Category objCategory)
        {
            //objCompayDL = new CompanyDL();
            DataTable dt;
            string res = "";
            if (objCategory.CatID > 0)
            {
                dt = CategoryDL.UpdateCategory(objCategory);
                if (dt.Rows[0]["RETVAL"].ToString() == "UPDATE")
                {
                    res = "Success";
                }

            }
            else
            {
                dt = CategoryDL.insertCategory(objCategory);
                if (dt.Rows[0]["RETVAL"].ToString() == "INSERT")
                {
                    res = "Success";
                }
            }

            return res;
        }

    }
}