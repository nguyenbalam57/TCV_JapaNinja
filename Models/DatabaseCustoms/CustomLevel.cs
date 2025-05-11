using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCV_JapaNinja.Models.DatabaseCustoms
{
    /// <summary>
    /// Lớp đại diện cho một cấp độ trong hệ thống.
    /// </summary>
    public class CustomLevel
    {
        public int Id { get; set; } // ID cấp độ
        public string Name { get; set; } // Tên cấp độ
        public string Description { get; set; } // Mô tả cấp độ
        public DateTime CreatedDate { get; set; } // Ngày tạo cấp độ
        public DateTime UpdatedDate { get; set; } // Ngày cập nhật cấp độ
        public bool IsActive { get; set; } // Trạng thái hoạt động
        public int UserId { get; set; } // ID người chỉnh sửa hoặc thêm mới
        public CustomLevel()
        {
            Id = -1;
            Name = string.Empty;
            Description = string.Empty;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            IsActive = true;
            UserId = -1;
        }
        public CustomLevel(int id, string name, string description, DateTime createdDate, DateTime updatedDate, bool isActive, int userId)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            IsActive = isActive;
            UserId = userId;
        }
    }
}
