using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCV_JapaNinja.Models.DatabaseCustoms
{
    /// <summary>
    /// Lớp đại diện cho một từ vựng trong hệ thống.
    /// </summary>
    public class CustomVocabulary
    {
        public int Id { get; set; } // ID từ vựng
        public int LessonNumber { get; set; } // Số bài
        public string Vocabulary { get; set; } // Từ vựng
        public string Kanji { get; set; } // Hán tự
        public string Hiragana { get; set; } // Cách đọc
        public string English { get; set; } // Nghĩa tiếng anh
        public string TiengViet { get; set; } // Nghĩa tiếng việt
        public string Example { get; set; } // Ví dụ
        public string Note { get; set; } // Ghi chú
        public DateTime CreatedDate { get; set; } // Ngày tạo từ vựng
        public DateTime UpdatedDate { get; set; } // Ngày update từ vựng
        public bool IsActive { get; set; } // Trạng thái hoạt động
        public List<CustomAnswer> Answers { get; set; } // Danh sách câu trả lời
        public CustomLevel Level { get; set; } // cấp độ
        public int UserId { get; set; } // ID người dùng
        public CustomGroup Group { get; set; } // Nhóm (ví dụ: CAR, SOFT)
        public CustomCurriculum Curriculum { get; set; } // Chương trình học
        public List<CustomImage> Images { get; set; } // Danh sách ảnh liên quan đến từ vựng, get thêm khi select từ dữ liệu
        public CustomTypeVoca TypeVoca { get; set; } // Loại từ vựng (ví dụ: danh từ, động từ, tính từ)

        // Bổ sung thêm từ vựng đã nhớ
        public CustomHistoryGKTV HistoryVocabulary { get; set; } // Lịch sử từ vựng đã nhớ

        public CustomVocabulary()
        {
            Id = -1;
            LessonNumber = -1;
            Vocabulary = string.Empty;
            Kanji = string.Empty;
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
            Curriculum = new CustomCurriculum();
            Images = new List<CustomImage>();
            TypeVoca = new CustomTypeVoca();
            HistoryVocabulary = new CustomHistoryGKTV();
        }
        public CustomVocabulary(
            int id,
            int lessonNumber,
            string vocabulary,
            string kanji,
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
            CustomCurriculum curriculum,
            List<CustomImage> images,
            CustomTypeVoca typeVoca,
            CustomHistoryGKTV historyVocabulary)
        {
            Id = id;
            LessonNumber = lessonNumber;
            Vocabulary = vocabulary;
            Kanji = kanji;
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
            Curriculum = curriculum;
            Images = images;
            TypeVoca = typeVoca;
            HistoryVocabulary = historyVocabulary;
        }
    }
}
