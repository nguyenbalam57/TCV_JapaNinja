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

namespace TCV_JapaNinja.Forms.CommonSection
{
    public partial class FormTrial_Test : Form
    {
        public FormTrial_Test()
        {
            InitializeComponent();
        }

        private void vocabulary_btn_Click(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;
            text_Focus_lb.Text = button.Text;
        }

        private void grammar_btn_Click(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;
            text_Focus_lb.Text = button.Text;
        }

        private void reading_btn_Click(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;
            text_Focus_lb.Text = button.Text;
        }

        private void listening_btn_Click(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;
            text_Focus_lb.Text = button.Text;
        }

    }
}
