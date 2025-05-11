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

    public static class CustomCurriculumConverter
    {
        /// <summary>
        /// Convert DataTable Curriculum sang List<CustomCurriculum>
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<CustomCurriculum> ConvertDataTableToCustomCurriculumList(DataTable table)
        {
            var list = new List<CustomCurriculum>();
            foreach (DataRow row in table.Rows)
            {
                var item = new CustomCurriculum
                {
                    Id = row.SafeField<int?>(ConnectedData.curriculumCol[(int)ConnectedData.enCurriculumCol.CurriculumCol_Id]).GetValueOrDefault(-1),
                    Name = row.SafeField<string>(ConnectedData.curriculumCol[(int)ConnectedData.enCurriculumCol.CurriculumCol_Name])?? string.Empty,
                    Description = row.SafeField<string>(ConnectedData.curriculumCol[(int)ConnectedData.enCurriculumCol.CurriculumCol_Description]) ?? string.Empty,
                    CreatedDate = row.SafeField<DateTime?>(ConnectedData.curriculumCol[(int)ConnectedData.enCurriculumCol.CurriculumCol_CreatedDate]) ?? DateTime.Now,
                    UpdatedDate = row.SafeField<DateTime?>(ConnectedData.curriculumCol[(int)ConnectedData.enCurriculumCol.CurriculumCol_UpdatedDate]) ?? DateTime.Now,
                    IsActive = row.SafeField<bool?>(ConnectedData.curriculumCol[(int)ConnectedData.enCurriculumCol.CurriculumCol_IsActive]).GetValueOrDefault(false),
                    UserId = row.SafeField<int?>(ConnectedData.curriculumCol[(int)ConnectedData.enCurriculumCol.CurriculumCol_UserId]).GetValueOrDefault(-1)

                };
                list.Add(item);
            }

            return list;
        }
    }
}
