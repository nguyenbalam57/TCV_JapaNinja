using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TCV_JapaNinja.Converters.Customs;
using TCV_JapaNinja.Models.DatabaseCustoms;

namespace TCV_JapaNinja.Class.ManagerData
{
    internal class DataLoader
    {
        private readonly string connectionString;

        // lưu dữ liệu các bảng đã load
        private readonly Dictionary<ConnectedData.enTables, DataTable> loadedTables;

        // Lưu danh sách đã chuyển đổi từ DataTable sang list data
        private readonly Dictionary<ConnectedData.enTables, object> loadedDataList;

        public DataLoader(string connectionString)
        {
            this.connectionString = connectionString;
            loadedTables = new Dictionary<ConnectedData.enTables, DataTable>();
            loadedDataList = new Dictionary<ConnectedData.enTables, object>();
        }

        #region DATATABLE Loader

        /// <summary>
        /// Lấy dataTable đã load nếu có, null nếu chưa load
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DataTable GetLoadedTable(ConnectedData.enTables table)
        {
            if (loadedTables.TryGetValue(table, out DataTable dt))
            {
                return dt;
            }

            return null;
        }

        public DataTable LoadAnswers()
        {
            return LoadTableWithCache(ConnectedData.enTables.Table_Answer);
        }
        public DataTable LoadCurriculums()
        {
            return LoadTableWithCache(ConnectedData.enTables.Table_Curriculum);
        }
        public DataTable LoadGrammars()
        {
            return LoadTableWithCache(ConnectedData.enTables.Table_Grammar);
        }
        public DataTable LoadGroups()
        {
            return LoadTableWithCache(ConnectedData.enTables.Table_Group);
        }
        public DataTable LoadHistoryGKTV()
        {
            return LoadTableWithCache(ConnectedData.enTables.Table_HistoryGKTV);
        }
        public DataTable LoadImages()
        {
            return LoadTableWithCache(ConnectedData.enTables.Table_Images);
        }
        public DataTable LoadKanjis()
        {
            return LoadTableWithCache(ConnectedData.enTables.Table_Kanji);
        }
        public DataTable LoadLevels()
        {
            return LoadTableWithCache(ConnectedData.enTables.Table_Level);
        }
        public DataTable LoadParentChilds()
        {
            return LoadTableWithCache(ConnectedData.enTables.Table_ParentChild);
        }
        public DataTable LoadPositions()
        {
            return LoadTableWithCache(ConnectedData.enTables.Table_Position);
        }
        public DataTable LoadRoles()
        {
            return LoadTableWithCache(ConnectedData.enTables.Table_Role);
        }
        public DataTable LoadTechnicals()
        {
            return LoadTableWithCache(ConnectedData.enTables.Table_Technical);
        }
        public DataTable LoadTypeVocas()
        {
            return LoadTableWithCache(ConnectedData.enTables.Table_TypeVoca);
        }
        public DataTable LoadUserRoles()
        {
            return LoadTableWithCache(ConnectedData.enTables.Table_UserRole);
        }
        public DataTable LoadUsers()
        {
            return LoadTableWithCache(ConnectedData.enTables.Table_User);
        }
        public DataTable LoadVocabularys()
        {
            return LoadTableWithCache(ConnectedData.enTables.Table_Vocabulary);
        }

        /// <summary>
        /// Cập nhật lại dữ liệu cho tất cả các bảng đã load
        /// </summary>
        public void RefreshLoadedTable()
        {
            foreach(var tableName in new List<ConnectedData.enTables>(loadedTables.Keys))
            {
                DataTable dt = LoadDataFromDb(tableName);
                if (dt != null)
                {
                    loadedTables[tableName] = dt;
                }
            }
        }
        /// <summary>
        /// Load dữ liệu từ cơ sở dữ liệu vào DataTable và lưu vào cache
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private DataTable LoadTableWithCache(ConnectedData.enTables table) 
        {
            if(loadedTables.ContainsKey(table))
            {
                return loadedTables[table];
            }
            else
            {
                DataTable dt = LoadDataFromDb(table);
                if(dt != null)
                {
                    loadedTables[table] = dt;
                }
                return dt;
            }
        }
        /// <summary>
        /// Load dữ liệu từ cơ sở dữ liệu vào DataTable
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private DataTable LoadDataFromDb(ConnectedData.enTables table)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter($"SELECT * FROM {ConnectedData.tableNames[(int)table]}", connection);
                    dataAdapter.Fill(dataTable);
                }
                catch (SqlException ex)
                {
                    // Xử lý lỗi nếu cần
                    MessageBox.Show("Có lỗi xảy ra khi truy vấn cơ sở dữ liệu: " + ex.Message);
                }
                catch(Exception ex)
                {
                    // Xử lý lỗi nếu cần
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
            return dataTable;
        }

        #endregion

        #region List Data Loader
        /// <summary>
        /// Lấy danh sách đã load từ cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<T> GetLoadedDataList<T>(ConnectedData.enTables table) where T : class
        {
            if (loadedDataList.TryGetValue(table, out object listObj))
            {
                return listObj as List<T>;
            }
            return null;
        }

        public List<CustomAnswer> LoadAnswersList()
        {
            return LoadDataListWithCache<CustomAnswer>(ConnectedData.enTables.Table_Answer);
        }
        public List<CustomCurriculum> LoadCurriculumsList()
        {
            return LoadDataListWithCache<CustomCurriculum>(ConnectedData.enTables.Table_Curriculum);
        }
        public List<CustomGrammar> LoadGrammarsList()
        {
            return LoadDataListWithCache<CustomGrammar>(ConnectedData.enTables.Table_Grammar);
        }
        public List<CustomGroup> LoadGroupsList()
        {
            return LoadDataListWithCache<CustomGroup>(ConnectedData.enTables.Table_Group);
        }
        public List<CustomHistoryGKTV> LoadHistoryGKTVList()
        {
            return LoadDataListWithCache<CustomHistoryGKTV>(ConnectedData.enTables.Table_HistoryGKTV);
        }
        public List<CustomImage> LoadImagesList()
        {
            return LoadDataListWithCache<CustomImage>(ConnectedData.enTables.Table_Images);
        }
        public List<CustomKanji> LoadKanjisList()
        {
            return LoadDataListWithCache<CustomKanji>(ConnectedData.enTables.Table_Kanji);
        }
        public List<CustomLevel> LoadLevelsList()
        {
            return LoadDataListWithCache<CustomLevel>(ConnectedData.enTables.Table_Level);
        }
        public List<CustomParentChild> LoadParentChildsList()
        {
            return LoadDataListWithCache<CustomParentChild>(ConnectedData.enTables.Table_ParentChild);
        }
        public List<CustomPosition> LoadPositionsList()
        {
            return LoadDataListWithCache<CustomPosition>(ConnectedData.enTables.Table_Position);
        }
        public List<CustomRole> LoadRolesList()
        {
            return LoadDataListWithCache<CustomRole>(ConnectedData.enTables.Table_Role);
        }
        public List<CustomTechnical> LoadTechnicalsList()
        {
            return LoadDataListWithCache<CustomTechnical>(ConnectedData.enTables.Table_Technical);
        }
        public List<CustomTypeVoca> LoadTypeVocasList()
        {
            return LoadDataListWithCache<CustomTypeVoca>(ConnectedData.enTables.Table_TypeVoca);
        }
        public List<CustomUser> LoadUsersList()
        {
            return LoadDataListWithCache<CustomUser>(ConnectedData.enTables.Table_User);
        }
        public List<CustomUserRole> LoadUserRolesList()
        {
            return LoadDataListWithCache<CustomUserRole>(ConnectedData.enTables.Table_UserRole);
        }
        public List<CustomVocabulary> LoadVocabularysList()
        {
            return LoadDataListWithCache<CustomVocabulary>(ConnectedData.enTables.Table_Vocabulary);
        }

        /// <summary>
        /// Cập nhật lại danh sách đã load từ cache
        /// </summary>
        public void RefreshLoadedDataList()
        {
            // Dùng ToList() để tạo một danh sách mới từ keys của loadedDataList
            // Dùng ToList() để tránh lỗi khi thay đổi collection trong vòng lặp
            foreach (var enTable in loadedDataList.Keys.ToList())
            {
                if(loadedTables.TryGetValue(enTable, out DataTable table))
                {
                    // Cập nhật lại tùy theo tên bảng
                    if(enTable == ConnectedData.enTables.Table_None)
                    {
                        loadedDataList[enTable] = null;
                    }
                    else
                    {
                        // Chuyển đổi từ DataTable sang List<T>
                        var list = ConvertDataTableToList<object>(table, enTable);
                        loadedDataList[enTable] = list;
                    }
                }    
            }
        }

        /// <summary>
        /// Load dữ liệu từ cơ sở dữ liệu vào List<T> và lưu vào cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        private List<T> LoadDataListWithCache<T>(ConnectedData.enTables table) where T : class
        {
            // Kiểm tra xem danh sách đã được load chưa
            if (loadedDataList.ContainsKey(table))
            {
                return loadedDataList[table] as List<T>;
            }

            // Nếu chưa có, kiểm tra DataTable
            if(loadedDataList.ContainsKey(table))
            {
                // Chuyển đổi từ DataTable sang List<T>
                var list = ConvertDataTableToList<T>(loadedTables[table], table );
                loadedDataList[table] = list;
                return list;
            }
            else
            {
                // Nếu chưa load, load từ cơ sở dữ liệu
                DataTable dataTable = LoadDataFromDb(table);
                if (dataTable != null)
                {
                    loadedTables[table] = dataTable;
                    // Chuyển đổi từ DataTable sang List<T>
                    var list = ConvertDataTableToList<T>(dataTable, table);
                    loadedDataList[table] = list;
                    return list;
                }
            }
            return null;
        }
        // Sử dụng static để sử dụng ngoài lớp
        public List<T> GetConvertDataTableToList<T>(DataTable dataTable, ConnectedData.enTables entable) where T : class
        {
            return ConvertDataTableToList<T>(dataTable, entable);
        }
        /// <summary>
        /// Chuyển đổi từ DataTable sang List<T> dựa trên kiểu dữ liệu
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable"></param>
        /// <param name="entable"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private List<T> ConvertDataTableToList<T>(DataTable dataTable, ConnectedData.enTables entable) where T : class
        {
            // Chuyển đổi từ DataTable sang List<T>
            var dataList = new List<T>();
            
            switch(entable)
            {
                case ConnectedData.enTables.Table_None:
                    dataList.Add(null); 
                    break;
                case ConnectedData.enTables.Table_Answer:
                    dataList = CustomAnswerConverter.ConvertDataTableToCustomAnswerList(dataTable) as List<T>;
                    break;
                case ConnectedData.enTables.Table_Curriculum:
                    dataList = CustomCurriculumConverter.ConvertDataTableToCustomCurriculumList(dataTable) as List<T>;
                    break;
                case ConnectedData.enTables.Table_Grammar:
                    dataList = CustomGrammarConvert.ConvertDataTableToCustomGrammarList(dataTable) as List<T>;
                    break;
                case ConnectedData.enTables.Table_Group:
                    dataList = CustomGroupConverter.ConvertDataTableToCustomGroupList(dataTable) as List<T>;
                    break;
                case ConnectedData.enTables.Table_HistoryGKTV:
                    // Giới hạn mức độ load lịch sử dữ liệu
                    // Load lịch sử dữ liệu đối với UserId mà người dùng đã chọn
                    // Nếu chưa chọn thì load tất cả
                    // Lấy danh sách UserId đã chọn
                    DataView dataView = new DataView(dataTable);
                    dataView.RowFilter = $"{ConnectedData.historyGKTVCol[(int)ConnectedData.enHistoryGKTVCol.HisGKTVCol_UserId]} = {Accounts.UserLogin.Id}";
                    DataTable filteredDataTable = dataView.ToTable();
                    dataList = CustomHistoryGKTVConverter.ConvertDataTableToCustomHistoryGKTVList(filteredDataTable) as List<T>;
                    break;
                case ConnectedData.enTables.Table_Images:
                    dataList = CustomImageConverter.ConvertDataTableToCustomImageList(dataTable) as List<T>;
                    break;
                case ConnectedData.enTables.Table_Kanji:
                    dataList = CustomKanjiConverter.ConvertDataTableToCustomKanjiList(dataTable) as List<T>;
                    break;
                case ConnectedData.enTables.Table_Level:
                    dataList = CustomLevelConverter.ConvertDataTableToCustomLevelList(dataTable) as List<T>;
                    break;
                case ConnectedData.enTables.Table_ParentChild:
                    dataList = CustomParentChildConverter.ConvertDataTableToCustomParentChildList(dataTable) as List<T>;
                    break;
                case ConnectedData.enTables.Table_Position:
                    dataList = CustomPositionConverter.ConvertDataTableToCustomPositionList(dataTable) as List<T>;
                    break;
                case ConnectedData.enTables.Table_Role:
                    dataList = CustomRoleConverter.ConvertDataTableToCustomRoleList(dataTable) as List<T>;
                    break;
                case ConnectedData.enTables.Table_Technical:
                    dataList = CustomTechnicalConverter.ConvertDataTableToCustomTechnicalList(dataTable) as List<T>;
                    break;
                case ConnectedData.enTables.Table_TypeVoca:
                    dataList = CustomTypeVocaConverter.ConvertDataTableToCustomTypeVocaList(dataTable) as List<T>;
                    break;
                case ConnectedData.enTables.Table_User:
                    dataList = CustomUserConverter.ConvertDataTableToCustomUserList(dataTable) as List<T>;
                    break;
                case ConnectedData.enTables.Table_UserRole:
                    dataList = CustomUserRoleConverter.ConvertDataTableToCustomUserRoleList(dataTable) as List<T>;
                    break;
                case ConnectedData.enTables.Table_Vocabulary:
                    dataList = CustomVocabularyConverter.ConvertDataTableToCustomVocabularyList(dataTable) as List<T>;
                    break;
                default:
                    throw new NotImplementedException($"Chưa hỗ trợ chuyển đổi cho bảng {entable}");
            }    

            return dataList;
        }

        #endregion


    }
}
