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
    public static class CustomGroupConverter
    {
        /// <summary>
        /// Convert DataTable Group sang List<CustomGroup>
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<CustomGroup> ConvertDataTableToCustomGroupList(DataTable table)
        {
            var list = new List<CustomGroup>();
            foreach (DataRow row in table.Rows)
            {
                var item = new CustomGroup
                {
                    Id = row.SafeField<int?>(ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Id]).GetValueOrDefault(-1),
                    Name = row.SafeField<string>(ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Name]) ?? string.Empty,
                    Description = row.SafeField<string>(ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Description]) ?? string.Empty,
                    CreatedDate = row.SafeField<DateTime?>(ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_CreatedDate]) ?? DateTime.Now,
                    UpdatedDate = row.SafeField<DateTime?>(ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_UpdatedDate]) ?? DateTime.Now,
                    IsActive = row.SafeField<bool?>(ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_IsActive]).GetValueOrDefault(false)
                };
                list.Add(item);
            }
            return list;
        }
    }
}
