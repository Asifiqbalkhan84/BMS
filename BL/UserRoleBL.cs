using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yuan.DA;
using Yuan.Model;
using System.Data;
namespace Yuan.BL
{
    public class UserRoleBL
    {
        public DataTable GetUserList(int uid = 0)
        {
            return UserRoleDL.selectUsers(GeneralFunctions.ValidateInt(uid));
        }
        
        public string insertupdateUser(UserAndRole ObjUser,ref int Uid)
        {
            string Message = "";
            try
            {
                if (ObjUser.UserId == 0)
                {
                    DataTable dt = UserRoleDL.insertUser(ObjUser);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["RETVAL"].ToString() == "INSERT")
                        {
                            Message = "success";
                            Uid = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                        }
                    }
                }
                else
                {
                    DataTable dt = UserRoleDL.updateUser(ObjUser);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["RETVAL"].ToString() == "UPDATE")
                        {
                            Message = "success";
                            Uid = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return Message;
        }
        public string deleteUser(int UserID)
        {
            string Message = "";
            try
            {
                DataTable dt = UserRoleDL.deleteUser(UserID);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["RETVAL"].ToString() == "DELETE")
                    {
                        Message = "Success";
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return Message;
        }
        public string deleteUserPermission(int userId)
        {
            string Message = "";
            try
            {
                DataTable dt = UserRoleDL.deleteUserPermission(userId);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["RETVAL"].ToString() == "DELETE")
                    {
                        Message = "Success";
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return Message;
        }


        public string deleteRolePermission(int RoleId)
        {
            string Message = "";
            try
            {
                DataTable dt = UserRoleDL.deleteRolesPermission(RoleId);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["RETVAL"].ToString() == "DELETE")
                    {
                        Message = "Success";
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return Message;
        }
        
        public DataTable GetUserPermissions(string Mode, int? ID)
        {
            return UserRoleDL.selectUserPermissions(Mode,GeneralFunctions.ValidateInt(ID));
        }
        public string SetUserPermissions(Permission ObjPermissions)
        {
            string Message = "";
            try
            {
                DataTable dt = UserRoleDL.SetUserPermissions(ObjPermissions);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["RETVAL"].ToString() == "INSERT")
                    {
                        Message = "Success";
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return Message;
        }

        public DataTable GetRolePermissions(string Mode,int RoleId)
        {
            return UserRoleDL.selectRolePermissions(Mode, GeneralFunctions.ValidateInt(RoleId));
        }

        public DataTable GetRoleList(int rid = 0)
        {
            return UserRoleDL.selectRoles(GeneralFunctions.ValidateInt(rid));
        }
        public string InsertUpdateRole(UserAndRole ObjRole, ref int rid)
        {
            string Message = "";
            try
            {
                if (ObjRole.LevelID == 0)
                {
                    DataTable dt = UserRoleDL.insertRole(ObjRole);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["RETVAL"].ToString() == "INSERT")
                        {
                            Message = "success";
                            rid = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                        }
                    }
                }
                else
                {
                    DataTable dt = UserRoleDL.updateRole(ObjRole);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["RETVAL"].ToString() == "UPDATE")
                        {
                            Message = "success";
                            rid = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return Message;
        }
        public string deleteRole(int RoleID)
        {
            string Message = "";
            try
            {
                DataTable dt = UserRoleDL.deleteRole(RoleID);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["RETVAL"].ToString() == "DELETE")
                    {
                        Message = "Success";
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            return Message;
        }
    }
}