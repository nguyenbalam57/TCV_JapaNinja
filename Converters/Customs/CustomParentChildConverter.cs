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
    public static class CustomParentChildConverter
    {
        /// <summary>
        /// Convert DataTable ParentChild sang List<CustomParentChild>
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<CustomParentChild> ConvertDataTableToCustomParentChildList(DataTable table)
        {
            var list = new List<CustomParentChild>();
            foreach (DataRow row in table.Rows)
            {
                var item = new CustomParentChild
                {
                    ParentId = row.SafeField<int?>(ConnectedData.parentChildCol[(int)ConnectedData.enParentChildCol.ParentChildCol_ParentId]).GetValueOrDefault(-1),
                    ChildId = row.SafeField<int?>(ConnectedData.parentChildCol[(int)ConnectedData.enParentChildCol.ParentChildCol_ChildId]).GetValueOrDefault(-1)
                };
                list.Add(item);
            }
            return list;
        }
        /// <summary>
        /// Get danh sách cha của user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static List<CustomUser> GetParentsList(CustomUser user)
        {
            var list = new List<CustomUser>();
            var parentChildList = ConnectedData.dataLoader.LoadParentChildsList();
            if (parentChildList != null && user.Id > -1)
            {
                // Lấy danh sách cha của user
                var parentChild = parentChildList.Where(o => o.ChildId == user.Id).ToList();
                foreach (CustomParentChild parent in parentChild)
                {
                    var parentUser = ConnectedData.dataLoader.LoadUsersList()?.Where(o => o.Id == parent.ParentId).FirstOrDefault();
                    if (parentUser != null)
                    {
                        list.Add(parentUser);
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// Get danh sách con của user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static List<CustomUser> GetChildsList(CustomUser user)
        {
            var list = new List<CustomUser>();
            var parentChildList = ConnectedData.dataLoader.LoadParentChildsList();
            if (parentChildList != null && user.Id > -1)
            {
                // Lấy danh sách con của user
                var parentChild = parentChildList.Where(o => o.ParentId == user.Id).ToList();
                foreach (CustomParentChild child in parentChild)
                {
                    var childUser = ConnectedData.dataLoader.LoadUsersList()?.Where(o => o.Id == child.ChildId).FirstOrDefault();
                    if (childUser != null)
                    {
                        list.Add(childUser);
                    }
                }
            }
            return list;
        }
    }
}
