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
    public partial class FormLevel : Form
    {
        public FormLevel()
        {
            InitializeComponent();
        }

        private string connecString = ConnectedData.connectionString;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private int levelIDActive = -1;
        private bool isLevelEdit = false;
        private bool isLevelActive = true;

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
        private string[] levelColumn = new string[(int)enColumn.Column_] { 
            "levelName = @levelName,",
            "levelDescription = @levelDescription,",
            "isActive = @isActive,",
            ""
        };

        private void FormGroup_Load(object sender, EventArgs e)
        {
            clearLevel_btn_Click();
            LoadData();
        }

        /// <summary>
        /// hien thi ra datagridview
        /// </summary>
        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connecString))
            {
                dataAdapter = new SqlDataAdapter("SELECT l.levelId AS levelId, l.levelName AS levelName, l.levelDescription AS levelDescription, l.createdDate AS createdDate, l.updatedDate AS updatedDate, l.isActive AS isActive, u.userName AS userName FROM levelTable l JOIN userTable u ON u.userId = l.userId", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                levelView_dgv.DataSource = dataTable;

                levelView_dgv.Columns["levelId"].HeaderText = "ID";
                levelView_dgv.Columns["levelId"].ReadOnly = true;
                levelView_dgv.Columns["levelName"].HeaderText = "Name";
                levelView_dgv.Columns["levelName"].ReadOnly = true;
                levelView_dgv.Columns["levelDescription"].HeaderText = "Description";
                levelView_dgv.Columns["levelDescription"].ReadOnly = true;
                levelView_dgv.Columns["createdDate"].HeaderText = "Created Date";
                levelView_dgv.Columns["createdDate"].ReadOnly = true;
                levelView_dgv.Columns["updatedDate"].HeaderText = "Updated Date";
                levelView_dgv.Columns["updatedDate"].ReadOnly = true;
                levelView_dgv.Columns["isActive"].HeaderText = "Active";
                levelView_dgv.Columns["isActive"].ReadOnly = true;
                levelView_dgv.Columns["userName"].HeaderText = "User";
                levelView_dgv.Columns["userName"].ReadOnly = true;

                if (levelView_dgv.Columns["levelEdit"] == null)
                {
                    /* them cot edit delete */
                    DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
                    editButtonColumn.Name = "levelEdit";
                    editButtonColumn.Text = "Edit";
                    editButtonColumn.UseColumnTextForButtonValue = true;
                    levelView_dgv.Columns.Add(editButtonColumn);
                    levelView_dgv.Columns["levelEdit"].HeaderText = "Edit";
                }

                if (levelView_dgv.Columns["levelDelete"] == null)
                {
                    DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                    deleteButtonColumn.Name = "levelDelete";
                    deleteButtonColumn.Text = "Delete";
                    deleteButtonColumn.UseColumnTextForButtonValue = true;
                    levelView_dgv.Columns.Add(deleteButtonColumn);
                    levelView_dgv.Columns["levelDelete"].HeaderText = "Delete";
                }
            }
        }

        private void regiter_Update_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(levelName_tb.Text))
            {
                MessageBox.Show("Please enter level name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connecString))
                {
                    connection.Open();
                    if (isLevelEdit)
                    {
                        // update group
                        updateLevel_data(connection, ConnectedData.enData.Data_Update);
                    }
                    else
                    {
                        // insert group
                        SqlCommand command = new SqlCommand("INSERT INTO levelTable ( levelName, levelDescription, createdDate, updatedDate, isActive, userId) VALUES ( @levelName, @levelDescription, @createdDate, @updatedDate, @isActive, @userId)", connection);
                        command.Parameters.AddWithValue("@levelName", levelName_tb.Text);
                        command.Parameters.AddWithValue("@levelDescription", levelDes_tb.Text);
                        command.Parameters.AddWithValue("@createdDate", DateTime.Now);
                        command.Parameters.AddWithValue("@updatedDate", DateTime.Now);
                        command.Parameters.AddWithValue("@isActive", true);
                        command.Parameters.AddWithValue("@userId", Class.Accounts.UserLogin.UserId);
                        command.ExecuteNonQuery();
                    }
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                    LoadData();
                    clearLevel_btn_Click();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Level Rigiter or Update" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearLevel_btn_Click();
            }
        }
        /// <summary>
        /// thuc hien update data
        /// boi vi khong cho xoa hoan toan nen chi su dung active hoac deactive
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="enData"></param>
        private void updateLevel_data(SqlConnection connection, ConnectedData.enData enData)
        {
            string updateQuery = @"UPDATE levelTable SET updatedDate = @updatedDate, isActive = @isActive, userId = @userId WHERE levelId = @levelId";

            bool thaydoi = false;

            switch (enData)
            {
                case ConnectedData.enData.Data_Insert:
                    break;
                case ConnectedData.enData.Data_Update:
                    enColumn _name = enColumn.Column_Empty;
                    enColumn _des = enColumn.Column_Empty;
                    if (!(levelNameOld == levelName_tb.Text))
                        { _name = enColumn.Column_Name; thaydoi = true; }
                    if (!(levelDesOld == levelDes_tb.Text))
                        { _des = enColumn.Column_Des; thaydoi = true; }
                    if(thaydoi)
                        updateQuery = $"UPDATE levelTable SET {levelColumn[(int)_name] } {levelColumn[(int)_des]} updatedDate = @updatedDate, userId = @userId WHERE levelId = @levelId";
                    break;
                case ConnectedData.enData.Data_Delete:
                    thaydoi = true;
                    updateQuery = $"UPDATE levelTable SET updatedDate = @updatedDate, isActive = @isActive, userId = @userId WHERE levelId = @levelId";
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
            command.Parameters.AddWithValue("@levelId", levelIDActive);
            command.Parameters.AddWithValue("@userId", Class.Accounts.UserLogin.UserId);

            switch (enData)
            {
                case ConnectedData.enData.Data_Insert:
                    break;
                case ConnectedData.enData.Data_Update:
                    command.Parameters.AddWithValue("@levelName", levelName_tb.Text);
                    command.Parameters.AddWithValue("@levelDescription", levelDes_tb.Text);
                    break;
                case ConnectedData.enData.Data_Delete:
                    command.Parameters.AddWithValue("@isActive", isLevelActive);
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
        private void levelView_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            
            if (e.RowIndex >= 0 && !string.IsNullOrEmpty(levelView_dgv.Rows[e.RowIndex].Cells["levelId"].Value.ToString()))
            {
                try
                {
                    DataGridViewRow row = levelView_dgv.Rows[e.RowIndex];
                    using (SqlConnection connection = new SqlConnection(connecString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SELECT levelName, levelDescription, isActive FROM levelTable WHERE levelId = @levelId", connection);
                        levelIDActive = int.Parse(row.Cells["levelId"].Value.ToString());
                        command.Parameters.AddWithValue("@levelId", levelIDActive);
                        // xu ly su kien click vao cell edit va delete
                        // khi su kien duoc click thi hien thi thong tin cua status len form

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bool _isActive = Convert.ToBoolean(reader["isActive"].ToString());
                                /* neu active thi moi cho sua */
                                if (e.ColumnIndex == levelView_dgv.Columns["levelEdit"].Index)
                                {
                                    if(_isActive)
                                    {
                                        levelName_tb.Text = levelDesOld = reader["levelName"].ToString();
                                        levelDes_tb.Text = levelDesOld = reader["levelDescription"].ToString();
                                        isLevelEdit = true;
                                        regiter_Update_btn.Text = "Update";
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Level does not exist!\r\n Active = {_isActive.ToString()} ");
                                    }
                                    
                                }
                                else if (e.ColumnIndex == levelView_dgv.Columns["levelDelete"].Index)
                                {
                                    // tien hanh xoa status
                                    DialogResult dialogResult = MessageBox.Show("Do you want to delete this status?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        isLevelActive = (_isActive == true) ? false : true;
                                        updateLevel_data(connection, ConnectedData.enData.Data_Delete);
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
                    MessageBox.Show("Level Edit \r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clearLevel_btn_Click();
                }

            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            clearLevel_btn_Click();
        }
        private void clearLevel_btn_Click()
        {
            levelIDActive = -1;
            levelName_tb.Text = "";
            levelDes_tb.Text = "";
            isLevelEdit = false;
            isLevelActive = true;
            regiter_Update_btn.Text = "Register";

            levelNameOld = string.Empty;
            levelDesOld = string.Empty;
    }

    }
}
