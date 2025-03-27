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
using TCV_JapaNinja.Class;
using TCV_JapaNinja.Forms.Login;
using TCV_JapaNinja.Models.Account;

namespace TCV_JapaNinja
{
    public partial class TCV_JapaNinja_form : Form
    {
        private IconButton activeIconButton;
        private IconButton activeIconButtonLevel2;
        private Panel activePanelMenu;
        private Form activeForm;

        private string titleHome = "Home";
        private string titleNameLevel1 = "Home";
        private string titleNameLevel2 = string.Empty;

        public TCV_JapaNinja_form()
        {
            InitializeComponent();
            InitializeLoadForm();
            ConnectedData.LoadDataAllSQL();
            reset();
            setTextColorAll();
            setNameLabelAccount();
        }

        static TCV_JapaNinja_form _frmJPObj;
        public static TCV_JapaNinja_form FrmJPObj
        {
            get { return _frmJPObj; }
            set { _frmJPObj = value; }
        }
        private void TCV_JapaNinja_form_Load(object sender, EventArgs e)
        {
            FrmJPObj = this;
        }
        private void reset()
        {
            study_pn.Visible = false;
        }
        private void InitializeLoadForm()
        {
            // Button Admin Management
            string[] man = Accounts.manAccount.Concat(Accounts.manData).ToArray();
            admin_Management_btn.Visible = false;
            if(Accounts.UserLogin.HasRermission(man))
            {
                admin_Management_btn.Visible = true;
            }    
        }
        /// <summary>
        /// set color and name luc thay doi gia tri
        /// </summary>
        private void setTextColorAll()
        {
            /* set Color */
            /* menu backcolor */
            ResetAllControlsBackColor(left_Menu_pn);

            /*set name label*/
            /* learning */
            study_btn.Text = Languages.lableName[(int)Languages.enLableName.LabelName_Study, (int)Languages.LanguageIndex];
            /* learning */
            study_Alphabet_btn.Text = Languages.lableName[(int)Languages.enLableName.LabelName_Alphabet, (int)Languages.LanguageIndex];
            /* learning */
            study_Technical_btn.Text = Languages.lableName[(int)Languages.enLableName.LabelName_Technical, (int)Languages.LanguageIndex];
            study_Kanji_btn.Text = Languages.lableName[(int)Languages.enLableName.LabelName_Kanji, (int)Languages.LanguageIndex];
            study_Vocabulary_btn.Text = Languages.lableName[(int)Languages.enLableName.LabelName_Vocabulary, (int)Languages.LanguageIndex];
            study_Grammar_btn.Text = Languages.lableName[(int)Languages.enLableName.LabelName_Grammar, (int)Languages.LanguageIndex];

            /* trial */
            trial_btn.Text = Languages.lableName[(int)Languages.enLableName.LabelName_Trial, (int)Languages.LanguageIndex];

            /* test */
            test_btn.Text = Languages.lableName[(int)Languages.enLableName.LabelName_Test, (int)Languages.LanguageIndex];

            /* Expand */
            advanced_btn.Text = Languages.lableName[(int)Languages.enLableName.LabelName_Advanced, (int)Languages.LanguageIndex];

            /* admin mannagement */
            admin_Management_btn.Text = Languages.lableName[(int)Languages.enLableName.LabelName_Admin_Management, (int)Languages.LanguageIndex];

            /* evaluate */
            evaluate_btn.Text = Languages.lableName[(int)Languages.enLableName.LabelName_Evaluate, (int)Languages.LanguageIndex];
        }

        // Reset all the controls to the user's default Control color. 
        private void ResetAllControlsBackColor(Control control)
        {
            string name = control.ToString();
            if(name.Contains("IconButton") || name.Contains("Panel"))
            {
                control.BackColor = ColorTranslator.FromHtml(Colors.Color[(int)Colors.enColors.Color_BackgroundMenu, (int)Colors.ModeColorsIndex]);
                control.ForeColor = ColorTranslator.FromHtml(Colors.Color[(int)Colors.enColors.Color_IconButtonText, (int)Colors.ModeColorsIndex]);
                if(name.Contains("IconButton"))
                {
                    IconButton iconButton = (IconButton)control;
                    iconButton.IconColor = ColorTranslator.FromHtml(Colors.Color[(int)Colors.enColors.Color_IconButtonText, (int)Colors.ModeColorsIndex]);
                }
            }

            if (control.HasChildren)
            {
                // Recursively call this method for each child control.
                foreach (Control childControl in control.Controls)
                {
                    ResetAllControlsBackColor(childControl);
                }
            }
        }

        

        #region MENUBUTTONLEVEL1
        private void study_btn_Click(object sender, EventArgs e)
        {
            activeIconButtonMenu(sender, e);
        }

        private void trial_btn_Click(object sender, EventArgs e)
        {
            activeIconButtonMenu(sender, e);
            var frmTrial = (Forms.Trial.FormTrial)Application.OpenForms["FormTrial"];
            frmTrial?.Focus();
            if (frmTrial == null) { frmTrial = new Forms.Trial.FormTrial(); }
            /*hien thi*/
            openChildForm(frmTrial);
        }

        private void test_btn_Click(object sender, EventArgs e)
        {
            activeIconButtonMenu(sender, e);
            var frmTest = (Forms.Test.FormTest)Application.OpenForms["FormTest"];
            frmTest?.Focus();
            if (frmTest == null) { frmTest = new Forms.Test.FormTest(); }
            /*hien thi*/
            openChildForm(frmTest);
        }

        private void advanced_btn_Click(object sender, EventArgs e)
        {
            activeIconButtonMenu(sender, e);
            var frmAdvanced = (Forms.Advanced.FormAdvanced)Application.OpenForms["FormAdvanced"];
            frmAdvanced?.Focus();
            if (frmAdvanced == null) { frmAdvanced = new Forms.Advanced.FormAdvanced(); }
            /*hien thi*/
            openChildForm(frmAdvanced);
        }

        private void evaluate_btn_Click(object sender, EventArgs e)
        {
            activeIconButtonMenu(sender, e);
        }

        private void admin_Managent_btn_Click(object sender, EventArgs e)
        {
            activeIconButtonMenu(sender, e);
            var formAdmin = (Forms.Admin_Managent.admin_Management)Application.OpenForms["admin_Management"];
            formAdmin?.Focus();
            if(formAdmin == null) { formAdmin = new Forms.Admin_Managent.admin_Management(); }
            /*hien thi*/
            openChildForm(formAdmin);

        }

        private void activeIconButtonMenu(object sender, EventArgs e)
        {
            IconButton btn = (IconButton)sender;

            if (btn != null)
            {
                diactiveIconButtonMenu();
                activeIconButton = btn;
                activePanelMenu = pnActiver(sender);
                titleNameLevel1 = activeIconButton.Text;
                activeIconButton.ForeColor = ColorTranslator.FromHtml(Class.Colors.Color[(int)Class.Colors.enColors.Color_IconButtonTextActive, (int)Class.Colors.ModeColorsIndex]);
                activeIconButton.IconColor = ColorTranslator.FromHtml(Class.Colors.Color[(int)Class.Colors.enColors.Color_IconButtonTextActive, (int)Class.Colors.ModeColorsIndex]);
                activeIconButton.BackColor = ColorTranslator.FromHtml(Class.Colors.Color[(int)Class.Colors.enColors.Color_IconButtonActive, (int)Class.Colors.ModeColorsIndex]);
                activeIconButton.TextImageRelation = TextImageRelation.TextBeforeImage;

                if (activePanelMenu != null) activePanelMenu.Visible = true;
                else
                {
                    diactiveIconButtonLevel2();
                    home_Menu_btn.IconChar = activeIconButton.IconChar;
                    title_Hearder_lb.Text = titleNameLevel1;
                }
            }
        }
        /// <summary>
        /// clear active icon button menu
        /// </summary>
        private void diactiveIconButtonMenu()
        {
            if(activePanelMenu != null)
            {
                activePanelMenu.Visible = false;
            }

            if (activeIconButton != null)
            {
                activeIconButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                activeIconButton.ForeColor = ColorTranslator.FromHtml(Class.Colors.Color[(int)Class.Colors.enColors.Color_IconButtonText, (int)Class.Colors.ModeColorsIndex]);
                activeIconButton.IconColor = ColorTranslator.FromHtml(Class.Colors.Color[(int)Class.Colors.enColors.Color_IconButtonText, (int)Class.Colors.ModeColorsIndex]);
                activeIconButton.BackColor = ColorTranslator.FromHtml(Class.Colors.Color[(int)Class.Colors.enColors.Color_IconButton, (int)Class.Colors.ModeColorsIndex]);
            }
        }
        /// <summary>
        /// read panel active
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        private Panel pnActiver(object sender)
        {
            Panel rspn = null;
            IconButton btn = (IconButton)sender;
            switch (btn.Name)
            {
                case "study_btn":
                    rspn = study_pn;
                    break;
                default:
                    break;
            }
            return rspn;
        }
        #endregion
        

        #region MENUBUTTONLEVEL2

        private void study_Alphabet_btn_Click(object sender, EventArgs e)
        {
            ActiveIconButtonLevel2(sender, e);
            var frmAlphabet = (Forms.Study.Alphabet.FormAlphabet)Application.OpenForms["FormAlphabet"];
            frmAlphabet?.Focus();
            if (frmAlphabet == null) { frmAlphabet = new Forms.Study.Alphabet.FormAlphabet(); }
            /*hien thi*/
            openChildForm(frmAlphabet);
        }

        private void study_Technical_btn_Click(object sender, EventArgs e)
        {
            ActiveIconButtonLevel2(sender, e);
            var frmTechnical = (Forms.Study.Technical.FormTechnical)Application.OpenForms["FormTechnical"];
            frmTechnical?.Focus();
            if (frmTechnical == null) { frmTechnical = new Forms.Study.Technical.FormTechnical(); }
            /*hien thi*/
            openChildForm(frmTechnical);
        }

        private void study_Kanji_btn_Click(object sender, EventArgs e)
        {
            ActiveIconButtonLevel2(sender, e);
            var frmKanji = (Forms.Study.Kanji.FormKanji)Application.OpenForms["FormKanji"];
            frmKanji?.Focus();
            if (frmKanji == null) { frmKanji = new Forms.Study.Kanji.FormKanji(); }
            /*hien thi*/
            openChildForm(frmKanji);
        }
        private void study_Vocabulary_btn_Click(object sender, EventArgs e)
        {
            ActiveIconButtonLevel2(sender, e);
            var frmKanji = (Forms.Study.Kanji.FormKanji)Application.OpenForms["FormKanji"];
            frmKanji?.Focus();
            if (frmKanji == null) { frmKanji = new Forms.Study.Kanji.FormKanji(); }
            /*hien thi*/
            openChildForm(frmKanji);
        }

        private void study_Grammar_btn_Click(object sender, EventArgs e)
        {
            ActiveIconButtonLevel2(sender, e);
            var frmKanji = (Forms.Study.Kanji.FormKanji)Application.OpenForms["FormKanji"];
            frmKanji?.Focus();
            if (frmKanji == null) { frmKanji = new Forms.Study.Kanji.FormKanji(); }
            /*hien thi*/
            openChildForm(frmKanji);
        }


        private void ActiveIconButtonLevel2(object sender, EventArgs e)
        {
            IconButton btn = (IconButton)sender;
            if (btn != null)
            {
                diactiveIconButtonLevel2();
                activeIconButtonLevel2 = btn;
                home_Menu_btn.IconChar = activeIconButton.IconChar;
                title_Hearder_lb.Text = titleNameLevel1 + " >> " + activeIconButtonLevel2.Text;
                activeIconButtonLevel2.TextImageRelation = TextImageRelation.TextBeforeImage;
                activeIconButtonLevel2.ForeColor = ColorTranslator.FromHtml(Class.Colors.Color[(int)Class.Colors.enColors.Color_IconButtonTextActive, (int)Class.Colors.ModeColorsIndex]);
                activeIconButtonLevel2.IconColor = ColorTranslator.FromHtml(Class.Colors.Color[(int)Class.Colors.enColors.Color_IconButtonTextActive, (int)Class.Colors.ModeColorsIndex]);
                activeIconButtonLevel2.BackColor = ColorTranslator.FromHtml(Class.Colors.Color[(int)Class.Colors.enColors.Color_IconButtonLevel2Active, (int)Class.Colors.ModeColorsIndex]);
            }
        }
        private void diactiveIconButtonLevel2()
        {
            if (activeIconButtonLevel2 != null)
            {
                activeIconButtonLevel2.TextImageRelation = TextImageRelation.ImageBeforeText;
                activeIconButtonLevel2.ForeColor = ColorTranslator.FromHtml(Class.Colors.Color[(int)Class.Colors.enColors.Color_IconButtonText, (int)Class.Colors.ModeColorsIndex]);
                activeIconButtonLevel2.IconColor = ColorTranslator.FromHtml(Class.Colors.Color[(int)Class.Colors.enColors.Color_IconButtonText, (int)Class.Colors.ModeColorsIndex]);
                activeIconButtonLevel2.BackColor = ColorTranslator.FromHtml(Class.Colors.Color[(int)Class.Colors.enColors.Color_IconButtonLevel2, (int)Class.Colors.ModeColorsIndex]);
            }
        }

        /// <summary>
        /// screen 
        /// </summary>
        /// <param name="childForm"></param>
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                if (activeForm == childForm) return;
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm_pn.Controls.Add(childForm);
            childForm_pn.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        #endregion

        private void logout_btn_Click(object sender, EventArgs e)
        {
            var formLogin = (FormLogin)Application.OpenForms["FormLogin"];
            this.Hide();
            Accounts.clearAccountLogin();
            if (formLogin == null)
            {
                formLogin = new FormLogin();
                formLogin.Show();
            }
            else
            {
                formLogin.WindowState = FormWindowState.Normal;
                formLogin.Show();
            }
        }

        private void TCV_JapaNinja_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            var formLogin = (FormLogin)Application.OpenForms["FormLogin"];
            if(formLogin != null)
            {
                // khi thực hiện đóng form sẽ loại bỏ user đăng nhập
                Accounts.clearAccountLogin();
                formLogin.Close();
            }
        }

        public static void SetNameAccount()
        {
            FrmJPObj.setNameLabelAccount();
        }

        public void setNameLabelAccount()
        {
            Accounts.vdScreenNameAccount(nameAccount_lb);
        }

        
    }
}
