using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCV_JapaNinja.Class
{
    internal class Languages
    {
        public enum enLableName
        {
            LabelName_Study = 0,
            LabelName_Trial,
            LabelName_Test,
            LabelName_Advanced,
            LabelName_Admin_Management,
            LabelName_Evaluate,
            LabelName_Alphabet,
            LabelName_Technical,
            LabelName_Kanji,
            LabelName_Vocabulary,
            LabelName_Grammar,
            LabelName_OK,
            LabelName_Cancel,
            LabelName_Exit,
            LabelName_Save,
            LabelName_SaveAs,
            LabelName_Open,
            LabelName_New,
            LabelName_Export,
            LabelName_Import,
            LabelName_Login,
            LabelName_Lesson,
            LabelName_
        }
        /// <summary>
        /// loại ngôn ngữ được hiển thị
        /// </summary>
        public enum enLanguage
        {
            Language_Name = 0,
            Language_English,
            Language_Japanese,
            Language_Vietnamese,
            Language_
        };
        // Chọn ngôn ngữ hiển thị
        public static string[,] LanguageVisi = new string[(int)enLanguage.Language_, (int)enLanguage.Language_]
        {
            {"0",   "1",           "2",            "3" },// Language_Name = 0,
            {"1",   "English",     "Japanese",     "Vietnamese" },//Language_English,
            {"2",   "英語",        "日本語",       "ベトナム語" },//Language_Japanese,
            {"3",   "Tiếng Anh",   "Tiếng Nhật",  "Tiếng Việt" },//Language_Vietnamese,
        };

        public static string[,] lableName = new string[(int)enLableName.LabelName_, (int)enLanguage.Language_]
        {
            {"","Study"                    ,"japanH", "Học Tập" },                             //LabelName_Learning = 0,
            {"","Trial"                    ,"japanT", "Thi Thu" },                             //LabelName_TestEx,
            {"", "Test"                     ,"japanD", "Kiem Tra" },                            //LabelName_Periodically,
            {"", "Advanced"                 ,"japanD", "Mo Rong" },                             //LabelName_Advanced,
            {"", "Admin Management"         ,"japanV", "Admin Quan Ly" },                       //LabelName_Management,
            {"", "Evaluate"                 ,"japanS", "Thong Ke" },                            //LabelName_Statistic,
            {"", "Alphabet"                 ,"japanV", "Chu Cai" },                             //LabelName_Vocabulary,
            {"", "Technical"                ,"japanC", "Chuyen Nganh" },                        //LabelName_VocabularySpecialized,
            {"", "Kanji"                    ,"japanP", "Han Tu" },                              //LabelName_Grammar,
            {"", "Vocabulary"               ,"japanJ", "Tu Vung" },                             //LabelName_JLPT,
            {"", "Grammar"                  ,"japanJ", "Ngu Phap" },                            //LabelName_JLPT,
            {"", "OK"                       ,"japanO", "OK" },                                  //LabelName_Ok,
            {"", "Cancel"                   ,"japanY", "Huy" },                                 //LabelName_Cancel,
            {"", "Exit"                     ,"japant", "Thoat" },                               //LabelName_Exit,
            {"", "Save"                     ,"japanU", "Luu" },                                 //LabelName_Save,
            {"", "SaveAs"                   ,"japanM", "Luu Moi" },                             //LabelName_SaveAs,
            {"", "Open"                     ,"japano", "Mo" },                                  //LabelName_Open,
            {"", "New"                      ,"japanm", "Moi" },                                 //LabelName_New,
            {"", "Export"                   ,"japanX", "Xuat File" },                           //LabelName_Export,
            {"", "Import"                   ,"japanc", "Doc File" },                            //LabelName_Import,
            {"", "Login"                    ,"japanc", "Dang Nhap" },                            //LabelName_Login,
            {"", "Lesson"                   ,"japanc", "Bài" }                            //LabelName_Lesson,
        };

        /* index language */
        public static enLanguage LanguageIndex = enLanguage.Language_English;

    }
}
