using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCV_JapaNinja.Forms.Study.Technical
{
    public partial class FormTechnical : Form
    {

        private int numNum = 0;
        private int soLuongNum = 19;
        private string[] group_Str = new string[] { "CAD", "SOFT" };
        public FormTechnical()
        {
            InitializeComponent();
        }

        private void group_btn_Click(object sender, EventArgs e)
        {
            foreach(string a in group_Str)
            {
                //Class.UserToolBoxs.createButton(groups_flpn, a);
            }
        }

        private void Vocabulary_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 5; i++)
            {
                numNum++;
                string textstr = numNum.ToString();
                numNum = numNum + soLuongNum;
                textstr += " - " + numNum.ToString();
                //Class.UserToolBoxs.createButton(numVocas_flpn, textstr);
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
            chillformTechnical_pn.Controls.Add(childForm);
            chillformTechnical_pn.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        /// <summary>
        /// phan hoc chung
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTechnical_Load(object sender, EventArgs e)
        {
            var frmCommonSection = (CommonSection.FormCommonSection)Application.OpenForms["FormCommonSection"];
            if(frmCommonSection == null) { frmCommonSection = new CommonSection.FormCommonSection(); }
            openChildForm(frmCommonSection);
        }
    }
}
