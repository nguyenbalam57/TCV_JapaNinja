using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCV_JapaNinja.Models.DatabaseCustoms
{
    /// <summary>
    /// Lớp đại diện cho một từ kanji trong hệ thống.
    /// </summary>
    public class CustomKanji
    {
        public int Id { get; set; } // Kanji ID
        public int LessonNumber { get; set; } // Số bài
        public string Kanji { get; set; } // Từ kanji
        public string HanTu { get; set; } // Cách đọc hán tự
        public string AmOn { get; set; } // Cách đọc Âm Ôn
        public string AmKun { get; set; } // Cách đọc Âm Kun
        public string English { get; set; } // Nghĩa tiếng anh
        public string TiengViet { get; set; } // Nghĩa tiếng việt
        public string Example { get; set; } // Ví dụ
        public string Note { get; set; } // Ghi chú
        public int Strokes { get; set; } // Số nét
        public DateTime CreatedDate { get; set; } // Ngày tạo từ hán tự
        public DateTime UpdatedDate { get; set; } // Ngày update từ hán tự
        public bool IsActive { get; set; } // Trạng thái hoạt động
        public List<CustomAnswer> Answers { get; set; } // Danh sách câu trả lời
        public CustomLevel Level { get; set; } // Cấp độ
        public int UserId { get; set; } // ID người dùng
        public CustomCurriculum Curriculum { get; set; } // Chương trình học
        public List<CustomImage> Images { get; set; } // Danh sách ảnh liên quan đến kanji, get thêm khi select từ dữ liệu

        // Bổ sung thêm kanji đã nhớ
        public CustomHistoryGKTV HistoryKanji { get; set; } // Lịch sử kanji đã nhớ

        public CustomKanji()
        {
            Id = -1;
            LessonNumber = -1;
            Kanji = string.Empty;
            HanTu = string.Empty;
            AmOn = string.Empty;
            AmKun = string.Empty;
            English = string.Empty;
            TiengViet = string.Empty;
            Example = string.Empty;
            Note = string.Empty;
            Strokes = 0;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            IsActive = true;
            Answers = new List<CustomAnswer>();
            Level = new CustomLevel();
            UserId = -1;
            Curriculum = new CustomCurriculum();
            Images = new List<CustomImage>();
            HistoryKanji = new CustomHistoryGKTV();
        }

        public CustomKanji(int id, 
            int lessonNumber, 
            string kanji, 
            string hanTu, 
            string amOn, 
            string amKun, 
            string english, 
            string tiengViet, 
            string example, 
            string note, 
            int strokes, 
            DateTime createdDate, 
            DateTime updatedDate, 
            bool isActive, 
            List<CustomAnswer> answers, 
            CustomLevel levelId, 
            int userId, 
            CustomCurriculum curriculumId, 
            List<CustomImage> images,
            CustomHistoryGKTV historyKanji)
        {
            Id = id;
            LessonNumber = lessonNumber;
            Kanji = kanji;
            HanTu = hanTu;
            AmOn = amOn;
            AmKun = amKun;
            English = english;
            TiengViet = tiengViet;
            Example = example;
            Note = note;
            Strokes = strokes;
            this.CreatedDate = createdDate;
            this.UpdatedDate = updatedDate;
            IsActive = isActive;
            Answers = answers;
            Level = levelId;
            UserId = userId;
            Curriculum = curriculumId;
            Images = images;
            HistoryKanji = historyKanji;
        }

        public CustomKanji(CustomKanji customKanji)
        {
            Id = customKanji.Id;
            LessonNumber = customKanji.LessonNumber;
            Kanji = customKanji.Kanji;
            HanTu = customKanji.HanTu;
            AmOn = customKanji.AmOn;
            AmKun = customKanji.AmKun;
            English = customKanji.English;
            TiengViet = customKanji.TiengViet;
            Example = customKanji.Example;
            Note = customKanji.Note;
            Strokes = customKanji.Strokes;
            CreatedDate = customKanji.CreatedDate;
            UpdatedDate = customKanji.UpdatedDate;
            IsActive = customKanji.IsActive;
            Answers = customKanji.Answers;
            Level = customKanji.Level;
            UserId = customKanji.UserId;
            Curriculum = customKanji.Curriculum;
            Images = customKanji.Images;
            HistoryKanji = customKanji.HistoryKanji;
        }

    }
}
