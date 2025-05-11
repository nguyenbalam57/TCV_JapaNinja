using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TCV_JapaNinja.Class;

namespace TCV_JapaNinja.Forms.Admin_Management.InputDatabase
{
    public partial class FormInputDatabase : Form
    {
        private SqlDataAdapter dataAdapterVoc = null;
        private SqlDataAdapter dataAdapterKanji = null;
        private SqlDataAdapter dataAdapterTechnical = null;
        private SqlDataAdapter dataAdapterGrammar = null;

        private enum enInputData
        {
            InputData_Voc,
            InputData_Kanji,
            InputData_Technical,
            InputData_Grammar,
            InputData_
        }

        public FormInputDatabase()
        {
            InitializeComponent();

            //InitializeDatabaseVoc();
            //InitializeDatabaseGrammar();
            //InitializeDatabaseKanji();
            //InitializeDatabaseTechnical();

            //loadData();
        }

        //private void loadData()
        //{

        //    LoadDataVoc();
        //    LoadDataKanji();
        //    LoadDataTechnical();
        //    LoadDataGrammar();
        //}

        //private void grammar_btn_Click(object sender, EventArgs e)
        //{
        //    if(getData(grammar_tb, enInputData.InputData_Grammar)) LoadDataGrammar();
        //}

        //private void vocabulary_btn_Click(object sender, EventArgs e)
        //{
        //    if(getData(vocabulary_tb, enInputData.InputData_Voc)) LoadDataVoc();
        //}

        //private void kanji_btn_Click(object sender, EventArgs e)
        //{
        //    if(getData(kanji_tb, enInputData.InputData_Kanji)) LoadDataKanji();
        //}

        //private void technical_btn_Click(object sender, EventArgs e)
        //{
        //    if(getData(technical_tb, enInputData.InputData_Technical)) LoadDataTechnical();
        //}

        //private bool getData(TextBox textBox, enInputData inputData)
        //{
        //    if (textBox == null) return false;
        //    try
        //    {
        //        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        //        {
        //            openFileDialog.InitialDirectory = ConnectedData.pathFolder;
        //            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx|All Files|*.*";
        //            openFileDialog.FilterIndex = 1;
        //            openFileDialog.RestoreDirectory = true;

        //            if (openFileDialog.ShowDialog() == DialogResult.OK)
        //            {
        //                string filePath = openFileDialog.FileName;
        //                textBox.Text = filePath;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Path File.\r\n" + ex.Message);
        //    }

        //    if (!string.IsNullOrWhiteSpace(textBox.Text))
        //    {
        //        vdAddDatasourceToDatagridview(textBox.Text, inputData);
        //        return true;
        //    }
        //    return false;
        //}

        /// <summary>
        /// import data to datagridview
        /// </summary>
        /// <param name="filePath"></param>
        //private void vdAddDatasourceToDatagridview( string filePath, enInputData inputData)
        //{
        //    try
        //    {
        //        string nameFile = Path.GetFileNameWithoutExtension(filePath);
        //        string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties=\"Excel 12.0 Xml;HDR=YES\";";

        //        using (OleDbConnection connection = new OleDbConnection(connectionString))
        //        {
        //            OleDbDataAdapter dataAdapter = new OleDbDataAdapter($"SELECT * FROM [{nameFile}$]", connection);
        //            DataTable dataTable = new DataTable();
        //            dataAdapter.Fill(dataTable);

        //            if (dataTable.Rows.Count > 0) 
        //            {
        //                for (int i = 0; i < dataTable.Rows.Count; i++)
        //                {
        //                    DataRow row = dataTable.Rows[i];
        //                    if (nameFile.Contains("GRAMMAR") && inputData == enInputData.InputData_Grammar)
        //                    {
        //                        AddDataRow_GRAMMAR(row);
        //                    }
        //                    else if(nameFile.Contains("TECHNICALVOC") && inputData == enInputData.InputData_Technical)
        //                    {
        //                        AddDataRow_TECHNICALVOC(row);
        //                    }
        //                    else if (nameFile.Contains("KANJI") && inputData == enInputData.InputData_Kanji)
        //                    {
        //                        AddDataRow_KANJI(row);
        //                    }
        //                    else if (nameFile.Contains("VOCABULARY") && inputData == enInputData.InputData_Voc)
        //                    {
        //                        AddDataRow_VOCABULARY(row);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Import To Data File.\r\n" + ex.Message);
        //    }
        //}

        //#region ADD_DATA_Vocabulary

        //private void InitializeDatabaseVoc()
        //{
        //    string queryVocabularyTable = $"SELECT * FROM {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Vocabulary]}";
        //    // Initialize The DataAdapter
        //    dataAdapterVoc = new SqlDataAdapter(queryVocabularyTable, Class.ConnectedData.connectionString);

        //    // set up the command builder for the Dataadapter
        //    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapterVoc);

        //}

        //private void LoadDataVoc()
        //{
        //    string nameTable = ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Vocabulary];
        //    // Fill the DataSet With data from the database
        //    dataAdapterVoc.Fill(ConnectedData.dataSet, nameTable);

        //    // Bind the DataGridView to the DataSet
        //    dataVocabulary_dgv.DataSource = ConnectedData.dataSet.Tables[nameTable];
        //}

        //private void AddDataRow_VOCABULARY(DataRow row)
        //{
        //    string nameTable = ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Vocabulary];

        //    if (string.IsNullOrWhiteSpace(row[4].ToString()) || checkVocabularyData(row)) return;
        //    // create a new row 
        //    DataRow newRow = ConnectedData.dataSet.Tables[nameTable].NewRow();
        //    // so bai
        //    newRow[ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_LessonNumber]] = row[2].ToString();
        //    // tu vung
        //    newRow[ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_Vocabulary]] = row[4].ToString();
        //    // han tu
        //    newRow[ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_Kanji]] = row[5].ToString();
        //    // hiragana
        //    newRow[ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_Hiragana]] = row[6].ToString();
        //    // tieng anh
        //    newRow[ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_English]] = row[7].ToString();
        //    // tieng viet
        //    newRow[ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_TiengViet]] = row[8].ToString();
        //    // vi du
        //    newRow[ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_Example]] = row[9].ToString();
        //    // ghi chu
        //    newRow[ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_Note]] = row[10].ToString();

        //    // phan tam su dung data de lay id level
        //    if (int.TryParse(row[1].ToString(), out int level))
        //        newRow[ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_Id]] = level;

        //    newRow[ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_CreatedDate]] = DateTime.Now;
        //    newRow[ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_UpdatedDate]] = DateTime.Now;
        //    newRow[ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_IsActive]] = true;
        //    newRow[ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_UserId]] = Class.Accounts.UserLogin.Id;

        //    // add the row to the datatable
        //    ConnectedData.dataSet.Tables[nameTable].Rows.Add(newRow);

        //    // update the dayabase
        //    dataAdapterVoc.Update(ConnectedData.dataSet, nameTable);
        //}
        ///// <summary>
        ///// kểm tra data đã tồn tại hay chưa
        ///// </summary>
        ///// <param name="row"></param>
        ///// <returns></returns>
        //private bool checkVocabularyData(DataRow row)
        //{
        //    bool rs = false;
        //    SqlConnection connection = new SqlConnection(ConnectedData.connectionString);
        //    // Check for existence in the database
        //    try
        //    {
        //        connection.Open();
        //        string query = $"SELECT COUNT(*) FROM {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Vocabulary]} WHERE {ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_LessonNumber]} = @{ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_LessonNumber]} AND {ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_Vocabulary]} = @{ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_Vocabulary]} AND {ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_LevelId]} = @{ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_LevelId]}";
        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue($"@{ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_LessonNumber]}", row[2].ToString());
        //        command.Parameters.AddWithValue($"@{ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_Vocabulary]}", row[4].ToString());
        //        command.Parameters.AddWithValue($"@{ConnectedData.vocCol[(int)ConnectedData.enVocCol.VocCol_LevelId]}", row[1].ToString());

        //        int count = (int)command.ExecuteScalar();

        //        if (count > 0)
        //        {
        //            rs = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("An error occurred: " + ex.Message);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return rs;
        //}

        //#endregion

        //#region ADD_DATA_GRAMMAR
        //private void InitializeDatabaseGrammar()
        //{
        //    string queryVocabularyTable = $"SELECT * FROM {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Grammar]}";
        //    // Initialize The DataAdapter
        //    dataAdapterGrammar = new SqlDataAdapter(queryVocabularyTable, ConnectedData.connectionString);

        //    // set up the command builder for the Dataadapter
        //    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapterGrammar);

        //}

        //private void LoadDataGrammar()
        //{
        //    string nameGra = ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Grammar];
        //    // Fill the DataSet With data from the database
        //    dataAdapterGrammar.Fill(ConnectedData.dataSet, nameGra);

        //    // Bind the DataGridView to the DataSet
        //    dataGrammar_dgv.DataSource = ConnectedData.dataSet.Tables[nameGra];
        //}

        //private void AddDataRow_GRAMMAR(DataRow row)
        //{
        //    string nameGra = ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Grammar];

        //    if (string.IsNullOrWhiteSpace(row[3].ToString()) || checkGrammarData(row)) return;
        //    // create a new row 
        //    DataRow newRow = ConnectedData.dataSet.Tables[nameGra].NewRow();
        //    // so bai
        //    newRow[ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_LessonNumber]] = row[2].ToString();
        //    // cau truc
        //    newRow[ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_Structure]] = row[3].ToString();
        //    // mau ngu phap
        //    newRow[ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_Sample]] = row[4].ToString();
        //    // giai thich
        //    newRow[ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_Explain]] = row[5].ToString();
        //    // vi du
        //    newRow[ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_Example]] = row[6].ToString();
        //    // ghi chu
        //    newRow[ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_Note]] = row[7].ToString();

        //    // phan tam su dung data de lay id level
        //    if (int.TryParse(row[1].ToString(), out int level))
        //        newRow[ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_LevelId]] = level;

        //    newRow[ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_CreatedData]] = DateTime.Now;
        //    newRow[ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_UpdatedDate]] = DateTime.Now;
        //    newRow[ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_IsActive]] = true;
        //    newRow[ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_UserId]] = Class.Accounts.UserLogin.UserId;

        //    // add the row to the datatable
        //    ConnectedData.dataSet.Tables[nameGra].Rows.Add(newRow);

        //    // update the dayabase
        //    dataAdapterGrammar.Update(ConnectedData.dataSet, nameGra);
        //}

        //private bool checkGrammarData(DataRow row)
        //{
        //    bool rs = false;
        //    SqlConnection connection = new SqlConnection(ConnectedData.connectionString);
        //    // Check for existence in the database
        //    try
        //    {
        //        connection.Open();
        //        string query = $"SELECT COUNT(*) FROM {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Grammar]} WHERE {ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_LessonNumber]} = @{ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_LessonNumber]} AND {ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_Structure]} = @{ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_Structure]} AND {ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_LevelId]} = @{ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_LevelId]}";
        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue($"@{ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_LessonNumber]}", row[2].ToString());
        //        command.Parameters.AddWithValue($"@{ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_Structure]}", row[3].ToString());
        //        command.Parameters.AddWithValue($"@{ConnectedData.grammarCol[(int)ConnectedData.enGraCol.GraCol_LevelId]}", row[1].ToString());

        //        int count = (int)command.ExecuteScalar();

        //        if (count > 0)
        //        {
        //            rs = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("An error occurred: " + ex.Message);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return rs;
        //}

        //#endregion

        //#region ADD_DATA_KANJI
        //private void InitializeDatabaseKanji()
        //{
        //    string queryVocabularyTable = $"SELECT * FROM {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Kanji]}";
        //    // Initialize The DataAdapter
        //    dataAdapterKanji = new SqlDataAdapter(queryVocabularyTable, ConnectedData.connectionString);

        //    // set up the command builder for the Dataadapter
        //    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapterKanji);

        //}

        //private void LoadDataKanji()
        //{
        //    string nameKanji = ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Kanji];
        //    // Fill the DataSet With data from the database
        //    dataAdapterKanji.Fill(ConnectedData.dataSet, nameKanji);

        //    // Bind the DataGridView to the DataSet
        //    dataKanji_dgv.DataSource = ConnectedData.dataSet.Tables[nameKanji];
        //}

        //private void AddDataRow_KANJI(DataRow row)
        //{
        //    string nameKanji = ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Kanji];

        //    if (string.IsNullOrWhiteSpace(row[3].ToString()) || checkKanjiData(row)) return;
        //    // create a new row 
        //    DataRow newRow = ConnectedData.dataSet.Tables[nameKanji].NewRow();
        //    // so bai
        //    newRow[ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_LessonNumber]] = row[2].ToString();
        //    // tu han
        //    newRow[ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_Kanji]] = row[3].ToString();
        //    // han tu
        //    newRow[ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_HanTu]] = row[4].ToString();
        //    // am on
        //    newRow[ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_AmOn]] = row[5].ToString();
        //    // am kun
        //    newRow[ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_AmKun]] = row[6].ToString();
        //    // tieng anh
        //    newRow[ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_English]] = row[7].ToString();
        //    // tieng viet
        //    newRow[ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_TiengViet]] = row[8].ToString();
        //    // vi du
        //    newRow[ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_Example]] = row[9].ToString();
        //    // ghi chu
        //    newRow[ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_Note]] = row[10].ToString();
        //    // so net
        //    if (int.TryParse(row[11].ToString(), out int strokes))
        //        newRow[ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_Strokes]] = strokes;

        //    // phan tam su dung data de lay id level
        //    if (int.TryParse(row[1].ToString(), out int level))
        //        newRow[ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_LevelId]] = level;

        //    newRow[ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_CreatedDate]] = DateTime.Now;
        //    newRow[ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_UpdatedDate]] = DateTime.Now;
        //    newRow[ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_IsActive]] = true;
        //    newRow[ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_UserId]] = Class.Accounts.UserLogin.UserId;

        //    // add the row to the datatable
        //    ConnectedData.dataSet.Tables[nameKanji].Rows.Add(newRow);

        //    // update the dayabase
        //    dataAdapterKanji.Update(ConnectedData.dataSet, nameKanji);
        //}

        //private bool checkKanjiData(DataRow row)
        //{
        //    bool rs = false;
        //    SqlConnection connection = new SqlConnection(ConnectedData.connectionString);
        //    // Check for existence in the database
        //    try
        //    {
        //        connection.Open();
        //        string query = $"SELECT COUNT(*) FROM {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Kanji]} WHERE {ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_LessonNumber]} = @{ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_LessonNumber]} AND {ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_Kanji]} = @{ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_Kanji]} AND {ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_LevelId]} = @{ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_LevelId]}";
        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue($"@{ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_LessonNumber]}", row[2].ToString());
        //        command.Parameters.AddWithValue($"@{ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_Kanji]}", row[3].ToString());
        //        command.Parameters.AddWithValue($"@{ConnectedData.kanjiCol[(int)ConnectedData.enKanjiCol.KanjiCol_LevelId]}", row[1].ToString());

        //        int count = (int)command.ExecuteScalar();

        //        if (count > 0)
        //        {
        //            rs = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("An error occurred: " + ex.Message);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return rs;
        //}

        //#endregion

        //#region ADD_DATA_TECHNICAL
        //private void InitializeDatabaseTechnical()
        //{
        //    string queryVocabularyTable = $"SELECT * FROM {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Technical]}";
        //    // Initialize The DataAdapter
        //    dataAdapterTechnical = new SqlDataAdapter(queryVocabularyTable, ConnectedData.connectionString);

        //    // set up the command builder for the Dataadapter
        //    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapterTechnical);

        //}

        //private void LoadDataTechnical()
        //{
        //    string nameTech = ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Technical];
        //    // Fill the DataSet With data from the database
        //    dataAdapterTechnical.Fill(ConnectedData.dataSet, nameTech);

        //    // Bind the DataGridView to the DataSet
        //    dataTechnical_dgv.DataSource = ConnectedData.dataSet.Tables[nameTech];
        //}

        //private void AddDataRow_TECHNICALVOC(DataRow row)
        //{
        //    string nameTech = ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Technical];

        //    if (string.IsNullOrWhiteSpace(row[3].ToString()) || checkTechnicalData(row)) return;
        //    // create a new row 
        //    DataRow newRow = ConnectedData.dataSet.Tables[nameTech].NewRow();
        //    // tu vung
        //    newRow[ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_Voc]] = row[3].ToString();
        //    // Hiragana
        //    newRow[ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_Hiragana]] = row[4].ToString();
        //    // English
        //    newRow[ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_English]] = row[5].ToString();
        //    // Tiếng việt
        //    newRow[ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_TiengViet]] = row[6].ToString();
        //    // Ví dụ
        //    newRow[ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_Example]] = row[7].ToString();
        //    // Note
        //    newRow[ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_Note]] = row[8].ToString();

        //    // lấy id level
        //    if (int.TryParse(row[1].ToString(), out int level))
        //        newRow[ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_LevelId]] = level;
        //    // Id group
        //    if(ConnectedData.getIdGroup(row[2].ToString(), out int groupId))
        //        newRow[ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_GroupId]] = groupId;

        //    // Xét createdDate, updatedDate, Active, UserId
        //    newRow[ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_CreatedDate]] = DateTime.Now;
        //    newRow[ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_UpdatedDate]] = DateTime.Now;
        //    newRow[ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_IsActive]] = true;
        //    newRow[ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_UserId]] = Class.Accounts.UserLogin.UserId;

        //    // add the row to the datatable
        //    ConnectedData.dataSet.Tables[nameTech].Rows.Add(newRow);

        //    // update the dayabase
        //    dataAdapterTechnical.Update(ConnectedData.dataSet, nameTech);
        //}
        ///// <summary>
        ///// kiểm tra đã tồn tại từ vựng chuyên ngành chưa
        ///// dùng phương thức tìm kiếm từ vựwng, level, group
        ///// </summary>
        ///// <param name="row"></param>
        ///// <returns></returns>
        //private bool checkTechnicalData(DataRow row)
        //{
        //    bool rs = false;
        //    SqlConnection connection = new SqlConnection(ConnectedData.connectionString);
        //    // Check for existence in the database
        //    try
        //    {
        //        connection.Open();
        //        string query = $"SELECT COUNT(*) FROM {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_Technical]} WHERE {ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_Voc]} = @{ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_Voc]} AND {ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_LevelId]} = @{ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_LevelId]} AND {ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_GroupId]} = @{ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_GroupId]}";
        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue($"@{ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_Voc]}", row[3].ToString());
        //        command.Parameters.AddWithValue($"@{ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_LevelId]}", row[1].ToString());
        //        command.Parameters.AddWithValue($"@{ConnectedData.techCol[(int)ConnectedData.enTechCol.TechCol_GroupId]}", (ConnectedData.getIdGroup(row[2].ToString(), out int groupId)) ? groupId.ToString() : string.Empty);

        //        int count = (int)command.ExecuteScalar();

        //        if (count > 0)
        //        {
        //            rs = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("An error occurred: " + ex.Message);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return rs;
        //}


        //#endregion


    }
}
