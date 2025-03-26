using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCV_JapaNinja.Forms.Study.CommonSection
{
    public partial class FormCommonSection : Form
    {
        DataTable kanjiTable;
        public FormCommonSection()
        {
            InitializeComponent();
        }

        public void DisplayKanjiData(DataTable kanjiData)
        {
            kanjiTable = kanjiData;

            dataView_dgv.DataSource = kanjiTable;
        }

        private void learning_btn_Click(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;

        }

        private void flashCard_btn_Click(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;

        }

        private void matching_btn_Click(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;

        }

        private void gap_Filling_btn_Click(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;

        }

        private void word_Selection_btn_Click(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;

        }

        private void mini_Test_btn_Click(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;


        }

        private void text_Focus_lb_Click(object sender, EventArgs e)
        {

        }
    }
}
