using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCV_JapaNinja.Models.DatabaseCustoms
{
    /// <summary>
    /// Lớp đại diện cho mối quan hệ giữa người dùng và vai trò trong hệ thống.
    /// </summary>
    public class CustomUserRole
    {
        public int UserId { get; set; } // ID người dùng
        public int RoleId { get; set; } // ID vai trò
        public int UserIdEdit { get; set; } // ID người dùng chỉnh sửa
        public DateTime CreatedDate { get; set; } // Ngày cập nhật
        public CustomUserRole()
        {
            UserId = -1;
            RoleId = -1;
            UserIdEdit = -1;
            CreatedDate = DateTime.Now;
        }
        public CustomUserRole(int userId, int roleId, int userIdEdit, DateTime createdDate)
        {
            UserId = userId;
            RoleId = roleId;
            UserIdEdit = userIdEdit;
            CreatedDate = createdDate;
        }
    }
}
