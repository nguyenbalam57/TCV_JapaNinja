using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCV_JapaNinja.Forms.Admin_Management;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TCV_JapaNinja.Forms.Admin_Managent
{
    public partial class admin_Management : Form
    {
        private Form activeFormAdminManagement = null;
        public admin_Management()
        {
            InitializeComponent();
            InitializeLoadButton();
        }

        private void admin_Management_Load(object sender, EventArgs e)
        {
 
        }

        private void InitializeLoadButton()
        {
            // không cho hiển thị tất cả nút nhấn
            visibleButtonMenu(false);

            // Nhóm quản lý Người dùng
            if(Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_UserRole, (int)Class.Accounts.enRoleCol.RoleCol_Id]))
            {
                userToolStripMenuItem.Visible = true;
            }
            if (Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_Group, (int)Class.Accounts.enRoleCol.RoleCol_Id]))
            {
                groupToolStripMenuItem.Visible = true;
            }
            if (Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_Role, (int)Class.Accounts.enRoleCol.RoleCol_Id]))
            {
                roleToolStripMenuItem.Visible = true;
            }
            if (Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_Position, (int)Class.Accounts.enRoleCol.RoleCol_Id]))
            {
                positionToolStripMenuItem.Visible = true;
            }

            // Nhóm quản lý cơ sở dữ liệu từ ngữ
            if (Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_InputData, (int)Class.Accounts.enRoleCol.RoleCol_Id]))
            {
                inputDatabaseToolStripMenuItem.Visible = true;
            }
            if (Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_Level, (int)Class.Accounts.enRoleCol.RoleCol_Id]))
            {
                levelToolStripMenuItem.Visible = true;
            }
            if (Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_TypeVoc, (int)Class.Accounts.enRoleCol.RoleCol_Id]))
            {
                typeVocabularyToolStripMenuItem.Visible = true;
            }
            if (Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_Curriculum, (int)Class.Accounts.enRoleCol.RoleCol_Id]))
            {
                curriculumToolStripMenuItem.Visible = true;
            }

        }

        private void visibleButtonMenu(bool status)
        {
            // mục quản lý người dùng
            userToolStripMenuItem.Visible = status;
            groupToolStripMenuItem.Visible = status;
            roleToolStripMenuItem.Visible = status;
            positionToolStripMenuItem.Visible = status;

            // mục quản lý dữ liệu ngôn ngữ
            inputDatabaseToolStripMenuItem.Visible = status;
            levelToolStripMenuItem.Visible = status;
            typeVocabularyToolStripMenuItem.Visible = status;
            curriculumToolStripMenuItem.Visible = status;
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmUser = (FormUser)Application.OpenForms["FormUser"];
            if (frmUser == null) { frmUser = new FormUser(); }

            /* kiem tra va mo form user */
            openFormChildAdminManagement(frmUser);
        }

        /// <summary>
        /// setting open form child admin management
        /// </summary>
        /// <param name="childForm"></param>
        private void openFormChildAdminManagement(Form childForm)
        {
            if (activeFormAdminManagement != null)
            {
                if(activeFormAdminManagement == childForm)
                {
                    return;
                }
                activeFormAdminManagement.Close();
            }
            activeFormAdminManagement = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            chilFormAdminManagement_pn.Controls.Add(childForm);
            chilFormAdminManagement_pn.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_Group, (int)Class.Accounts.enRoleCol.RoleCol_Id]))
            {
                var frmGroup = (Admin_Management.Accounts.FormGroup)Application.OpenForms["FormGroup"];
                if (frmGroup == null) { frmGroup = new Admin_Management.Accounts.FormGroup(); }
                openFormChildAdminManagement(frmGroup);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
            
        }

        private void positionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_Position, (int)Class.Accounts.enRoleCol.RoleCol_Id]))
            {
                var frmPositon = (Admin_Management.Accounts.FormPosition)Application.OpenForms["FormPosition"];
                if (frmPositon == null) { frmPositon = new Admin_Management.Accounts.FormPosition(); }
                openFormChildAdminManagement(frmPositon);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void inputDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_InputData, (int)Class.Accounts.enRoleCol.RoleCol_Id]))
            {
                var frmInputDataBase = (Admin_Management.InputDatabase.FormInputDatabase)Application.OpenForms["FormInputDatabase"];
                if (frmInputDataBase == null) { frmInputDataBase = new Admin_Management.InputDatabase.FormInputDatabase(); }
                openFormChildAdminManagement(frmInputDataBase);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// level cap the hien trinh do
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void levelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_Level, (int)Class.Accounts.enRoleCol.RoleCol_Id]))
            {
                var frmLevel = (Admin_Management.InputDatabase.FormLevel)Application.OpenForms["FormLevel"];
                if (frmLevel == null) { frmLevel = new Admin_Management.InputDatabase.FormLevel(); }
                openFormChildAdminManagement(frmLevel);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Phan loai tu, dong tu, tinh tu, trang tu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void typeVocabularyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_TypeVoc, (int)Class.Accounts.enRoleCol.RoleCol_Id]))
            {
                var frmTypeVoca = (Admin_Management.InputDatabase.FormTypeVocabulary)Application.OpenForms["FormTypeVocabulary"];
                if (frmTypeVoca == null) { frmTypeVoca = new Admin_Management.InputDatabase.FormTypeVocabulary(); }
                openFormChildAdminManagement(frmTypeVoca);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Giao trinh, su dung sach giao khoa nao
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void curriculumToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_Curriculum, (int)Class.Accounts.enRoleCol.RoleCol_Id]))
            {
                var frmCurri = (Admin_Management.InputDatabase.FormCurriculum)Application.OpenForms["FormCurriculum"];
                if (frmCurri == null) { frmCurri = new Admin_Management.InputDatabase.FormCurriculum(); }
                openFormChildAdminManagement(frmCurri);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void roleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_Role, (int)Class.Accounts.enRoleCol.RoleCol_Id]))
            {
                var frRole = (Admin_Management.Accounts.FormRole)Application.OpenForms["FormRole"];
                if (frRole == null) { frRole = new Admin_Management.Accounts.FormRole(); }
                openFormChildAdminManagement(frRole);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
