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
    public partial class FormPosition : Form
    {
        private string connecString = Class.ConnectedData.connectionString;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private int positionIDActive = -1;
        private bool isPositionEdit = false;

        public FormPosition()
        {
            InitializeComponent();
        }
        private void Formposition_Load(object sender, EventArgs e)
        {
            clearposition_btn_Click();
            LoadData();
        }

        private void regiter_Update_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(positionName_tb.Text))
            {
                MessageBox.Show("Please enter position name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connecString))
            {
                connection.Open();
                if (isPositionEdit)
                {
                    // update position
                    updatePosition_data(connection, ConnectedData.enData.Data_Update, false);
                }
                else
                {
                    string query = $"INSERT INTO " +
                        $"{ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Position]} ( " +
                        $"{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Name]}, " +
                        $"{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Description]}, " +
                        $"{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_CreatedDate]}, " +
                        $"{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_UpdatedDate]}, " +
                        $"{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_IsActive]}) " +
                        $"VALUES ( " +
                        $"@{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Name]}, " +
                        $"@{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Description]}, " +
                        $"@{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_CreatedDate]}, " +
                        $"@{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_UpdatedDate]}, " +
                        $"@{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_IsActive]})";
                    // insert position
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue($"@{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Name]}", positionName_tb.Text);
                    command.Parameters.AddWithValue($"@{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Description]}", positionDescription_tb.Text);
                    command.Parameters.AddWithValue($"@{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_CreatedDate]}", DateTime.Now);
                    command.Parameters.AddWithValue($"@{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_UpdatedDate]}", DateTime.Now);
                    command.Parameters.AddWithValue($"@{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_IsActive]}", true);
                    command.ExecuteNonQuery();
                }
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
                LoadData();
                clearposition_btn_Click();
            }
        }

        /// <summary>
        /// thuc hien update data
        /// boi vi khong cho xoa hoan toan nen chi su dung active hoac deactive
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="enData"></param>
        private void updatePosition_data(SqlConnection connection, ConnectedData.enData enData, bool isActive)
        {
            string updateQuery = $"UPDATE {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Position]} SET ";
            List<string> updateFields = new List<string>();
            bool hasChanges = false;

            // Lấy giá trị hiện tại từ cơ sở dữ liệu
            string selectQuery = $"SELECT * FROM {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Position]} " +
                $"WHERE {ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Id]} = @activeId";
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@activeId", positionIDActive);
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
                    if (currentRow[ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Name]].ToString() != positionName_tb.Text)
                    {
                        updateFields.Add($"{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Name]} = @{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Name]}");
                        hasChanges = true;
                    }
                    if (currentRow[ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Description]].ToString() != positionDescription_tb.Text)
                    {
                        updateFields.Add($"{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Description]} = @{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Description]}");
                        hasChanges = true;
                    }
                    break;
                case ConnectedData.enData.Data_Delete:
                    updateFields.Add($"{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_IsActive]} = @{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_IsActive]}");
                    hasChanges = true;
                    break;
                default:
                    break;
            }

            if (hasChanges)
            {
                updateQuery += string.Join(", ", updateFields);
                updateQuery += $", {ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_UpdatedDate]} = @{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_UpdatedDate]} " +
                    $"WHERE {ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Id]} = @{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Id]}";

                try
                {
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue($"@{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Name]}", positionName_tb.Text);
                        command.Parameters.AddWithValue($"@{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Description]}", positionDescription_tb.Text);
                        command.Parameters.AddWithValue($"@{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_IsActive]}", isActive);
                        command.Parameters.AddWithValue($"@{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_UpdatedDate]}", DateTime.Now);
                        command.Parameters.AddWithValue($"@{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Id]}", positionIDActive);
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
            positionView_dgv.Refresh();

            using (SqlConnection connection = new SqlConnection(connecString))
            {
                dataAdapter = new SqlDataAdapter($"SELECT *  FROM {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Position]} ", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                positionView_dgv.DataSource = dataTable;

                positionView_dgv.Columns[ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Id]].HeaderText = "ID";
                positionView_dgv.Columns[ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Id]].ReadOnly = true;
                positionView_dgv.Columns[ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Name]].HeaderText = "Name";
                positionView_dgv.Columns[ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Name]].ReadOnly = true;
                positionView_dgv.Columns[ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Description]].HeaderText = "Description";
                positionView_dgv.Columns[ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Description]].ReadOnly = true;
                positionView_dgv.Columns[ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_CreatedDate]].HeaderText = "Created Date";
                positionView_dgv.Columns[ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_CreatedDate]].ReadOnly = true;
                positionView_dgv.Columns[ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_UpdatedDate]].HeaderText = "Updated Date";
                positionView_dgv.Columns[ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_UpdatedDate]].ReadOnly = true;
                positionView_dgv.Columns[ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_IsActive]].HeaderText = "Active";
                positionView_dgv.Columns[ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_IsActive]].ReadOnly = true;
                positionView_dgv.Columns[ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_IsActive]].ReadOnly = false;

                if (positionView_dgv.Columns["positionEdit"] == null)
                {
                    /* them cot edit delete */
                    DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
                    editButtonColumn.Name = "positionEdit";
                    editButtonColumn.Text = "Edit";
                    editButtonColumn.UseColumnTextForButtonValue = true;
                    positionView_dgv.Columns.Add(editButtonColumn);
                    positionView_dgv.Columns["positionEdit"].HeaderText = "Edit";
                }
                UserToolBoxs.LoadDataGridView(positionView_dgv);
            }

        }

        /// <summary>
        /// xu ly su kien click vao cell edit va delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void positionView_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool checkIsActive = false;
            bool isEditTemp = false;

            DataGridViewRow row = positionView_dgv.Rows[e.RowIndex];
            if (e.RowIndex >= 0 && !string.IsNullOrEmpty(row.Cells["positionId"].Value.ToString()))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connecString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand($"SELECT * FROM {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Position]} WHERE {ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Id]} = @{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Id]}", connection);
                        positionIDActive = int.Parse(row.Cells[ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Id]].Value.ToString());
                        command.Parameters.AddWithValue($"@{ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Id]}", positionIDActive);
                        // xu ly su kien click vao cell edit va delete

                        // khi su kien duoc click thi hien thi thong tin cua status len form
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (e.ColumnIndex == positionView_dgv.Columns["positionEdit"].Index)
                                {
                                    positionName_tb.Text = reader[ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Name]].ToString();
                                    positionDescription_tb.Text = reader[ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_Description]].ToString();
                                    isPositionEdit = true;
                                    regiter_update_btn.Text = "Update";
                                }
                                else if ( e.ColumnIndex == positionView_dgv.Columns[ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_IsActive]].Index)
                                {
                                    // tien hanh xoa status
                                    // tien hanh xoa
                                    isEditTemp = Convert.ToBoolean(reader[ConnectedData.positionCol[(int)ConnectedData.enPositionCol.PositionCol_IsActive]].ToString());
                                    string messageStr = "Do you want to delete Position?";
                                    if (!isEditTemp)
                                    {
                                        messageStr = "Do you want to Data Recovery your rights?";
                                    }
                                    DialogResult dialogResult = MessageBox.Show(messageStr, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        // xu ly cap nhat xoa
                                        checkIsActive = true;
                                        
                                    }
                                }
                            }
                        }
                        if(checkIsActive)
                        {
                            updatePosition_data(connection, ConnectedData.enData.Data_Delete, (isEditTemp) ? false : true);
                            MessageBox.Show("Completed successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Position edit \r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clearposition_btn_Click();
                }

            }
        }

        private void cancelposition_btn_Click(object sender, EventArgs e)
        {
            clearposition_btn_Click();
        }
        /// <summary>
        /// clear trangj thai ban dau
        /// </summary>
        private void clearposition_btn_Click()
        {
            positionIDActive = -1;
            positionName_tb.Text = "";
            positionDescription_tb.Text = "";
            isPositionEdit = false;
            regiter_update_btn.Text = "Register";
        }
    }
}
