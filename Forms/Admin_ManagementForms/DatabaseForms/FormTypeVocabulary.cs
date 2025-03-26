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

namespace TCV_JapaNinja.Forms.Admin_Management.InputDatabase
{
    public partial class FormTypeVocabulary : Form
    {
        public FormTypeVocabulary()
        {
            InitializeComponent();
        }
        #region ADD_EDIT_DELETE_DATA

        private string connecString = ConnectedData.connectionString;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private int IDActive = -1;
        private bool isEdit = false;
        private bool isActive = true;

        /* du lieu old */
        private string levelNameOld = string.Empty;
        private string levelDesOld = string.Empty;

        /* column data level column thay doi */
        enum enColumn
        {
            Column_Name = 0,
            Column_Des,
            Column_isActive,
            Column_Empty,
            Column_
        }
        enum enStruterSql
        {
            StruterSql_Name = 0,
            StruterSql_Value,
            StruterSql_
        }
        private string[] Column = new string[(int)enColumn.Column_] {
            "typeVocaName = @typeVocaName,",
            "typeVocaDescription = @typeVocaDescription,",
            "isActive = @isActive,",
            ""
        };

        private void Form_Load(object sender, EventArgs e)
        {
            clear_btn_Click();
            LoadData();
        }

        /// <summary>
        /// hien thi ra datagridview
        /// </summary>
        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connecString))
            {
                dataAdapter = new SqlDataAdapter("SELECT c.typeVocaId AS typeVocaId, c.typeVocaName AS typeVocaName, c.typeVocaDescription AS typeVocaDescription, c.createdDate AS createdDate, c.updatedDate AS updatedDate, c.isActive AS isActive, u.userName AS userName FROM typeVocaTable c JOIN userTable u ON u.userId = c.userId", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                viewData_dgv.DataSource = dataTable;

                viewData_dgv.Columns["typeVocaId"].HeaderText = "ID";
                viewData_dgv.Columns["typeVocaId"].ReadOnly = true;
                viewData_dgv.Columns["typeVocaName"].HeaderText = "Name";
                viewData_dgv.Columns["typeVocaName"].ReadOnly = true;
                viewData_dgv.Columns["typeVocaDescription"].HeaderText = "Description";
                viewData_dgv.Columns["typeVocaDescription"].ReadOnly = true;
                viewData_dgv.Columns["createdDate"].HeaderText = "Created Date";
                viewData_dgv.Columns["createdDate"].ReadOnly = true;
                viewData_dgv.Columns["updatedDate"].HeaderText = "Updated Date";
                viewData_dgv.Columns["updatedDate"].ReadOnly = true;
                viewData_dgv.Columns["isActive"].HeaderText = "Active";
                viewData_dgv.Columns["isActive"].ReadOnly = true;
                viewData_dgv.Columns["userName"].HeaderText = "User";
                viewData_dgv.Columns["userName"].ReadOnly = true;

                if (viewData_dgv.Columns["EditRow"] == null)
                {
                    /* them cot edit delete */
                    DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
                    editButtonColumn.Name = "EditRow";
                    editButtonColumn.Text = "Edit";
                    editButtonColumn.UseColumnTextForButtonValue = true;
                    viewData_dgv.Columns.Add(editButtonColumn);
                    viewData_dgv.Columns["EditRow"].HeaderText = "Edit";
                }

                if (viewData_dgv.Columns["DeleteRow"] == null)
                {
                    DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                    deleteButtonColumn.Name = "DeleteRow";
                    deleteButtonColumn.Text = "Delete";
                    deleteButtonColumn.UseColumnTextForButtonValue = true;
                    viewData_dgv.Columns.Add(deleteButtonColumn);
                    viewData_dgv.Columns["DeleteRow"].HeaderText = "Delete";
                }
            }
        }

        private void regiter_Update_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(name_tb.Text))
            {
                MessageBox.Show("Please enter Type Vocabulary name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connecString))
                {
                    connection.Open();
                    if (isEdit)
                    {
                        // update group
                        update_data(connection, ConnectedData.enData.Data_Update);
                    }
                    else
                    {
                        // insert group
                        SqlCommand command = new SqlCommand("INSERT INTO typeVocaTable ( typeVocaName, typeVocaDescription, createdDate, updatedDate, isActive, userId) VALUES ( @typeVocaName, @typeVocaDescription, @createdDate, @updatedDate, @isActive, @userId)", connection);
                        command.Parameters.AddWithValue("@typeVocaName", name_tb.Text);
                        command.Parameters.AddWithValue("@typeVocaDescription", des_tb.Text);
                        command.Parameters.AddWithValue("@createdDate", DateTime.Now);
                        command.Parameters.AddWithValue("@updatedDate", DateTime.Now);
                        command.Parameters.AddWithValue("@isActive", true);
                        command.Parameters.AddWithValue("@userId", Class.Accounts.UserLogin.UserId);
                        command.ExecuteNonQuery();
                    }
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                    LoadData();
                    clear_btn_Click();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Type Vocabulary Rigiter or Update" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clear_btn_Click();
            }
        }
        /// <summary>
        /// thuc hien update data
        /// boi vi khong cho xoa hoan toan nen chi su dung active hoac deactive
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="enData"></param>
        private void update_data(SqlConnection connection, ConnectedData.enData enData)
        {
            string updateQuery = @"UPDATE typeVocaTable SET updatedDate = @updatedDate, isActive = @isActive, userId = @userId WHERE typeVocaId = @typeVocaId";

            bool thaydoi = false;

            switch (enData)
            {
                case ConnectedData.enData.Data_Insert:
                    break;
                case ConnectedData.enData.Data_Update:
                    enColumn _name = enColumn.Column_Empty;
                    enColumn _des = enColumn.Column_Empty;
                    if (!(levelNameOld == name_tb.Text))
                    { _name = enColumn.Column_Name; thaydoi = true; }
                    if (!(levelDesOld == des_tb.Text))
                    { _des = enColumn.Column_Des; thaydoi = true; }
                    if (thaydoi)
                        updateQuery = $"UPDATE typeVocaTable SET {Column[(int)_name]} {Column[(int)_des]} updatedDate = @updatedDate, userId = @userId WHERE typeVocaId = @typeVocaId";
                    break;
                case ConnectedData.enData.Data_Delete:
                    thaydoi = true;
                    updateQuery = $"UPDATE typeVocaTable SET updatedDate = @updatedDate, isActive = @isActive, userId = @userId WHERE typeVocaId = @typeVocaId";
                    break;
                default:
                    break;
            }

            if (!thaydoi) return;

            if (connection.State != ConnectionState.Closed)
                connection.Close();

            connection.Open();
            SqlCommand command = new SqlCommand(updateQuery, connection);
            command.Parameters.AddWithValue("@updatedDate", DateTime.Now);
            command.Parameters.AddWithValue("@typeVocaId", IDActive);
            command.Parameters.AddWithValue("@userId", Class.Accounts.UserLogin.UserId);

            switch (enData)
            {
                case ConnectedData.enData.Data_Insert:
                    break;
                case ConnectedData.enData.Data_Update:
                    command.Parameters.AddWithValue("@typeVocaName", name_tb.Text);
                    command.Parameters.AddWithValue("@typeVocaDescription", des_tb.Text);
                    break;
                case ConnectedData.enData.Data_Delete:
                    command.Parameters.AddWithValue("@isActive", isActive);
                    break;
                default:
                    break;
            }
            command.ExecuteNonQuery();

            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }

        /// <summary>
        /// xu ly su kien click vao cell edit va delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewData_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0 && !string.IsNullOrEmpty(viewData_dgv.Rows[e.RowIndex].Cells["typeVocaId"].Value.ToString()))
            {
                try
                {
                    DataGridViewRow row = viewData_dgv.Rows[e.RowIndex];
                    using (SqlConnection connection = new SqlConnection(connecString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SELECT typeVocaName, typeVocaDescription, isActive FROM typeVocaTable WHERE typeVocaId = @typeVocaId", connection);
                        IDActive = int.Parse(row.Cells["typeVocaId"].Value.ToString());
                        command.Parameters.AddWithValue("@typeVocaId", IDActive);
                        // xu ly su kien click vao cell edit va delete
                        // khi su kien duoc click thi hien thi thong tin cua status len form

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bool _isActive = Convert.ToBoolean(reader["isActive"].ToString());
                                /* neu active thi moi cho sua */
                                if (e.ColumnIndex == viewData_dgv.Columns["EditRow"].Index)
                                {
                                    if (_isActive)
                                    {
                                        name_tb.Text = levelDesOld = reader["typeVocaName"].ToString();
                                        des_tb.Text = levelDesOld = reader["typeVocaDescription"].ToString();
                                        isEdit = true;
                                        regiter_Update_btn.Text = "Update";
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Type Vocabulary does not exist!\r\n Active = {_isActive.ToString()} ");
                                    }

                                }
                                else if (e.ColumnIndex == viewData_dgv.Columns["DeleteRow"].Index)
                                {
                                    // tien hanh xoa status
                                    DialogResult dialogResult = MessageBox.Show("Do you want to delete this status?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        isActive = (_isActive == true) ? false : true;
                                        update_data(connection, ConnectedData.enData.Data_Delete);
                                        MessageBox.Show("Delete completed successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        LoadData();
                                    }
                                }
                            }
                        }
                        if (connection.State != ConnectionState.Closed)
                            connection.Close();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Type Vocabulary Edit \r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clear_btn_Click();
                }

            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            clear_btn_Click();
        }
        private void clear_btn_Click()
        {
            IDActive = -1;
            name_tb.Text = "";
            des_tb.Text = "";
            isEdit = false;
            isActive = true;
            regiter_Update_btn.Text = "Register";

            levelNameOld = string.Empty;
            levelDesOld = string.Empty;
        }

        #endregion

    }
}
