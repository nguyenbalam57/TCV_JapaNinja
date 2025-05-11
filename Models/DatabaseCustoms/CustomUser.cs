using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCV_JapaNinja.Class;
using TCV_JapaNinja.Models.Account;

namespace TCV_JapaNinja.Models.DatabaseCustoms
{
    /// <summary>
    /// Lớp đại diện cho một người dùng trong hệ thống.
    /// </summary>
    public class CustomUser
    {
        public int Id { get; set; } // ID người dùng
        public byte[] UserImage { get; set; } // Hình ảnh người dùng
        public string EmployeeCode { get; set; } // Mã nhân viên
        public string Name { get; set; } // Tên người dùng
        public string Password { get; set; } // Mật khẩu
        public string PasswordOld { get; set; } // Mật khẩu Cũ
        public string Description { get; set; } // Mô tả người dùng
        public string Email { get; set; } // Địa chỉ email
        public string PhoneNumber { get; set; } // Số điện thoại
        public DateTime CreatedDate { get; set; } // Ngày tạo tài khoản
        public DateTime UpdatedDate { get; set; } // Ngày cập nhật tài khoản
        public bool IsActive { get; set; } // Trạng thái hoạt động
        public CustomGroup Group { get; set; } // Nhóm người dùng
        public CustomPosition Position { get; set; } // Vị trí người dùng
        public string IPAddress { get; set; } // Địa chỉ IP

        public List<CustomRolePer> Roles { get; set; } // Danh sách quyền của người dùng

        // Phần mở rộng về cấp, quản lý, nhân viên
        // Việc add thêm các thuộc tính này sẽ làm tăng độ phức tạp của lớp
        //public List<CustomUser> Parents { get; set; } // Danh sách người dùng cha
        //public List<CustomUser> Childrens { get; set; } // Danh sách người dùng con
        public CustomUser()
        {
            Id = -1;
            UserImage = null;
            EmployeeCode = string.Empty;
            Name = string.Empty;
            Password = string.Empty;
            PasswordOld = string.Empty;
            Description = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            IsActive = true;
            Group = new CustomGroup();
            Position = new CustomPosition();
            IPAddress = string.Empty;
            Roles = new List<CustomRolePer>();
        }
        public CustomUser(int id, 
            byte[] userImage, 
            string employeeCode, 
            string name, 
            string password, 
            string passwordOld, 
            string des, 
            string email, 
            string phoneNumber, 
            DateTime createdDate, 
            DateTime updatedDate, 
            bool isActive,
            CustomGroup group,
            CustomPosition position,
            string iPAddress,
            List<CustomRolePer> role
            )
        {
            Id = id;
            UserImage = userImage;
            EmployeeCode = employeeCode;
            Name = name;
            Password = password;
            PasswordOld = passwordOld;
            Description = des;
            Email = email;
            PhoneNumber = phoneNumber;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            IsActive = isActive;
            Group = group;
            Position = position;
            IPAddress = iPAddress;
            Roles = role;
        }
        public CustomUser(CustomUser user)
        {
            Id = user.Id;
            UserImage = user.UserImage;
            EmployeeCode = user.EmployeeCode;
            Name = user.Name;
            Password = user.Password;
            PasswordOld = user.PasswordOld;
            Description = user.Description;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            CreatedDate = user.CreatedDate;
            UpdatedDate = user.UpdatedDate;
            IsActive = user.IsActive;
            Group = user.Group;
            Position = user.Position;
            IPAddress = user.IPAddress;
            Roles = user.Roles;
        }
        /// <summary>
        /// Thêm quyền cho người dùng
        /// </summary>
        /// <param name="rolePer"></param>
        public void AddRolePer(CustomRolePer rolePer)
        {
            if(!Roles.Contains(rolePer))
                Roles.Add(rolePer);
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
                foreach (string _role in idRoles)
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
