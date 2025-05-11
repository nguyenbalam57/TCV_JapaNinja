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
    public static class CustomImageConverter
    {
        /// <summary>
        /// Conveter Datatable Image sang Lis<customimage>
        /// </summary>
        /// <param name="imageTable"></param>
        /// <returns></returns>
        public static List<CustomImage> ConvertDataTableToCustomImageList(DataTable imageTable)
        {
            var list = new List<CustomImage>();
            foreach (DataRow row in imageTable.Rows)
            {
                var item = new CustomImage
                {
                    Id = row.SafeField<int?>(ConnectedData.imagesCol[(int)ConnectedData.enImageCol.ImageCol_Id]).GetValueOrDefault(-1),
                    VocabularyId = row.SafeField<int?>(ConnectedData.imagesCol[(int)ConnectedData.enImageCol.ImageCol_VocId]).GetValueOrDefault(-1),
                    TechnicalId = row.SafeField<int?>(ConnectedData.imagesCol[(int)ConnectedData.enImageCol.ImageCol_TechnicalId]).GetValueOrDefault(-1),
                    GrammarId = row.SafeField<int?>(ConnectedData.imagesCol[(int)ConnectedData.enImageCol.ImageCol_GrammarId]).GetValueOrDefault(-1),
                    KanjiId = row.SafeField<int?>(ConnectedData.imagesCol[(int)ConnectedData.enImageCol.ImageCol_KanjiId]).GetValueOrDefault(-1),
                    ImageData = row.SafeField<byte[]>(ConnectedData.imagesCol[(int)ConnectedData.enImageCol.ImageCol_Data]) ?? null,
                    ImageType = row.SafeField<string>(ConnectedData.imagesCol[(int)ConnectedData.enImageCol.ImageCol_Type]) ?? string.Empty,
                    ImageName = row.SafeField<string>(ConnectedData.imagesCol[(int)ConnectedData.enImageCol.ImageCol_Name]) ?? string.Empty,
                    CreatedDate = row.SafeField<DateTime?>(ConnectedData.imagesCol[(int)ConnectedData.enImageCol.ImageCol_CreatedDate]) ?? DateTime.Now,
                    UpdatedDate = row.SafeField<DateTime?>(ConnectedData.imagesCol[(int)ConnectedData.enImageCol.ImageCol_UpdatedDate]) ?? DateTime.Now,

                };
                list.Add(item);
            }

            return list;
        }
    }
}
