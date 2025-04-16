namespace TCV_JapaNinja
{
    partial class TCV_JapaNinja
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCV_JapaNinja));
            this.top_Main_pn = new System.Windows.Forms.Panel();
            this.image_User_icpt = new FontAwesome.Sharp.IconPictureBox();
            this.login_ctmnstrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.show_Menu_btn = new FontAwesome.Sharp.IconButton();
            this.nameAccount_lb = new System.Windows.Forms.Label();
            this.buttom_Main_pn = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.left_Main_pn = new System.Windows.Forms.Panel();
            this.menu_flpn = new System.Windows.Forms.FlowLayoutPanel();
            this.study_btn = new FontAwesome.Sharp.IconButton();
            this.trial_btn = new FontAwesome.Sharp.IconButton();
            this.test_btn = new FontAwesome.Sharp.IconButton();
            this.advanced_btn = new FontAwesome.Sharp.IconButton();
            this.admin_Management_btn = new FontAwesome.Sharp.IconButton();
            this.evaluate_btn = new FontAwesome.Sharp.IconButton();
            this.logo_pn = new System.Windows.Forms.Panel();
            this.logo_pt = new System.Windows.Forms.PictureBox();
            this.right_Main_pn = new System.Windows.Forms.Panel();
            this.chillForm_Main_pn = new System.Windows.Forms.Panel();
            this.menu_pn = new System.Windows.Forms.Panel();
            this.top_Main_pn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_User_icpt)).BeginInit();
            this.login_ctmnstrip.SuspendLayout();
            this.buttom_Main_pn.SuspendLayout();
            this.left_Main_pn.SuspendLayout();
            this.menu_flpn.SuspendLayout();
            this.logo_pn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo_pt)).BeginInit();
            this.menu_pn.SuspendLayout();
            this.SuspendLayout();
            // 
            // top_Main_pn
            // 
            this.top_Main_pn.BackColor = System.Drawing.Color.White;
            this.top_Main_pn.Controls.Add(this.image_User_icpt);
            this.top_Main_pn.Controls.Add(this.nameAccount_lb);
            this.top_Main_pn.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_Main_pn.Location = new System.Drawing.Point(0, 0);
            this.top_Main_pn.Margin = new System.Windows.Forms.Padding(0);
            this.top_Main_pn.Name = "top_Main_pn";
            this.top_Main_pn.Size = new System.Drawing.Size(1067, 39);
            this.top_Main_pn.TabIndex = 0;
            // 
            // image_User_icpt
            // 
            this.image_User_icpt.BackColor = System.Drawing.Color.White;
            this.image_User_icpt.ContextMenuStrip = this.login_ctmnstrip;
            this.image_User_icpt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.image_User_icpt.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.image_User_icpt.IconColor = System.Drawing.SystemColors.ControlText;
            this.image_User_icpt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.image_User_icpt.IconSize = 45;
            this.image_User_icpt.Location = new System.Drawing.Point(4, -1);
            this.image_User_icpt.Margin = new System.Windows.Forms.Padding(0);
            this.image_User_icpt.Name = "image_User_icpt";
            this.image_User_icpt.Size = new System.Drawing.Size(45, 45);
            this.image_User_icpt.TabIndex = 8;
            this.image_User_icpt.TabStop = false;
            // 
            // login_ctmnstrip
            // 
            this.login_ctmnstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem});
            this.login_ctmnstrip.Name = "login_ctmnstrip";
            this.login_ctmnstrip.Size = new System.Drawing.Size(118, 26);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.logoutToolStripMenuItem.Text = "Log Out";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // show_Menu_btn
            // 
            this.show_Menu_btn.FlatAppearance.BorderSize = 0;
            this.show_Menu_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.show_Menu_btn.IconChar = FontAwesome.Sharp.IconChar.Navicon;
            this.show_Menu_btn.IconColor = System.Drawing.Color.Black;
            this.show_Menu_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.show_Menu_btn.IconSize = 35;
            this.show_Menu_btn.Location = new System.Drawing.Point(4, -3);
            this.show_Menu_btn.Margin = new System.Windows.Forms.Padding(0);
            this.show_Menu_btn.Name = "show_Menu_btn";
            this.show_Menu_btn.Size = new System.Drawing.Size(35, 45);
            this.show_Menu_btn.TabIndex = 7;
            this.show_Menu_btn.UseVisualStyleBackColor = true;
            this.show_Menu_btn.Click += new System.EventHandler(this.show_Menu_btn_Click);
            // 
            // nameAccount_lb
            // 
            this.nameAccount_lb.AutoSize = true;
            this.nameAccount_lb.ContextMenuStrip = this.login_ctmnstrip;
            this.nameAccount_lb.Location = new System.Drawing.Point(58, 13);
            this.nameAccount_lb.Margin = new System.Windows.Forms.Padding(0);
            this.nameAccount_lb.Name = "nameAccount_lb";
            this.nameAccount_lb.Size = new System.Drawing.Size(45, 17);
            this.nameAccount_lb.TabIndex = 6;
            this.nameAccount_lb.Text = "Name";
            this.nameAccount_lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttom_Main_pn
            // 
            this.buttom_Main_pn.BackColor = System.Drawing.Color.White;
            this.buttom_Main_pn.Controls.Add(this.label1);
            this.buttom_Main_pn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttom_Main_pn.Location = new System.Drawing.Point(0, 636);
            this.buttom_Main_pn.Margin = new System.Windows.Forms.Padding(0);
            this.buttom_Main_pn.Name = "buttom_Main_pn";
            this.buttom_Main_pn.Size = new System.Drawing.Size(1067, 25);
            this.buttom_Main_pn.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(993, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Copyright";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // left_Main_pn
            // 
            this.left_Main_pn.BackColor = System.Drawing.Color.White;
            this.left_Main_pn.Controls.Add(this.menu_flpn);
            this.left_Main_pn.Controls.Add(this.logo_pn);
            this.left_Main_pn.Controls.Add(this.menu_pn);
            this.left_Main_pn.Dock = System.Windows.Forms.DockStyle.Left;
            this.left_Main_pn.Location = new System.Drawing.Point(0, 39);
            this.left_Main_pn.Margin = new System.Windows.Forms.Padding(0);
            this.left_Main_pn.Name = "left_Main_pn";
            this.left_Main_pn.Size = new System.Drawing.Size(200, 597);
            this.left_Main_pn.TabIndex = 2;
            // 
            // menu_flpn
            // 
            this.menu_flpn.BackColor = System.Drawing.Color.White;
            this.menu_flpn.Controls.Add(this.study_btn);
            this.menu_flpn.Controls.Add(this.trial_btn);
            this.menu_flpn.Controls.Add(this.test_btn);
            this.menu_flpn.Controls.Add(this.advanced_btn);
            this.menu_flpn.Controls.Add(this.admin_Management_btn);
            this.menu_flpn.Controls.Add(this.evaluate_btn);
            this.menu_flpn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menu_flpn.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.menu_flpn.Location = new System.Drawing.Point(0, 136);
            this.menu_flpn.Margin = new System.Windows.Forms.Padding(0);
            this.menu_flpn.Name = "menu_flpn";
            this.menu_flpn.Size = new System.Drawing.Size(200, 461);
            this.menu_flpn.TabIndex = 2;
            // 
            // study_btn
            // 
            this.study_btn.FlatAppearance.BorderSize = 0;
            this.study_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.study_btn.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.study_btn.IconChar = FontAwesome.Sharp.IconChar.MortarBoard;
            this.study_btn.IconColor = System.Drawing.Color.Black;
            this.study_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.study_btn.IconSize = 35;
            this.study_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.study_btn.Location = new System.Drawing.Point(0, 0);
            this.study_btn.Margin = new System.Windows.Forms.Padding(0);
            this.study_btn.Name = "study_btn";
            this.study_btn.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.study_btn.Size = new System.Drawing.Size(248, 59);
            this.study_btn.TabIndex = 0;
            this.study_btn.Text = "Study";
            this.study_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.study_btn.UseVisualStyleBackColor = false;
            this.study_btn.Click += new System.EventHandler(this.study_btn_Click);
            // 
            // trial_btn
            // 
            this.trial_btn.FlatAppearance.BorderSize = 0;
            this.trial_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.trial_btn.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trial_btn.IconChar = FontAwesome.Sharp.IconChar.CircleCheck;
            this.trial_btn.IconColor = System.Drawing.Color.Black;
            this.trial_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.trial_btn.IconSize = 35;
            this.trial_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.trial_btn.Location = new System.Drawing.Point(0, 59);
            this.trial_btn.Margin = new System.Windows.Forms.Padding(0);
            this.trial_btn.Name = "trial_btn";
            this.trial_btn.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.trial_btn.Size = new System.Drawing.Size(248, 59);
            this.trial_btn.TabIndex = 2;
            this.trial_btn.Text = "Trial";
            this.trial_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.trial_btn.UseVisualStyleBackColor = true;
            this.trial_btn.Click += new System.EventHandler(this.trial_btn_Click);
            // 
            // test_btn
            // 
            this.test_btn.FlatAppearance.BorderSize = 0;
            this.test_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.test_btn.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.test_btn.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
            this.test_btn.IconColor = System.Drawing.Color.Black;
            this.test_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.test_btn.IconSize = 35;
            this.test_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.test_btn.Location = new System.Drawing.Point(0, 118);
            this.test_btn.Margin = new System.Windows.Forms.Padding(0);
            this.test_btn.Name = "test_btn";
            this.test_btn.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.test_btn.Size = new System.Drawing.Size(248, 59);
            this.test_btn.TabIndex = 3;
            this.test_btn.Text = "Test";
            this.test_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.test_btn.UseVisualStyleBackColor = true;
            this.test_btn.Click += new System.EventHandler(this.test_btn_Click);
            // 
            // advanced_btn
            // 
            this.advanced_btn.FlatAppearance.BorderSize = 0;
            this.advanced_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.advanced_btn.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advanced_btn.IconChar = FontAwesome.Sharp.IconChar.Perbyte;
            this.advanced_btn.IconColor = System.Drawing.Color.Black;
            this.advanced_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.advanced_btn.IconSize = 35;
            this.advanced_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.advanced_btn.Location = new System.Drawing.Point(0, 177);
            this.advanced_btn.Margin = new System.Windows.Forms.Padding(0);
            this.advanced_btn.Name = "advanced_btn";
            this.advanced_btn.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.advanced_btn.Size = new System.Drawing.Size(248, 59);
            this.advanced_btn.TabIndex = 4;
            this.advanced_btn.Text = "Advanced";
            this.advanced_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.advanced_btn.UseVisualStyleBackColor = true;
            this.advanced_btn.Click += new System.EventHandler(this.advanced_btn_Click);
            // 
            // admin_Management_btn
            // 
            this.admin_Management_btn.FlatAppearance.BorderSize = 0;
            this.admin_Management_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.admin_Management_btn.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_Management_btn.IconChar = FontAwesome.Sharp.IconChar.ScrewdriverWrench;
            this.admin_Management_btn.IconColor = System.Drawing.Color.Black;
            this.admin_Management_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.admin_Management_btn.IconSize = 35;
            this.admin_Management_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.admin_Management_btn.Location = new System.Drawing.Point(0, 236);
            this.admin_Management_btn.Margin = new System.Windows.Forms.Padding(0);
            this.admin_Management_btn.Name = "admin_Management_btn";
            this.admin_Management_btn.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.admin_Management_btn.Size = new System.Drawing.Size(248, 59);
            this.admin_Management_btn.TabIndex = 5;
            this.admin_Management_btn.Text = "Management";
            this.admin_Management_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.admin_Management_btn.UseVisualStyleBackColor = true;
            this.admin_Management_btn.Click += new System.EventHandler(this.admin_Managent_btn_Click);
            // 
            // evaluate_btn
            // 
            this.evaluate_btn.FlatAppearance.BorderSize = 0;
            this.evaluate_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.evaluate_btn.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.evaluate_btn.IconChar = FontAwesome.Sharp.IconChar.ChartSimple;
            this.evaluate_btn.IconColor = System.Drawing.Color.Black;
            this.evaluate_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.evaluate_btn.IconSize = 35;
            this.evaluate_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.evaluate_btn.Location = new System.Drawing.Point(0, 295);
            this.evaluate_btn.Margin = new System.Windows.Forms.Padding(0);
            this.evaluate_btn.Name = "evaluate_btn";
            this.evaluate_btn.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.evaluate_btn.Size = new System.Drawing.Size(248, 59);
            this.evaluate_btn.TabIndex = 6;
            this.evaluate_btn.Text = "Evaluate";
            this.evaluate_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.evaluate_btn.UseVisualStyleBackColor = true;
            this.evaluate_btn.Click += new System.EventHandler(this.evaluate_btn_Click);
            // 
            // logo_pn
            // 
            this.logo_pn.Controls.Add(this.logo_pt);
            this.logo_pn.Dock = System.Windows.Forms.DockStyle.Top;
            this.logo_pn.Location = new System.Drawing.Point(0, 35);
            this.logo_pn.Margin = new System.Windows.Forms.Padding(0);
            this.logo_pn.Name = "logo_pn";
            this.logo_pn.Size = new System.Drawing.Size(200, 101);
            this.logo_pn.TabIndex = 1;
            // 
            // logo_pt
            // 
            this.logo_pt.BackColor = System.Drawing.Color.White;
            this.logo_pt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logo_pt.Image = ((System.Drawing.Image)(resources.GetObject("logo_pt.Image")));
            this.logo_pt.InitialImage = ((System.Drawing.Image)(resources.GetObject("logo_pt.InitialImage")));
            this.logo_pt.Location = new System.Drawing.Point(0, 0);
            this.logo_pt.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.logo_pt.Name = "logo_pt";
            this.logo_pt.Size = new System.Drawing.Size(200, 101);
            this.logo_pt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo_pt.TabIndex = 0;
            this.logo_pt.TabStop = false;
            // 
            // right_Main_pn
            // 
            this.right_Main_pn.BackColor = System.Drawing.Color.White;
            this.right_Main_pn.Dock = System.Windows.Forms.DockStyle.Right;
            this.right_Main_pn.Location = new System.Drawing.Point(1017, 39);
            this.right_Main_pn.Margin = new System.Windows.Forms.Padding(0);
            this.right_Main_pn.Name = "right_Main_pn";
            this.right_Main_pn.Size = new System.Drawing.Size(50, 597);
            this.right_Main_pn.TabIndex = 3;
            this.right_Main_pn.Visible = false;
            // 
            // chillForm_Main_pn
            // 
            this.chillForm_Main_pn.BackColor = System.Drawing.Color.White;
            this.chillForm_Main_pn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chillForm_Main_pn.Location = new System.Drawing.Point(200, 39);
            this.chillForm_Main_pn.Name = "chillForm_Main_pn";
            this.chillForm_Main_pn.Size = new System.Drawing.Size(817, 597);
            this.chillForm_Main_pn.TabIndex = 1;
            // 
            // menu_pn
            // 
            this.menu_pn.Controls.Add(this.show_Menu_btn);
            this.menu_pn.Dock = System.Windows.Forms.DockStyle.Top;
            this.menu_pn.Location = new System.Drawing.Point(0, 0);
            this.menu_pn.Name = "menu_pn";
            this.menu_pn.Size = new System.Drawing.Size(200, 35);
            this.menu_pn.TabIndex = 0;
            // 
            // TCV_JapaNinja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1067, 661);
            this.Controls.Add(this.chillForm_Main_pn);
            this.Controls.Add(this.right_Main_pn);
            this.Controls.Add(this.left_Main_pn);
            this.Controls.Add(this.buttom_Main_pn);
            this.Controls.Add(this.top_Main_pn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TCV_JapaNinja";
            this.Text = "TCV_JapaNinja";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TCV_JapaNinja_FormClosed);
            this.Load += new System.EventHandler(this.TCV_JapaNinja_Load);
            this.top_Main_pn.ResumeLayout(false);
            this.top_Main_pn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_User_icpt)).EndInit();
            this.login_ctmnstrip.ResumeLayout(false);
            this.buttom_Main_pn.ResumeLayout(false);
            this.buttom_Main_pn.PerformLayout();
            this.left_Main_pn.ResumeLayout(false);
            this.menu_flpn.ResumeLayout(false);
            this.logo_pn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo_pt)).EndInit();
            this.menu_pn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel top_Main_pn;
        private System.Windows.Forms.Panel buttom_Main_pn;
        private System.Windows.Forms.Panel left_Main_pn;
        private System.Windows.Forms.Panel right_Main_pn;
        private System.Windows.Forms.Panel chillForm_Main_pn;
        private System.Windows.Forms.FlowLayoutPanel menu_flpn;
        private FontAwesome.Sharp.IconButton study_btn;
        private FontAwesome.Sharp.IconButton trial_btn;
        private FontAwesome.Sharp.IconButton test_btn;
        private FontAwesome.Sharp.IconButton advanced_btn;
        private FontAwesome.Sharp.IconButton admin_Management_btn;
        private FontAwesome.Sharp.IconButton evaluate_btn;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton show_Menu_btn;
        private System.Windows.Forms.Label nameAccount_lb;
        private System.Windows.Forms.Panel logo_pn;
        private System.Windows.Forms.PictureBox logo_pt;
        private FontAwesome.Sharp.IconPictureBox image_User_icpt;
        private System.Windows.Forms.ContextMenuStrip login_ctmnstrip;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.Panel menu_pn;
    }
}