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

namespace TCV_JapaNinja.Forms.Study.Kanji
{
    public partial class FormKanji : Form
    {
        DataTable kanjiTable;

        public FormKanji()
        {
            InitializeComponent();
            DisplayLevel();
        }
        /// <summary>
        /// Hiển thị nút nhấn level
        /// </summary>
        private void DisplayLevel()
        {
            DataTable levelTable = ConnectedData.dataSet.Tables[ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Level]];
            // Lấy level từ danh sách database
            foreach(DataRow row in levelTable.Rows)
            {
                // Add button vào flowlayoutpanel có name = name, tag = ID
                int levelId = Convert.ToInt32(row[ConnectedData.levelCol[(int)ConnectedData.enLevelCol.LevelCol_Id]]);
                string levelName = row[ConnectedData.levelCol[(int)ConnectedData.enLevelCol.LevelCol_Name]].ToString();
                Button button = UserToolBoxs.createButton(level_flpn, levelId, levelName);
                button.Click += LevelButton_Click;
            }
        }

        private void LevelButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int levelId = (int)button.Tag;
            FilterKanjiDataByLevel(levelId);
        }
        /// <summary>
        /// Phương thức này sẽ lọc dữ liệu Kanji theo cấp đỗ đã chọn, trích xuất các số bài học duy nhất, 
        /// sắp xếp chúngs theo thứ tự tăng dần, sau đó gọi -> để thực hiện.
        /// </summary>
        /// <param name="levelId"></param>
        private void FilterKanjiDataByLevel(int levelId)
        {
            // Get data kanji từ bảng table
            DataTable kanjis = ConnectedData.dataSet.Tables[ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Kanji]];
            DataView dataView = new DataView(kanjis);
            dataView.RowFilter = $"{ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_LevelId]} = {levelId}";

            if(dataView.Count > 0)
            {
                // Lấy lessonNumber (Bài) theo thứ tự tăng dần
                var uniqueLessons = dataView.ToTable(true, $"{ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_LessonNumber]}")
                                            .AsEnumerable()
                                            .Select(row => Convert.ToInt32(row[$"{ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_LessonNumber]}"]))
                                            .Distinct()
                                            .OrderBy(lessonNumber => lessonNumber) // sắp xếp theo thứ tự tăng dần
                                            .ToList();

                DisplayLessonButtons(uniqueLessons);
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
        /// <param name="lessons"></param>
        private void DisplayLessonButtons(List<int> lessons)
        {
            lessonNumber_flpn.Controls.Clear();

            foreach (int lesson in lessons)
            {
                Button button = UserToolBoxs.createButton(lessonNumber_flpn, lesson ,Languages.lableName[(int)Languages.enLableName.LabelName_Lesson, (int)Languages.LanguageIndex] + " "+ lesson.ToString());
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

            DisplayKanijComonSection(FilterKanjiDataByLessonNumber(lessonNumber));
        }

        /// <summary>
        /// lấy những data nào là thuộc bài nào đó
        /// </summary>
        /// <param name="lessonNumber"></param>
        /// <returns></returns>
        private DataTable FilterKanjiDataByLessonNumber(int lessonNumber)
        {
            kanjiTable = ConnectedData.dataSet.Tables[ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Kanji]];
            DataView dataView = new DataView(kanjiTable);
            dataView.RowFilter = $"{ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_LessonNumber]} = {lessonNumber}";

            return dataView.ToTable();
        }

        private void DisplayKanijComonSection(DataTable kanjiDatas)
        {
            // Nếu được cấp quyền sẽ được học từ kanji
            if (Accounts.UserLogin.HasRermission(Accounts.codeRoles[(int)Accounts.enRoleRow.RoleRow_Kanji, (int)Accounts.enRoleCol.RoleCol_Id], Models.Account.Permission.Read))
            {
                var frmCommonSection = (CommonSection.FormCommonSection)Application.OpenForms["FormCommonSection"];
                if (frmCommonSection == null) { frmCommonSection = new CommonSection.FormCommonSection(); }
                frmCommonSection.DisplayKanjiData(kanjiDatas);
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
