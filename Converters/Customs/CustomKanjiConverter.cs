using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCV_JapaNinja.Class;
using TCV_JapaNinja.Forms.Admin_Managent;
using TCV_JapaNinja.Models.DatabaseCustoms;

namespace TCV_JapaNinja.Converters.Customs
{
    public static class CustomKanjiConverter
    {
        /// <summary>
        /// Convert DataTable Kanji sang List<CustomKanji>
        /// 
        /// </summary>
        /// <param name="kanjiTable"></param>
        /// <param name="allAnswers"></param>
        /// <param name="allImages"></param>
        /// <returns></returns>
        public static List<CustomKanji> ConvertDataTableToCustomKanjiList(DataTable kanjiTable, List<CustomAnswer> allAnswers, List<CustomImage> allImages)
        {
            var kanjiList = new List<CustomKanji>();

            foreach (DataRow kanjiRow in kanjiTable.Rows)
            {
                int kanjiId = kanjiRow.Field<int>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_Id]);

                var kanji = new CustomKanji
                {
                    Id = kanjiId,
                    LessonNumber = kanjiRow.Field<int>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_LessonNumber]),
                    Kanji = kanjiRow.Field<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_Kanji]) ?? string.Empty,
                    HanTu = kanjiRow.Field<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_HanTu]) ?? string.Empty,
                    AmOn = kanjiRow.Field<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_AmOn]) ?? string.Empty,
                    AmKun = kanjiRow.Field<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_AmKun]) ?? string.Empty,
                    English = kanjiRow.Field<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_English]) ?? string.Empty,
                    TiengViet = kanjiRow.Field<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_TiengViet]) ?? string.Empty,
                    Example = kanjiRow.Field<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_Example]) ?? string.Empty,
                    Note = kanjiRow.Field<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_Note]) ?? string.Empty,
                    Strokes = kanjiRow.Field<int>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_Strokes]),
                    CreatedDate = kanjiRow.Field<DateTime>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_CreatedDate]),
                    UpdatedDate = kanjiRow.Field<DateTime>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_UpdatedDate]),
                    IsActive = kanjiRow.Field<bool>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_IsActive]),
                    LevelId = kanjiRow.Field<int>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_LevelId]),
                    UserId = kanjiRow.Field<int>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_UserId]),
                    CurriculumId = kanjiRow.Field<int>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_CurriculumId]),

                    // Lấy danh sách Answer
                    Answers = allAnswers.Where(a => a.KanjiId == kanjiId).ToList(),

                    // Lấy danh sách Image
                    Images = allImages.Where(img => img.KanjiId == kanjiId).ToList()
                };

                kanjiList.Add(kanji);
            }
 

            return kanjiList;
        }
    }
}
