using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCV_JapaNinja.Class
{
    public static class DataRowExtensions
    {
        /// <summary>
        /// Convert DataRow to T
        /// Fix Specified cast is not valid
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static T SafeField<T>(this DataRow row, string columnName)
        {
            try
            {
                if(row == null || row.IsNull(columnName))
                {
                    return default(T);
                }

                object value = row[columnName];

                if (value is T variable) 
                {
                    return (T)variable;
                }

                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch 
            {
                return default(T); 
            }

        }
    }
}
