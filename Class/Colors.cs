using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCV_JapaNinja.Class
{
    internal class Colors
    {

        /// <summary>
        /// ád
        /// </summary>
        public enum enColors
        {
            Color_Background = 0,
            Color_BackgroundMenu = 1,
            Color_IconButton,
            Color_IconButtonActive,
            Color_IconButtonHover,
            Color_IconButtonClick,
            Color_IconButtonClickActive,
            Color_IconButtonClickHover,
            Color_ButtonPanel,
            Color_ButtonPanelActive,
            Color_ButtonPanelHover,
            Color_ButtonPanelClick,
            Color_IconButtonLevel2,
            Color_IconButtonLevel2Active,
            Color_IconButtonLevel2Hover,
            Color_IconButtonLevel2Click,
            Color_IconButtonLevel2ClickActive,
            Color_IconButtonText,
            Color_IconButtonTextActive,
            Color_
        }

        public enum enModeColors
        {
            ModeColor_Dark = 0,
            ModeColor_Light = 1,
            ModeColor_
        }

        public static string[] ModeColor = new string[(int)enModeColors.ModeColor_]
        {
            "Dark",
            "Light"
        };

        public static string[,] Color = new string[(int)enColors.Color_, (int)enModeColors.ModeColor_]
        {
            { "#77A6F7", "" }, //Color_Background
            { "#77A6F7", "" }, //Color_BackgroundMenu
            { "#77A6F7", "" }, //Color_IconButton
            { "#FFFFFF", "" }, //Color_IconButtonActive
            { "#2c3e50", "" }, //Color_IconButtonHover
            { "#2c3e50", "" }, //Color_IconButtonClick
            { "#2c3e50", "" }, //Color_IconButtonClickActive
            { "#2c3e50", "" }, //Color_IconButtonClickHover
            { "#2c3e50", "" }, //Color_ButtonPanel
            { "#2c3e50", "" }, //Color_ButtonPanelActive
            { "#2c3e50", "" }, //Color_ButtonPanelHover
            { "#2c3e50", "" }, //Color_ButtonPanelClick
            { "#77A6F7", "" }, //Color_IconButtonLeve2,
            { "#D3E3FC", "" }, //Color_IconButtonLeve2Active,
            { "#2c3e50", "" }, //Color_IconButtonLeve2Hover,
            { "#2c3e50", "" }, //Color_IconButtonLeve2Click,
            { "#2c3e50", "" }, //Color_IconButtonLeve2ClickActive,
            { "#FFFFFF", "" }, //Color_IconButtonText,
            { "#000000", "" }  //Color_IconButtonTextActive,
        };

        public static enModeColors ModeColorsIndex = enModeColors.ModeColor_Dark;
    }
}
