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
using TCV_JapaNinja.Forms.Login;

namespace TCV_JapaNinja
{
    public partial class TCV_JapaNinja: Form
    {
        

        public TCV_JapaNinja()
        {
            InitializeComponent();
            
            // Load data sql
            ConnectedData.LoadDataAllSQL();

            // Khởi tạo timer
            initializeTimer();

            // Khởi tạo phân quyền cho menu
            InitializeLoadRole();

            // Hiển thị tên người dùng
            setNameLabelAccount();
        }

        #region Event Form

        /// <summary>
        /// Phân quyền
        /// </summary>
        private void InitializeLoadRole()
        {
            // Button Admin Management
            string[] man = Accounts.manAccount.Concat(Accounts.manData).ToArray();
            admin_Management_btn.Visible = false;
            if (Accounts.UserLogin.HasRermission(man))
            {
                admin_Management_btn.Visible = true;
            }
        }

        /// <summary>
        /// Sự kiện load Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TCV_JapaNinja_Load(object sender, EventArgs e)
        {
            FrmJPObj = this;
        }

        /// <summary>
        /// Sự kiện đóng form chính
        /// Trước khi đóng form chính thì bỏ trạng thái đang đăng nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TCV_JapaNinja_FormClosed(object sender, FormClosedEventArgs e)
        {
            var formLogin = (FormLogin)Application.OpenForms["FormLogin"];
            if (formLogin != null)
            {
                // khi thực hiện đóng form sẽ loại bỏ user đăng nhập
                Accounts.updateIPAdress(Accounts.UserLogin.UserId, string.Empty);
                formLogin.Close();
            }
        }

        #endregion

        #region Header_Main
        /// <summary>
        /// Dùng để làm trung gian gọi hàm set tên của user
        /// </summary>
        public static void SetNameAccount()
        {
            FrmJPObj.setNameLabelAccount();
        }

        /// <summary>
        /// Set tên người dùng
        /// </summary>
        public void setNameLabelAccount()
        {
            //Accounts.vdScreenNameAccount(nameAccount_lb);
            nameAccount_lb.Text = Accounts.UserLogin.UserName;
            // Chạy khi thay đổi tên người dùng
            InitializeLoadRole();
        }

        /// <summary>
        /// log out
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logout_btn();
        }

        /// <summary>
        /// log out ra màn hình login
        /// </summary>
        private void logout_btn()
        {
            var formLogin = (FormLogin)Application.OpenForms["FormLogin"];
            this.Hide();
            Accounts.clearAccountLogin();
            if (formLogin == null)
            {
                formLogin = new FormLogin();
                formLogin.Show();
            }
            else
            {
                formLogin.WindowState = FormWindowState.Normal;
                formLogin.Show();
            }
        }


        #endregion

        #region MENU BUTTON

        private IconButton activeIconButton; // IconButton đang sử dụng
        private Panel activePanelMenu; // Panel đang sử dụng
        private Form activeForm; // Form đang sử dụng

        /// <summary>
        /// active icon button menu level 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void study_btn_Click(object sender, EventArgs e)
        {
            activeIconButtonMenu(sender, e);
            var frmStudy = (Forms.Study.FormStudy)Application.OpenForms["FormStudy"];
            frmStudy?.Focus();
            if (frmStudy == null) { frmStudy = new Forms.Study.FormStudy(); }
            /* hiển thị */
            openChildForm(frmStudy);
        }

        private void trial_btn_Click(object sender, EventArgs e)
        {
            activeIconButtonMenu(sender, e);
            var frmTrial = (Forms.Trial.FormTrial)Application.OpenForms["FormTrial"];
            frmTrial?.Focus();
            if (frmTrial == null) { frmTrial = new Forms.Trial.FormTrial(); }
            /*hien thi*/
            openChildForm(frmTrial);
        }

        private void test_btn_Click(object sender, EventArgs e)
        {
            activeIconButtonMenu(sender, e);
            var frmTest = (Forms.Test.FormTest)Application.OpenForms["FormTest"];
            frmTest?.Focus();
            if (frmTest == null) { frmTest = new Forms.Test.FormTest(); }
            /*hien thi*/
            openChildForm(frmTest);
        }

        private void advanced_btn_Click(object sender, EventArgs e)
        {
            activeIconButtonMenu(sender, e);
            var frmAdvanced = (Forms.Advanced.FormAdvanced)Application.OpenForms["FormAdvanced"];
            frmAdvanced?.Focus();
            if (frmAdvanced == null) { frmAdvanced = new Forms.Advanced.FormAdvanced(); }
            /*hien thi*/
            openChildForm(frmAdvanced);
        }

        private void evaluate_btn_Click(object sender, EventArgs e)
        {
            activeIconButtonMenu(sender, e);
        }

        private void admin_Managent_btn_Click(object sender, EventArgs e)
        {
            activeIconButtonMenu(sender, e);
            var formAdmin = (Forms.Admin_Managent.admin_Management)Application.OpenForms["admin_Management"];
            formAdmin?.Focus();
            if (formAdmin == null) { formAdmin = new Forms.Admin_Managent.admin_Management(); }
            /*hien thi*/
            openChildForm(formAdmin);

        }

        /// <summary>
        /// active icon button menu level 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void activeIconButtonMenu(object sender, EventArgs e)
        {
            IconButton btn = (IconButton)sender;

            if (btn != null)
            {
                diactiveIconButtonMenu();
                activeIconButton = btn;
                activeIconButton.ForeColor = ColorTranslator.FromHtml(Colors.Color[(int)Colors.enColors.Color_IconButtonTextActive, (int)Colors.ModeColorsIndex]);
                activeIconButton.IconColor = ColorTranslator.FromHtml(Colors.Color[(int)Colors.enColors.Color_IconButtonTextActive, (int)Colors.ModeColorsIndex]);
                activeIconButton.BackColor = ColorTranslator.FromHtml(Colors.Color[(int)Colors.enColors.Color_IconButtonActive, (int)Colors.ModeColorsIndex]);
                //activeIconButton.TextImageRelation = TextImageRelation.TextBeforeImage;

            }
        }

        /// <summary>
        /// clear active icon button menu
        /// </summary>
        private void diactiveIconButtonMenu()
        {
            if (activePanelMenu != null)
            {
                activePanelMenu.Visible = false;
            }

            if (activeIconButton != null)
            {
                //activeIconButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                activeIconButton.ForeColor = ColorTranslator.FromHtml(Colors.Color[(int)Colors.enColors.Color_IconButtonText, (int)Colors.ModeColorsIndex]);
                activeIconButton.IconColor = ColorTranslator.FromHtml(Colors.Color[(int)Colors.enColors.Color_IconButtonText, (int)Colors.ModeColorsIndex]);
                activeIconButton.BackColor = ColorTranslator.FromHtml(Colors.Color[(int)Colors.enColors.Color_IconButton, (int)Colors.ModeColorsIndex]);
            }
        }

        /// <summary>
        /// screen 
        /// </summary>
        /// <param name="childForm"></param>
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                if (activeForm == childForm) return;
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            chillForm_Main_pn.Controls.Add(childForm);
            chillForm_Main_pn.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        #endregion

        #region FormStatic

        static TCV_JapaNinja _frmJPObj;

        public static TCV_JapaNinja FrmJPObj
        {
            get
            {
                if (_frmJPObj == null)
                {
                    _frmJPObj = new TCV_JapaNinja();
                }
                return _frmJPObj;
            }
            set
            {
                _frmJPObj = value;
            }
        }

        #endregion

        #region AnimationsMenu

        /*
         * Điều chỉnh thanh menu show and hide
         * Sử dụng timer để điều chỉnh
         * Bằng cách thay đổi kích thước của panel
         * Thay đổi panel logo cho phù hợp với kích thước
         */
        private Timer timer;
        private bool isMenuExpanded = true; // Biến để theo dõi trạng thái của menu
        private bool isRelationImageBeforeText = true; // Biến để theo dõi trạng thái của textImageRelation
        private const int menuWidth = 200; // Chiều rộng của menu khi mở
        private const int menuCollapsedWidth = 50; // Chiều rộng của menu khi thu gọn
        private const int menuAnimationInterval = 10; // Thời gian giữa các bước hoạt ảnh
        private const int menuAnimationSteps = 25; // Số bước trong hoạt ảnh
        private const int menuAnimationStepSize = (menuWidth - menuCollapsedWidth) / menuAnimationSteps; // Kích thước mỗi bước hoạt ảnh
        private const int logoHideHeight = 25; // Chiều dài của logo khi thu gọn
        private const int logoShowHeight = 100; // Chiều dài của logo khi mở
        private const int logoAnimationStepSize = (logoShowHeight - logoHideHeight) / menuAnimationSteps; // Kích thước mỗi bước hoạt ảnh của logo


        /// <summary>
        /// khởi tạo timer animation menu
        /// </summary>
        private void initializeTimer()
        {
            timer = new Timer();
            timer.Interval = menuAnimationInterval; // Thời gian giữa các bước hoạt ảnh
            timer.Tick += Timer_Tick; // Đăng ký sự kiện Tick
        }
        /// <summary>
        /// Sự kiện nhấp chuột vào nút menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (isMenuExpanded)
            {
                // Nếu menu đang mở, thu gọn nó
                if (left_Main_pn.Width > menuCollapsedWidth)
                {
                    left_Main_pn.Width -= menuAnimationStepSize;
                    // Điều chỉnh chiều cao của logo
                    logo_pn.Height -= logoAnimationStepSize;
                }
                else
                {
                    timer.Stop();
                    isMenuExpanded = false;
                    // đặt lại textimageRelation
                    buttonMenuShow(TextImageRelation.Overlay);
                }
            }
            else
            {
                // Check trạng thái của textImageRelation
                // Nếu textImageRelation không phải là ImageBeforeText, đặt lại nó
                if (!isRelationImageBeforeText)
                {
                    buttonMenuShow(TextImageRelation.ImageBeforeText);
                }

                // Nếu menu đang thu gọn, mở rộng nó
                if (left_Main_pn.Width < menuWidth)
                {
                    left_Main_pn.Width += menuAnimationStepSize;
                    // Điều chỉnh chiều cao của logo
                    logo_pn.Height += logoAnimationStepSize;
                }
                else
                {
                    timer.Stop();
                    isMenuExpanded = true;
                    // đặt lại textimageRelation
                    buttonMenuShow(TextImageRelation.ImageBeforeText);
                }
            }
        }
        /// <summary>
        /// Hiển thị nôi dung button menu như thế nào
        /// Check nếu đã thực hiện thì biến isRelationImageBeforeText sẽ là true
        /// </summary>
        /// <param name="textImageRelation"></param>
        private void buttonMenuShow(TextImageRelation textImageRelation)
        {
            study_btn.TextImageRelation = textImageRelation;
            trial_btn.TextImageRelation = textImageRelation;
            test_btn.TextImageRelation = textImageRelation;
            advanced_btn.TextImageRelation = textImageRelation;
            admin_Management_btn.TextImageRelation = textImageRelation;
            evaluate_btn.TextImageRelation = textImageRelation;

            isRelationImageBeforeText = true;
        }
        /// <summary>
        /// Sự kiện nhấp chuột vào nút menu để mở rộng hoặc thu gọn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void show_Menu_btn_Click(object sender, EventArgs e)
        {
            isRelationImageBeforeText = false;
            timer.Start();

        }

        #endregion

        
    }
}
