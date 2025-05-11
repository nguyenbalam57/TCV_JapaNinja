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
    public static class CustomLevelConverter
    {
        /// <summary>
        /// Convert DataTable Level sang List<CustomLevel>
        /// </summary>
        /// <param name="levelTable"></param>
        /// <returns></returns>
        public static List<CustomLevel> ConvertDataTableToCustomLevelList(DataTable levelTable)
        {
            var list = new List<CustomLevel>();
            foreach (DataRow row in levelTable.Rows)
            {
                var item = new CustomLevel
                {
                    Id = row.SafeField<int?>(ConnectedData.levelCol[(int)ConnectedData.enLevelCol.LevelCol_Id]).GetValueOrDefault(-1),
                    Name = row.SafeField<string>(ConnectedData.levelCol[(int)ConnectedData.enLevelCol.LevelCol_Name]) ?? string.Empty,
                    Description = row.SafeField<string>(ConnectedData.levelCol[(int)ConnectedData.enLevelCol.LevelCol_Description]) ?? string.Empty,
                    CreatedDate = row.SafeField<DateTime?>(ConnectedData.levelCol[(int)ConnectedData.enLevelCol.LevelCol_CreatedDate]) ?? DateTime.Now,
                    UpdatedDate = row.SafeField<DateTime?>(ConnectedData.levelCol[(int)ConnectedData.enLevelCol.LevelCol_UpdatedDate]) ?? DateTime.Now,
                    IsActive = row.SafeField<bool?>(ConnectedData.levelCol[(int)ConnectedData.enLevelCol.LevelCol_IsActive]).GetValueOrDefault(false),
                    UserId = row.SafeField<int?>(ConnectedData.levelCol[(int)ConnectedData.enLevelCol.LevelCol_UserId]).GetValueOrDefault(-1),
                };
                list.Add(item);
            }

            return list;
        }
    }
}
