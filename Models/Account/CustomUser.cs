using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCV_JapaNinja.Class;

namespace TCV_JapaNinja.Models.Account
{
    public class CustomUser
    {
        public int UserId { get; set; }
        public string EmployerCode { get; set; }
        public string UserName { get; set; }

        public List<CustomRolePer> Roles { get; set; }

        public CustomUser()
        {
            UserId = -1;
            EmployerCode = string.Empty;
            UserName = string.Empty;
            Roles = new List<CustomRolePer>();
        }

        public CustomUser(int id, string code, string name)
        {
            UserId = id;
            EmployerCode = code;
            UserName = name;
            Roles = new List<CustomRolePer>();
        }

        public void AddRole(CustomRolePer role)
        {
            if (!Roles.Contains(role)) Roles.Add(role);
        }
        /// <summary>
        /// lấy quyền truy cập
        /// </summary>
        /// <param name="idRoles"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        public bool HasRermission(string[] idRoles, List<Permission> permissions)
        {
            bool hasRermission = false;

            if (!hasRermission)
                hasRermission = Roles.Any(role => role.RoleId == Accounts.codeRoles[(int)Accounts.enRoleRow.RoleRow_Admin, (int)Accounts.enRoleCol.RoleCol_Id]);
            if (!hasRermission)
            {
                foreach (string _role in idRoles)
                {
                    if (!hasRermission)
                    {
                        foreach (Permission permission in permissions)
                        {
                            if (!hasRermission)
                            {
                                hasRermission = Roles.Any(role => role.RoleId == _role && role.HasPermission(permission));
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return hasRermission;
        }
        public bool HasRermission(string _role, List<Permission> permissions)
        {
            bool hasRermission = false;
            // Kiểm tra xác nhận admin
            if (!hasRermission)
                hasRermission = Roles.Any(role => role.RoleId == Accounts.codeRoles[(int)Accounts.enRoleRow.RoleRow_Admin, (int)Accounts.enRoleCol.RoleCol_Id]);

            if (!hasRermission)
            {
                foreach (Permission permission in permissions)
                {
                    if (!hasRermission)
                    {
                        hasRermission = Roles.Any(role => role.RoleId == _role && role.HasPermission(permission));
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return hasRermission;
        }
        public bool HasRermission(string[] idRoles, Permission permission)
        {
            bool hasRermission = false;
            // Kiểm tra xác nhận admin
            if (!hasRermission)
                hasRermission = Roles.Any(role => role.RoleId == Accounts.codeRoles[(int)Accounts.enRoleRow.RoleRow_Admin, (int)Accounts.enRoleCol.RoleCol_Id]);

            if (!hasRermission) 
            {
                foreach(string _role in idRoles)
                {
                    if (!hasRermission)
                    {
                        hasRermission = Roles.Any(role => role.RoleId == _role && role.HasPermission(permission));
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return hasRermission;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_role"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        public bool HasRermission(string _role, Permission permission)
        {
            bool hasRermission = false;
            // Kiểm tra xác nhận admin
            if (!hasRermission)
                hasRermission = Roles.Any(role => role.RoleId == Accounts.codeRoles[(int)Accounts.enRoleRow.RoleRow_Admin, (int)Accounts.enRoleCol.RoleCol_Id]);

            if (!hasRermission)
            {
                hasRermission = Roles.Any(role => role.RoleId == _role && role.HasPermission(permission));
            }

            return hasRermission;
        }
        /// <summary>
        /// chỉ xet Admin
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public bool HasRermission(Permission permission) 
        {
            bool hasRermission = false;

            // Kiểm tra xác nhận admin
            if (!hasRermission)
                hasRermission = Roles.Any(role => role.RoleId == Accounts.codeRoles[(int)Accounts.enRoleRow.RoleRow_Admin, (int)Accounts.enRoleCol.RoleCol_Id]);

            return hasRermission;
        }
        public bool HasRermission(string[] idRoles)
        {
            bool hasRermission = false;

            // Kiểm tra xác nhận admin
            if (!hasRermission)
                hasRermission = Roles.Any(role => role.RoleId == Accounts.codeRoles[(int)Accounts.enRoleRow.RoleRow_Admin, (int)Accounts.enRoleCol.RoleCol_Id]);

            if (!hasRermission)
            {
                foreach (string _role in idRoles)
                {
                    hasRermission = Roles.Any(role => role.RoleId == _role);
                }
            }
            return hasRermission;
        }
        public bool HasRermission(string _role) 
        {
            bool hasRermission = false;

            // Kiểm tra xác nhận admin
            if (!hasRermission)
                hasRermission = Roles.Any(role => role.RoleId == Accounts.codeRoles[(int)Accounts.enRoleRow.RoleRow_Admin, (int)Accounts.enRoleCol.RoleCol_Id]);
            
            if (!hasRermission)
            {
                hasRermission = Roles.Any(role => role.RoleId == _role);
            }

            return hasRermission;
        }
    }
}
