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
    public static class CustomVocabularyConverter
    {
        /// <summary>
        /// Convert DataTable Vocabulary sang List<CustomVocabulary>
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<CustomVocabulary> ConvertDataTableToCustomVocabularyList(DataTable table)
        {
            var list = new List<CustomVocabulary>();
            foreach (DataRow row in table.Rows)
            {
                // Lấy giá trị Id từ DataRow
                int vocaId = row.SafeField<int?>(ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_Id]).GetValueOrDefault(-1);
                var item = new CustomVocabulary
                {
                    Id = vocaId,
                    LessonNumber = row.SafeField<int?>(ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_LessonNumber]).GetValueOrDefault(-1),
                    Vocabulary = row.SafeField<string>(ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_Vocabulary]) ?? string.Empty,
                    Kanji = row.SafeField<string>(ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_Kanji]) ?? string.Empty,
                    Hiragana = row.SafeField<string>(ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_Hiragana]) ?? string.Empty,
                    English = row.SafeField<string>(ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_English]) ?? string.Empty,
                    TiengViet = row.SafeField<string>(ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_TiengViet]) ?? string.Empty,
                    Example = row.SafeField<string>(ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_Example]) ?? string.Empty,
                    Note = row.SafeField<string>(ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_Note]) ?? string.Empty,
                    CreatedDate = row.SafeField<DateTime?>(ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_CreatedDate]) ?? DateTime.Now,
                    UpdatedDate = row.SafeField<DateTime?>(ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_UpdatedDate]) ?? DateTime.Now,
                    IsActive = row.SafeField<bool?>(ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_IsActive]).GetValueOrDefault(false),
                    UserId = row.SafeField<int?>(ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_UserId]).GetValueOrDefault(-1),

                    // Lấy giá trị Level từ danh sách Level
                    Level = ConnectedData.dataLoader.LoadLevelsList()?.Where(o => o.Id == row.SafeField<int?>(ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_LevelId]).GetValueOrDefault(-1)).First() ?? new CustomLevel(),
                    // Lấy giá trị group từ danh sách group
                    Group = ConnectedData.dataLoader.LoadGroupsList()?.Where(o => o.Id == row.SafeField<int?>(ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_GroupId]).GetValueOrDefault(-1)).First() ?? new CustomGroup(),
                    // Lấy giá trị Curriculum từ danh sách Curriculum
                    Curriculum = ConnectedData.dataLoader.LoadCurriculumsList()?.Where(o => o.Id == row.SafeField<int?>(ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_CurriculumId]).GetValueOrDefault(-1)).First() ?? new CustomCurriculum(),
                    // Lấy giá trị TypeVoca từ danh sách TypeVoca
                    TypeVoca = ConnectedData.dataLoader.LoadTypeVocasList()?.Where(o => o.Id == row.SafeField<int?>(ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_TypeVocaId]).GetValueOrDefault(-1)).First() ?? new CustomTypeVoca(),

                    HistoryVocabulary = ConnectedData.dataLoader.LoadHistoryGKTVList()?.Where(o => o.VocabularyId == vocaId).FirstOrDefault() ?? new CustomHistoryGKTV(),
                };
                list.Add(item);
            }
            return list;
        }
    }
}
