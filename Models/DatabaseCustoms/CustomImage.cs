using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TCV_JapaNinja.Models.DatabaseCustoms
{
    public class CustomImage
    {
        public int Id { get; set; } // ID ảnh
        public int VocabularyId { get; set; } // ID từ vựng
        public int TechnicalId { get; set; } // ID từ vựng chuyên ngành
        public int GrammarId { get; set; } // ID ngữ pháp
        public int KanjiId { get; set; } // ID kanji
        public byte[] ImageData { get; set; } // Dữ liệu ảnh, Lưu dưới dạng byte[] 
        public string ImageType { get; set; } // Kiểu ảnh, ví dụ: "image/png", "image/jpeg"
        public string ImageName { get; set; } // Tên ảnh
        public DateTime CreatedDate { get; set; } // Ngày tạo ảnh
        public DateTime UpdatedDate { get; set; } // Ngày cập nhật ảnh

        /// <summary>
        /// Khởi tạo ban đầu
        /// </summary>
        public CustomImage()
        {
            Id = -1; 
            ImageData = new byte[0];
            ImageType = string.Empty;
            ImageName = string.Empty;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }
        /// <summary>
        /// Khởi tạo với các tham số
        /// </summary>
        /// <param name="id"></param>
        /// <param name="imageData"></param>
        /// <param name="imageType"></param>
        /// <param name="imageName"></param>
        /// <param name="createdDate"></param>
        /// <param name="updatedDate"></param>
        public CustomImage(int id, byte[] imageData, string imageType, string imageName, DateTime createdDate, DateTime updatedDate)
        {
            Id = id;
            ImageData = imageData;
            ImageType = imageType;
            ImageName = imageName;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
        }
        /// <summary>
        /// Khởi tạo Image, Type, Name
        /// </summary>
        /// <param name="imageData"></param>
        /// <param name="imageType"></param>
        /// <param name="imageName"></param>
        public CustomImage(byte[] imageData, string imageType, string imageName)
        {
            Id = -1;
            ImageData = imageData;
            ImageType = imageType;
            ImageName = imageName;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }
        /// <summary>
        /// Khởi tạo Name, Type
        /// </summary>
        /// <param name="imageName"></param>
        /// <param name="imageType"></param>
        public CustomImage(string imageName, string imageType)
        {
            Id = -1;
            ImageData = new byte[0];
            ImageType = imageType;
            ImageName = imageName;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }
        /// <summary>
        /// Khởi tạo từ CustomImage khác
        /// </summary>
        /// <param name="customImage"></param>
        public CustomImage(CustomImage customImage)
        {
            Id = customImage.Id;
            ImageData = customImage.ImageData;
            ImageType = customImage.ImageType;
            ImageName = customImage.ImageName;
            CreatedDate = customImage.CreatedDate;
            UpdatedDate = customImage.UpdatedDate;
        }

        /// <summary>
        /// Chuyển đổi dữ liệu ảnh từ byte[] sang Image
        /// </summary>
        /// <returns></returns>
        public Image GetImage()
        {
            if (ImageData == null || ImageData.Length == 0)
                return null;
            using (var ms = new System.IO.MemoryStream(ImageData))
            {
                return Image.FromStream(ms);
            }
        }

        /// <summary>
        /// Chuyển đổi dữ liệu ảnh từ Image sang byte[]
        /// </summary>
        /// <param name="image"></param>
        public void SetImage(Image image)
        {
            if (image == null)
                return;
            using (var ms = new System.IO.MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ImageData = ms.ToArray();
            }
        }
    }
}
