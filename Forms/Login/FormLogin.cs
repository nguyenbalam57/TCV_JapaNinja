using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using TCV_JapaNinja.Class;
using TCV_JapaNinja.Models.Account;

namespace TCV_JapaNinja.Forms.Login
{
    public partial class FormLogin : Form
    {
        Languages.enLanguage languageOld = Languages.LanguageIndex;

        public FormLogin()
        {
            InitializeComponent();
            setColorsAndName();
            vdLanguageListCombobox(language_cbb, Languages.LanguageIndex);
            clearAccout();
        }
        /// <summary>
        /// su dung nut nhan enter
        /// lay su kien enter
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                vdCheckLoginAccount();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void setColorsAndName()
        {
            /* mau nen xanh */
            this.BackColor = ColorTranslator.FromHtml("#77A6F7");

            /* nen mau trang, logo mau xanh */
            logo_ptb.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            logo_ptb.IconColor = ColorTranslator.FromHtml("#77A6F7");

            /* nen mau xanh, icon mau trang */
            user_ptb.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            user_ptb.IconColor = ColorTranslator.FromHtml("#77A6F7");

            lock_ptb.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            lock_ptb.IconColor = ColorTranslator.FromHtml("#77A6F7");

            eye_ptb.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            eye_ptb.IconColor = ColorTranslator.FromHtml("#77A6F7");

            minus_btn.BackColor = ColorTranslator.FromHtml("#77A6F7");
            minus_btn.IconColor = ColorTranslator.FromHtml("#FFFFFF");
            exit_btn.BackColor = ColorTranslator.FromHtml("#77A6F7");
            exit_btn.IconColor = ColorTranslator.FromHtml("#FFFFFF");


            /*xet name*/
            login_btn.Text = Languages.lableName[(int)Languages.enLableName.LabelName_Login, (int)Languages.LanguageIndex];

        }

        private void minus_btn_MouseEnter(object sender, EventArgs e)
        {
            minus_btn.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            minus_btn.IconColor = ColorTranslator.FromHtml("#77A6F7");
        }

        private void minus_btn_MouseLeave(object sender, EventArgs e)
        {
            minus_btn.BackColor = ColorTranslator.FromHtml("#77A6F7");
            minus_btn.IconColor = ColorTranslator.FromHtml("#FFFFFF");
        }

        private void exit_btn_MouseEnter(object sender, EventArgs e)
        {
            exit_btn.BackColor = Color.Red;
            exit_btn.IconColor = Color.White;
        }

        private void exit_btn_MouseLeave(object sender, EventArgs e)
        {
            exit_btn.BackColor = ColorTranslator.FromHtml("#77A6F7");
            exit_btn.IconColor = ColorTranslator.FromHtml("#FFFFFF");
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// kiem tra xem co phai la password hay khong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void login_btn_Click(object sender, EventArgs e)
        {
            vdCheckLoginAccount();
        }
        /// <summary>
        /// kiem tra tai khoan login co hop le khong
        /// </summary>
        private void vdCheckLoginAccount()
        {
            string name = userName_tb.Text;
            string pass = password_tb.Text;
            /*
             * kiem tra xem user va pass da duoc nhap chua
             */
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("You have not entered a username!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                userName_tb.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("You have not entered a password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                password_tb.Focus();
                return;
            }

            // Hiển thị ProgressBar
            loadingProgressBar.Visible = true;
            loadingProgressBar.Style = ProgressBarStyle.Marquee;

            // Kiểm tra xem dataset đã được load hay chưa, nếu chưa thì thực hiện load data all.
            if (ConnectedData.dataSet == null)
            {
                Task.Run(() =>
                {
                    ConnectedData.LoadDataAllSQL();

                    // Sử dụng Invoke để cập nhật giao diện người dùng từ luồng khác
                    this.Invoke((MethodInvoker)delegate
                    {
                        // Ẩn ProgressBar sau khi tải xong
                        loadingProgressBar.Visible = false;

                        // tiếp tục kiểm tra tài khoản đăng nhập
                        CheckLogin(name, pass);
                    });
                });
            }
            else
            {
                // ẩn progressBar nếu dữ liệu đã được tải
                loadingProgressBar.Visible = false;
                CheckLogin(name, pass);
            }

        }

        private void CheckLogin(string name, string pass)
        {
            try
            {
                // lấy bảng user từ Dataset
                DataTable userData = ConnectedData.dataSet.Tables[ConnectedData.tableNames[(int)ConnectedData.enTables.Table_User]];
                // Tìm hàng khớp với employeeCode và password
                DataView dataView = new DataView(userData);
                dataView.RowFilter = $"{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_EmployeeCode]} = '{name}' AND {ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Pasword]} = '{pass}'";

                if (dataView.Count > 0)
                {
                    // Lấy userId, employeeCode và userName từ hàng đầu tiên tìm thấy
                    DataRow row = dataView[0].Row;

                    Accounts.UserLogin.UserId = (int)row[ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Id]];
                    Accounts.UserLogin.EmployerCode = row[ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_EmployeeCode]].ToString();
                    Accounts.UserLogin.UserName = row[ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Name]].ToString();
                    Accounts.UserLogin.Roles = getUserRolePer(Accounts.UserLogin.UserId);

                    if (!string.IsNullOrWhiteSpace(row[ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_IPAddress]].ToString()))
                    {
                        string ip = string.Empty;
                        if (Accounts.UserLogin.HasRermission(Permission.Read))
                        {
                            // quyền truy cập và xem được địa chỉ IP
                            ip = row[ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_IPAddress]].ToString();
                        }
                        DialogResult dialog = MessageBox.Show($"Tài khoản của bạn đang được đăng nhập ở nơi nào đó.{ip}\r\nBạn có muốn thực hiện đăng nhập không?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Cancel)
                        {
                            return;
                        }
                    }

                    // update địa chỉ IP
                    Accounts.updateIPAdress(Accounts.UserLogin.UserId, Accounts.GetIPAddress());

                    /* clear ve textbox */
                    clearAccout();

                    this.Hide();
                    var form = (TCV_JapaNinja_form)Application.OpenForms["TCV_JapaNinja_form"];
                    if (form == null)
                    {
                        form = new TCV_JapaNinja_form();
                        form.Show();
                    }
                    else
                    {
                        form.WindowState = FormWindowState.Normal;
                        TCV_JapaNinja_form.SetNameAccount();
                        form.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        /// <summary>
        /// Lấy giá trị từ data add vào bảng role
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private List<CustomRolePer> getUserRolePer(int userId)
        {
            List<CustomRolePer> userRoles = new List<CustomRolePer>();

            try
            {
                // Đọc toàn bộ RoleId liên quan đến userId trong table UserRole
                DataTable userRoleTable = ConnectedData.dataSet.Tables[ConnectedData.tableNames[(int)ConnectedData.enTables.Table_UserRole]];
                DataView userRoleView = new DataView(userRoleTable);
                userRoleView.RowFilter = $"{ConnectedData.userRoleCol[(int)ConnectedData.enUserRoleCol.UserRoleCol_UserId]} = {userId}";

                foreach (DataRowView userRoleRow in userRoleView)
                {
                    int roleId = (int)userRoleRow[ConnectedData.userRoleCol[(int)ConnectedData.enUserRoleCol.UserRoleCol_RoleId]];

                    // Lấy RoleId để lấy tất cả những Role liên quan ở trong table Role
                    DataTable roleTable = ConnectedData.dataSet.Tables[ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Role]];
                    DataView roleView = new DataView(roleTable);
                    roleView.RowFilter = $"{ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Id]} = {roleId}";

                    if (roleView.Count > 0)
                    {
                        DataRow roleRow = roleView[0].Row;
                        string roleCode = roleRow[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Code]].ToString();
                        //string roleName = roleRow[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Name]].ToString();

                        // Từ những code ở trong Role split ' ' để lấy danh sách ID có trong codeRoles
                        string[] roleCodes = roleCode.Split(' ');

                        CustomRolePer customRole = new CustomRolePer();

                        // Bắt đầu sử dụng Add từng role có sử dụng, và những roleID nào đã tồn tại thì không add vào
                        foreach (string code in roleCodes)
                        {
                            bool hasChange = false;

                            // Lấy giá trị cũ, nếu tồn tại
                            CustomRolePer roleOld = userRoles.FirstOrDefault(r => r.RoleId == code);
                            
                            // Giá trị mới được thực hiện
                            customRole = new CustomRolePer(code, Accounts.GetNameCodeRoleOfId(code));

                            // Kiểm tra tồn tại của ADMIN, nếu ADMIN chưa tồn tại thì add ADMIN vào.
                            // ADMIN không cần phải CRUD
                            if (roleOld == null) 
                            {
                                hasChange = true;
                            }

                            // Đọc trong table Role những trường CreatedRole, ReadRole, UpdateRole, DeleteRole thì dùng để Add Permission
                            if ((roleOld != null && roleOld.HasPermission(Permission.Create)) || Convert.ToBoolean(roleRow[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Created]]))
                            {
                                customRole.AddPermission(Permission.Create);
                                hasChange = true;
                            }
                            if ((roleOld != null && roleOld.HasPermission(Permission.Read)) || Convert.ToBoolean(roleRow[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Read]]))
                            {
                                customRole.AddPermission(Permission.Read);
                                hasChange = true;
                            }
                            if ((roleOld != null && roleOld.HasPermission(Permission.Update)) || Convert.ToBoolean(roleRow[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Update]]))
                            {
                                customRole.AddPermission(Permission.Update);
                                hasChange = true;
                            }
                            if ((roleOld != null && roleOld.HasPermission(Permission.Delete)) || Convert.ToBoolean(roleRow[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Delete]]))
                            {
                                customRole.AddPermission(Permission.Delete);
                                hasChange = true;
                            }

                            // Kiểm tra giữa giá trị mới và giá trị cũ, nếu có sự khác biệt thì tiến hành gộp cả 2 lại 1
                            if (hasChange)
                            {
                                userRoles.Add(customRole);
                                if (roleOld != null && !string.IsNullOrWhiteSpace(roleOld.RoleId))
                                {
                                    userRoles.Remove(roleOld);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            return userRoles;
        }

        /// <summary>
        /// load ngon ngu len combobox
        /// truyền vào ngôn ngữ mảng cần được chọn.
        /// sau đó dựa theo ngôn ngữ đó load data lên
        /// chọn ngôn ngữ đang được hiển thị sẽ select
        /// </summary>
        private void vdLanguageListCombobox(ComboBox comboBox, Languages.enLanguage selectLangua )
        {

            comboBox.Items.Clear();

            for(int i = 1; i < (int)Languages.enLanguage.Language_; i++)
            {
                comboBox.Items.Add(Languages.LanguageVisi[(int)selectLangua, i]);
                //Console.WriteLine($"{i} : {Languages.LanguageVisi[(int)selectLangua, i]}");
            }
            
            login_btn.Text = Languages.lableName[(int)Languages.enLableName.LabelName_Login, (int)selectLangua];
            comboBox.SelectedIndex = (int)selectLangua - 1;

        }
        /// <summary>
        /// kiem tra thay doi ngon ngu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void language_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //kiem tra xem co thay doi ngon ngu khong
            ComboBox comboBox = (ComboBox)sender;
            Languages.enLanguage selecIndex = (Languages.enLanguage)(comboBox.SelectedIndex + 1);
            if (languageOld == selecIndex)
            {
                return;
            }
            //thay doi ngon ngu
            Languages.LanguageIndex = selecIndex;
            languageOld = Languages.LanguageIndex;

            //reload lai su thay doi
            vdLanguageListCombobox(comboBox,  Languages.LanguageIndex);
        }
        private void clearAccout()
        {
            userName_tb.Text = "TCV";
            userName_tb.Focus();
            password_tb.Text = string.Empty;
        }
        private bool checkEye = false;
        /// <summary>
        /// hien thi password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eye_ptb_Click(object sender, EventArgs e)
        {
            if (checkEye)
            {
                /* thay doi Icon char cua nut nhan hien thi */
                eye_ptb.IconChar = FontAwesome.Sharp.IconChar.Eye;
                /* hien thi password */
                password_tb.PasswordChar = '\0';
                password_tb.Focus();
                checkEye = false;
            }
            else
            {
                /* thay doi Icon char cua nut nhan hien thi */
                eye_ptb.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                /* hien thi password */
                password_tb.PasswordChar = '*';
                password_tb.Focus();
                checkEye = true;
            }
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            // update địa chỉ IP
            Accounts.updateIPAdress(Accounts.UserLogin.UserId, string.Empty);
        }
    }
}
