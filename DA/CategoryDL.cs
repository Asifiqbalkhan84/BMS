using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Yuan.DA
{
    public class CategoryDL
    {
        public static DataTable GetCategorylist(int CID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@CId", CID)
            };
            DataTable dt = DataAccessor.ExecuteQueryDataTable("sp_select_category", param);
            return dt;
        }
        //For Grid View
        public static DataTable GetCategory(int CID = 0)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@CID", CID)
            };
            DataTable dt = DataAccessor.ExecuteQueryDataTable("sp_get_category_det", param);
            return dt;            
        }
        public static DataTable insertCategory(Model.Category ObjCategory)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@CatName", ObjCategory.CatName),
                new SqlParameter("@ParentId", ObjCategory.ParentID),
                new SqlParameter("@Active", ObjCategory.Active),
                new SqlParameter("@CreatedBy", ObjCategory.CreatedBy)
            };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_insert_category", param);
            return dt;
        }

        public static DataTable UpdateCategory(Model.Category ObjCategory)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@CatID", ObjCategory.CatID),
                new SqlParameter("@CatName", ObjCategory.CatName),
                new SqlParameter("@ParentID", ObjCategory.ParentID),
                new SqlParameter("@Active", ObjCategory.Active),
                new SqlParameter("@UpdatedBy", ObjCategory.UpdatedBy)
            };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_update_category", param);
            return dt;
        }

        public static DataTable DeleteCategory(int CId)
        {
            DataTable dt = null;
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@CId",CId)
                };
                dt = new DataTable();
                dt = DataAccessor.ExecuteProcDataTable("sp_delete_category", param);
            }
            catch (Exception ex)
            {
                
            }
            return dt;
        }

    }
}