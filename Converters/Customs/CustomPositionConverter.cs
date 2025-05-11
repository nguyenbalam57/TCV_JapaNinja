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
    public static class CustomPositionConverter
    {
        /// <summary>
        /// Convert DataTable Position sang List<CustomPosition>
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<CustomPosition> ConvertDataTableToCustomPositionList(DataTable table)
        {
            var list = new List<CustomPosition>();
            foreach (DataRow row in table.Rows)
            {
                var item = new CustomPosition
                {
                    Id = row.SafeField<int?>(ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Id]).GetValueOrDefault(-1),
                    Name = row.SafeField<string>(ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Name]) ?? string.Empty,
                    Description = row.SafeField<string>(ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Description]) ?? string.Empty,
                    CreatedDate = row.SafeField<DateTime?>(ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_CreatedDate]) ?? DateTime.Now,
                    UpdatedDate = row.SafeField<DateTime?>(ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_UpdatedDate]) ?? DateTime.Now,
                    IsActive = row.SafeField<bool?>(ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_IsActive]).GetValueOrDefault(false)
                };
                list.Add(item);
            }
            return list;
        }
    }
}
