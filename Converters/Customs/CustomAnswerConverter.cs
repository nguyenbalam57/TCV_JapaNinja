using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using TCV_JapaNinja.Class;
using TCV_JapaNinja.Models.DatabaseCustoms;

namespace TCV_JapaNinja.Converters.Customs
{
    public static class CustomAnswerConverter
    {
        /// <summary>
        /// Convert DataTable Answer sang List<CustomAnswer>
        /// </summary>
        /// <param name="answerTable"></param>
        /// <returns></returns>
        public static List<CustomAnswer> ConvertDataTableToCustomAnswerList(DataTable table)
        {
            var list = new List<CustomAnswer>();
            foreach (DataRow row in table.Rows)
            {
                var item = new CustomAnswer
                {
                    Id = row.SafeField<int?>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_Id]).GetValueOrDefault(-1),
                    VocabularyId = row.SafeField<int?>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_VocId]).GetValueOrDefault(-1),
                    TechnicalId = row.SafeField<int?>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_TechnicalId]).GetValueOrDefault(-1),
                    GrammarId = row.SafeField<int?>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_GrammarId]).GetValueOrDefault(-1),
                    KanjiId = row.SafeField<int?>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_KanjiId]).GetValueOrDefault(-1),
                    AnswerText = row.SafeField<string>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_Text]) ?? string.Empty,
                    IsCorrect = row.SafeField<bool?>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_IsCorrect]).GetValueOrDefault(false),
                    AnswerCheck = row.SafeField<bool?>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_IsCorrect]).GetValueOrDefault(false),
                    CreatedDate = row.SafeField<DateTime?>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_CreatedDate]) ?? DateTime.Now,
                    UpdatedDate = row.SafeField<DateTime?>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_UpdatedDate]) ?? DateTime.Now,
                    UserId = row.SafeField<int?>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_UserId]).GetValueOrDefault(-1)

                };
                list.Add(item);
            }

            return list;
        }
    }
}
