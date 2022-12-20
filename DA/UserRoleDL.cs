using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Yuan.Model;
namespace Yuan.DA
{
    public class UserRoleDL
    {
        public static DataTable selectUsers(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@UserID", SqlDbType.Int);
            param[0].Value = ID;

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_select_Users", param);
            return dt;
        }

        public static DataTable insertUser(UserAndRole ObjUser)
        {
            SqlParameter[] param =
            {
            //new SqlParameter("@UserID",ObjUser.UserId),
            new SqlParameter("@LevelID",ObjUser.LevelID),
            new SqlParameter("@Name",ObjUser.Name),
            new SqlParameter("@StaffId",ObjUser.StaffID),
            new SqlParameter("@UserType",GeneralFunctions.ValidateString(ObjUser.UType)),
            new SqlParameter("@UserName",ObjUser.UName),
            new SqlParameter("@Password",ObjUser.Pass),
            new SqlParameter("@Active",ObjUser.Active),
                new SqlParameter("@SessionUserID",ObjUser.CreatedBy),
        };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_insert_Users", param);
            return dt;
        }

        public static DataTable updateUser(UserAndRole ObjUser)
        {
            SqlParameter[] param =
            {
            new SqlParameter("@UserId",ObjUser.UserId),
            new SqlParameter("@LevelID",ObjUser.LevelID),
            new SqlParameter("@Name",ObjUser.Name),
            new SqlParameter("@StaffId",ObjUser.StaffID),
            new SqlParameter("@UserType",GeneralFunctions.ValidateString(ObjUser.UType)),
            //new SqlParameter("@UserName",ObjUser.UName),
            new SqlParameter("@Password",ObjUser.Pass),
            new SqlParameter("@Active",ObjUser.Active),
            new SqlParameter("@SessionUserID",ObjUser.UpdatedBy)
        };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_update_Users", param);
            return dt;
        }

        public static DataTable deleteUser(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@UserID", SqlDbType.Int);
            param[0].Value = ID;
           
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_delete_user", param);
            return dt;
        }

        public static DataTable deleteUserPermission(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@UserId", SqlDbType.Int);
            param[0].Value = ID;

            //param[1] = new SqlParameter("@SessionUserID", SqlDbType.Int);
            //param[1].Value = SessionUserID;

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_del_User_Permission", param);
            return dt;
        }
        public static DataTable selectUserPermissions(string Mode, int ID)
        {
            SqlParameter[] param = new SqlParameter[2];            
            param[0] = new SqlParameter("@Action", SqlDbType.VarChar);
            param[0].Value = Mode;
            param[1] = new SqlParameter("@UserID", SqlDbType.Int);
            param[1].Value = ID;            

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_select_UserPermissions", param);
            return dt;
        }

        public static DataTable SetUserPermissions(Permission ObjPermissions)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@UserID",ObjPermissions.UserID),
                new SqlParameter("@RoleID",ObjPermissions.RoleID),
                new SqlParameter("@ModuleID",ObjPermissions.ModuleID),
                new SqlParameter("@FullPerm",ObjPermissions.FullPerm),
                new SqlParameter("@AddPerm",ObjPermissions.AddPerm),
                new SqlParameter("@EditPerm",ObjPermissions.EditPerm),
                new SqlParameter("@ViewPerm",ObjPermissions.ViewPerm),
                new SqlParameter("@DeletePerm",ObjPermissions.DeletePerm),
                new SqlParameter("@ExportPerm",ObjPermissions.ExportPerm),
            };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_insert_UserPermissions", param);
            return dt;
        }

        
        #region Roles
        public static DataTable insertRole(UserAndRole ObjUser)
        {
            SqlParameter[] param =
            {            
            new SqlParameter("@Name",ObjUser.LevelName),
            new SqlParameter("@AccountType",GeneralFunctions.ValidateString(ObjUser.AccountType)),            
            new SqlParameter("@Active",ObjUser.Active),
                new SqlParameter("@CreatedBy",ObjUser.CreatedBy),
        };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_insert_role", param);
            return dt;
        }

        public static DataTable updateRole(UserAndRole ObjUser)
        {
            SqlParameter[] param =
            {            
            new SqlParameter("@LevelID",ObjUser.LevelID),
            new SqlParameter("@Name",ObjUser.LevelName),
            new SqlParameter("@AccountType",GeneralFunctions.ValidateString(ObjUser.AccountType)),            
            new SqlParameter("@Active",ObjUser.Active),
            new SqlParameter("@UpdatedBy",ObjUser.UpdatedBy)
        };
            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_update_role", param);
            return dt;
        }

        public static DataTable deleteRole(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RID", SqlDbType.Int);
            param[0].Value = ID;

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_delete_role", param);
            return dt;
        }

        public static DataTable selectRoles(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RID", SqlDbType.Int);
            param[0].Value = ID;

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_select_roles", param);
            return dt;
        }
        public static DataTable selectRolePermissions(string Mode, int ID)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Action", SqlDbType.VarChar);
            param[0].Value = Mode;
            param[1] = new SqlParameter("@RoleID", SqlDbType.Int);
            param[1].Value = ID;

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_select_Role_Permissions", param);
            return dt;
        }

        public static DataTable deleteRolesPermission(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RId", SqlDbType.Int);
            param[0].Value = ID;

            //param[1] = new SqlParameter("@SessionUserID", SqlDbType.Int);
            //param[1].Value = SessionUserID;

            DataTable dt = DataAccessor.ExecuteProcDataTable("sp_del_Role_Permission", param);
            return dt;
        }
        #endregion
    }
}