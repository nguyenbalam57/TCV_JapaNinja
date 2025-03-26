using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Text;
using System.Windows;
using System.Windows.Forms;

namespace TCV_JapaNinja.Class
{
    /// <summary>
    /// Connected File
    /// Font
    /// Size
    /// Color
    /// Light
    /// 
    /// </summary>
    public class Connecteds
    {
        /// <summary>
        /// hàm khởi đầu
        /// </summary>
        public void initializeConnected()
        {
            Load_CustomFonts();
            Load_Font();
        }

        #region FONT_JP_VN
        /// <summary>
        /// Font
        /// </summary>
        PrivateFontCollection privateFonts = new PrivateFontCollection();

        /// <summary>
        /// font hiển thị tiếng nhật
        /// </summary>
        FontFamily JPFont = null;
        /// <summary>
        /// font hiển thị latin
        /// </summary>
        FontFamily VNFont = null;

        enum enFonts
        {
            Font_NotoSansJP=0,
            Font_Roboto,
            Font_SegoeUI,
            Font_Arial,
            Font_
        }

        string[] nameFont = new string[(int)enFonts.Font_] { 
            "NotoSansJP-Regular",
            "Roboto-Regular",
            "Segoe UI",
            "Arial"
        };
        
        

        /// <summary>
        /// Load tất cả font trong folder fonts
        /// </summary>
        public void Load_CustomFonts()
        {
            // đương dẫn tới thư mục chứa các tệp font trong thu mục dự án
            string pathFonts = Path.Combine(System.Windows.Forms.Application.StartupPath, "Fonts");

            foreach (string fontFile in Directory.GetFiles(pathFonts, "*.ttf"))
            {
                privateFonts.AddFontFile(fontFile);
            }
        }

        /// <summary>
        /// load font 2 ngon ngu tieng nhat va tieng viet
        /// </summary>
        public void Load_Font()
        {
            enFonts font = enFonts.Font_NotoSansJP;

            // tìm font cho Japanes
            while(JPFont == null && (int)font < (int)enFonts.Font_)
            {
                JPFont = GetFontFamily(nameFont[(int)font]);
                font = (enFonts)((int)font + 1);
            }

            font = enFonts.Font_Roboto;
            // tìm font cho vietNamese
            while(VNFont == null && (int)font < (int)enFonts.Font_)
            {
                VNFont = GetFontFamily(nameFont[(int)font]);
                font = (enFonts)((int)font + 1);
            }
        }
        

        /// <summary>
        /// get font
        /// </summary>
        /// <param name="fontName"></param>
        /// <returns></returns>
        public FontFamily GetFontFamily(string fontName)
        {
            FontFamily family = null;
            // duyệt qua tất cả các font và chọn ra font cần lấy
            foreach(FontFamily font in privateFonts.Families)
            {
                if(font.Name.Equals(fontName, StringComparison.OrdinalIgnoreCase))
                {
                    family = font;
                    break;
                }
            }
            // trường hợp trong list trên không có font thì tìm ở window
            if(family == null)
            {
                if(GetFontFamilyToWindows(fontName) != null)
                    family = GetFontFamilyToWindows(fontName);
            }    

            return family;
        }
        /// <summary>
        /// lấy font từ window
        /// </summary>
        /// <param name="fontName"></param>
        /// <returns></returns>
        public FontFamily GetFontFamilyToWindows(string fontName)
        {
            return new FontFamily(fontName);
        }
        #endregion
    }
}
