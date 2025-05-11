using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCV_JapaNinja.Models.DatabaseCustoms
{
    /// <summary>
    /// Lớp đại diện cho một vai trò trong hệ thống.
    /// </summary>
    public class CustomRole
    {
        public int Id { get; set; } // ID vai trò
        public string Code { get; set; } // Mã vai trò
        public string Name { get; set; } // Tên vai trò
        public string Description { get; set; } // Mô tả vai trò
        public bool Created { get; set; } // Quyền tạo
        public bool Readed { get; set; } // Quyền đọc
        public bool Updated { get; set; } // Quyền cập nhật
        public bool Deleted { get; set; } // Quyền xóa
        public DateTime CreatedDate { get; set; } // Ngày tạo vai trò
        public DateTime UpdatedDate { get; set; } // Ngày cập nhật vai trò
        public bool IsActive { get; set; } // Trạng thái hoạt động
        public CustomRole()
        {
            Id = -1;
            Code = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
            Created = false;
            Readed = false;
            Updated = false;
            Deleted = false;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            IsActive = true;
        }
        public CustomRole(int id, string code, string name, string description, bool created, bool readed, bool updated, bool deleted, DateTime createdDate, DateTime updatedDate, bool isActive)
        {
            Id = id;
            Code = code;
            Name = name;
            Description = description;
            Created = created;
            Readed = readed;
            Updated = updated;
            Deleted = deleted;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            IsActive = isActive;
        }
    }
}
