using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCV_JapaNinja.Forms.Study.Alphabet
{
    public partial class FormAlphabet : Form
    {
        
        private enum enModePanel
        {
            ModePanel_Hiragana_Katakana = 0,
            ModePanel_Hiragana,
            ModePanel_Katakana,
            ModePanel_Trial,
            ModePanel_
        }
        /* Text button */
        private string[] hiragana_katakana_str = new string[(int)enModePanel.ModePanel_] { "Hira - Kata", "Hiragana", "Katakana", "Trial" };
        private enModePanel modePanel = enModePanel.ModePanel_Hiragana_Katakana;

        public FormAlphabet()
        {
            InitializeComponent();

        }

        /// <summary>
        /// thay doi mode
        /// hien thi 2 panel
        /// hien thi 1 hiragana chiem 2 vung
        /// hien thi 1 katakana chiem 2 vung
        /// khong hien thi gi
        /// </summary>
        private void hiraganaAndKatakanaShowPanel( )
        {
            alphabet_tlpn.Show();
            alphabet_tlpn.Controls.Clear();
            var frmTrialAlphabet = (FormTrialAlphabet)Application.OpenForms["FormTrialAlphabet"];
            if (frmTrialAlphabet != null) { frmTrialAlphabet.Hide(); }

            switch (modePanel)
            {
                case enModePanel.ModePanel_Hiragana_Katakana:
                    alphabet_tlpn.Controls.Add(hiragana_pn, 0, 0);
                    alphabet_tlpn.SetColumnSpan(hiragana_pn, 1);
                    alphabet_tlpn.Controls.Add(katakana_pn, 1, 0);
                    alphabet_tlpn.SetColumnSpan(katakana_pn, 1);
                    modePanel = enModePanel.ModePanel_Hiragana;

                    break;
                case enModePanel.ModePanel_Hiragana:
                    alphabet_tlpn.Controls.Add(hiragana_pn, 0, 0);
                    alphabet_tlpn.SetColumnSpan(hiragana_pn, 2);
                    modePanel = enModePanel.ModePanel_Katakana;
                    break;
                case enModePanel.ModePanel_Katakana:
                    alphabet_tlpn.Controls.Add(katakana_pn, 0, 0);
                    alphabet_tlpn.SetColumnSpan(katakana_pn, 2);
                    modePanel = enModePanel.ModePanel_Trial;
                    break;
                case enModePanel.ModePanel_Trial:
                    alphabet_tlpn.Hide();
                    var frmTrial = (FormTrialAlphabet)Application.OpenForms["FormTrialAlphabet"];
                    if(frmTrial == null) { frmTrial =  new FormTrialAlphabet(); }
                    openChildForm(frmTrial);
                    modePanel = enModePanel.ModePanel_Hiragana_Katakana;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// hien thi ten button
        /// </summary>
        private void buttonModeText()
        {
            name_Mode_lb.Text = hiragana_katakana_str[(int)modePanel];
            switch (modePanel)
            {
                case enModePanel.ModePanel_Hiragana_Katakana:
                    hira_kata_btn.Text = hiragana_katakana_str[(int)enModePanel.ModePanel_Hiragana];
                    break;
                case enModePanel.ModePanel_Hiragana:
                    hira_kata_btn.Text = hiragana_katakana_str[(int)enModePanel.ModePanel_Katakana];
                    break;
                case enModePanel.ModePanel_Katakana:
                    hira_kata_btn.Text = hiragana_katakana_str[(int)enModePanel.ModePanel_Trial];
                    break;
                case enModePanel.ModePanel_Trial:
                    hira_kata_btn.Text = hiragana_katakana_str[(int)enModePanel.ModePanel_Hiragana_Katakana];
                    break;
                default:
                    break;
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
            panelOpenChill_pn.Controls.Add(childForm);
            panelOpenChill_pn.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void FormAlphabet_Load(object sender, EventArgs e)
        {
            buttonModeText();
            hiraganaAndKatakanaShowPanel();
        }

        private void hira_kata_btn_Click(object sender, EventArgs e)
        {
            buttonModeText();
            hiraganaAndKatakanaShowPanel();
        }
    }
}
