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
                int kanjiId = kanjiRow.SafeFieId<int>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_Id]);

                var kanji = new CustomKanji
                {
                    Id = kanjiId,
                    LessonNumber = kanjiRow.SafeFieId<int?>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_LessonNumber]).GetValueOrDefault(-1),
                    Kanji = kanjiRow.SafeFieId<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_Kanji]) ?? string.Empty,
                    HanTu = kanjiRow.SafeFieId<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_HanTu]) ?? string.Empty,
                    AmOn = kanjiRow.SafeFieId<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_AmOn]) ?? string.Empty,
                    AmKun = kanjiRow.SafeFieId<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_AmKun]) ?? string.Empty,
                    English = kanjiRow.SafeFieId<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_English]) ?? string.Empty,
                    TiengViet = kanjiRow.SafeFieId<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_TiengViet]) ?? string.Empty,
                    Example = kanjiRow.SafeFieId<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_Example]) ?? string.Empty,
                    Note = kanjiRow.SafeFieId<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_Note]) ?? string.Empty,
                    Strokes = kanjiRow.SafeFieId<int?>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_Strokes]).GetValueOrDefault(-1),
                    CreatedDate = kanjiRow.SafeFieId<DateTime?>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_CreatedDate]) ?? DateTime.Now,
                    UpdatedDate = kanjiRow.SafeFieId<DateTime?>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_UpdatedDate]) ?? DateTime.Now,
                    IsActive = kanjiRow.SafeFieId<bool?>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_IsActive]).GetValueOrDefault(false),
                    LevelId = kanjiRow.SafeFieId<int?>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_LevelId]).GetValueOrDefault(-1),
                    UserId = kanjiRow.SafeFieId<int?>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_UserId]).GetValueOrDefault(-1),
                    //CurriculumId = kanjiRow.Field<int?>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_CurriculumId]).GetValueOrDefault(-1),

                    // Lấy danh sách Answer
                    Answers = allAnswers?.Where(a => a.KanjiId == kanjiId).ToList() ?? new List<CustomAnswer>(),

                    // Lấy danh sách Image
                    Images = allImages?.Where(img => img.KanjiId == kanjiId).ToList() ?? new List<CustomImage>()
                };

                kanjiList.Add(kanji);
            }
 

            return kanjiList;
        }
    }
}
