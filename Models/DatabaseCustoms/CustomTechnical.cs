using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCV_JapaNinja.Models.DatabaseCustoms
{
    /// <summary>
    /// Lớp đại diện cho một từ vựng chuyên ngành trong hệ thống.
    /// </summary>
    public class CustomTechnical
    {
        public int Id { get; set; } // ID kỹ thuật
        public string Vocabulary { get; set; } // Từ kỹ thuật
        public string Hiragana { get; set; } // Cách đọc
        public string English { get; set; } // Nghĩa tiếng anh
        public string TiengViet { get; set; } // Nghĩa tiếng việt
        public string Example { get; set; } // Ví dụ
        public string Note { get; set; } // Ghi chú
        public DateTime CreatedDate { get; set; } // Ngày tạo từ kỹ thuật
        public DateTime UpdatedDate { get; set; } // Ngày update từ kỹ thuật
        public bool IsActive { get; set; } // Trạng thái hoạt động
        public List<CustomAnswer> Answers { get; set; } // Danh sách câu trả lời
        public CustomLevel Level { get; set; } // Cấp độ
        public int UserId { get; set; } // ID người dùng
        public CustomGroup Group { get; set; } // Nhóm (ví dụ: CAR, SOFT)
        public List<CustomImage> Images { get; set; } // Danh sách ảnh liên quan đến từ kỹ thuật, get thêm khi select từ dữ liệu

        // Bổ sung thêm từ kỹ thuật đã nhớ
        public CustomHistoryGKTV HistoryTechnical { get; set; } // Lịch sử từ kỹ thuật đã nhớ

        public CustomTechnical()
        {
            Id = -1;
            Vocabulary = string.Empty;
            Hiragana = string.Empty;
            English = string.Empty;
            TiengViet = string.Empty;
            Example = string.Empty;
            Note = string.Empty;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            IsActive = true;
            Answers = new List<CustomAnswer>();
            Level = new CustomLevel();
            UserId = -1;
            Group = new CustomGroup();
            Images = new List<CustomImage>();
            HistoryTechnical = new CustomHistoryGKTV();
        }
        public CustomTechnical(int id, 
            string vocabulary, 
            string hiragana, 
            string english, 
            string tiengViet, 
            string example, 
            string note, 
            DateTime createdDate, 
            DateTime updatedDate, 
            bool isActive, 
            List<CustomAnswer> answers, 
            CustomLevel level, 
            int userId, 
            CustomGroup group, 
            List<CustomImage> images,
            CustomHistoryGKTV historyTechnical)
        {
            Id = id;
            Vocabulary = vocabulary;
            Hiragana = hiragana;
            English = english;
            TiengViet = tiengViet;
            Example = example;
            Note = note;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            IsActive = isActive;
            Answers = answers;
            Level = level;
            UserId = userId;
            Group = group;
            Images = images;
            HistoryTechnical = historyTechnical;
        }
    }
}
