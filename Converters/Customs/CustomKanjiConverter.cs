using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public static List<CustomKanji> ConvertDataTableToCustomKanjiList(DataTable table)
        {
            var list = new List<CustomKanji>();

            foreach (DataRow row in table.Rows)
            {
                int kanjiId = row.SafeField<int?>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_Id]).GetValueOrDefault(-1);

                var item = new CustomKanji
                {
                    Id = kanjiId,
                    LessonNumber = row.SafeField<int?>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_LessonNumber]).GetValueOrDefault(-1),
                    Kanji = row.SafeField<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_Kanji]) ?? string.Empty,
                    HanTu = row.SafeField<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_HanTu]) ?? string.Empty,
                    AmOn = row.SafeField<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_AmOn]) ?? string.Empty,
                    AmKun = row.SafeField<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_AmKun]) ?? string.Empty,
                    English = row.SafeField<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_English]) ?? string.Empty,
                    TiengViet = row.SafeField<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_TiengViet]) ?? string.Empty,
                    Example = row.SafeField<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_Example]) ?? string.Empty,
                    Note = row.SafeField<string>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_Note]) ?? string.Empty,
                    Strokes = row.SafeField<int?>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_Strokes]).GetValueOrDefault(-1),
                    CreatedDate = row.SafeField<DateTime?>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_CreatedDate]) ?? DateTime.Now,
                    UpdatedDate = row.SafeField<DateTime?>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_UpdatedDate]) ?? DateTime.Now,
                    IsActive = row.SafeField<bool?>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_IsActive]).GetValueOrDefault(false),
                    UserId = row.SafeField<int?>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_UserId]).GetValueOrDefault(-1),
                    // Lấy giá trị Level từ danh sách Level
                    Level = ConnectedData.dataLoader.LoadLevelsList()?.Where(o => o.Id == row.SafeField<int?>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_LevelId]).GetValueOrDefault(-1)).FirstOrDefault() ?? new CustomLevel(),
                    // Lấy giá trị Curriculum từ danh sách Curriculum
                    Curriculum = ConnectedData.dataLoader.LoadCurriculumsList()?.Where(o => o.Id == row.Field<int?>(ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_CurriculumId]).GetValueOrDefault(-1)).FirstOrDefault() ?? new CustomCurriculum(),
                    // Lấy danh sách Answer
                    Answers = ConnectedData.dataLoader.LoadAnswersList()?.Where(o => o.KanjiId == kanjiId).ToList() ?? new List<CustomAnswer>(),
                    // Lấy danh sách Image
                    Images = ConnectedData.dataLoader.LoadImagesList()?.Where(img => img.KanjiId == kanjiId).ToList() ?? new List<CustomImage>(),

                    HistoryKanji = ConnectedData.dataLoader.LoadHistoryGKTVList()?.Where(o => o.KanjiId == kanjiId).FirstOrDefault() ?? new CustomHistoryGKTV(),
                };

                list.Add(item);
            }
 

            return list;
        }
    }
}
