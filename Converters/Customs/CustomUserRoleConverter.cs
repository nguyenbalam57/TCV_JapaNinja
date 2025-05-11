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
    public static class CustomUserRoleConverter
    {
        /// <summary>
        /// Convert DataTable UserRole sang List<CustomUserRole>
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<CustomUserRole> ConvertDataTableToCustomUserRoleList(DataTable table)
        {
            var list = new List<CustomUserRole>();
            foreach (DataRow row in table.Rows)
            {
                var item = new CustomUserRole
                {
                    UserId = row.SafeField<int?>(ConnectedData.userRoleCol[(int)ConnectedData.enUserRoleCol.UserRoleCol_UserId]).GetValueOrDefault(-1),
                    RoleId = row.SafeField<int?>(ConnectedData.userRoleCol[(int)ConnectedData.enUserRoleCol.UserRoleCol_RoleId]).GetValueOrDefault(-1),
                    UserIdEdit = row.SafeField<int?>(ConnectedData.userRoleCol[(int)ConnectedData.enUserRoleCol.UserRoleCol_UserId]).GetValueOrDefault(-1),
                    CreatedDate = row.SafeField<DateTime?>(ConnectedData.userRoleCol[(int)ConnectedData.enUserRoleCol.UserRoleCol_CreatedDate]) ?? DateTime.Now,
                };
                list.Add(item);
            }
            return list;
        }
    }
}
