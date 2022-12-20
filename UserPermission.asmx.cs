using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yuan.BL;
using System.Web.Services;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Runtime.Remoting.Contexts;

namespace Yuan
{
    /// <summary>
    /// Summary description for UserPermission
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [ScriptService]
    public class UserPermission : System.Web.Services.WebService
    {
        string json;

        [WebMethod]
        public string GetUserPermission(int UserId)
        {
            UserRoleBL objUser = new UserRoleBL();
            DataTable dtSelect = objUser.GetUserPermissions("GetPermissionsByID", UserId);
            CustList(dtSelect);
            return json;
        }

        public void CustList(DataTable dt)
        {
            List<Menu> list = new List<Menu>();
            foreach (DataRow dr in dt.Rows)
            {                
                var menu = new Menu
                {
                    ID = Convert.ToInt32(dr["ModID"]),
                    ModuleName = dr["ModuleName"].ToString(),
                    //Url = dr["Url"].ToString(),
                    ParentID = dr["ParentID"] != DBNull.Value ? Convert.ToInt32(dr["ParentID"]) : (int?)null,
                    FullP = dr["FullPerm"] != DBNull.Value ? Convert.ToBoolean(dr["FullPerm"]) : false,
                    AddP = dr["AddPerm"] != DBNull.Value ? Convert.ToBoolean(dr["AddPerm"]) : false,
                    ViewP = dr["ViewPerm"] != DBNull.Value ? Convert.ToBoolean(dr["ViewPerm"]) : false,
                    EditP = dr["EditPerm"] != DBNull.Value ? Convert.ToBoolean(dr["EditPerm"]) : false,
                    DeleteP = dr["DeletePerm"] != DBNull.Value ? Convert.ToBoolean(dr["DeletePerm"]) : false,
                    ExportP = dr["ExportPerm"] != DBNull.Value ? Convert.ToBoolean(dr["ExportPerm"]) : false
                    //IsActive = Convert.ToBoolean(dr["IsActive"])
                };
                list.Add(menu);
            }

            var mainList = GetMenuTree(list, null);

            var js = new JavaScriptSerializer();
            //Context.Response.Write(js.Serialize(mainList));
            json = js.Serialize(mainList);
        }
        public void JsonCall(DataTable dt)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            json = js.Serialize(rows);
        }

        private List<Menu> GetMenuTree(List<Menu> list, int? parent)
        {
            return list.Where(x => x.ParentID == parent).Select(x => new Menu
            {
                ID = x.ID,
                ModuleName = x.ModuleName,
                Url = x.Url,
                ParentID = x.ParentID,
                IsActive = x.IsActive,
                FullP = x.FullP,
                AddP = x.AddP,
                ViewP = x.ViewP,
                EditP = x.EditP,
                DeleteP = x.DeleteP,
                ExportP = x.ExportP,
                List = GetMenuTree(list, x.ID)
            }).ToList();
        }
    }

    public class Menu
    {
        public int ID { get; set; }
        public int? ParentID { get; set; }
        public string ModuleName { get; set; }
        public string Url { get; set; }
        public string ParentMod { get; set; }
        public bool IsActive { get; set; }
        public bool FullP { get; set; }
        public bool AddP { get; set; }
        public bool ViewP { get; set; }
        public bool EditP { get; set; }
        public bool ExportP { get; set; }
        public bool DeleteP { get; set; }
        public List<Menu> List { get; set; }
    }
}
