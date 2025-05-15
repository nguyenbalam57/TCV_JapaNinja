using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCV_JapaNinja.Class;
using TCV_JapaNinja.Models.DatabaseCustoms;
using TCV_JapaNinja.UserControls.Studys.CommonSections.Learnings;
using static TCV_JapaNinja.Class.ConnectedData;

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

        /*
         * Phần đang còn làm dở là nút heart (trái tim) chưa hoàn thành, có animation của heart và chỉ cần tải ảnh và add vào.
         */

        private List<CustomKanji> Kanjis = new List<CustomKanji>();

        public FormLearning()
        {
            InitializeComponent();
            SetUpUI();
        }

        private void SetUpUI ()
        {
            this.TopLevel = false;
        }

        /// <summary>
        /// Lấy dữ liệu từ database về và hiển thị lên form
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datas"></param>
        /// <param name="leaningCatego"></param>
        public void GetDataTableLeaningData<T>(List<T> datas, int leaningCatego) where T : class
        {

            enLearningCategory enLearning = (enLearningCategory)leaningCatego;

            switch (enLearning)
            {
                case enLearningCategory.Kanji:
                    LoadKanjiDisplay(datas as List<CustomKanji>);
                    break;
                case enLearningCategory.Vocabulary:
                    LoadVocabularyDisplay(datas as List<CustomVocabulary>);
                    break;
                case enLearningCategory.Grammar:
                    LoadGrammarDisplay(datas as List<CustomGrammar>);
                    break;
                case enLearningCategory.Technical:
                    LoadTechnicalDisplay(datas as List<CustomTechnical>);
                    break;
                default:
                    break;
            }    
        }
        /// <summary>
        /// Load danh sách kanji vào form
        /// </summary>
        /// <param name="kanjis"></param>
        public void LoadKanjiDisplay( List<CustomKanji> kanjis )
        {
            if (Accounts.UserLogin.HasRermission(Accounts.codeRoles[(int)Accounts.enRoleRow.RoleRow_Kanji, (int)Accounts.enRoleCol.RoleCol_Id], Models.Account.Permission.Read))
            {
                if (kanjis == null || kanjis.Count() <= 0 || Kanjis.SequenceEqual(kanjis)) return;

                viewVocabulary_flpn.Controls.Clear();

                Kanjis = kanjis;

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
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        /// <summary>
        /// Load danh sách từ vựng vào form
        /// </summary>
        /// <param name="vocabularys"></param>
        public void LoadVocabularyDisplay(List<CustomVocabulary> vocabularys)
        {
            if (Accounts.UserLogin.HasRermission(Accounts.codeRoles[(int)Accounts.enRoleRow.RoleRow_Voc, (int)Accounts.enRoleCol.RoleCol_Id], Models.Account.Permission.Read))
            {
                
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        /// <summary>
        /// Load danh sách ngữ pháp vào form
        /// </summary>
        /// <param name="grammars"></param>
        public void LoadGrammarDisplay(List<CustomGrammar> grammars)
        {
            if (Accounts.UserLogin.HasRermission(Accounts.codeRoles[(int)Accounts.enRoleRow.RoleRow_Grammar, (int)Accounts.enRoleCol.RoleCol_Id], Models.Account.Permission.Read))
            {

            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Load danh sách từ kỹ thuật vào form
        /// </summary>
        /// <param name="technicals"></param>
        public void LoadTechnicalDisplay(List<CustomTechnical> technicals)
        {
            if (Accounts.UserLogin.HasRermission(Accounts.codeRoles[(int)Accounts.enRoleRow.RoleRow_Technical, (int)Accounts.enRoleCol.RoleCol_Id], Models.Account.Permission.Read))
            {

            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
