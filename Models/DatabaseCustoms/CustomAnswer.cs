using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TCV_JapaNinja.Models.DatabaseCustoms
{
    /// <summary>
    /// Lớp đại diện cho một câu trả lời tùy chỉnh trong hệ thống.
    /// </summary>
    public class CustomAnswer
    {
        public int Id { get; set; } // ID câu trả lời
        public int VocabularyId { get; set; } // Id của từ vựng
        public int TechnicalId { get; set; } // Id Từ vựng chuyên ngành
        public int GrammarId { get; set; } // Id Ngữ pháp
        public int KanjiId { get; set; } // Id của từ kanji
        public string AnswerText { get; set; } // Nội dung câu trả lời
        public bool IsCorrect { get; set; } // Trạng thái đúng hay sai
        public bool AnswerCheck { get; set; } // Trạng thái đã kiểm tra hay chưa
        public DateTime CreatedDate { get; set; } // Ngày tạo câu trả lời
        public DateTime UpdatedDate { get; set; } // Ngày cập nhật câu trả lời
        public int UserId { get; set; } // ID người dùng cập nhật hoặc tạo mới

        public CustomAnswer()
        {
            Id = -1;
            VocabularyId = -1;
            TechnicalId = -1;
            GrammarId = -1;
            KanjiId = -1;
            AnswerText = string.Empty;
            IsCorrect = false;
            AnswerCheck = false;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            UserId = -1;
        }

        public CustomAnswer(int id, int vocabularyId, int technicalId, int grammarId, int kanjiId, string answerText, bool isCorrect, bool answerCheck, DateTime createdDate, DateTime updatedDate, int userId)
        {
            Id = id;
            VocabularyId = vocabularyId;
            TechnicalId = technicalId;
            GrammarId = grammarId;
            KanjiId = kanjiId;
            AnswerText = answerText;
            IsCorrect = isCorrect;
            AnswerCheck = answerCheck;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            UserId = userId;
        }

        public CustomAnswer(CustomAnswer customAnswer)
        {
            Id = customAnswer.Id;
            VocabularyId = customAnswer.VocabularyId;
            TechnicalId = customAnswer.TechnicalId;
            GrammarId = customAnswer.GrammarId;
            KanjiId = customAnswer.KanjiId;
            AnswerText = customAnswer.AnswerText;
            IsCorrect = customAnswer.IsCorrect;
            AnswerCheck = customAnswer.AnswerCheck;
            CreatedDate = customAnswer.CreatedDate;
            UpdatedDate = customAnswer.UpdatedDate;
            UserId = customAnswer.UserId;
        }
    }
}
