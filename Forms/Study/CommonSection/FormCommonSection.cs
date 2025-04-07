using FontAwesome.Sharp;
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
    public partial class FormCommonSection : Form
    {
        DataTable kanjiTable;
        public FormCommonSection()
        {
            InitializeComponent();
            defaultDisplay();
        }

        public void defaultDisplay()
        {
            // Nếu được cấp quyền sẽ được học từ kanji
            if (Accounts.UserLogin.HasRermission(Accounts.codeRoles[(int)Accounts.enRoleRow.RoleRow_Kanji, (int)Accounts.enRoleCol.RoleCol_Id], Models.Account.Permission.Read))
            {
                var frmLearning = (FormLearning)Application.OpenForms["FormLearning"];
                if (frmLearning == null) { frmLearning = new FormLearning(); }
                frmLearning.getDataTableLeaningData(kanjiTable);
                openChildForm(frmLearning);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void DisplayKanjiData(DataTable kanjiData)
        {
            kanjiTable = kanjiData;
        }

        private void learning_btn_Click(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;

            var frmLeaning = (FormLearning)Application.OpenForms["FormLearning"];
            if (frmLeaning == null) {frmLeaning = new FormLearning(); }
            frmLeaning.getDataTableLeaningData(kanjiTable);

            openChildForm(frmLeaning);

        }

        private void flashCard_btn_Click(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;

        }

        private void matching_btn_Click(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;

        }

        private void gap_Filling_btn_Click(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;

        }

        private void word_Selection_btn_Click(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;

        }

        private void mini_Test_btn_Click(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;


        }

        private void text_Focus_lb_Click(object sender, EventArgs e)
        {

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
            chillFormSection_pn.Controls.Add(childForm);
            chillFormSection_pn.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
