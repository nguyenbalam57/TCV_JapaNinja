using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace TCV_JapaNinja.Class
{
    internal class UserDefineFunction
    {
        

        /// <summary>
        /// ham kiem tra number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsValidNumber(string input)
        {
            return int.TryParse(input, out _);
        }
        /// <summary>
        /// kiểm tra có phải là number không. và trả về giá trị
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int getNumberDataNullOrValue(string input)
        {
            int result = -1;
            if (!string.IsNullOrWhiteSpace(input) && IsValidNumber(input))
            {
                result = int.Parse(input);
            }

            return result;
        }
        /// <summary>
        /// Dùng để kiểm tra xem giá trị value của combobox và giá trị input có khác nhau không.
        /// nếu khác nhau thì sẽ lấy ra giá trị output
        /// và hàm trả về true
        /// </summary>
        /// <param name="comboBox">lấy value từ combobox</param>
        /// <param name="input">gửi xuống 1 giá trị đã có hoặc là giá trị null</param>
        /// <param name="output">nhận lại giá trị sau khi đã thực hiện xong</param>
        /// <returns></returns>
        public static bool getValueCombobox(System.Windows.Forms.ComboBox comboBox, string input, out string output)
        {
            bool rsult = false;
            output = null;
            // xây dụng thuật toán để trả về kết quả.
            // giá trị mới nhất là value của combobox.
            // nếu có sự khác biệt giữa value combobox và input

            if (comboBox.SelectedValue != null && !string.IsNullOrWhiteSpace(comboBox.Text))
            {
                string selectedValue = comboBox.SelectedValue.ToString();

                if (selectedValue != input)
                {
                    output = selectedValue;
                    rsult = true;
                }
            }
            else if (!string.IsNullOrWhiteSpace(input))
            {
                output = null;
                rsult = true;
            }

            return rsult;
        }

        public static void InitDataGridViewButton(DataGridView dataGridView, string name, string text, string pathImage)
        {
            if (dataGridView == null) return;

            string path = Path.Combine(ConnectedData.pathFolder, pathImage);

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if(!row.IsNewRow)
                {
                    // Kiểm tra xem cột "Edit" có tồn tại không
                    if (dataGridView.Columns[name] != null)
                    {
                        row.Cells[name].Value = path;
                    }
                    else
                    {
                        // Thêm cột nếu chưa tồn tại
                        DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                        imageColumn.Name = name;
                        imageColumn.HeaderText = text;
                        dataGridView.Columns.Add(imageColumn);
                        row.Cells[name].Value = path;
                    }

                }    
            }    
        }

    }
}
