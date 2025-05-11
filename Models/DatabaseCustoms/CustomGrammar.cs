using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCV_JapaNinja.Models.DatabaseCustoms
{
    /// <summary>
    /// Lớp đại diện cho một ngữ pháp trong hệ thống.
    /// </summary>
    public class CustomGrammar
    {
        public int Id { get; set; }
        public int LessonNumber { get; set; } // Số bài
        public string Structure { get; set; } // Cấu trúc ngữ pháp
        public string Sample { get; set; } // Mẫu câu
        public string Explain { get; set; } // Giải thích ngữ nghĩa của câu
        public string Example { get; set; } // Ví dụ
        public string Note { get; set; } // Ghi chú
        public DateTime CreatedDate { get; set; } // Ngày tạo ngữ pháp
        public DateTime UpdatedDate { get; set; } // Ngày update ngữ pháp
        public bool IsActive { get; set; } // Trạng thái hoạt động
        public List<CustomAnswer> Answers { get; set; } // Danh sách câu trả lời
        public CustomLevel Level { get; set; } // Cấp độ
        public int UserId { get; set; } // ID người dùng
        public CustomCurriculum Curriculum { get; set; } // Chương trình học
        public List<CustomImage> Images { get; set; } // Danh sách ảnh liên quan đến ngữ pháp, get thêm khi select từ dữ liệu

        // Bổ sung thêm ngữ pháp đã nhớ
        public CustomHistoryGKTV HistoryGrammar { get; set; } // Lịch sử ngữ pháp đã nhớ

        // Phần Icon chưa phát triển
        //public string Icon { get; set; } // Icon ngữ pháp

        public CustomGrammar()
        {
            Id = -1;
            LessonNumber = -1;
            Structure = string.Empty;
            Sample = string.Empty;
            Explain = string.Empty;
            Example = string.Empty;
            Note = string.Empty;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            IsActive = true;
            Answers = new List<CustomAnswer>();
            Level = new CustomLevel();
            UserId = -1;
            Curriculum = new CustomCurriculum();
            Images = new List<CustomImage>();

            HistoryGrammar = new CustomHistoryGKTV();
        }

        public CustomGrammar(int id, 
            int lessonNumber, 
            string structure, 
            string sample, 
            string explain, 
            string example, 
            string note, 
            DateTime createdDate, 
            DateTime updatedDate, 
            bool isActive, 
            List<CustomAnswer> answers, 
            CustomLevel level, 
            int userId, 
            CustomCurriculum curriculum,
            CustomHistoryGKTV historyGKTV)
        {
            Id = id;
            LessonNumber = lessonNumber;
            Structure = structure;
            Sample = sample;
            Explain = explain;
            Example = example;
            Note = note;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            IsActive = isActive;
            Answers = answers;
            Level = level;
            UserId = userId;
            Curriculum = curriculum;
            HistoryGrammar = historyGKTV;
        }

        public CustomGrammar(CustomGrammar customGrammar)
        {
            Id = customGrammar.Id;
            LessonNumber = customGrammar.LessonNumber;
            Structure = customGrammar.Structure;
            Sample = customGrammar.Sample;
            Explain = customGrammar.Explain;
            Example = customGrammar.Example;
            Note = customGrammar.Note;
            CreatedDate = customGrammar.CreatedDate;
            UpdatedDate = customGrammar.UpdatedDate;
            IsActive = customGrammar.IsActive;
            Answers = customGrammar.Answers;
            Level = customGrammar.Level;
            UserId = customGrammar.UserId;
            Curriculum = customGrammar.Curriculum;
            Images = customGrammar.Images;
            HistoryGrammar = customGrammar.HistoryGrammar;
        }
    }
}
