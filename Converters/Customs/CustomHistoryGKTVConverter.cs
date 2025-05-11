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
    public static class CustomHistoryGKTVConverter
    {
        /// <summary>
        /// Convert DataTable HistoryGKTV sang List<CustomHistoryGKTV>
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<CustomHistoryGKTV> ConvertDataTableToCustomHistoryGKTVList(DataTable table)
        {
            var list = new List<CustomHistoryGKTV>();
            foreach (DataRow row in table.Rows)
            {
                var item = new CustomHistoryGKTV
                {
                    Id = row.SafeField<int?>(ConnectedData.historyGKTVCol[(int)ConnectedData.enHistoryGKTVCol.HisGKTVCol_Id]).GetValueOrDefault(-1),
                    UserId = row.SafeField<int?>(ConnectedData.historyGKTVCol[(int)ConnectedData.enHistoryGKTVCol.HisGKTVCol_UserId]).GetValueOrDefault(-1),
                    GrammarId = row.SafeField<int?>(ConnectedData.historyGKTVCol[(int)ConnectedData.enHistoryGKTVCol.HisGKTVCol_GrammarId]).GetValueOrDefault(-1),
                    KanjiId = row.SafeField<int?>(ConnectedData.historyGKTVCol[(int)ConnectedData.enHistoryGKTVCol.HisGKTVCol_KanjiId]).GetValueOrDefault(-1),
                    TechnicalId = row.SafeField<int?>(ConnectedData.historyGKTVCol[(int)ConnectedData.enHistoryGKTVCol.HisGKTVCol_TechnicalId]).GetValueOrDefault(-1),
                    VocabularyId = row.SafeField<int?>(ConnectedData.historyGKTVCol[(int)ConnectedData.enHistoryGKTVCol.HisGKTVCol_VocId]).GetValueOrDefault(-1),
                    IsRemembered = row.SafeField<bool?>(ConnectedData.historyGKTVCol[(int)ConnectedData.enHistoryGKTVCol.HisGKTVCol_IsRemembered]).GetValueOrDefault(false),
                    IsRememberedCheck = row.SafeField<bool?>(ConnectedData.historyGKTVCol[(int)ConnectedData.enHistoryGKTVCol.HisGKTVCol_IsRememberedCheck]).GetValueOrDefault(false),
                    ICons = row.SafeField<int?>(ConnectedData.historyGKTVCol[(int)ConnectedData.enHistoryGKTVCol.HisGKTVCol_Icons]).GetValueOrDefault(-1),
                    CreatedDate = row.SafeField<DateTime?>(ConnectedData.historyGKTVCol[(int)ConnectedData.enHistoryGKTVCol.HisGKTVCol_CreatedDate]) ?? DateTime.Now,
                    UpdatedDate = row.SafeField<DateTime?>(ConnectedData.historyGKTVCol[(int)ConnectedData.enHistoryGKTVCol.HisGKTVCol_UpdatedDate]) ?? DateTime.Now,
                };
                list.Add(item);
            }
            return list;
        }
    }
}
