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
    public static class CustomTechnicalConverter
    {
        /// <summary>
        /// Convert DataTable Technical sang List<CustomTechnical>
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<CustomTechnical> ConvertDataTableToCustomTechnicalList(DataTable table)
        {
            var list = new List<CustomTechnical>();
            foreach (DataRow row in table.Rows)
            {
                // Lấy giá trị Id từ DataRow
                // Nếu không có giá trị Id thì gán giá trị mặc định là -1
                int technicalId = row.SafeField<int?>(ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_Id]).GetValueOrDefault(-1);

                var item = new CustomTechnical
                {
                    Id = technicalId,
                    Vocabulary = row.SafeField<string>(ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_Voc]) ?? string.Empty,
                    Hiragana = row.SafeField<string>(ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_Hiragana]) ?? string.Empty,
                    English = row.SafeField<string>(ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_English]) ?? string.Empty,
                    TiengViet = row.SafeField<string>(ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_TiengViet]) ?? string.Empty,
                    Example = row.SafeField<string>(ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_Example]) ?? string.Empty,
                    Note = row.SafeField<string>(ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_Note]) ?? string.Empty,
                    CreatedDate = row.SafeField<DateTime?>(ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_CreatedDate]) ?? DateTime.Now,
                    UpdatedDate = row.SafeField<DateTime?>(ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_UpdatedDate]) ?? DateTime.Now,
                    IsActive = row.SafeField<bool?>(ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_IsActive]).GetValueOrDefault(false),
                    UserId = row.SafeField<int?>(ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_UserId]).GetValueOrDefault(-1),
                    // Lấy level
                    Level = ConnectedData.dataLoader.LoadLevelsList()?.Where(o => o.Id == row.SafeField<int?>(ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_LevelId]).GetValueOrDefault(-1)).First() ?? new CustomLevel(),
                    // Lấy Group
                    Group = ConnectedData.dataLoader.LoadGroupsList()?.Where( o => o.Id == row.SafeField<int?>(ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_GroupId]).GetValueOrDefault(-1)).First() ?? new CustomGroup(),

                    // Lấy danh sách câu trả lời
                    Answers = ConnectedData.dataLoader.LoadAnswersList()?.Where(o => o.TechnicalId == technicalId).ToList() ?? new List<CustomAnswer>(),
                    // Lấy danh sách Image
                    Images = ConnectedData.dataLoader.LoadImagesList()?.Where(o => o.TechnicalId == technicalId).ToList() ?? new List<CustomImage>(),

                    HistoryTechnical = ConnectedData.dataLoader.LoadHistoryGKTVList()?.Where(o => o.TechnicalId == technicalId).FirstOrDefault() ?? new CustomHistoryGKTV(),
                };
                list.Add(item);
            }
            return list;
        }
    }
}
