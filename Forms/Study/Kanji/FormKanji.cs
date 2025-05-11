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
using TCV_JapaNinja.Class.ManagerData;
using TCV_JapaNinja.Models.DatabaseCustoms;
using static TCV_JapaNinja.Class.ConnectedData;

namespace TCV_JapaNinja.Forms.Study.Kanji
{
    public partial class FormKanji : Form
    {
        private List<CustomKanji> Kanjis;
        private Button ActiveLevel;
        private Button ActiveLesson;

        /*
         * Load data kanji theo level, chưa load theo chương trình học
         * Nếu mục level để trống sẽ load theo Other or ...
         */

        public FormKanji()
        {
            InitializeComponent();
            DisplayLevelKanji();
        }

        /// <summary>
        /// Lấy dữ liệu kanji từ database
        /// </summary>
        /// <returns></returns>
        private List<CustomKanji> GetDataKanjis()
        {
            return dataLoader.LoadKanjisList();
        }
        /// <summary>
        /// Hiển thị nút nhấn level
        /// Lấy level từ database Kanji, sắp xếp theo ID từ nhỏ đến lớn
        /// </summary>
        private void DisplayLevelKanji()
        {
            level_flpn.Controls.Clear();
            // Lấy levels từ kanjis, sau đó chỉ lọc không trùng level.
            List<CustomLevel> levels = GetDataKanjis().Where(o => o.Level != null && o.IsActive).Select(o => o.Level).Distinct().ToList();
            // Sắp xếp danh sách level theo ID từ nhỏ đến lớn
            List<CustomLevel> sortedLevels = levels.OrderBy(level => level.Id).ToList();
            // Lấy level từ danh sách database
            foreach (CustomLevel level in sortedLevels)
            {
                // Add button vào flowlayoutpanel có name = name, tag = ID
                string levelName = level.Name.ToString();
                Button button = UserToolBoxs.createButton(level_flpn, levelName);
                button.Tag = level;
                button.Click += LevelButton_Click;
            }
        }

        private void LevelButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ActiveLevel = button;
            CustomLevel level = (CustomLevel)button.Tag;
            FilterKanjiDataByLevel();
        }
        /// <summary>
        /// Phương thức này sẽ lọc dữ liệu Kanji theo cấp đỗ đã chọn, trích xuất các số bài học duy nhất, 
        /// sắp xếp chúng theo thứ tự tăng dần, sau đó gọi -> để thực hiện.
        /// </summary>
        /// <param name="levelId"></param>
        private void FilterKanjiDataByLevel()
        {
            if (ActiveLevel == null) return; // Nếu không có level thì không làm gì cả
            // Get data kanji từ bảng table, thứ tự tăng dần
            CustomLevel level = (CustomLevel)ActiveLevel.Tag;
            List<int> lessonNumbers = GetDataKanjis().Where(o => o.Level.Id == level.Id && o.IsActive == true).Select(o => o.LessonNumber).Distinct().OrderBy(o => o).ToList();
            // kiểm tra xem có dữ liệu hay không
            if (lessonNumbers.Count > 0)
            {
                DisplayLessonButtons(lessonNumbers);
            }
            else
            {
                // xử lý trường hợp không có dữ liệu
                DisplayLessonButtons(new List<int>());
            }

        }
        /// <summary>
        /// hiển thị button số lượng bài
        /// </summary>
        /// <param name="lessonNumbers"></param>
        private void DisplayLessonButtons(List<int> lessonNumbers)
        {
            lessonNumber_flpn.Controls.Clear();
            // Nếu không có bài nào thì không cần hiển thị
            foreach (int lesson in lessonNumbers)
            {
                Button button = UserToolBoxs.createButton(lessonNumber_flpn, Languages.lableName[(int)Languages.enLableName.LabelName_Lesson, (int)Languages.LanguageIndex] + " " + lesson.ToString());
                button.Tag = lesson;
                button.Click += LessonButton_Click;
            }
        }
        /// <summary>
        /// chọn bài thực hành
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LessonButton_Click(object sender, EventArgs e)
        {
            // Handle lesson button click event
            Button button = sender as Button;
            int lessonNumber = (int)button.Tag;
            ActiveLesson = button;
            DisplayKanijComonSection(FilterKanjiDataByLessonNumber());
        }

        /// <summary>
        /// lấy những data nào là thuộc bài nào đó
        /// </summary>
        /// <param name="lessonNumber"></param>
        /// <returns></returns>
        private List<CustomKanji> FilterKanjiDataByLessonNumber()
        {
            List<CustomKanji> kanjis = new List<CustomKanji>();

            if(ActiveLevel != null && ActiveLesson != null)
            {
                CustomLevel level = (CustomLevel)ActiveLevel.Tag;
                int lessonNumber = (int)ActiveLesson.Tag;

                kanjis = GetDataKanjis().Where(o => o.Level.Id == level.Id && o.LessonNumber == lessonNumber).ToList();
            }

            return kanjis;
        }
        /// <summary>
        /// Hiển thị form con cho phần học kanji
        /// </summary>
        /// <param name="kanjiDatas"></param>
        private void DisplayKanijComonSection(List<CustomKanji> kanjis)
        {
            // Nếu được cấp quyền sẽ được học từ kanji
            if (Accounts.UserLogin.HasRermission(Accounts.codeRoles[(int)Accounts.enRoleRow.RoleRow_Kanji, (int)Accounts.enRoleCol.RoleCol_Id], Models.Account.Permission.Read))
            {
                var frmCommonSection = (CommonSection.FormCommonSection)Application.OpenForms["FormCommonSection"];
                if (frmCommonSection == null) { frmCommonSection = new CommonSection.FormCommonSection(); }
                frmCommonSection.DisplayCommonSectionData(kanjis, (int)enLearningCategory.Kanji);
                openChildForm(frmCommonSection);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Mở một form con trong panel hiện tại.
        /// </summary>
        /// <param name="childForm">Form con cần mở</param>
        private void openChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            chillformKanji_pn.Controls.Add(childForm);
            chillformKanji_pn.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
