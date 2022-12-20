using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Yuan.BL;

namespace Yuan
{
    public partial class Users : System.Web.UI.Page
    {
        string Message = string.Empty;
        public DataTable dt = new DataTable();
        string json;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetUserList()
        {
            Users obj = new Users();
            obj.GetUser();
            obj.JsonCall(obj.dt);

            return obj.json;
        }

        public void GetUser()
        {
            //int cid = Session[""]
            UserRoleBL ObjUser = new UserRoleBL();
            dt = ObjUser.GetUserList();

        }

        [WebMethod]
        public static string DeleteUser(int ID)
        {
            Users obj = new Users();
            obj.DeleteUserById(ID);
            obj.DeleteUserPerm(ID);
            return obj.json;
        }

        public void DeleteUserById(int id)
        {
            //int uid = Convert.ToInt32(Session["UserId"]);
            UserRoleBL ObjUser = new UserRoleBL();
            ObjUser.deleteUser(id);
        }
        public void DeleteUserPerm(int id)
        {
            UserRoleBL objuser = new UserRoleBL();
            json = objuser.deleteUserPermission(id);            
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
    }
}
