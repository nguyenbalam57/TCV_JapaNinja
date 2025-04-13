using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCV_JapaNinja.Class;
using TCV_JapaNinja.Models.DatabaseCustoms;
using TCV_JapaNinja.UserControls.Studys.CommonSections.Learnings;

namespace TCV_JapaNinja.Forms.Study.CommonSection
{
    public partial class FormLearning : Form
    {
        /*
         * Lấy thông tin data về form
         * Hiển thị dưới dạng học tập
         * Tham khảo các cách hiển thị học tập của các ứng dụng khác
         * Các nội dung chính cần thực hiện
         *  - Hiển thị danh sách
         *  - Nhấn vào từ hiển thị thông tin chi tiết
         *  - Cấu tạo và chia ô hiển thị
         *  - Tạo chức năng khi nhấn thì hiển thị ô chi tiết, có nút ẩn ô chi tiết, hoặc nhấn lại từ đó thì sẽ ẩn ô chi tiết
         *  - Tính năng nâng cao, xem nhanh, di chuyển chuột vào ô cần xem thì hiển thị bản text hover thông tin chi tiết
         *  - Thao tác nào đó để có thể xem được ví dụ sử dụng, hay từ liên quan đến nhau
         *  - Thêm chức năng nhớ từ vừa học, thêm nút trái tim để hiển thị. Load từ data về từ nào đã học thì hiển thị trái tim đỏ, tô trái tim
         * Thiết kế giao diện UX UI cho dễ sử dụng
         * 
         * 
         */

        DataTable leaningData;

        public FormLearning()
        {
            InitializeComponent();
        }

        public void getDataTableLeaningData(DataTable dataTable)
        {
            leaningData = new DataTable();
            leaningData = dataTable;
            //viewLeaning_dgv.DataSource = leaningData;

            setDataLayoutKanji();
        }

        public void setDataLayoutKanji()
        {
            if (leaningData == null || leaningData.Rows.Count == 0) return;

            viewVocabulary_flpn.Controls.Clear();

            // Lấy dữ liệu từ bảng Answers
            List<CustomAnswer> answers = Converters.Customs.CustomAnswerConverter.ConvertDataTableToCustomAnswerList(ConnectedData.dataSet.Tables[ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Answer]]);
            // Lấy dữ liệu từ bảng image
            List<CustomImage> images = Converters.Customs.CustomImageConverter.ConvertDataTableToCustomImageList(ConnectedData.dataSet.Tables[ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Images]]);
            // Lấy dữ liệu từ bảng kanji
            List<CustomKanji> kanjis = Converters.Customs.CustomKanjiConverter.ConvertDataTableToCustomKanjiList(leaningData, answers, images);

            foreach (var kanji in kanjis)
            {
                var item = new WordDisplayKanji
                {
                    Data = kanji,
                    Width = viewVocabulary_flpn.ClientSize.Width - 10,
                };

                viewVocabulary_flpn.Controls.Add(item);
            }
        }

        private void viewVocabulary_flpn_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control ctrl in viewVocabulary_flpn.Controls)
            {
                if (ctrl is WordDisplayKanji)
                {
                    ctrl.Width = viewVocabulary_flpn.ClientSize.Width;
                }
            }
        }
    }
}
