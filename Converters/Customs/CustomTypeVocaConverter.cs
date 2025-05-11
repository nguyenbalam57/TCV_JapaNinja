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
    public class CustomTypeVocaConverter
    {
        /// <summary>
        /// Convert DataTable TypeVoca sang List<CustomTypeVoca>
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<CustomTypeVoca> ConvertDataTableToCustomTypeVocaList(DataTable table)
        {
            var list = new List<CustomTypeVoca>();
            foreach (DataRow row in table.Rows)
            {
                var item = new CustomTypeVoca
                {
                    Id = row.SafeField<int?>(ConnectedData.typeVocCol[(int)ConnectedData.enTypeVocCol.TypeVocCol_Id]).GetValueOrDefault(-1),
                    Name = row.SafeField<string>(ConnectedData.typeVocCol[(int)ConnectedData.enTypeVocCol.TypeVocCol_Name]) ?? string.Empty,
                    Description = row.SafeField<string>(ConnectedData.typeVocCol[(int)ConnectedData.enTypeVocCol.TypeVocCol_Description]) ?? string.Empty,
                    CreatedDate = row.SafeField<DateTime?>(ConnectedData.typeVocCol[(int)ConnectedData.enTypeVocCol.TypeVocCol_CreatedDate]) ?? DateTime.Now,
                    UpdatedDate = row.SafeField<DateTime?>(ConnectedData.typeVocCol[(int)ConnectedData.enTypeVocCol.TypeVocCol_UpdatedDate]) ?? DateTime.Now,
                    IsActive = row.SafeField<bool?>(ConnectedData.typeVocCol[(int)ConnectedData.enTypeVocCol.TypeVocCol_IsActive]).GetValueOrDefault(false),
                    UserId = row.SafeField<int?>(ConnectedData.typeVocCol[(int)ConnectedData.enTypeVocCol.TypeVocCol_UserId]).GetValueOrDefault(-1)
                };
                list.Add(item);
            }
            return list;
        }
    }
}
