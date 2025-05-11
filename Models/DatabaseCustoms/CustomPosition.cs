using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCV_JapaNinja.Models.DatabaseCustoms
{
    /// <summary>
    /// Lớp đại diện cho một vị trí trong hệ thống.
    /// </summary>
    public class CustomPosition
    {
        public int Id { get; set; } // ID vị trí
        public string Name { get; set; } // Tên vị trí
        public string Description { get; set; } // Mô tả vị trí
        public DateTime CreatedDate { get; set; } // Ngày tạo vị trí
        public DateTime UpdatedDate { get; set; } // Ngày cập nhật vị trí
        public bool IsActive { get; set; } // Trạng thái hoạt động
        public CustomPosition()
        {
            Id = -1;
            Name = string.Empty;
            Description = string.Empty;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            IsActive = true;
        }
        public CustomPosition(int id, string name, string description, DateTime createdDate, DateTime updatedDate, bool isActive)
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
