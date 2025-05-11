using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCV_JapaNinja.Class
{
    internal class UserToolBoxs
    {
        public static Button createButton(FlowLayoutPanel layoutPanel, string name )
        {
            Button button = new Button();
            button.Text = name;
            button.Size = new Size(94, 25);
            button.BackColor = ColorTranslator.FromHtml(Class.Colors.Color[(int)Class.Colors.enColors.Color_BackgroundMenu, (int)Class.Colors.ModeColorsIndex]);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            layoutPanel.Controls.Add(button);

            return button;
        }

        public static void LoadDataGridView(DataGridView dataGridView )
        {
            // Tùy chỉnh giao diện DataGridView
            dataGridView.BackgroundColor = Color.White;
            dataGridView.DefaultCellStyle.Font = new Font("Arial", 12);
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView.EnableHeadersVisualStyles = false;

            // Kích hoạt DoubleBuffered để cải thiện hiệu suất
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null, dataGridView, new object[] { true });
        }
    }
}
