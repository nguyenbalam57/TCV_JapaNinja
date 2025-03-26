using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCV_JapaNinja.Class;

namespace TCV_JapaNinja.Forms.Admin_Management.Accounts
{
    public partial class FormRole : Form
    {
        private string connecString = ConnectedData.connectionString;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private int roleIDActive = -1;
        private bool isRoleEdit = false;
        public FormRole()
        {
            InitializeComponent();
            InitializeRoleCheckboxes();
        }

        private void FormRole_Load(object sender, EventArgs e)
        {
            clearRole_btn_Click();
            LoadData();
        }

        /// <summary>
        /// khởi tạo check box roles
        /// </summary>
        private void InitializeRoleCheckboxes()
        {
            roles_flp.Controls.Clear(); // Clear existing checkboxes
            for (int i = 0; i < (int)Class.Accounts.enRoleRow.RoleRow_; i++)
            {
                CheckBox checkBox = new CheckBox
                {
                    Text = Class.Accounts.codeRoles[i, (int)Class.Accounts.enRoleCol.RoleCol_Name],
                    Tag = Class.Accounts.codeRoles[i, (int)Class.Accounts.enRoleCol.RoleCol_Id],
                    AutoSize = true
                };
                roles_flp.Controls.Add(checkBox);
            }
        }


        private void regiter_Update_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(roleName_tb.Text))
            {
                MessageBox.Show("Please enter Role name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connecString))
                {
                    connection.Open();
                    if (isRoleEdit)
                    {
                        // update Role
                        updateRole_data(connection, ConnectedData.enData.Data_Update, false);
                    }
                    else
                    {
                        string queryRole = $"INSERT INTO {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Role]} ( " +
                            $"{ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Code]}, " +
                            $"{ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Name]}, " +
                            $"{ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Description]}, " +
                            $"{ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Created]}, " +
                            $"{ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Read]}, " +
                            $"{ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Update]}, " +
                            $"{ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Delete]}, " +
                            $"{ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_CreatedDate]}, " +
                            $"{ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_UpdatedDate]}, " +
                            $"{ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_IsActive]}) " +
                            $"VALUES ( " +
                            $"@Code, " +
                            $"@Name, " +
                            $"@Description, " +
                            $"@CreatedRole, " +
                            $"@ReadRole, " +
                            $"@UpdateRole, " +
                            $"@DeleteRole, " +
                            $"@CreatedDate, " +
                            $"@UpdatedDate, " +
                            $"@IsActive)";
                        // insert Role
                        using (SqlCommand command = new SqlCommand(queryRole, connection))
                        {
                            command.Parameters.AddWithValue("@Code", ConvertListToStringRole(roles_flp));
                            command.Parameters.AddWithValue("@Name", roleName_tb.Text);
                            command.Parameters.AddWithValue("@Description", roleDescription_tb.Text);
                            command.Parameters.AddWithValue("@CreatedRole", GetCheckBoxCRUD(create_cb));
                            command.Parameters.AddWithValue("@ReadRole", GetCheckBoxCRUD(read_cb));
                            command.Parameters.AddWithValue("@UpdateRole", GetCheckBoxCRUD(update_cb));
                            command.Parameters.AddWithValue("@DeleteRole", GetCheckBoxCRUD(delete_cb));
                            command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                            command.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
                            command.Parameters.AddWithValue("@IsActive", true);
                            command.ExecuteNonQuery();
                        }

                    }
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                    LoadData();
                    clearRole_btn_Click();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Role regiter and update\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearRole_btn_Click();
            }
        }
        /// <summary>
        /// thuc hien update data
        /// boi vi khong cho xoa hoan toan nen chi su dung active hoac deactive
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="enData"></param>
        private void updateRole_data(SqlConnection connection, ConnectedData.enData enData, bool isActive)
        {
            // lưu danh sach role
            string code = string.Empty;

            string updateQuery = $"UPDATE {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Role]} SET ";
            List<string> updateFields = new List<string>();
            bool hasChanges = false;

            // Lấy giá trị hiện tại từ cơ sở dữ liệu
            string selectQuery = $"SELECT * FROM {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Role]} " +
                $"WHERE {ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Id]} = @RoleId";
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@RoleId", roleIDActive);
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
                    // So sánh từng trường và thêm vào truy vấn cập nhật nếu có thay đổi
                    code = ConvertListToStringRole(roles_flp);
                    if (currentRow[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Code]].ToString() != code)
                    {
                        updateFields.Add($"{ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Code]} = @code");
                        hasChanges = true;
                    }
                    if (currentRow[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Name]].ToString() != roleName_tb.Text)
                    {
                        updateFields.Add($"{ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Name]} = @name");
                        hasChanges = true;
                    }
                    if (currentRow[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Description]].ToString() != roleDescription_tb.Text)
                    {
                        updateFields.Add($"{ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Description]} = @description");
                        hasChanges = true;
                    }
                    if (Convert.ToInt32(currentRow[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Created]]) != Convert.ToInt32(GetCheckBoxCRUD(create_cb)))
                    {
                        updateFields.Add($"{ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Created]} = @CreatedRole");
                        hasChanges = true;
                    }
                    if (Convert.ToInt32(currentRow[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Read]]) != Convert.ToInt32(GetCheckBoxCRUD(read_cb)))
                    {
                        updateFields.Add($"{ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Read]} = @ReadRole");
                        hasChanges = true;
                    }
                    if (Convert.ToInt32(currentRow[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Update]]) != Convert.ToInt32(GetCheckBoxCRUD(update_cb)))
                    {
                        updateFields.Add($"{ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Update]} = @UpdateRole");
                        hasChanges = true;
                    }
                    if (Convert.ToInt32(currentRow[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Delete]]) != Convert.ToInt32(GetCheckBoxCRUD(delete_cb)))
                    {
                        updateFields.Add($"{ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Delete]} = @DeleteRole");
                        hasChanges = true;
                    }
                    break;
                case ConnectedData.enData.Data_Delete:
                    updateFields.Add($"{ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_IsActive]} = @isActive");
                    hasChanges = true;
                    break;
                default:
                    break;
            }

            if (hasChanges)
            {
                updateQuery += string.Join(", ", updateFields);
                updateQuery += $", {ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_UpdatedDate]} = @updatedDate WHERE {ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Id]} = @RoleId";

                try
                {
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@code", code);
                        command.Parameters.AddWithValue("@name", roleName_tb.Text);
                        command.Parameters.AddWithValue("@description", roleDescription_tb.Text);
                        command.Parameters.AddWithValue("@CreatedRole", GetCheckBoxCRUD(create_cb));
                        command.Parameters.AddWithValue("@ReadRole", GetCheckBoxCRUD(read_cb));
                        command.Parameters.AddWithValue("@UpdateRole", GetCheckBoxCRUD(update_cb));
                        command.Parameters.AddWithValue("@DeleteRole", GetCheckBoxCRUD(delete_cb));
                        command.Parameters.AddWithValue("@isActive", isActive);
                        command.Parameters.AddWithValue("@updatedDate", DateTime.Now);
                        command.Parameters.AddWithValue("@RoleId", roleIDActive);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Update Role.\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            using (SqlConnection connection = new SqlConnection(connecString))
            {
                dataAdapter = new SqlDataAdapter($"SELECT * FROM {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Role]}", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                roleView_dgv.DataSource = dataTable;

                roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Id]].HeaderText = "ID";
                roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Id]].ReadOnly = true;
                roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Code]].HeaderText = "Code";
                roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Code]].Visible = false;
                roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Name]].HeaderText = "Name";
                roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Name]].ReadOnly = true;
                roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Description]].HeaderText = "Description";
                roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Description]].ReadOnly = true;
                roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Created]].HeaderText = "Created";
                roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Created]].ReadOnly = true;
                roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Read]].HeaderText = "Read";
                roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Read]].ReadOnly = true;
                roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Update]].HeaderText = "Update";
                roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Update]].ReadOnly = true;
                roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Delete]].HeaderText = "Delete";
                roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Delete]].ReadOnly = true;
                roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_CreatedDate]].HeaderText = "Created Date";
                roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_CreatedDate]].ReadOnly = true;
                roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_UpdatedDate]].HeaderText = "Updated Date";
                roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_UpdatedDate]].ReadOnly = true;
                roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_IsActive]].HeaderText = "Active";
                roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_IsActive]].ReadOnly = true;
                roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_IsActive]].ReadOnly = false;

                if (roleView_dgv.Columns["roleEdit"] == null)
                {
                    /* them cot edit delete */
                    DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
                    editButtonColumn.Name = "roleEdit";
                    editButtonColumn.Text = "Edit";
                    editButtonColumn.UseColumnTextForButtonValue = true;
                    roleView_dgv.Columns.Add(editButtonColumn);
                    roleView_dgv.Columns["roleEdit"].HeaderText = "Edit";
                }

                UserToolBoxs.LoadDataGridView(roleView_dgv);
            }

        }

        /// <summary>
        /// xu ly su kien click vao cell edit va delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roleView_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool checkIsActive = false;
            bool isRoleEditTemp = false;

            if (e.RowIndex < 0) return;

            DataGridViewRow row = roleView_dgv.Rows[e.RowIndex];
            if (e.RowIndex >= 0 && !string.IsNullOrEmpty(row.Cells[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Id]].Value.ToString()))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connecString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand($"SELECT * FROM " +
                            $"{ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Role]} " +
                            $"WHERE {ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Id]} = @RoleId", connection);
                        roleIDActive = int.Parse(row.Cells[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Id]].Value.ToString());
                        command.Parameters.AddWithValue("@RoleId", roleIDActive);
                        // xu ly su kien click vao cell edit va delete
                        // khi su kien duoc click thi hien thi thong tin cua status len form

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (e.ColumnIndex == roleView_dgv.Columns["roleEdit"].Index)
                                {
                                    // Ghi vào role flowlayoutpanel, có giá trị checkbox
                                    SetCheckBoxStringToList(roles_flp, reader[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Code]].ToString());
                                    // Tên role
                                    roleName_tb.Text = reader[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Name]].ToString();
                                    // Mô tả role
                                    roleDescription_tb.Text = reader[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Description]].ToString();
                                    // Checkbox tạo mới
                                    SetCheckboxCRUD(create_cb, reader[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Created]].ToString());
                                    // Checkbox đọc
                                    SetCheckboxCRUD(read_cb, reader[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Read]].ToString());
                                    // Checkbox cập nhật
                                    SetCheckboxCRUD(update_cb, reader[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Update]].ToString());
                                    // Checkbox Xóa
                                    SetCheckboxCRUD(delete_cb, reader[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_Delete]].ToString());

                                    // bật trạng thái đang edit
                                    isRoleEdit = true;
                                    regiter_Update_btn.Text = "Update";
                                }
                                // sử dụng Active or deActive thay vì xóa vinh viễn
                                // else if (e.ColumnIndex == roleView_dgv.Columns["roleDelete"].Index)
                                else if (e.ColumnIndex == roleView_dgv.Columns[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_IsActive]].Index)
                                {
                                    // tien hanh xoa
                                    isRoleEditTemp = Convert.ToBoolean(reader[ConnectedData.roleCol[(int)ConnectedData.enRoleCol.RoleCol_IsActive]].ToString());
                                    string messageStr = "Do you want to delete Roles?";
                                    if (!isRoleEditTemp)
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
                        // Active Or DeActive
                        if (checkIsActive)
                        {
                            updateRole_data(connection, ConnectedData.enData.Data_Delete, (isRoleEditTemp) ? false : true); 
                            MessageBox.Show("Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Role edit \r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clearRole_btn_Click();
                }

            }
        }

        private void cancelRole_btn_Click(object sender, EventArgs e)
        {
            clearRole_btn_Click();
        }

        /// <summary>
        /// clear giá trị ở trong form
        /// </summary>
        private void clearRole_btn_Click()
        {
            roleIDActive = -1;
            roleName_tb.Text = "";
            roleDescription_tb.Text = "";
            isRoleEdit = false;
            regiter_Update_btn.Text = "Register";

            // Clear về false
            SetCheckBoxStringToList(roles_flp, " ");
            SetCheckboxCRUD(create_cb, "");
            SetCheckboxCRUD(read_cb, "");
            SetCheckboxCRUD(update_cb, "");
            SetCheckboxCRUD(delete_cb, "");
        }

        #region ROLES
        /// <summary>
        /// get tag checkbox
        /// </summary>
        /// <param name="flowLayoutPanel"></param>
        /// <param name="result"></param>
        private string ConvertListToStringRole(FlowLayoutPanel flowLayoutPanel)
        {
            List<string> selectedRoles = new List<string>();
            foreach (CheckBox checkBox in flowLayoutPanel.Controls)
            {
                if (checkBox.Checked)
                {
                    selectedRoles.Add(checkBox.Tag.ToString());
                }
            }

            return string.Join(" ", selectedRoles);
        }
        /// <summary>
        /// xét checkbox true theo string code
        /// </summary>
        /// <param name="flowLayoutPanel"></param>
        /// <param name="code"></param>
        private void SetCheckBoxStringToList(FlowLayoutPanel flowLayoutPanel, string code)
        {
            string[] splist = code.Split(' ');
            foreach (CheckBox checkBox in flowLayoutPanel.Controls)
            {
                if (splist.Contains(checkBox.Tag.ToString()))
                {
                    checkBox.Checked = true;
                }
                else
                {
                    checkBox.Checked = false;
                }
            }
        }
        /// <summary>
        /// lay gia tri tru false Checkbox
        /// </summary>
        /// <param name="checkBox"></param>
        /// <returns></returns>
        private bool GetCheckBoxCRUD(CheckBox checkBox)
        {
            if (checkBox.Checked) return true;

            return false;
        }
        /// <summary>
        /// ghi gia tri xuong checkbox
        /// </summary>
        /// <param name="checkBox"></param>
        /// <param name="value"></param>
        private void SetCheckboxCRUD(CheckBox checkBox, string value)
        {
            bool check = false;

            if(string.IsNullOrWhiteSpace(value))
            {
                /* nothing to do */
            }
            else if ( Convert.ToBoolean(value) )
            {
                check = true;
            }
            else if(UserDefineFunction.IsValidNumber(value) && Convert.ToInt32(value) > 0)
            {
                check = true;
            }

            checkBox.Checked = check;

        }



        #endregion
    }
}
