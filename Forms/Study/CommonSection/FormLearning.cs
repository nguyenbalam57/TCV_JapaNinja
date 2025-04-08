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
            if(leaningData == null || leaningData.Rows.Count == 0) return;
            foreach (DataRow row in leaningData.Rows) 
            {
                UserControls.Studys.CommonSections.Learnings.LearningWordDisplay learningWordDisplay = new UserControls.Studys.CommonSections.Learnings.LearningWordDisplay();
                //learningWordDisplay.Dock = DockStyle.Top;
                learningWordDisplay.vocabulary_lb.Text = row[ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_Kanji]].ToString();
                learningWordDisplay.phienAm_lb.Text = row[ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_HanTu]].ToString();
                learningWordDisplay.meaning_lb.Text = row[ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_TiengViet]].ToString();
                //learningWordDisplay.Anchor = learningWordDisplay.Anchor | AnchorStyles.Left | AnchorStyles.Right;
                learningWordDisplay.Size = new Size(viewVocabulary_flpn.Size.Width, learningWordDisplay.Size.Height);

                viewVocabulary_flpn.Controls.Add(learningWordDisplay);
            }
        }


    }
}
