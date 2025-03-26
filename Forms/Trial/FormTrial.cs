using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCV_JapaNinja.Forms.Trial
{
    public partial class FormTrial : Form
    {
        public FormTrial()
        {
            InitializeComponent();
        }

        private int numLevel = 5;
        private int numYear = 2017;
        private int num7th = 7;
        private int num12th = 12;

        private void level_btn_Click(object sender, EventArgs e)
        {
            if (numLevel > 0 && numLevel < 6)
            {
                string textstr = "N" + numLevel.ToString();
                numLevel--;
                createButton(level_flpn, textstr);
            }
        }

        private void year_Click(object sender, EventArgs e)
        {
            numYear++;
            string textstr = numYear.ToString() + "-" + num7th.ToString();
            createButton(year_flpn, textstr);
            textstr = numYear.ToString() + "-" + num12th.ToString();
            createButton(year_flpn, textstr);

        }

        private void createButton(FlowLayoutPanel layoutPanel, string text)
        {
            Button button = new Button();
            button.Text = text;
            button.Size = new Size(94, 25);
            button.BackColor = Color.Blue;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            layoutPanel.Controls.Add(button);
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
            chillformTrial_pn.Controls.Add(childForm);
            chillformTrial_pn.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        private void FormTrial_Load(object sender, EventArgs e)
        {
            var frmCommonSection = (CommonSection.FormTrial_Test)Application.OpenForms["FormTrial_Test"];
            if (frmCommonSection == null) { frmCommonSection = new CommonSection.FormTrial_Test(); }
            openChildForm(frmCommonSection);
        }
    }
}
