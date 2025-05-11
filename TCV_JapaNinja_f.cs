using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCV_JapaNinja.Class;
using TCV_JapaNinja.Forms.Login;
using TCV_JapaNinja.Models.Account;

namespace TCV_JapaNinja
{
    public partial class TCV_JapaNinja_form : Form
    {
        private IconButton activeIconButton;
        private Panel activePanelMenu;
        private Form activeForm;

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


        public TCV_JapaNinja_form()
        {
            InitializeComponent();
            //fixedDefaultForm();
            InitializeLoadForm();

            // Khởi tạo timer
            initializeTimer();

            setTextColorAll();
            setNameLabelAccount();
        }

        static TCV_JapaNinja_form _frmJPObj;
        public static TCV_JapaNinja_form FrmJPObj
        {
            get { return _frmJPObj; }
            set { _frmJPObj = value; }
        }
        private void TCV_JapaNinja_form_Load(object sender, EventArgs e)
        {
            FrmJPObj = this;

            this.FormBorderStyle = FormBorderStyle.Sizable; // Đặt kiểu viền của form là Sizable

            //fullScreenForm();

        }

        private void fixedDefaultForm()
        {
            this.FormBorderStyle = FormBorderStyle.Sizable; // Đặt kiểu viền của form là FixedSingle
            this.WindowState = FormWindowState.Normal; // Đặt trạng thái của form là bình thường
            this.RecreateHandle(); // Tạo lại handle của form
            this.Refresh(); // Làm mới form
            
        }

        private void InitializeLoadForm()
        {
            // Button Admin Management
            string[] man = Accounts.manAccount.Concat(Accounts.manData).ToArray();
            admin_Management_btn.Visible = false;
            if(Accounts.UserLogin.HasRermission(man))
            {
                admin_Management_btn.Visible = true;
            }    
        }

        /// <summary>
        /// set color and name luc thay doi gia tri
        /// </summary>
        private void setTextColorAll()
        {
            /* set Color */
            /* menu backcolor */
            ResetAllControlsBackColor(bottom_Menu_pn);

            /*set name label*/
            /* learning */
            study_btn.Text = Languages.lableName[(int)Languages.enLableName.LabelName_Study, (int)Languages.LanguageIndex];

            /* trial */
            trial_btn.Text = Languages.lableName[(int)Languages.enLableName.LabelName_Trial, (int)Languages.LanguageIndex];

            /* test */
            test_btn.Text = Languages.lableName[(int)Languages.enLableName.LabelName_Test, (int)Languages.LanguageIndex];

            /* Expand */
            advanced_btn.Text = Languages.lableName[(int)Languages.enLableName.LabelName_Advanced, (int)Languages.LanguageIndex];

            /* admin mannagement */
            admin_Management_btn.Text = Languages.lableName[(int)Languages.enLableName.LabelName_Admin_Management, (int)Languages.LanguageIndex];

            /* evaluate */
            evaluate_btn.Text = Languages.lableName[(int)Languages.enLableName.LabelName_Evaluate, (int)Languages.LanguageIndex];
        }

        // Reset all the controls to the user's default Control color. 
        private void ResetAllControlsBackColor(Control control)
        {
            string name = control.ToString();
            if(name.Contains("IconButton") || name.Contains("Panel"))
            {
                control.BackColor = ColorTranslator.FromHtml(Colors.Color[(int)Colors.enColors.Color_BackgroundMenu, (int)Colors.ModeColorsIndex]);
                control.ForeColor = ColorTranslator.FromHtml(Colors.Color[(int)Colors.enColors.Color_IconButtonText, (int)Colors.ModeColorsIndex]);
                if(name.Contains("IconButton"))
                {
                    IconButton iconButton = (IconButton)control;
                    iconButton.IconColor = ColorTranslator.FromHtml(Colors.Color[(int)Colors.enColors.Color_IconButtonText, (int)Colors.ModeColorsIndex]);
                }
            }

            if (control.HasChildren)
            {
                // Recursively call this method for each child control.
                foreach (Control childControl in control.Controls)
                {
                    ResetAllControlsBackColor(childControl);
                }
            }
        }

        /// <summary>
        /// active icon button menu level 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region MENUBUTTONLEVEL1
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
            if(formAdmin == null) { formAdmin = new Forms.Admin_Managent.admin_Management(); }
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
            if(activePanelMenu != null)
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

        #endregion

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
            childForm_pn.Controls.Add(childForm);
            childForm_pn.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
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

        private void TCV_JapaNinja_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            var formLogin = (FormLogin)Application.OpenForms["FormLogin"];
            if(formLogin != null)
            {
                // khi thực hiện đóng form sẽ loại bỏ user đăng nhập
                Accounts.updateIPAdress(Accounts.UserLogin.Id, string.Empty);
                formLogin.Close();
            }
        }

        public static void SetNameAccount()
        {
            FrmJPObj.setNameLabelAccount();
        }

        public void setNameLabelAccount()
        {
            Accounts.vdScreenNameAccount(nameAccount_lb);
        }

        #region AnimationsMenu
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
                if (left_Menu_pnn.Width > menuCollapsedWidth)
                {
                    left_Menu_pnn.Width -= menuAnimationStepSize;
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
                if (left_Menu_pnn.Width < menuWidth)
                {
                    left_Menu_pnn.Width += menuAnimationStepSize;
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


        #region FormResize

        private bool isDragging = false;
        private bool isResizing = false; // Biến để theo dõi trạng thái kéo
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private Point resizeStartPoitn;


        /*thông số để nhận vị trí con trỏ chuột*/
        private const int HTCLIENT = 1;
        private const int HTBOTTOMRIGHT = 17;
        private const int HTBOTTOM = 15;
        private const int HTRIGHT = 11;

        /*
         * Kéo di chuyển Form
         * Kéo mở rộng Form
         */
        /// <summary>
        /// Xử lý thông điệp Windows để thay đổi kích thước form
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0084) // WM_NCHITTEST
            {
                Point mousePos = this.PointToClient(new Point(m.LParam.ToInt32()));
                if (mousePos.X >= this.ClientSize.Width - 10 && mousePos.Y >= this.ClientSize.Height - 10)
                {
                    m.Result = (IntPtr)HTBOTTOMRIGHT; // Kéo từ góc dưới bên phải
                    return;
                }
                else if (mousePos.X >= this.ClientSize.Width - 10)
                {
                    m.Result = (IntPtr)HTRIGHT; // Kéo từ bên phải
                    return;
                }
                else if (mousePos.Y >= this.ClientSize.Height - 10)
                {
                    m.Result = (IntPtr)HTBOTTOM; // Kéo từ dưới
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void ResizeForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                isResizing = true;
                resizeStartPoitn = e.Location; // Lưu vị trí bắt đầu kéo
            }
        }

        private void ResizeForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isResizing)
            {
                // Tính toán sự khác biệt giữa vị trí chuột hiện tại và vị trí bắt đầu kéo
                int widthChange = e.X - resizeStartPoitn.X;
                int heightChange = e.Y - resizeStartPoitn.Y;
                // Cập nhật kích thước của form
                this.Size = new Size(this.Width + widthChange, this.Height + heightChange);
                resizeStartPoitn = e.Location; // Cập nhật vị trí chuột
            }
        }

        private void ResizeForm_MouseUp(object sender, MouseEventArgs e)
        {
            isResizing = false; // Dừng kéo
        }


        /// <summary>
        /// Sự kiện nhấp chuột vào form để bắt đầu kéo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MovableForm_MouseDown(object sender, MouseEventArgs e)
        {

        }
        /// <summary>
        /// Sự kiện di chuyển chuột để kéo form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MovableForm_MouseMove(object sender, MouseEventArgs e)
        {

        }
        /// <summary>
        /// Sự kiện nhả chuột để dừng kéo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MovableForm_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false; // Dừng kéo
        }


        #endregion

        #region CloseMaxSizeHide

        private Size sizeStart; // Size truước khi mở rộng
        private Point locationStart; // Vị trí truớc khi mở rộng

        /// <summary>
        /// Sự kiện nhấp chuột vào nút thu nhỏ form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hide_icbtn_Click(object sender, EventArgs e)
        {
            // Nếu sử dụng this.Hide() thì sẽ không có sự kiện FormClosing, và sẽ ẩn luôn. k hiển thị icon ở thanh tabbar
            this.WindowState = FormWindowState.Minimized; // Ẩn form
        }
        /// <summary>
        /// Sự kiện nhấp chuột vào nút tối đa hóa hoặc khôi phục kích thước form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void maxSize_icbtn_Click(object sender, EventArgs e)
        {
            if (!isScreenForm)
            {
                fullScreenForm();
            }
            else
            {
                normalScreenForm();
            }
        }

        private bool isScreenForm = false;
        /// <summary>
        /// full screen form
        /// </summary>
        private void fullScreenForm()
        {
            // lấy vị trí và size trước khi mở rộng
            sizeStart = this.Size; // Lưu kích thước ban đầu
            locationStart = this.Location;

            // Thiết lập kích thước của form để chiếm toàn bộ màn hình
            //maxSize_icbtn.IconChar = IconChar.WindowRestore; // Đổi icon thành icon khôi phục
            this.Location = new Point(0, 0); // Đặt vị trí ở góc trên bên trái
            this.StartPosition = FormStartPosition.CenterParent; // Đặt vị trí khởi đầu ở giữa màn hình
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height); // Chiếm toàn bộ màn hình trừ thanh tác vụ

            // Biến sự thay đổi
            isScreenForm = true;
        }


        private void normalScreenForm()
        {
            // Trở lại trạng thái ban đầu
            //maxSize_icbtn.IconChar = IconChar.WindowMaximize; // Đổi icon thành icon tối đa
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = sizeStart; // Kích thước mặc định của form
            this.Location = locationStart; // Đặt vị trí ở góc trên bên trái
            // Biến sự thay đổi
            isScreenForm = false;
        }

        /// <summary>
        /// Sự kiện nhấp chuột vào nút đóng form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close_icbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void close_icbtn_MouseEnter(object sender, EventArgs e)
        {
            // Thay đổi màu nền khi chuột di chuyển vào nút đóng
            IconButton iconButton = (IconButton)sender;
            iconButton.BackColor = Color.Red;
            iconButton.IconColor = Color.White; // Thay đổi màu icon
        }

        private void close_icbtn_MouseLeave(object sender, EventArgs e)
        {
            IconButton iconButton = (IconButton)sender;
            // Đặt lại màu nền khi chuột rời khỏi nút đóng
            iconButton.BackColor = Color.White; // Màu mặc định
            iconButton.IconColor = Color.Black; // Màu mặc định của icon
        }
        #endregion




    }
}
