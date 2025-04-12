using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using static TCV_JapaNinja.Class.Languages;

namespace TCV_JapaNinja.Class
{
    internal class ConnectedData
    {
        #region ConnectedDataSQL

        /* data sql server */
        // lấy đường dẫn ở project, no bin, no debug
        public static string pathProject = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
        public static string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={pathProject}\\databases\\JapaNinja_Database.mdf;Integrated Security=True";
        //public static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\TCV220027\\Desktop\\TCV_JapaNinja\\databases\\JapaNinja_Database.mdf;Integrated Security=True";
        //public static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\\\\192.168.248.1\\tcv_file_share\\TCVF010\\SOFT\\JapaneseSoftware\\databases\\JapaNinja_Database.mdf;Integrated Security=True;Connect Timeout=30";

        /* excel data */
        //public static string pathFolder = @"\\\\192.168.248.1\\tcv_file_share";
        public static string pathFolder = @"\\\\192.168.248.1\\tcv_file_share\\TCVF013\\04_SHARE\\03_LAM\\TCV_JapaNjnja";

        public static int IsActive = 1;
        public static int NotActive = 0;

        public static string passWordNew = "TCV@000000";

        // Lấy đường dẫn file hình ảnh
        public static string pathImageEdit = "Images\\ButtonImages\\compose.png";
        public static string pathImageRead = "Images\\ButtonImages\\eyes.png";
        public static string pathImageDelete = "Images\\ButtonImages\\bin.png";

        public enum enTables
        {
            Table_None,
            Table_Answer,
            Table_Curriculum,
            Table_Grammar,
            Table_Group,
            Table_HistoryGrammar,
            Table_HistoryKanji,
            Table_HistoryTechnical,
            Table_HistoryVoc,
            Table_Kanji,
            Table_Level,
            Table_Role,
            Table_Position,
            Table_Technical,
            Table_TypeVoca,
            Table_UserRole,
            Table_User,
            Table_Vocabulary,
            Table_
        }

        /// <summary>
        /// Tên của table, data
        /// </summary>
        public static string[] tableNames = new string[(int)enTables.Table_] 
        {
            "",//Table_None,
            "answerTable",//Table_Answer,
            "curriculumTable",//Table_Curriculum,
            "grammarTable",//Table_Grammar,
            "groupTable",//Table_Group,
            "historyGrammarTable",//Table_HistoryGrammar,
            "historyKanjiTable",//Table_HistoryKanji,
            "historyTechnicalTable",//Table_HistoryTechnical,
            "historyVocabularyTable",//Table_HistoryVoc,
            "kanjiTable",//Table_Kanji,
            "levelTable",//Table_Level,
            "roleTable",//Table_Role,
            "positionTable",//Table_Position,
            "technicalTable",//Table_Technical,
            "typeVocaTable",//Table_TypeVoca,
            "userRoleTable",//Table_UserRole,
            "userTable",//Table_User,
            "vocabularyTable"//Table_Vocabulary,
        };

        /// <summary>
        /// trang thai su dung
        /// </summary>
        public enum enData
        {
            Data_Insert = 0,
            Data_Update,
            Data_Active,
            Data_Delete,
            Data_View,
            Data_ResetPW,
            Data_Edit,
            Data_Regiter,
            Data_Cancel,
            Data_
        }
        // Kết hợp 3 thứ tiếng
        public static string[,] nameButtonDatas = new string[(int)enData.Data_, (int)enLanguage.Language_] 
        {
            {"insertData", "Insert","0","Thêm" },//Data_Insert = 0,
            { "updateData","Update","1","Sửa" },//Data_Update,
            { "activeData","Active","1","Chọn" },//Data_Active,
            { "deleteData","Delete","3","Xóa" },//Data_Delete,
            { "viewData","View","4","Xem" }, //Data_View,
            { "resetPWData","Reset PassWord","5","Reset Mật khẩu" },//Data_ResetPW,
            { "editData","Edit","6","Chỉnh sửa" },//Data_Edit,
            { "regiterData","Regiter","7","Thêm vào" },//Data_Regiter,
            { "cancelData","Cancel","8","Hủy bỏ" }//Data_Cancel,
        };

        // tao dataset de add table vao dataset
        public static DataSet dataSet;

        /// <summary>
        /// load All Data
        /// </summary>
        public static void LoadDataAllSQL()
        {
            dataSet = new DataSet();

            // su dung using de ket not csdl, va tu dong khi khong can thiet

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Lấy danh sách tên các bảng
                    DataTable schemaTable = connection.GetSchema("Tables");

                    foreach(DataRow row in schemaTable.Rows)
                    {
                        string tableName = row["TABLE_NAME"].ToString();

                        // Tạo sqlDataAdapter cho mỗi bảng
                        SqlDataAdapter dataAdapter = new SqlDataAdapter($"SELECT * FROM {tableName}", connection);

                        // điền dữ liệu vào dataset
                        dataAdapter.Fill(dataSet, tableName);
                    }

                }
                catch (SqlException sqlEx)
                {
                    // Xử lý lỗi liên quan đến SQL
                    MessageBox.Show("Có lỗi xảy ra khi truy vấn cơ sở dữ liệu: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    // Xử lý các lỗi khác
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
                finally
                {
                    // Đảm bảo rằng kết nối được đóng
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        #endregion


        #region ANSWER

        public enum enAnswerCol
        {
            AnswerCol_Id,
            AnswerCol_A,
            AnswerCol_B,
            AnswerCol_C,
            AnswerCol_D,
            AnswerCol_True,
            AnswerCol_Check,
            AnswerCol_CreatedDate,
            AnswerCol_UpdatedDate,
            AnswerCol_UserId,
            AnswerCol_
        }

        public static string[] answerCol = new string[(int)enAnswerCol.AnswerCol_] 
        {
            "answerId",//AnswerCol_Id,
            "answerA",//AnswerCol_A,
            "answerB",//AnswerCol_B,
            "answerC",//AnswerCol_C,
            "answerD",//AnswerCol_D,
            "answerTrue",//AnswerCol_True,
            "answerCheck",//AnswerCol_Check,
            "createdDate",//AnswerCol_CreatedDate,
            "updatedDate",//AnswerCol_UpdatedDate,
            "userId"//AnswerCol_UserId,
        };

        #endregion

        #region CURRICULUM
        public enum enCurriculumCol
        {
            CurriculumCol_Id,
            CurriculumCol_Name,
            CurriculumCol_Description,
            CurriculumCol_CreatedDate,
            CurriculumCol_UpdatedDate,
            CurriculumCol_IsActive,
            CurriculumCol_UserId,
            CurriculumCol_
        }

        public static string[] curriculumCol = new string[(int)enCurriculumCol.CurriculumCol_]
        {
            "curriculumId",//CurriculumCol_Id,
            "name",//CurriculumCol_Name,
            "description",//CurriculumCol_Description,
            "createdDate",//CurriculumCol_CreatedDate,
            "updatedDate",//CurriculumCol_UpdatedDate,
            "isActive",//CurriculumCol_IsActive,
            "userId"//CurriculumCol_UserId,
        };

        #endregion

        #region GRAMMAR

        public enum enGraCol
        {
            GraCol_Id = 0,
            GraCol_LessonNumber,
            GraCol_Structure,
            GraCol_Sample,
            GraCol_Explain,
            GraCol_Example,
            GraCol_Note,
            GraCol_CreatedData,
            GraCol_UpdatedDate,
            GraCol_IsActive,
            GraCol_AnswerId,
            GraCol_LevelId,
            GraCol_UserId,
            GraCol_CurriculumId,
            GraCol_
        }

        public static string[] grammarCol = new string[(int)enGraCol.GraCol_] 
        {
            "grammarId",        //GraCol_Id = 0,
            "lessonNumber",     //GraCol_LessonNumber
            "structure",        // GraCol_Structure
            "sample",           // GraCol_Sample
            "explain",          // GraCol_Explain
            "example",          // GraCol_Example
            "note",             // GraCol_Note
            "createdDate",      // GraCol_CreatedData
            "updatedDate",      // GraCol_UpdatedDate
            "isActive",         // GraCol_IsActive
            "answerId",         // GraCol_AnswerId
            "levelId",          // GraCol_LevelId
            "userId",           // GraCol_UserId
            "curriculumId"      // GraCol_CurriculumId
        };

        #endregion

        #region GROUP

        public enum enGroupCol
        {
            GroupCol_Id,
            GroupCol_Name,
            GroupCol_Description,
            GroupCol_CreatedDate,
            GroupCol_UpdatedDate,
            GroupCol_IsActive,
            GroupCol_
        }

        public static string[] groupCol = new string[(int)enGroupCol.GroupCol_]
        {
            "groupId",//GroupCol_Id,
            "name",//GroupCol_Name,
            "description",//GroupCol_Description,
            "createdDate",//GroupCol_CreatedDate,
            "updatedDate",//GroupCol_UpdatedDate,
            "isActive"//GroupCol_IsActive,
        };

        /// <summary>
        /// tim kiem id group
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool getIdGroup(string text, out int id)
        {
            bool rs = false;
            id = -1;

            DataTable dataTable = dataSet.Tables[tableNames[(int)enTables.Table_Group]];
            DataView dataView = new DataView(dataTable);
            dataView.RowFilter = $"{groupCol[(int)enGroupCol.GroupCol_Name]} = {text}";

            foreach (DataRowView rowView in dataView)
            {
                DataRow row = rowView.Row;
                id = int.Parse(row[(int)enGroupCol.GroupCol_Id].ToString());
                return true;
            }

            return rs;
        }

        #endregion

        #region HISTORY_GRAMMAR

        public enum enHisGrammarCol
        {
            HisGrammarCol_UserId,
            HisGrammarCol_GrammarId,
            HisGrammarCol_Memorize,
            HisGrammarCol_CreatedDate,
            HisGrammarCol_UpdatedDate,
            HisGrammarCol_
        }

        public static string[] hisGrammarCol = new string[(int)enHisGrammarCol.HisGrammarCol_]
        {
            "userId",//HisGrammarCol_UserId,
            "grammarId",//HisGrammarCol_GrammarId,
            "memorize",//HisGrammarCol_Memorize,
            "createdDate",//HisGrammarCol_CreatedDate,
            "updatedDate"//HisGrammarCol_UpdatedDate,
        };

        #endregion

        #region HISTORY_KANJI

        public enum enHisKanjiCol
        {
            HisKanjiCol_UserId,
            HisKanjiCol_KanjiId,
            HisKanjiCol_Memorize,
            HisKanjiCol_CreatedDate,
            HisKanjiCol_UpdatedDate,
            HisKanjiCol_
        }

        public static string[] hisKanjiCol = new string[(int)enHisKanjiCol.HisKanjiCol_]
        {
            "userId",//HisKanjiCol_UserId,
            "kanjiId",//HisKanjiCol_KanjiId,
            "memorize",//HisKanjiCol_Memorize,
            "createdDate",//HisKanjiCol_CreatedDate,
            "updatedDate"//HisKanjiCol_UpdatedDate,
        };

        #endregion

        #region HISTORY_TECHNICAL

        public enum enHisTechCol
        {
            HisTechCol_UserId,
            HisTechCol_TechnicalId,
            HisTechCol_Memorize,
            HisTechCol_CreatedDate,
            HisTechColl_UpdatedDate,
            HisTechCol_
        }

        public static string[] hisTechCol = new string[(int)enHisTechCol.HisTechCol_]
        {
            "userId",//HisTechCol_UserId,
            "technicalId",//HisTechCol_TechnicalId,
            "memorize",//HisTechCol_Memorize,
            "createdDate",//HisTechCol_CreatedDate,
            "updatedDate"//HisTechColl_UpdatedDate,
        };

        #endregion

        #region HISTORY_VOCABULARY

        public enum enHisVocCol
        {
            HisVocCol_UserId,
            HisVocCol_VocabularyId,
            HisVocCol_Memorize,
            HisVocCol_CreatedDate,
            HisVocCol_UpdatedDate,
            HisVocCol_
        }

        public static string[] hisVocCol = new string[(int)enHisVocCol.HisVocCol_]
        {
            "userId",//HisVocCol_UserId,
            "vocabularyId",//HisVocCol_VocabularyId,
            "memorize",//HisVocCol_Memorize,
            "createdDate",//HisVocCol_CreatedDate,
            "updatedDate"//HisVocCol_UpdatedDate,
        };

        #endregion

        #region IMAGES

        public enum enImageCol
        {
            ImageCol_Id,
            ImageCol_Data,
            ImageCol_Type,
            ImageCol_Name,
            ImageCol_CreatedDate,
            ImageCol_UpdatedDate,
            ImageCol_
        }

        public static string[] imagesCol = new string[(int)enImageCol.ImageCol_]
        {
            "imageId",//ImageCol_Id,
            "imageData",//ImageCol_Data,
            "imageType",//ImageCol_Type,
            "imageName",//ImageCol_Name,
            "createdDate",//ImageCol_CreatedDate,
            "updatedDate"//ImageCol_UpdatedDate,
        };

        #endregion



        #region KANJI

        public enum enKanjiCol
        {
            KanjiCol_Id = 0,
            KanjiCol_LessonNumber,
            KanjiCol_Kanji,
            KanjiCol_HanTu,
            KanjiCol_AmOn,
            KanjiCol_AmKun,
            KanjiCol_English,
            KanjiCol_TiengViet,
            KanjiCol_Example,
            KanjiCol_Note,
            KanjiCol_Strokes,
            KanjiCol_CreatedDate,
            KanjiCol_UpdatedDate,
            KanjiCol_IsActive,
            KanjiCol_AnswerId,
            KanjiCol_LevelId,
            KanjiCol_UserId,
            KanjiCol_CurriculumId,
            KanjiCol_
        }

        public static string[] kanjiCol = new string[(int)enKanjiCol.KanjiCol_] 
        {
            "kanjiId",//KanjiCol_Id = 0,
            "lessonNumber",//KanjiCol_LessonNumber,
            "kanji",//KanjiCol_Kanji,
            "hanTu",//KanjiCol_HanTu,
            "amOn",//KanjiCol_AmOn,
            "amKun",//KanjiCol_AmKun,
            "english",//KanjiCol_English,
            "tiengViet",//KanjiCol_TiengViet,
            "example",//KanjiCol_Example,
            "note",//KanjiCol_Note,
            "strokes",//KanjiCol_Strokes,
            "createdDate",//KanjiCol_CreatedDate,
            "updatedDate",//KanjiCol_UpdatedDate,
            "isActive",//KanjiCol_IsActive,
            "answerId",//KanjiCol_AnswerId,
            "levelId",//KanjiCol_LevelId,
            "userId",//KanjiCol_UserId,
            "curriculumId"//KanjiCol_CurriculumId,
        };

        #endregion

        #region LEVEL

        public enum enLevelCol
        {
            LevelCol_Id,
            LevelCol_Name,
            LevelCol_Description,
            LevelCol_CreatedDate,
            LevelCol_UpdatedDate,
            LevelCol_IsActive,
            LevelCol_UserId,
            LevelCol_
        }

        public static string[] levelCol = new string[(int)enLevelCol.LevelCol_]
        {
            "levelId",//LevelCol_Id,
            "name",//LevelCol_Name,
            "description",//LevelCol_Description,
            "createdDate",//LevelCol_CreatedDate,
            "updatedDate",//LevelCol_UpdatedDate,
            "isActive",//LevelCol_IsActive,
            "userId"//LevelCol_UserId,
        };

        #endregion

        #region ROLE

        public enum enRoleCol
        {
            RoleCol_Id,
            RoleCol_Code,
            RoleCol_Name,
            RoleCol_Description,
            RoleCol_Created,
            RoleCol_Read,
            RoleCol_Update,
            RoleCol_Delete,
            RoleCol_CreatedDate,
            RoleCol_UpdatedDate,
            RoleCol_IsActive,
            RoleCol_
        }

        public static string[] roleCol = new string[(int)enRoleCol.RoleCol_]
        {
            "roleId",//RoleCol_Id,
            "code", //RoleCol_Code
            "name",//RoleCol_Name,
            "description",//RoleCol_Description,
            "createdRole",//RoleCol_Created,
            "readRole",//RoleCol_Read,
            "updateRole",//RoleCol_Update,
            "deleteRole",//RoleCol_Delete,
            "createdDate",//RoleCol_CreatedDate,
            "updatedDate",//RoleCol_UpdatedDate,
            "isActive"//RoleCol_IsActive,
        };

        #endregion

        #region POSITION

        public enum enPositionCol
        {
            PositionCol_Id,
            PositionCol_Name,
            PositionCol_Description,
            PositionCol_CreatedDate,
            PositionCol_UpdatedDate,
            PositionCol_IsActive,
            PositionCol_
        }

        public static string[] positionCol = new string[(int)enPositionCol.PositionCol_]
        {
            "positionId",//PositionCol_Id,
            "name",//PositionCol_Name,
            "description",//PositionCol_Description,
            "createdDate",//PositionCol_CreatedDate,
            "updatedDate",//PositionCol_UpdatedDate,
            "isActive"//PositionCol_IsActive,
        };

        #endregion

        #region TECHNICAL

        public enum enTechCol
        {
            TechCol_Id,
            TechCol_Voc,
            TechCol_Hiragana,
            TechCol_English,
            TechCol_TiengViet,
            TechCol_Example,
            TechCol_Note,
            TechCol_CreatedDate,
            TechCol_UpdatedDate,
            TechCol_IsActive,
            TechCol_AnswerId,
            TechCol_LevelId,
            TechCol_UserId,
            TechCol_GroupId,
            TechCol_
        }

        public static string[] techCol = new string[(int)enTechCol.TechCol_]
        {
            "technicalId",//TechCol_Id,
            "vocabulary",//TechCol_Voc,
            "hiragana",//TechCol_Hiragana,
            "english",//TechCol_English,
            "tiengViet",//TechCol_TiengViet,
            "example",//TechCol_Example,
            "note",//TechCol_Note,
            "createdDate",//TechCol_CreatedDate,
            "updatedDate",//TechCol_UpdatedDate,
            "isActive",//TechCol_IsActive,
            "answerId",//TechCol_AnswerId,
            "levelId",//TechCol_LevelId,
            "userId",//TechCol_UserId,
            "groupId",//TechCol_GroupId,
            
        };

        #endregion

        #region TYPE_VOCABULARY

        public enum enTypeVocCol
        {
            TypeVocCol_Id,
            TypeVocCol_Name,
            TypeVocCol_Description,
            TypeVocCol_CreatedDate,
            TypeVocCol_UpdatedDate,
            TypeVocCol_IsActive,
            TypeVocCol_UserId,
            TypeVocCol_
        }

        public static string[] typeVocCol = new string[(int)enTypeVocCol.TypeVocCol_]
        {
            "typeVocaId",//TypeVocCol_Id,
            "name",//TypeVocCol_Name,
            "description",//TypeVocCol_Description,
            "createdDate",//TypeVocCol_CreatedDate,
            "updatedDate",//TypeVocCol_UpdatedDate,
            "isActive",//TypeVocCol_IsActive,
            "userId"//TypeVocCol_UserId,
        };

        #endregion

        #region USER_ROLE

        public enum enUserRoleCol
        {
            UserRoleCol_UserId,
            UserRoleCol_RoleId,
            UserRoleCol_UserIdEdit,
            UserRoleCol_CreatedDate,
            UserRoleCol_
        }

        public static string[] userRoleCol = new string[(int)enUserRoleCol.UserRoleCol_]
        {
            "userId",//UserRoleCol_UserId,
            "roleId",//UserRoleCol_roleId,
            "userIdEdit",//UserRoleCol_UserIdEdit,
            "createdDate"//UserRoleCol_CreatedDate,
        };

        #endregion

        #region USER

        public enum enUserCol
        {
            UserCol_Id,
            UserCol_Image,
            UserCol_EmployeeCode,
            UserCol_Name,
            UserCol_Pasword,
            UserCol_PaswordOld,
            UserCol_Description,
            UserCol_Email,
            UserCol_CreatedDate,
            UserCol_UpdatedDate,
            UserCol_IsActive,
            UserCol_GroupId,
            UserCol_PositionId,
            UserCol_IPAddress,
            UserCol_
        }

        public static string[] userCol = new string[(int)enUserCol.UserCol_]
        {
            "userId",//UserCol_Id,
            "userImage",//UserCol_Image,
            "employeeCode",//UserCol_EmployeeCode,
            "userName",//UserCol_Name,
            "userPassword",//UserCol_Pasword,
            "userPasswordOld",//UserCol_PaswordOld,
            "userDescription",//UserCol_Description,
            "userEmail",//UserCol_Email,
            "createdDate",//UserCol_CreatedDate,
            "updatedDate",//UserCol_UpdatedDate,
            "isActive",//UserCol_IsActive,
            "groupId",//UserCol_GroupId,
            "positionId",//UserCol_PositionId,
            "IPAddress"//UserCol_IPAddress
        };

        #endregion

        #region VOCABULARY

        public enum enVocCol
        {
            VocCol_Id,
            VocCol_LessonNumber,
            VocCol_Vocabulary,
            VocCol_Kanji,
            VocCol_Hiragana,
            VocCol_English,
            VocCol_TiengViet,
            VocCol_Example,
            VocCol_Note,
            VocCol_CreatedDate,
            VocCol_UpdatedDate,
            VocCol_IsActive,
            VocCol_AnswerId,
            VocCol_LevelId,
            VocCol_UserId,
            VocCol_GroupId,
            VocCol_CurriculumId,
            VocCol_TypeVocaId,
            VocCol_
        }
        public static string[] vocCol = new string[(int)enVocCol.VocCol_] 
        {
            "vocabularyId",//VocCol_Id,
            "lessonNumber",//VocCol_LessonNumber
            "Vocabulary",//VocCol_Vocabulary,
            "kanji",//VocCol_Kanji,
            "hiragana",//VocCol_Hiragana,
            "english",//VocCol_English,
            "tiengViet",//VocCol_TiengViet,
            "example",//VocCol_Example,
            "note",//VocCol_Note,
            "createdDate",//VocCol_CreatedDate,
            "updatedDate",//VocCol_UpdatedDate,
            "isActive",//VocCol_IsActive,
            "answerId",//VocCol_AnswerId,
            "levelId",//VocCol_LevelId,
            "userId",//VocCol_UserId,
            "GroupId",//VocCol_GroupId,
            "curriculumId",//VocCol_CurriculumId,
            "typeVocaId"//VocCol_TypeVocaId,
        };

        #endregion






    }
}
