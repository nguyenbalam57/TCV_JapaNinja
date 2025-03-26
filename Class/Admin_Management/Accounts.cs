using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using TCV_JapaNinja.Models;
using TCV_JapaNinja.Models.Account;

namespace TCV_JapaNinja.Class
{
    internal class Accounts
    {
        public enum enRoleCol
        {
            RoleCol_Id,
            RoleCol_Name,
            RoleCol_Des,
            RoleCol_
        }

        public enum enRoleRow
        {
            RoleRow_Admin,
            RoleRow_Answer,
            RoleRow_Curriculum,
            RoleRow_Grammar,
            RoleRow_Group,
            RoleRow_HisGrammar,
            RoleRow_HisKanji,
            RoleRow_HisTechnical,
            RoleRow_HisVoc,
            RoleRow_Kanji,
            RoleRow_Level,
            RoleRow_Position,
            RoleRow_Role,
            RoleRow_Technical,
            RoleRow_TypeVoc,
            RoleRow_UserRole,
            RoleRow_User,
            RoleRow_Voc,
            RoleRow_InputData,
            RoleRow_
        }

        // danh sách phân quyền quản lý từng mục
        public static string[,] codeRoles = new string[(int)enRoleRow.RoleRow_, (int)enRoleCol.RoleCol_]
        {
            {"ADMIN",           "Admin",                "Quản lý tất cả mọi quyền hạn"},                //RoleRow_Admin
            {"ANSWER",          "Answer",               "Đáp án"},                                      //RoleRow_Answer
            {"CURRICULUM",      "Curriculum",           "Giáo trình (sách giáo khoa của hãng nào)"},    //RoleRow_Curriculum
            {"GRAMMAR",         "Grammar",              "Ngữ pháp"},                                    //RoleRow_Grammar
            {"GROUP",           "Group",                "Nhóm Quản lý"},                                //RoleRow_Group
            {"HISGRAMMAR",      "History Grammar",      "Lịch sử Học ngữ pháp"},                        //RoleRow_HisGrammar
            {"HISKANJI",        "History Kanji",        "Lịch sử học hán tự"},                          //RoleRow_HisKanji
            {"HISTECHNICAL",    "History Technical",    "Lịch sử học từ vựng chuyên ngành"},            //RoleRow_HisTechnical
            {"HISVOC",          "History Vocabulary",   "Lịch sử học từ vựng"},                         //RoleRow_HisVoc
            {"KANJI",           "Kanji",                "Hán tự"},                                      //RoleRow_Kanji
            {"LEVEL",           "Level",                "Cấp độ trong tiếng Nhật"},                     //RoleRow_Level
            {"POSITION",        "Position",             "Chức vụ trong Công ty"},                       //RoleRow_Position
            {"ROLE",            "Role",                 "Phân quyền quản lý"},                          //RoleRow_Role
            {"TECHNICAL",       "Technical",            "Từ vựng chuyên ngành"},                        //RoleRow_Technical
            {"TYPEVOC",         "Type Vocabulary",      "Loại từ vựng"},                                //RoleRow_TypeVoc
            {"USERROLE",        "User Role",            "Quản lý phân quyền đối với người dùng"},       //RoleRow_UserRole
            {"USER",            "User",                 "Tên người dùng"},                              //RoleRow_User
            {"VOC",             "Vocabulary",           "Từ vựng tiếng Nhật"},                           //RoleRow_Voc
            {"INPUTDATA",       "Input Data",           "Thêm dữ liệu data vào Cơ sở dữ liệu"}                           //RoleRow_InputData
        };

        /* ID accounts dang nhap */
        public static CustomUser UserLogin = new CustomUser();


        // Quản lý về người dùng, account
        public static string[] manAccount = new string[] 
        {
            codeRoles[(int)enRoleRow.RoleRow_Group, (int)enRoleCol.RoleCol_Id],
            codeRoles[(int)enRoleRow.RoleRow_Position, (int)enRoleCol.RoleCol_Id],
            codeRoles[(int)enRoleRow.RoleRow_Role, (int)enRoleCol.RoleCol_Id],
            codeRoles[(int)enRoleRow.RoleRow_UserRole, (int)enRoleCol.RoleCol_Id],
            codeRoles[(int)enRoleRow.RoleRow_User, (int)enRoleCol.RoleCol_Id]

        };
        // Quản lý về dữ liệu từ vựng
        public static string[] manData = new string[] 
        {
            codeRoles[(int)enRoleRow.RoleRow_Answer, (int)enRoleCol.RoleCol_Id],
            codeRoles[(int)enRoleRow.RoleRow_Curriculum, (int)enRoleCol.RoleCol_Id],
            codeRoles[(int)enRoleRow.RoleRow_Grammar, (int)enRoleCol.RoleCol_Id],
            codeRoles[(int)enRoleRow.RoleRow_HisGrammar, (int)enRoleCol.RoleCol_Id],
            codeRoles[(int)enRoleRow.RoleRow_HisKanji, (int)enRoleCol.RoleCol_Id],
            codeRoles[(int)enRoleRow.RoleRow_HisTechnical, (int)enRoleCol.RoleCol_Id],
            codeRoles[(int)enRoleRow.RoleRow_HisVoc, (int)enRoleCol.RoleCol_Id],
            codeRoles[(int)enRoleRow.RoleRow_Kanji, (int)enRoleCol.RoleCol_Id],
            codeRoles[(int)enRoleRow.RoleRow_Level, (int)enRoleCol.RoleCol_Id],
            codeRoles[(int)enRoleRow.RoleRow_Technical, (int)enRoleCol.RoleCol_Id],
            codeRoles[(int)enRoleRow.RoleRow_TypeVoc, (int)enRoleCol.RoleCol_Id],
            codeRoles[(int)enRoleRow.RoleRow_Voc, (int)enRoleCol.RoleCol_Id]
        };

        public static void clearAccountLogin()
        {
            UserLogin = new CustomUser();
        }

        // Ghi Name vào để hiển thị
        public static void vdScreenNameAccount(System.Windows.Forms.Label namelabel)
        {
            namelabel.Text = UserLogin.UserName;
        }

        /// <summary>
        /// get Name của role từ Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetNameCodeRoleOfId(string id)
        {
            string rsult = string.Empty;

            if (!string.IsNullOrWhiteSpace(id))
            {
                // Search codeRoles
                for (int i = 0; i < (int)enRoleRow.RoleRow_; i++) 
                {
                    if(id == codeRoles[i, (int)enRoleCol.RoleCol_Id])
                    {
                        rsult = codeRoles[i, (int)enRoleCol.RoleCol_Name]; 
                        break;
                    }
                }
            }

            return rsult;
        }
        /// <summary>
        /// lấy địa chỉ IP
        /// </summary>
        /// <returns></returns>
        public static string GetIPAddress()
        {
            string rsult = string.Empty;

            // Tên máy tính
            string machineName = Environment.MachineName;
            //Console.WriteLine($"Machine Name: {machineName}");

            // Tên người dùng
            string userName = Environment.UserName;
            //Console.WriteLine($"Current User: {userName}");

            // Địa chỉ IP
            string hotst = string.Empty;
            string hostName = Dns.GetHostName();
            IPHostEntry host = Dns.GetHostEntry(hostName);
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork) // IPv4
                {
                    //Console.WriteLine($"IP Address: {ip}");
                    hotst = ip.ToString();
                }
            }

            rsult = $"{machineName} {userName} {hotst}";

            return rsult;
        }
        /// <summary>
        /// ghi vào dữ liệu là địa chỉ ip nào đang giữ tài khoản
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="ipadress"></param>
        public static void updateIPAdress(int userId, string ipadress)
        {
            if( userId >= 0)
            {
                try
                {
                    string query = $"UPDATE {ConnectedData.tableNames[(int)ConnectedData.enTables.Table_User]} " +
                        $"SET {ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_IPAddress]} = @ipAddress " +
                        $"WHERE {ConnectedData.userCol[(int)ConnectedData.enUserCol.UserCol_Id]} = @UserId";
                    using (SqlConnection connection = new SqlConnection(ConnectedData.connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ipAddress", ipadress);
                            command.Parameters.AddWithValue("@UserId", userId);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Update IPAddress Error" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
