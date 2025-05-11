using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCV_JapaNinja.Models.DatabaseCustoms
{
    /// <summary>
    /// Lớp đại diện cho lịch sử học tập của người dùng trong hệ thống.
    /// </summary>
    public class CustomHistoryGKTV
    {
        public int Id { get; set; } // ID lịch sử học tập
        public int UserId { get; set; } // ID người dùng
        public int GrammarId { get; set; } // ID ngữ pháp
        public int KanjiId { get; set; } // ID kanji
        public int TechnicalId { get; set; } // ID từ kỹ thuật
        public int VocabularyId { get; set; } // ID từ vựng
        public bool IsRemembered { get; set; } // Trạng thái đã ghi nhớ
        public bool IsRememberedCheck { get; set; } // Trạng thái đã kiểm tra
        public int ICons { get; set; } // ID biểu tượng
        public DateTime CreatedDate { get; set; } // Ngày tạo
        public DateTime UpdatedDate { get; set; } // Ngày cập nhật

        public CustomHistoryGKTV()
        {
            Id = -1;
            UserId = -1;
            GrammarId = -1;
            KanjiId = -1;
            TechnicalId = -1;
            VocabularyId = -1;
            IsRemembered = false;
            IsRememberedCheck = false;
            ICons = -1;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

        public CustomHistoryGKTV( int id,int userId, int grammarId, int kanjiId, int technicalId, int vocabularyId, bool isRemembered, bool isRememberedCheck, int iCons, DateTime createdDate, DateTime updatedDate)
        {
            Id = id;
            UserId = userId;
            GrammarId = grammarId;
            KanjiId = kanjiId;
            TechnicalId = technicalId;
            VocabularyId = vocabularyId;
            IsRemembered = isRemembered;
            IsRememberedCheck = isRememberedCheck;
            ICons = iCons;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
        }
    }
}
