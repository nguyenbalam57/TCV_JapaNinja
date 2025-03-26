using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCV_JapaNinja.Forms.Advanced
{
    public partial class FormAdvanced : Form
    {
        public FormAdvanced()
        {
            InitializeComponent();
        }
        private int numLevel = 5;
        private int numAdvanced = 4;

        private string[] advanced_Str = new string[] { "Ngay Thang Nam", "Gio Phut", "So Tien", "So Dem" };

        private void group_btn_Click(object sender, EventArgs e)
        {
            if (numLevel > 0 && numLevel < 6)
            {
                string textstr = "N" + numLevel.ToString();
                numLevel--;
                //Class.UserToolBoxs.createButton(level_flpn, textstr);
            }

        }

        private void advanced_Click(object sender, EventArgs e)
        {
            foreach(string str in advanced_Str)
            {
                //Class.UserToolBoxs.createButton(advanced_flpn, str);
            }
        }

        /// <summary>
        /// screen 
        /// </summary>
        /// <param name="childForm"></param>
        private void openChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            chillformAdvanced_pn.Controls.Add(childForm);
            chillformAdvanced_pn.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void FormKanji_Load(object sender, EventArgs e)
        {
            var frmCommonSection = (Study.CommonSection.FormCommonSection)Application.OpenForms["FormCommonSection"];
            if (frmCommonSection == null) { frmCommonSection = new Study.CommonSection.FormCommonSection(); }
            openChildForm(frmCommonSection);
        }
    }
}
