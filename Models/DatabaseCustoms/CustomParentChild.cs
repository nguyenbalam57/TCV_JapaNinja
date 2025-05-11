using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCV_JapaNinja.Models.DatabaseCustoms
{
    /// <summary>
    /// Lớp đại diện cho mối quan hệ cha-con giữa các phần tử trong hệ thống.
    /// </summary>
    public class CustomParentChild
    {
        public int ParentId { get; set; } // ID của phần tử cha
        public int ChildId { get; set; } // ID của phần tử con

        public CustomParentChild()
        {
            ParentId = -1;
            ChildId = -1;
        }
        public CustomParentChild(int parentId, int childId)
        {
            ParentId = parentId;
            ChildId = childId;
        }
    }
}
