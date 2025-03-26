using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using TCV_JapaNinja.Class;
using System.Diagnostics.Eventing.Reader;

namespace TCV_JapaNinja.Forms.Admin_Management.Accounts
{
    public partial class FormGroup : Form
    {
        private string connecString = ConnectedData.connectionString;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private int groupIDActive = -1;
        private bool isGroupEdit = false;

        public FormGroup()
        {
            InitializeComponent();
        }

        private void FormGroup_Load(object sender, EventArgs e)
        {
            clearGroup_btn_Click();
            LoadData();
        }

        private void regiter_Update_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(groupName_tb.Text))
            {
                MessageBox.Show("Please enter group name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connecString))
                {
                    connection.Open();
                    // Kiểm tra quyền Update
                    if (isGroupEdit &&
                        Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_Group, (int)Class.Accounts.enRoleCol.RoleCol_Id], Models.Account.Permission.Update))
                    {
                        // update group
                        updateGroup_data(connection, ConnectedData.enData.Data_Update, false);
                    }
                    // Kiểm tra quyền tạo mới
                    else if (Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_Group, (int)Class.Accounts.enRoleCol.RoleCol_Id], Models.Account.Permission.Create))
                    {
                        string queryGroup = $"INSERT INTO {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Group]} " +
                            $"({ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Name]}, " +
                            $"{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Description]}, " +
                            $"{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_CreatedDate]}, " +
                            $"{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_UpdatedDate]}, " +
                            $"{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_IsActive]}) " +
                            $"VALUES ( " +
                            $"@{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Name]}," +
                            $"@{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Description]}, " +
                            $"@{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_CreatedDate]}, " +
                            $"@{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_UpdatedDate]}, " +
                            $"@{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_IsActive]})";

                        // insert group
                        SqlCommand command = new SqlCommand(queryGroup, connection);
                        command.Parameters.AddWithValue($"@{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Name]}", groupName_tb.Text);
                        command.Parameters.AddWithValue($"@{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Description]}", groupDescription_tb.Text);
                        command.Parameters.AddWithValue($"@{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_CreatedDate]}", DateTime.Now);
                        command.Parameters.AddWithValue($"@{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_UpdatedDate]}", DateTime.Now);
                        command.Parameters.AddWithValue($"@{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_IsActive]}", true);
                        command.ExecuteNonQuery();
                    }
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                    LoadData();
                    clearGroup_btn_Click();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Group regiter and update" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearGroup_btn_Click();
            }
        }
        /// <summary>
        /// thuc hien update data
        /// boi vi khong cho xoa hoan toan nen chi su dung active hoac deactive
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="enData"></param>
        private void updateGroup_data(SqlConnection connection, ConnectedData.enData enData, bool isActive)
        {
            string updateQuery = $"UPDATE {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Group]} SET ";
            List<string> updateFields = new List<string>();
            bool hasChanges = false;

            // Lấy giá trị hiện tại từ cơ sở dữ liệu
            string selectQuery = $"SELECT * FROM {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Group]} " +
                $"WHERE {ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Id]} = @activeId";
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@activeId", groupIDActive);
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable currentData = new DataTable();
            adapter.Fill(currentData);

            if (currentData.Rows.Count == 0)
            {
                throw new Exception("Không tìm thấy.");
            }

            DataRow currentRow = currentData.Rows[0];


            switch (enData)
            {
                case ConnectedData.enData.Data_Insert:
                    break;
                case ConnectedData.enData.Data_Update:
                    if (currentRow[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Name]].ToString() != groupName_tb.Text)
                    {
                        updateFields.Add($"{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Name]} = @{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Name]}");
                        hasChanges = true;
                    }
                    if (currentRow[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Description]].ToString() != groupDescription_tb.Text)
                    {
                        updateFields.Add($"{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Description]} = @{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Description]}");
                        hasChanges = true;
                    }
                    break;
                case ConnectedData.enData.Data_Delete:
                    updateFields.Add($"{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_IsActive]} = @{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_IsActive]}");
                    hasChanges = true;
                    break;
                default:
                    break;
            }

            if (hasChanges)
            {
                updateQuery += string.Join(", ", updateFields);
                updateQuery += $", {ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_UpdatedDate]} = @{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_UpdatedDate]} WHERE {ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Id]} = @{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Id]}";

                try
                {
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue($"@{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Name]}", groupName_tb.Text);
                        command.Parameters.AddWithValue($"@{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Description]}", groupDescription_tb.Text);
                        command.Parameters.AddWithValue($"@{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_IsActive]}", isActive);
                        command.Parameters.AddWithValue($"@{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_UpdatedDate]}", DateTime.Now);
                        command.Parameters.AddWithValue($"@{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Id]}", groupIDActive);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Update Group.\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không có thay đổi nào được phát hiện.");
            }
        }
        /// <summary>
        /// hien thi ra datagridview
        /// </summary>
        private void LoadData()
        {
            // Nếu là Admin hoặc Group được xem (GROUP -> READ) thì sẽ được xem
            if (Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_Group, (int)Class.Accounts.enRoleCol.RoleCol_Id], Models.Account.Permission.Read))
            {
                /* Chức năng IsActive dùng để xóa hoặc khôi phục
                 * Không sử dụng xóa hoàn toàn
                 * Cập nhật quyền thay đổi của Admin 
                 * Nếu admin sẽ thay đổi thành nút nhấn xóa hoặc khôi phục. -> Sẽ để dạng checkbox để cho phép admin có thể check hoặc bỏ check.  
                 * Người dùng được cấp quyền thì nhấn nút IsActive thành nút xóa.
                 * Người dùng được cấp quyền thì sẽ không khôi phục được isActive
                 */
                bool hasChangesAdmin = false;
                string Active = $"WHERE {ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_IsActive]} = {ConnectedData.IsActive}";

                // Nếu là Admin thì có thể xem active hoặc deactive
                // Vì cấu tạo của trường data là không xóa. chỉ có active và deactive
                // Và Admin có thể khôi phục lại. Hiển thị được ai đang được active hoăc deActive
                // Quản lý được cấp quyền thì không được khôi phục.
                // Cấp quyền chỉ được xem.
                if (Class.Accounts.UserLogin.HasRermission(Models.Account.Permission.Read))
                {
                    Active = string.Empty;
                    hasChangesAdmin = true;
                }

                /*
                 * Sử dụng using để đọc dữ liệu, tránh trường hợp connect nhưng không disconnect. dễ bị sai sót sảy ra.
                 * sử dụng try catch để đọc lỗi
                 */
                try
                {
                    using (SqlConnection connection = new SqlConnection(connecString))
                    {
                        dataAdapter = new SqlDataAdapter($"SELECT * FROM {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Group]} {Active}", connection);
                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                        dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        groupView_dgv.DataSource = dataTable;

                        groupView_dgv.Columns[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Id]].HeaderText = "ID";
                        groupView_dgv.Columns[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Id]].ReadOnly = true;
                        groupView_dgv.Columns[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Name]].HeaderText = "Name";
                        groupView_dgv.Columns[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Name]].ReadOnly = true;
                        groupView_dgv.Columns[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Description]].HeaderText = "Description";
                        groupView_dgv.Columns[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Description]].ReadOnly = true;

                        // Nếu Admin thì hiển thị
                        if (!hasChangesAdmin)
                        {
                            groupView_dgv.Columns[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_CreatedDate]].HeaderText = "Created Date";
                            groupView_dgv.Columns[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_CreatedDate]].ReadOnly = true;
                            groupView_dgv.Columns[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_CreatedDate]].Visible = false;
                            groupView_dgv.Columns[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_UpdatedDate]].HeaderText = "Updated Date";
                            groupView_dgv.Columns[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_UpdatedDate]].ReadOnly = true;
                            groupView_dgv.Columns[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_UpdatedDate]].Visible = false;
                            groupView_dgv.Columns[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_IsActive]].HeaderText = "Active";
                            groupView_dgv.Columns[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_IsActive]].ReadOnly = false;
                            groupView_dgv.Columns[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_IsActive]].Visible = false;
                        }

                        /* them cot view, xem thêm */
                        UserDefineFunction.InitDataGridViewButton(
                                groupView_dgv,
                                ConnectedData.nameButtonDatas[(int)ConnectedData.enData.Data_View, (int)Languages.enLanguage.Language_Name],
                                ConnectedData.nameButtonDatas[(int)ConnectedData.enData.Data_View, (int)Languages.LanguageIndex], ConnectedData.pathImageRead);
                        groupView_dgv.Columns[ConnectedData.nameButtonDatas[(int)ConnectedData.enData.Data_View, (int)Languages.enLanguage.Language_Name]].Visible = false;
                        // Admin được sử dụng
                        // Người dùng cấp quyền update mới được thêm trường Read
                        if (Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_Group, (int)Class.Accounts.enRoleCol.RoleCol_Id], Models.Account.Permission.Read))
                        {
                            groupView_dgv.Columns[ConnectedData.nameButtonDatas[(int)ConnectedData.enData.Data_View, (int)Languages.enLanguage.Language_Name]].Visible = true;
                        }

                        /* them cot edit chỉnh sửa */
                        UserDefineFunction.InitDataGridViewButton(
                                groupView_dgv,
                                ConnectedData.nameButtonDatas[(int)ConnectedData.enData.Data_Edit, (int)Languages.enLanguage.Language_Name],
                                ConnectedData.nameButtonDatas[(int)ConnectedData.enData.Data_Edit, (int)Languages.LanguageIndex], ConnectedData.pathImageEdit);
                        groupView_dgv.Columns[ConnectedData.nameButtonDatas[(int)ConnectedData.enData.Data_Edit, (int)Languages.enLanguage.Language_Name]].Visible = false;
                        // Người dùng cấp quyền update mới được thêm trường Update, hay edit
                        if (Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_Group, (int)Class.Accounts.enRoleCol.RoleCol_Id], Models.Account.Permission.Update))
                        {
                            groupView_dgv.Columns[ConnectedData.nameButtonDatas[(int)ConnectedData.enData.Data_Edit, (int)Languages.enLanguage.Language_Name]].Visible = true;
                        }

                        /* them cot xóa */
                        UserDefineFunction.InitDataGridViewButton(
                                groupView_dgv,
                                ConnectedData.nameButtonDatas[(int)ConnectedData.enData.Data_Delete, (int)Languages.enLanguage.Language_Name],
                                ConnectedData.nameButtonDatas[(int)ConnectedData.enData.Data_Delete, (int)Languages.LanguageIndex], ConnectedData.pathImageDelete);
                        groupView_dgv.Columns[ConnectedData.nameButtonDatas[(int)ConnectedData.enData.Data_Delete, (int)Languages.enLanguage.Language_Name]].Visible = false;
                        /* Nếu Quyền Admin thì sẽ hiển thị column là Active
                         * Người dùng cấp quyền sẽ thì sẽ ẩn Column Active, thay vào đó thêm Column Delete
                         */
                        if (!hasChangesAdmin && Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_Group, (int)Class.Accounts.enRoleCol.RoleCol_Id], Models.Account.Permission.Delete))
                        {
                            groupView_dgv.Columns[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_IsActive]].Visible = false;

                            groupView_dgv.Columns[ConnectedData.nameButtonDatas[(int)ConnectedData.enData.Data_Delete, (int)Languages.enLanguage.Language_Name]].Visible = true;

                        }

                        UserToolBoxs.LoadDataGridView(groupView_dgv);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error read data Group" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        /// <summary>
        /// xu ly su kien click vao cell edit va delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupView_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool checkIsActive = false;
            bool isGroupEditTemp = false;

            if (e.RowIndex < 0) return;
            DataGridViewRow row = groupView_dgv.Rows[e.RowIndex];
            if (!string.IsNullOrEmpty(row.Cells[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Id]].Value.ToString()))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connecString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand($"SELECT * FROM {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Group]} WHERE {ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Id]} = @{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Id]}", connection);
                        groupIDActive = int.Parse(row.Cells[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Id]].Value.ToString());
                        command.Parameters.AddWithValue($"@{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Id]}", groupIDActive);
                        // xu ly su kien click vao cell edit va delete
                        // khi su kien duoc click thi hien thi thong tin cua status len form

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Quyền xem, thuộc column xem
                                if ((Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_Group, (int)Class.Accounts.enRoleCol.RoleCol_Id], Models.Account.Permission.Read) &&
                                    e.ColumnIndex == groupView_dgv.Columns[ConnectedData.nameButtonDatas[(int)ConnectedData.enData.Data_View, (int)Languages.enLanguage.Language_Name]].Index) ||
                                    // OR quyền update, column edit được chỉnh sửa
                                    (Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_Group, (int)Class.Accounts.enRoleCol.RoleCol_Id], Models.Account.Permission.Update) &&
                                    e.ColumnIndex == groupView_dgv.Columns[ConnectedData.nameButtonDatas[(int)ConnectedData.enData.Data_Edit, (int)Languages.enLanguage.Language_Name]].Index))
                                {
                                    groupName_tb.Text = reader[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Name]].ToString();
                                    groupDescription_tb.Text = reader[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Description]].ToString();
                                    isGroupEdit = true;
                                    regiter_Update_btn.Text = ConnectedData.nameButtonDatas[(int)ConnectedData.enData.Data_Update, (int)Languages.LanguageIndex];
                                }
                                // Admin có quyền Isactive or deactive
                                else if ((Class.Accounts.UserLogin.HasRermission(Models.Account.Permission.Delete) &&
                                    e.ColumnIndex == groupView_dgv.Columns[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_IsActive]].Index) ||
                                    // Or có quyền delete
                                    (Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_Group, (int)Class.Accounts.enRoleCol.RoleCol_Id], Models.Account.Permission.Delete) &&
                                    e.ColumnIndex == groupView_dgv.Columns[ConnectedData.nameButtonDatas[(int)ConnectedData.enData.Data_Delete, (int)Languages.enLanguage.Language_Name]].Index))
                                {
                                    // tien hanh xoa status
                                    isGroupEditTemp = Convert.ToBoolean(reader[ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_IsActive]].ToString());
                                    string messageStr = "Do you want to delete Group?";
                                    if (!isGroupEditTemp)
                                    {
                                        messageStr = "Do you want to Data Recovery your rights?";
                                    }
                                    DialogResult dialogResult = MessageBox.Show(messageStr, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        /* thực hiện xóa và không xóa */
                                        checkIsActive = true;
                                    }
                                }
                            }
                        }
                        if (checkIsActive)
                        {
                            updateGroup_data(connection, ConnectedData.enData.Data_Delete, (isGroupEditTemp) ? false : true);
                            MessageBox.Show("Successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Group edit \r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clearGroup_btn_Click();
                }

            }
        }

        private void cancelGroup_btn_Click(object sender, EventArgs e)
        {
            clearGroup_btn_Click();
        }
        /// <summary>
        /// clear về trạng thái ban đầu
        /// </summary>
        private void clearGroup_btn_Click()
        {
            groupIDActive = -1;
            groupName_tb.Text = "";
            groupDescription_tb.Text = "";
            isGroupEdit = false;

            regiter_Update_btn.Visible = false;
            cancel_btn.Visible = false;
            if (Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_Group, (int)Class.Accounts.enRoleCol.RoleCol_Id], Models.Account.Permission.Create) ||
                Class.Accounts.UserLogin.HasRermission(Class.Accounts.codeRoles[(int)Class.Accounts.enRoleRow.RoleRow_Group, (int)Class.Accounts.enRoleCol.RoleCol_Id], Models.Account.Permission.Update))
            {
                regiter_Update_btn.Text = ConnectedData.nameButtonDatas[(int)ConnectedData.enData.Data_Regiter, (int)Languages.LanguageIndex];
                regiter_Update_btn.Visible = true;
                cancel_btn.Visible = true;
            }


        }

    }
}
