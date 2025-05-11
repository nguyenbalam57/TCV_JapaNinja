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
    public static class CustomRoleConverter
    {
        /// <summary>
        /// Convert DataTable Role sang List<CustomRole>
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<CustomRole> ConvertDataTableToCustomRoleList(DataTable table)
        {
            var list = new List<CustomRole>();
            foreach (DataRow row in table.Rows)
            {
                var item = new CustomRole
                {
                    Id = row.SafeField<int?>(ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Id]).GetValueOrDefault(-1),
                    Code = row.SafeField<string>(ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Code]) ?? string.Empty,
                    Name = row.SafeField<string>(ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Name]) ?? string.Empty,
                    Description = row.SafeField<string>(ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Description]) ?? string.Empty,
                    Created = row.SafeField<bool?>(ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Created]).GetValueOrDefault(false),
                    Readed = row.SafeField<bool?>(ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Read]).GetValueOrDefault(false),
                    Updated = row.SafeField<bool?>(ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Update]).GetValueOrDefault(false),
                    Deleted = row.SafeField<bool?>(ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Delete]).GetValueOrDefault(false),
                    CreatedDate = row.SafeField<DateTime?>(ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_CreatedDate]) ?? DateTime.Now,
                    UpdatedDate = row.SafeField<DateTime?>(ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_UpdatedDate]) ?? DateTime.Now,
                    IsActive = row.SafeField<bool?>(ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_IsActive]).GetValueOrDefault(false)
                };
                list.Add(item);
            }
            return list;
        }
    }
}
