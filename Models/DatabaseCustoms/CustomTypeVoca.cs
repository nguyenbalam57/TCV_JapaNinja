using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCV_JapaNinja.Models.DatabaseCustoms
{
    /// <summary>
    /// Lớp đại diện cho loại từ vựng trong cơ sở dữ liệu.
    /// </summary>
    public class CustomTypeVoca
    {
        public int Id { get; set; } // ID loại từ vựng
        public string Name { get; set; } // Tên loại từ vựng
        public string Description { get; set; } // Mô tả
        public DateTime CreatedDate { get; set; } // Ngày tạo loại từ vựng
        public DateTime UpdatedDate { get; set; } // Ngày update loại từ vựng
        public bool IsActive { get; set; } // Trạng thái hoạt động
        public int UserId { get; set; } // ID người dùng
        public CustomTypeVoca()
        {
            Id = -1;
            Name = string.Empty;
            Description = string.Empty;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            IsActive = true;
            UserId = -1;
        }
        public CustomTypeVoca(int id, string name, string description, DateTime createdDate, DateTime updatedDate, bool isActive, int userId)
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
