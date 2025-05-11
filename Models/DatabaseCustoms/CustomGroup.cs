using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCV_JapaNinja.Models.DatabaseCustoms
{
    /// <summary>
    /// Lớp đại diện cho một nhóm từ vựng hoặc kỹ thuật trong hệ thống.
    /// </summary>
    public class CustomGroup
    {
        public int Id { get; set; } // ID nhóm
        public string Name { get; set; } // Tên nhóm
        public string Description { get; set; } // Mô tả nhóm
        public DateTime CreatedDate { get; set; } // Ngày tạo nhóm
        public DateTime UpdatedDate { get; set; } // Ngày cập nhật nhóm
        public bool IsActive { get; set; } // Trạng thái hoạt động
        public CustomGroup()
        {
            Id = -1;
            Name = string.Empty;
            Description = string.Empty;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            IsActive = true;
        }
        public CustomGroup(int id, string name, string description, DateTime createdDate, DateTime updatedDate, bool isActive)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            IsActive = isActive;
        }
    }
}
