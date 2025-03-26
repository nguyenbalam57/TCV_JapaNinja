using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Controls;
using System.Windows.Forms;
using TCV_JapaNinja.Class;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TCV_JapaNinja.Forms.Admin_Management
{
    public partial class FormUser : Form
    {
        private string connecString = ConnectedData.connectionString;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private int userIDActive = -1;
        private bool isUserEdit = false;

        private List<int> getRoles = new List<int>();
         
        public FormUser()
        {
            InitializeComponent();
            InitializeRoleCheckBoxs();
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            clearUser_Click();
            LoadDataUserDatagridView();
        }

        #region ROLES
        /// <summary>
        /// Khởi tạo checkbox cho Role
        /// </summary>
        private void InitializeRoleCheckBoxs()
        {
            DataTable dataTable = ConnectedData.dataSet.Tables[ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Role]];
            DataView data = new DataView(dataTable);
            data.RowFilter = $"{ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_IsActive]} = {true}";

            roles_flp.Controls.Clear(); // Clear existing checkboxes

            for (int i = 0; i < data.Count; i++)

            {
                System.Windows.Forms.CheckBox checkBox = new System.Windows.Forms.CheckBox
                {
                    Text = data[i][ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Name]].ToString(),
                    Tag = data[i][ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Id]].ToString(),
                    AutoSize = true
                };
                roles_flp.Controls.Add(checkBox);
            }
        }

        /// <summary>
        /// get role được chọn
        /// </summary>
        /// <returns></returns>
        private List<int> GetSelectedRoleIds()
        {
            List<int> selectedRoleIds = new List<int>();

            foreach (System.Windows.Forms.CheckBox checkBox in roles_flp.Controls)
            {
                if (checkBox.Checked)
                {
                    selectedRoleIds.Add(Convert.ToInt32(checkBox.Tag));
                }
            }
            return selectedRoleIds;

        }
        /// <summary>
        /// ghi trang thái selected
        /// </summary>
        /// <param name="selectedIds"></param>
        private void SetSelectedRoleIds(List<int> selectedIds)
        {
            foreach (System.Windows.Forms.CheckBox checkBox in roles_flp.Controls)
            {
                if (selectedIds.Contains(Convert.ToInt32(checkBox.Tag)))
                {
                    checkBox.Checked = true;
                }
            }
        }
        /// <summary>
        /// sử dụng khi đã đăng kí account
        /// </summary>
        /// <param name="active"></param>
        private void ActiveRole(bool active)
        {
            user_Role_pn.Visible = active;
        }

        #endregion

        /// <summary>
        /// hien thi danh sach xuong datagridview 
        /// </summary>
        private void LoadDataUserDatagridView()
        {
            // truy vấn user

            string selectQuery = $"SELECT " +
                $"u.{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Id]} AS userId, " +
                $"g.{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Name]} AS groupName, " +
                $"p.{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Name]} AS positionName, " +
                $"u.{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_EmployeeCode]} AS employeeCode, " +
                $"u.{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Name]} AS userName," +
                $"u.{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Pasword]} AS userPassword, " +
                $"u.{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_PaswordOld]} AS userPasswordOld, " +
                $"u.{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Description]} AS userDescription, " +
                $"u.{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_CreatedDate]} AS createdDate, " +
                $"u.{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_UpdatedDate]} AS updatedDate, " +
                $"u.{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_IsActive]} AS isActive " +
                $"FROM {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_User]} u " +
                $"LEFT JOIN {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Group]} g " +
                $"ON u.{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_GroupId]} = g.{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Id]} " +
                $"AND g.{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_IsActive]} = {ConnectedData.IsActive} " +
                $"LEFT JOIN {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Position]} p " +
                $"ON u.{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_PositionId]} = p.{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Id]} " +
                $"AND p.{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_IsActive]} = {ConnectedData.IsActive}";

            using (SqlConnection connection = new SqlConnection(connecString))
            {
                connection.Open();
                dataAdapter = new SqlDataAdapter(selectQuery, connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                userView_dgv.DataSource = dataTable;

                userView_dgv.Columns["userId"].HeaderText = "ID";
                userView_dgv.Columns["userId"].ReadOnly = true;
                userView_dgv.Columns["employeeCode"].HeaderText = "Employee Code";
                userView_dgv.Columns["employeeCode"].ReadOnly = true;
                userView_dgv.Columns["userName"].HeaderText = "Name";
                userView_dgv.Columns["userName"].ReadOnly = true;
                userView_dgv.Columns["userPassword"].HeaderText = "Password";
                userView_dgv.Columns["userPassword"].ReadOnly = true;
                userView_dgv.Columns["userPasswordOld"].HeaderText = "Password Old";
                userView_dgv.Columns["userPasswordOld"].ReadOnly = true;
                userView_dgv.Columns["userDescription"].HeaderText = "Description";
                userView_dgv.Columns["userDescription"].ReadOnly = true;
                userView_dgv.Columns["groupName"].HeaderText = "Group";
                userView_dgv.Columns["groupName"].ReadOnly = true;
                userView_dgv.Columns["positionName"].HeaderText = "Position";
                userView_dgv.Columns["positionName"].ReadOnly = true;
                userView_dgv.Columns["createdDate"].HeaderText = "Created Date";
                userView_dgv.Columns["createdDate"].ReadOnly = true;
                userView_dgv.Columns["updatedDate"].HeaderText = "Updated Date";
                userView_dgv.Columns["updatedDate"].ReadOnly = true;
                userView_dgv.Columns["isActive"].HeaderText = "Active";
                userView_dgv.Columns["isActive"].ReadOnly = true;
                userView_dgv.Columns["isActive"].ReadOnly = false;

                if (userView_dgv.Columns["userEdit"] == null)
                {
                    /* them cot edit delete */
                    DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
                    editButtonColumn.Name = "userEdit";
                    editButtonColumn.Text = "Edit";
                    editButtonColumn.UseColumnTextForButtonValue = true;
                    userView_dgv.Columns.Add(editButtonColumn);
                    userView_dgv.Columns["userEdit"].HeaderText = "Edit";
                }

                if (userView_dgv.Columns["userResetPass"] == null)
                {
                    DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                    deleteButtonColumn.Name = "userResetPass";
                    deleteButtonColumn.Text = "Reset Password";
                    deleteButtonColumn.UseColumnTextForButtonValue = true;
                    userView_dgv.Columns.Add(deleteButtonColumn);
                    userView_dgv.Columns["userResetPass"].HeaderText = "Reset Password";
                }
                connection.Close();
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="reload"></param>
        /// <param name="strSelect"></param>
        private void LoadDataGroupCombobox(int selectValue)
        {
            try
            {
                DataTable groupT = ConnectedData.dataSet.Tables[ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Group]];
                DataView dataView = new DataView(groupT);
                dataView.RowFilter = $"{ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_IsActive]} = {ConnectedData.IsActive}";
                groupT = dataView.ToTable();

                ScreenCombobox(userGroup_cbb,
                    groupT,
                    ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Name],
                    ConnectedData.groupCol[(int)ConnectedData.enGroupCol.GroupCol_Id],
                    selectValue);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Group.\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// load nhung position (chuc vu) ra combobox
        /// </summary>
        /// <param name="indexSelect"></param>
        private void LoadDataPositionCombobox(int selectValue)
        {
            try
            {
                DataTable groupT = ConnectedData.dataSet.Tables[ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Position]];
                DataView dataView = new DataView(groupT);
                dataView.RowFilter = $"{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_IsActive]} = {ConnectedData.IsActive}";
                groupT = dataView.ToTable();

                ScreenCombobox(userPosition_cbb, groupT, ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Name], ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Id], selectValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Position.\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// in ra combobox
        /// </summary>
        /// <param name="combobox"></param>
        /// <param name="dataTable"></param>
        /// <param name="display"></param>
        /// <param name="value"></param>
        /// <param name="selectValue"></param>
        private void ScreenCombobox(System.Windows.Forms.ComboBox combobox, DataTable dataTable, string display, string value, int selectValue)
        {
            //combobox.Items.Clear();

            combobox.DataSource = dataTable;
            combobox.DisplayMember = display;
            combobox.ValueMember = value;

            // su dung cho truong hop can edit
            if ( selectValue >= 0 && combobox.Items.Count > 0)
            {
                combobox.SelectedValue = selectValue;
            }
            else
            {
                combobox.Text = "";
            }

        }

        /// <summary>
        /// clear ve lai trang thai ban dau
        /// </summary>
        /// <param name="reload"></param>
        private void clearUser_Click()
        {
            LoadDataGroupCombobox(-1);
            LoadDataPositionCombobox(-1);
            userEmployeeCode_tb.Text = "";
            userEmployeeCode_tb.Focus();
            userName_tb.Text = "";
            userDescription_tb.Text = "";

            userIDActive = -1;
            isUserEdit = false;
            regiter_update_btn.Text = "Register";

            ActiveRole(false);
            // CLear roles
            getRoles = new List<int>();

        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            clearUser_Click();
        }

        private void regiter_Update_btn_Click(object sender, EventArgs e)
        {

            //giai quyet viec khong co data nhung van khai bao insert
            string insertQuery = $"INSERT INTO {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_User]} " +
                $"({ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_GroupId]}, " +
                $"{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_PositionId]}, " +
                $"{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_EmployeeCode]}, " +
                $"{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Name]}, " +
                $"{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Pasword]}, " +
                $"{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Description]}, " +
                $"{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_CreatedDate]}, " +
                $"{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_UpdatedDate]}, " +
                $"{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_IsActive]}) " +
                $"VALUES (" +
                $"@GroupId, " +
                $"@PositionId, " +
                $"@EmployeeCode, " +
                $"@Name, " +
                $"@Pasword, " +
                $"@Description, " +
                $"@CreatedDate, " +
                $"@UpdatedDate, " +
                $"@IsActive)";


            if (string.IsNullOrEmpty(userEmployeeCode_tb.Text) || string.IsNullOrEmpty(userName_tb.Text))
            {
                MessageBox.Show("Please enter User Employee Code And Name not Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connecString))
                {
                    connection.Open();
                    if (isUserEdit)
                    {
                        // update group
                        updateUser_data(connection, ConnectedData.enData.Data_Update, false);
                    }
                    else
                    {
                        // insert group
                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            UserDefineFunction.getValueCombobox(userGroup_cbb, string.Empty, out string groupValue);
                            command.Parameters.AddWithValue($"@GroupId", (object)groupValue ?? DBNull.Value);
                            UserDefineFunction.getValueCombobox(userPosition_cbb, string.Empty, out string positionValue);
                            command.Parameters.AddWithValue($"@PositionId", (object)positionValue ?? DBNull.Value);
                            command.Parameters.AddWithValue($"@EmployeeCode", userEmployeeCode_tb.Text);
                            command.Parameters.AddWithValue($"@Name", userName_tb.Text);
                            command.Parameters.AddWithValue($"@Pasword", ConnectedData.passWordNew);
                            command.Parameters.AddWithValue($"@Description", userDescription_tb.Text);
                            command.Parameters.AddWithValue($"@CreatedDate", DateTime.Now);
                            command.Parameters.AddWithValue($"@UpdatedDate", DateTime.Now);
                            command.Parameters.AddWithValue($"@IsActive", ConnectedData.IsActive);
                            command.ExecuteNonQuery();
                        }
                    }

                    LoadDataUserDatagridView();
                    clearUser_Click();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("User regiter or update.\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearUser_Click();
            }
        }

        /// <summary>
        /// thuc hien update data
        /// boi vi khong cho xoa hoan toan nen chi su dung active hoac deactive
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="enData"></param>
        private void updateUser_data(SqlConnection connection, ConnectedData.enData enData, bool isActive)
        {
            string passWordOld = string.Empty;
            string groupValue = null;
            string positionValue = null;

            string updateQuery = $"UPDATE {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_User]} SET ";
            List<string> updateFields = new List<string>();
            bool hasChanges = false;
            bool hasChangesUserRole = false;

            // Lấy giá trị hiện tại từ cơ sở dữ liệu
            string selectQuery = $"SELECT * FROM {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_User]} " +
                $"WHERE {ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Id]} = @UserId";
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue($"@UserId", userIDActive);
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable currentData = new DataTable();
            adapter.Fill(currentData);

            if (currentData.Rows.Count == 0)
            {
                throw new Exception("Không tìm thấy người dùng.");
            }

            DataRow currentRow = currentData.Rows[0];

            switch (enData)
            {
                case ConnectedData.enData.Data_Insert:
                    break;
                case ConnectedData.enData.Data_Update:
                    // So sánh từng trường và thêm vào truy vấn cập nhật nếu có thay đổi
                    if (UserDefineFunction.getValueCombobox(userGroup_cbb, currentRow[ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_GroupId]].ToString(), out string groupId))
                    {
                        updateFields.Add($"{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_GroupId]} = @GroupId");
                        groupValue = groupId;
                        hasChanges = true;
                    }

                    if (UserDefineFunction.getValueCombobox(userPosition_cbb, currentRow[ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_PositionId]].ToString(), out string positionId))
                    {
                        updateFields.Add($"{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_PositionId]} = @PositionId");
                        positionValue = positionId;
                        hasChanges = true;
                    }

                    if (currentRow[ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_EmployeeCode]].ToString() != userEmployeeCode_tb.Text)
                    {
                        updateFields.Add($"{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_EmployeeCode]} = @EmployeeCode");
                        hasChanges = true;
                    }
                    if (currentRow[ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Name]].ToString() != userName_tb.Text)
                    {
                        updateFields.Add($"{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Name]} = @Name");
                        hasChanges = true;
                    }
                    if (currentRow[ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Description]].ToString() != userDescription_tb.Text)
                    {
                        updateFields.Add($"{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Description]} = @Description");
                        hasChanges = true;
                    }
                    hasChangesUserRole = true;
                    break;
                case ConnectedData.enData.Data_Delete:
                    // active
                    updateFields.Add($"{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_IsActive]} = @IsActive");
                    hasChanges = true;
                    break;
                case ConnectedData.enData.Data_ResetPW:
                    // reset pw. chuyen pw sang pwold
                    updateFields.Add($"{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Pasword]} = @PassWord");
                    passWordOld = currentRow[ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_PaswordOld]].ToString();
                    updateFields.Add($"{ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_PaswordOld]} = @PaswordOld");
                    hasChanges = true;
                    break;
                default:
                    break;
            }

            if (hasChanges)
            {
                updateQuery += string.Join(", ", updateFields);
                updateQuery += $", {ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_UpdatedDate]} = @UpdatedDate " +
                    $"WHERE {ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Id]} = @UserId";

                try
                {
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue($"@GroupId", (object)groupValue ?? DBNull.Value);
                        command.Parameters.AddWithValue($"@PositionId", (object)positionValue ?? DBNull.Value);
                        command.Parameters.AddWithValue($"@EmployeeCode", userEmployeeCode_tb.Text);
                        command.Parameters.AddWithValue($"@Name", userName_tb.Text);
                        command.Parameters.AddWithValue($"@Description", userDescription_tb.Text);
                        command.Parameters.AddWithValue($"@IsActive", isActive);
                        command.Parameters.AddWithValue($"@PassWord", ConnectedData.passWordNew);
                        command.Parameters.AddWithValue($"@PaswordOld", passWordOld);
                        command.Parameters.AddWithValue($"@UpdatedDate", DateTime.Now);
                        command.Parameters.AddWithValue($"@UserId", userIDActive);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Update User.\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không có thay đổi nào được phát hiện.");
            }

            // xem su thay doi
            if(hasChangesUserRole)
            {
                updateUserRole(userIDActive);
            }

        }


        private void updateUserRole(int userId)
        {
            // so sanh 2 list danh sach role user
            List<int> currentRoles = GetSelectedRoleIds();
            List<int> rolesToAdd = currentRoles.Except(getRoles).ToList();
            List<int> rolesToRemove = getRoles.Except(currentRoles).ToList();

            try
            {
                using (SqlConnection connection = new SqlConnection(connecString))
                {
                    connection.Open();

                    // Thêm các vai trò mới
                    foreach (int roleId in rolesToAdd)
                    {
                        string insertQuery = $"INSERT INTO {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_UserRole]} " +
                            $"({ConnectedData.userRoleCol[(int)ConnectedData.enUserRoleCol.UserRoleCol_UserId]}, " +
                            $"{ConnectedData.userRoleCol[(int)ConnectedData.enUserRoleCol.UserRoleCol_RoleId]}, " +
                            $"{ConnectedData.userRoleCol[(int)ConnectedData.enUserRoleCol.UserRoleCol_UserIdEdit]}," +
                            $"{ConnectedData.userRoleCol[(int)ConnectedData.enUserRoleCol.UserRoleCol_CreatedDate]}) " +
                            $"VALUES (" +
                            $"@UserId, " +
                            $"@RoleId, " +
                            $"@UserIdEdit, " +
                            $"@CreatedDate)";
                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue($"@UserId", userId);
                            command.Parameters.AddWithValue($"@RoleId", roleId);
                            command.Parameters.AddWithValue($"@UserIdEdit", Class.Accounts.UserLogin.UserId);
                            command.Parameters.AddWithValue($"@CreatedDate", DateTime.Now);
                            command.ExecuteNonQuery();
                        }
                    }

                    // Xóa các vai trò không còn được chọn
                    foreach (int roleId in rolesToRemove)
                    {
                        string deleteQuery = $"DELETE FROM {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_UserRole]} " +
                            $"WHERE {ConnectedData.userRoleCol[(int)ConnectedData.enUserRoleCol.UserRoleCol_UserId]} = @UserId " +
                            $"AND {ConnectedData.userRoleCol[(int)ConnectedData.enUserRoleCol.UserRoleCol_RoleId]} = @RoleId";
                        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue($"@UserId", userId);
                            command.Parameters.AddWithValue($"@RoleId", roleId);
                            command.ExecuteNonQuery();
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("User Role edit.\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            bool isEditTemp = false;
            bool checkResetpw = false;

            if (e.RowIndex >= 0 && !string.IsNullOrEmpty(userView_dgv.Rows[e.RowIndex].Cells[ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Id]].Value.ToString()))
            {
                try
                {
                    DataGridViewRow row = userView_dgv.Rows[e.RowIndex];
                    using (SqlConnection connection = new SqlConnection(connecString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand($"SELECT * FROM {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_User]} " +
                            $"WHERE {ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Id]} = @UserId", connection);
                        userIDActive = int.Parse(row.Cells[ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Id]].Value.ToString());
                        command.Parameters.AddWithValue($"@UserId", userIDActive);
                        // xu ly su kien click vao cell edit va delete
                        // khi su kien duoc click thi hien thi thong tin cua status len form

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                /*
                                 * Edit user -> hien thi len form nhap -> chinh sua thong tin -> update
                                 */
                                if (e.ColumnIndex == userView_dgv.Columns["userEdit"].Index)
                                {
                                    isEditTemp = Convert.ToBoolean(reader[ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_IsActive]].ToString());
                                    if (isEditTemp)
                                    {
                                        userEmployeeCode_tb.Text = reader[ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_EmployeeCode]].ToString();
                                        userName_tb.Text = reader[ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Name]].ToString();
                                        userDescription_tb.Text = reader[ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Description]].ToString();
                                        LoadDataGroupCombobox(UserDefineFunction.getNumberDataNullOrValue(reader[ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_GroupId]].ToString()));
                                        LoadDataPositionCombobox(UserDefineFunction.getNumberDataNullOrValue(reader[ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_PositionId]].ToString()));

                                        isUserEdit = true;
                                        regiter_update_btn.Text = "Update";
                                    }
                                    else
                                    {
                                        MessageBox.Show("User NotActive!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                }
                                /*
                                 * Delete -> update isActive
                                 */
                                else if (e.ColumnIndex == userView_dgv.Columns[ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_IsActive]].Index)
                                {
                                    // tien hanh xoa status
                                    isEditTemp = Convert.ToBoolean(reader[ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_IsActive]].ToString());
                                    string messageStr = "Do you want to delete Roles?";
                                    if (!isEditTemp)
                                    {
                                        messageStr = "Do you want to Data Recovery your rights?";
                                    }
                                    DialogResult dialogResult = MessageBox.Show(messageStr, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        checkIsActive = true;
                                    }
                                }
                                /*
                                 * Re set password trong truong hop quyen
                                 */
                                else if (e.ColumnIndex == userView_dgv.Columns["userResetPass"].Index)
                                {
                                    DialogResult dialogResult = MessageBox.Show("Do you want to Reset Password this User?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        checkResetpw = true;
                                    }
                                }
                            }
                        }
                        // Load role
                        if (isUserEdit)
                        {
                            getRoles = new List<int>();
                            string queryUserRole = $"SELECT * " +
                                $"FROM {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_UserRole]} " +
                                $"WHERE {ConnectedData.userRoleCol[(int)ConnectedData.enUserRoleCol.UserRoleCol_UserId]} = @UserId";
                            using (SqlCommand commandUR = new SqlCommand(queryUserRole, connection))
                            {
                                commandUR.Parameters.AddWithValue($"@UserId", userIDActive);

                                using (SqlDataReader reader = commandUR.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        getRoles.Add(Convert.ToInt32(reader[ConnectedData.userRoleCol[(int)ConnectedData.enUserRoleCol.UserRoleCol_RoleId]].ToString()));
                                    }
                                }

                                // set id to checkbox
                                SetSelectedRoleIds(getRoles);
                                // chỉ khi update mới hiển thị
                                ActiveRole(true);
                            }
                        }
                        // thực hiện Active 
                        if (checkIsActive)
                        {
                            updateUser_data(connection, ConnectedData.enData.Data_Delete, (isEditTemp) ? false : true);
                            MessageBox.Show("Completed successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataUserDatagridView();
                        }
                        // Thực hiện Reset PW
                        if (checkResetpw)
                        {
                            updateUser_data(connection, ConnectedData.enData.Data_ResetPW, false);
                            MessageBox.Show("Reset successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataUserDatagridView();
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("User edit.\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clearUser_Click();
                }

            }
        }


    }
}
