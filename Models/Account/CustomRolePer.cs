using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCV_JapaNinja.Models.Account
{
    public enum Permission
    {
        Create,
        Read,
        Update,
        Delete,
    }
    /// <summary>
    /// Lớp đại diện cho một vai trò tùy chỉnh trong hệ thống.
    /// </summary>
    public class CustomRolePer
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public List<Permission> Permissions { get; set; }

        public CustomRolePer() 
        {
            RoleId = string.Empty;
            RoleName = string.Empty;
            Permissions = new List<Permission>();
        }
        public CustomRolePer(string id)
        {
            RoleId = id;
            RoleName = string.Empty;
            Permissions = new List<Permission>();
        }
        public CustomRolePer(string id, string roleName) 
        {
            RoleId = id;
            RoleName = roleName;
            Permissions = new List<Permission>();
        }

        public void AddPermission(Permission permission) 
        {
            if(!Permissions.Contains(permission))
                Permissions.Add(permission);
        }
        public bool HasPermission(Permission permission)
        {
            return Permissions.Contains(permission);
        }
    }


}
