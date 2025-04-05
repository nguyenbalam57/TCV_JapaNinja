using FrameworkTest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCV_JapaNinja.Forms.Study.Alphabet;
using TCV_JapaNinja.Forms.Study.Technical;

namespace TCV_JapaNinja.Forms.Study
{
    public partial class FormStudy : Form
    {
        SATAButton activeStudy;
        Form ActiveForm;

        public FormStudy()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Hiển thị Học Alphabet (Chữ cái)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void alphabet_stbtn_Click(object sender, EventArgs e)
        {
            activeStudy = Class.UserDefineFunction.ActiveSATAButtons((SATAButton)sender, activeStudy);
            var frmAlphabet = (FormAlphabet)Application.OpenForms["FormAlphabet"];
            frmAlphabet?.Focus();
            if (frmAlphabet == null) { frmAlphabet = new FormAlphabet(); }
            /*hien thi*/
            ActiveForm = Class.UserDefineFunction.openChildForm(frmAlphabet, formChill_pn, ActiveForm);
        }
        /// <summary>
        /// Hiển thị Học Technical (Từ vựng chuyên ngành)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void technical_stbtn_Click(object sender, EventArgs e)
        {
            activeStudy = Class.UserDefineFunction.ActiveSATAButtons((SATAButton)sender, activeStudy);
            var frmTechnical = (FormTechnical)Application.OpenForms["FormTechnical"];
            frmTechnical?.Focus();
            if (frmTechnical == null) { frmTechnical = new FormTechnical(); }
            /*hien thi*/
            ActiveForm = Class.UserDefineFunction.openChildForm(frmTechnical, formChill_pn, ActiveForm);
        }
        /// <summary>
        /// Hiển thị Học Kanji (Chữ Hán)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kanji_stbtn_Click(object sender, EventArgs e)
        {
            activeStudy = Class.UserDefineFunction.ActiveSATAButtons((SATAButton)sender, activeStudy);
            var frmKanji = (Kanji.FormKanji)Application.OpenForms["FormKanji"];
            frmKanji?.Focus();
            if (frmKanji == null) { frmKanji = new Kanji.FormKanji(); }
            /*hien thi*/
            ActiveForm = Class.UserDefineFunction.openChildForm(frmKanji, formChill_pn, ActiveForm);
        }

        private void vocabulary_stbtn_Click(object sender, EventArgs e)
        {
            activeStudy = Class.UserDefineFunction.ActiveSATAButtons((SATAButton)sender, activeStudy);
            var frmKanji = (Kanji.FormKanji)Application.OpenForms["FormKanji"];
            frmKanji?.Focus();
            if (frmKanji == null) { frmKanji = new Kanji.FormKanji(); }
            /*hien thi*/
            ActiveForm = Class.UserDefineFunction.openChildForm(frmKanji, formChill_pn, ActiveForm);
        }

        private void gramma_stbtn_Click(object sender, EventArgs e)
        {
            activeStudy = Class.UserDefineFunction.ActiveSATAButtons((SATAButton)sender, activeStudy);
            var frmKanji = (Kanji.FormKanji)Application.OpenForms["FormKanji"];
            frmKanji?.Focus();
            if (frmKanji == null) { frmKanji = new Kanji.FormKanji(); }
            /*hien thi*/
            ActiveForm = Class.UserDefineFunction.openChildForm(frmKanji, formChill_pn, ActiveForm);
        }



    }
}
