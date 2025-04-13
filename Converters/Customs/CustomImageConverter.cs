using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCV_JapaNinja.Class;
using TCV_JapaNinja.Models.DatabaseCustoms;

namespace TCV_JapaNinja.Converters.Customs
{
    public static class CustomImageConverter
    {
        /// <summary>
        /// Conveter Datatable Image sang Lis<customimage>
        /// </summary>
        /// <param name="imageTable"></param>
        /// <returns></returns>
        public static List<CustomImage> ConvertDataTableToCustomImageList(DataTable imageTable)
        {
            var list = new List<CustomImage>();
            foreach (DataRow answerRow in imageTable.Rows)
            {
                var image = new CustomImage
                {
                    Id = answerRow.Field<int>(ConnectedData.imagesCol[(int)ConnectedData.enImageCol.ImageCol_Id]),
                    VocabularyId = answerRow.Field<int>(ConnectedData.imagesCol[(int)ConnectedData.enImageCol.ImageCol_VocId]),
                    TechnicalId = answerRow.Field<int>(ConnectedData.imagesCol[(int)ConnectedData.enImageCol.ImageCol_TechnicalId]),
                    GrammarId = answerRow.Field<int>(ConnectedData.imagesCol[(int)ConnectedData.enImageCol.ImageCol_GrammarId]),
                    KanjiId = answerRow.Field<int>(ConnectedData.imagesCol[(int)ConnectedData.enImageCol.ImageCol_KanjiId]),
                    ImageData = answerRow.Field<byte[]>(ConnectedData.imagesCol[(int)ConnectedData.enImageCol.ImageCol_Data]),
                    ImageType = answerRow.Field<string>(ConnectedData.imagesCol[(int)ConnectedData.enImageCol.ImageCol_Type]),
                    ImageName = answerRow.Field<string>(ConnectedData.imagesCol[(int)ConnectedData.enImageCol.ImageCol_Name]),
                    CreatedDate = answerRow.Field<DateTime>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_CreatedDate]),
                    UpdatedDate = answerRow.Field<DateTime>(ConnectedData.answerCol[(int)ConnectedData.enAnswerCol.AnswerCol_UpdatedDate]),

                };
                list.Add(image);
            }

            return list;
        }
    }
}
