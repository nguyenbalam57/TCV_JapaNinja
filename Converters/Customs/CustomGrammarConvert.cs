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
    public static class CustomGrammarConvert
    {
        /// <summary>
        /// Convert DataTable Grammar sang List<CustomGrammar>
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<CustomGrammar> ConvertDataTableToCustomGrammarList(DataTable table)
        {
            var list = new List<CustomGrammar>();
            foreach (DataRow row in table.Rows)
            {
                int grammarId = row.SafeField<int?>(ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_Id]).GetValueOrDefault(-1);
                var item = new CustomGrammar
                {
                    Id = grammarId,
                    LessonNumber = row.SafeField<int?>(ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_LessonNumber]).GetValueOrDefault(-1),
                    Structure = row.SafeField<string>(ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_Structure]) ?? string.Empty,
                    Sample = row.SafeField<string>(ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_Sample]) ?? string.Empty,
                    Explain = row.SafeField<string>(ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_Explain]) ?? string.Empty,
                    Example = row.SafeField<string>(ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_Example]) ?? string.Empty,
                    Note = row.SafeField<string>(ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_Note]) ?? string.Empty,
                    CreatedDate = row.SafeField<DateTime?>(ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_CreatedData]) ?? DateTime.Now,
                    UpdatedDate = row.SafeField<DateTime?>(ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_UpdatedDate]) ?? DateTime.Now,
                    IsActive = row.SafeField<bool?>(ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_IsActive]).GetValueOrDefault(false),
                    UserId = row.SafeField<int?>(ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_UserId]).GetValueOrDefault(-1),

                    // lấy thông tin từ bảng Level
                    Level = ConnectedData.dataLoader.LoadLevelsList()?.Where(o => o.Id == row.Field<int?>(ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_LevelId]).GetValueOrDefault(-1)).First() ?? new CustomLevel(),
                    // lấy thông tin từ bảng Curriculum
                    Curriculum = ConnectedData.dataLoader.LoadCurriculumsList()?.Where(o => o.Id == row.Field<int?>(ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_CurriculumId]).GetValueOrDefault(-1)).First() ?? new CustomCurriculum(),

                    HistoryGrammar = ConnectedData.dataLoader.LoadHistoryGKTVList()?.Where(o => o.GrammarId == grammarId).FirstOrDefault() ?? new CustomHistoryGKTV(),
                };
                list.Add(item);
            }
            return list;
        }
    }
}
