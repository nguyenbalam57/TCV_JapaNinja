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
    public static class CustomUserConverter
    {
        /// <summary>
        /// Convert DataTable User sang List<CustomUser>
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<CustomUser> ConvertDataTableToCustomUserList(DataTable table)
        {
            var list = new List<CustomUser>();
            foreach (DataRow row in table.Rows)
            {
                // Lấy giá trị Id từ DataRow
                int userId = row.SafeField<int?>(ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Id]).GetValueOrDefault(-1);
                var item = new CustomUser
                {
                    Id = userId,
                    UserImage = row.SafeField<byte[]>(ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Image]) ?? null,
                    EmployeeCode = row.SafeField<string>(ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_EmployeeCode]) ?? string.Empty,
                    Name = row.SafeField<string>(ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Name]) ?? string.Empty,
                    Password = row.SafeField<string>(ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Pasword]) ?? string.Empty,
                    PasswordOld = row.SafeField<string>(ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_PaswordOld]) ?? string.Empty,
                    Description = row.SafeField<string>(ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Description]) ?? string.Empty,
                    Email = row.SafeField<string>(ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Email]) ?? string.Empty,
                    PhoneNumber = row.SafeField<string>(ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Phone]) ?? string.Empty,
                    CreatedDate = row.SafeField<DateTime?>(ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_CreatedDate]) ?? DateTime.Now,
                    UpdatedDate = row.SafeField<DateTime?>(ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_UpdatedDate]) ?? DateTime.Now,
                    IsActive = row.SafeField<bool?>(ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_IsActive]).GetValueOrDefault(false),
                    IPAddress = row.SafeField<string>(ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_IPAddress]) ?? string.Empty,

                    // Lấy Nhóm
                    Group = ConnectedData.dataLoader.LoadGroupsList()?.Where(o => o.Id == row.SafeField<int?>(ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_GroupId]).GetValueOrDefault(-1)).First() ?? new CustomGroup(),
                    // Lấy Vị trí
                    Position = ConnectedData.dataLoader.LoadPositionsList()?.Where( o => o.Id == row.SafeField<int?>(ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_PositionId]).GetValueOrDefault(-1)).First() ?? new CustomPosition(),
                };
                 

                list.Add(item);
            }
            return list;
        }
    }
}
