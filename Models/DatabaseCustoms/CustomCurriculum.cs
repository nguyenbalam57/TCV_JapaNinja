using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCV_JapaNinja.Models.DatabaseCustoms
{
    /// <summary>
    /// Lớp đại diện cho một chương trình học trong hệ thống.
    /// </summary>
    public class CustomCurriculum
    {
        public int Id { get; set; } // ID chương trình học
        public string Name { get; set; } // Tên chương trình học
        public string Description { get; set; } // Mô tả chương trình học
        public DateTime CreatedDate { get; set; } // Ngày tạo chương trình học
        public DateTime UpdatedDate { get; set; } // Ngày cập nhật chương trình học
        public bool IsActive { get; set; } // Trạng thái hoạt động
        public int UserId { get; set; } // ID người dùng
        public CustomCurriculum()
        {
            Id = -1;
            Name = string.Empty;
            Description = string.Empty;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            IsActive = true;
            UserId = -1;
        }
        public CustomCurriculum(int id, string name, string description, DateTime createdDate, DateTime updatedDate, bool isActive, int userId)
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
