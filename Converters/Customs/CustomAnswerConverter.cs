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
        public static List<CustomAnswer> ConvertDataTableToCustomAnswerList(DataTable answerTable)
        {
            var list = new List<CustomAnswer>();
            foreach (DataRow answerRow in answerTable.Rows)
            {
                var answer = new CustomAnswer
                {
                    Id = answerRow.Field<int>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_Id]),
                    VocabularyId = answerRow.Field<int>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_VocId]),
                    TechnicalId = answerRow.Field<int>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_TechnicalId]),
                    GrammarId = answerRow.Field<int>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_GrammarId]),
                    KanjiId = answerRow.Field<int>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_KanjiId]),
                    AnswerText = answerRow.Field<string>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_Text]),
                    IsCorrect = answerRow.Field<bool>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_IsCorrect]),
                    AnswerCheck = answerRow.Field<bool>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_IsCorrect]),
                    CreatedDate = answerRow.Field<DateTime>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_CreatedDate]),
                    UpdatedDate = answerRow.Field<DateTime>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_UpdatedDate]),
                    UserId = answerRow.Field<int>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_UserId])

                };
                list.Add(answer);
            }

            return list;
        }
    }
}
