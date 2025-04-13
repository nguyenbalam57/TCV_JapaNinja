using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCV_JapaNinja.Models.DatabaseCustoms
{
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
        public int LevelId { get; set; } // ID cấp độ
        public int UserId { get; set; } // ID người dùng
        public int CurriculumId { get; set; } // ID chương trình học

        public List<CustomImage> Images { get; set; } // Danh sách ảnh liên quan đến kanji, get thêm khi select từ dữ liệu

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
            LevelId = -1;
            UserId = -1;
            CurriculumId = -1;
            Images = new List<CustomImage>();
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
            int levelId, 
            int userId, 
            int curriculumId, 
            List<CustomImage> images)
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
            LevelId = levelId;
            UserId = userId;
            CurriculumId = curriculumId;
            Images = images;
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
            this.CreatedDate = customKanji.CreatedDate;
            this.UpdatedDate = customKanji.UpdatedDate;
            IsActive = customKanji.IsActive;
            Answers = customKanji.Answers;
            LevelId = customKanji.LevelId;
            UserId = customKanji.UserId;
            CurriculumId = customKanji.CurriculumId;
            Images = new List<CustomImage>(customKanji.Images);
        }

    }
}
