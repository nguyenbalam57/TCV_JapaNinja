namespace TCV_JapaNinja.Forms.Login
{
    partial class FormLogin
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
            this.logo_ptb = new FontAwesome.Sharp.IconPictureBox();
            this.user_ptb = new FontAwesome.Sharp.IconPictureBox();
            this.lock_ptb = new FontAwesome.Sharp.IconPictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userName_tb = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.password_tb = new System.Windows.Forms.TextBox();
            this.eye_ptb = new FontAwesome.Sharp.IconButton();
            this.login_btn = new FontAwesome.Sharp.IconButton();
            this.language_cbb = new System.Windows.Forms.ComboBox();
            this.exit_btn = new FontAwesome.Sharp.IconButton();
            this.minus_btn = new FontAwesome.Sharp.IconButton();
            this.loadingProgressBar = new System.Windows.Forms.ProgressBar();
            this.sataEllipseControl1 = new SATAUiFramework.Controls.SATAEllipseControl();
            ((System.ComponentModel.ISupportInitialize)(this.logo_ptb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_ptb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lock_ptb)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // logo_ptb
            // 
            this.logo_ptb.BackColor = System.Drawing.Color.WhiteSmoke;
            this.logo_ptb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.logo_ptb.IconChar = FontAwesome.Sharp.IconChar.Language;
            this.logo_ptb.IconColor = System.Drawing.SystemColors.ControlText;
            this.logo_ptb.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.logo_ptb.IconSize = 384;
            this.logo_ptb.Location = new System.Drawing.Point(0, 0);
            this.logo_ptb.Margin = new System.Windows.Forms.Padding(4);
            this.logo_ptb.Name = "logo_ptb";
            this.logo_ptb.Size = new System.Drawing.Size(384, 414);
            this.logo_ptb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.logo_ptb.TabIndex = 0;
            this.logo_ptb.TabStop = false;
            // 
            // user_ptb
            // 
            this.user_ptb.BackColor = System.Drawing.Color.White;
            this.user_ptb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.user_ptb.IconChar = FontAwesome.Sharp.IconChar.User;
            this.user_ptb.IconColor = System.Drawing.SystemColors.ControlText;
            this.user_ptb.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.user_ptb.IconSize = 66;
            this.user_ptb.Location = new System.Drawing.Point(1, 0);
            this.user_ptb.Margin = new System.Windows.Forms.Padding(0);
            this.user_ptb.Name = "user_ptb";
            this.user_ptb.Size = new System.Drawing.Size(88, 66);
            this.user_ptb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.user_ptb.TabIndex = 1;
            this.user_ptb.TabStop = false;
            // 
            // lock_ptb
            // 
            this.lock_ptb.BackColor = System.Drawing.Color.White;
            this.lock_ptb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lock_ptb.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.lock_ptb.IconColor = System.Drawing.SystemColors.ControlText;
            this.lock_ptb.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.lock_ptb.IconSize = 66;
            this.lock_ptb.Location = new System.Drawing.Point(1, 0);
            this.lock_ptb.Margin = new System.Windows.Forms.Padding(0);
            this.lock_ptb.Name = "lock_ptb";
            this.lock_ptb.Size = new System.Drawing.Size(88, 66);
            this.lock_ptb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.lock_ptb.TabIndex = 2;
            this.lock_ptb.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.userName_tb);
            this.panel1.Controls.Add(this.user_ptb);
            this.panel1.Location = new System.Drawing.Point(383, 134);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 66);
            this.panel1.TabIndex = 6;
            // 
            // userName_tb
            // 
            this.userName_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userName_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.userName_tb.Location = new System.Drawing.Point(92, 15);
            this.userName_tb.Margin = new System.Windows.Forms.Padding(4);
            this.userName_tb.Name = "userName_tb";
            this.userName_tb.Size = new System.Drawing.Size(539, 31);
            this.userName_tb.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.password_tb);
            this.panel2.Controls.Add(this.eye_ptb);
            this.panel2.Controls.Add(this.lock_ptb);
            this.panel2.Location = new System.Drawing.Point(383, 208);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(645, 66);
            this.panel2.TabIndex = 7;
            // 
            // password_tb
            // 
            this.password_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.password_tb.Location = new System.Drawing.Point(92, 15);
            this.password_tb.Margin = new System.Windows.Forms.Padding(4);
            this.password_tb.Name = "password_tb";
            this.password_tb.PasswordChar = '*';
            this.password_tb.Size = new System.Drawing.Size(476, 31);
            this.password_tb.TabIndex = 3;
            // 
            // eye_ptb
            // 
            this.eye_ptb.FlatAppearance.BorderSize = 0;
            this.eye_ptb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eye_ptb.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.eye_ptb.IconColor = System.Drawing.Color.Black;
            this.eye_ptb.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.eye_ptb.Location = new System.Drawing.Point(572, 1);
            this.eye_ptb.Margin = new System.Windows.Forms.Padding(0);
            this.eye_ptb.Name = "eye_ptb";
            this.eye_ptb.Size = new System.Drawing.Size(72, 64);
            this.eye_ptb.TabIndex = 4;
            this.eye_ptb.UseVisualStyleBackColor = true;
            this.eye_ptb.Click += new System.EventHandler(this.eye_ptb_Click);
            // 
            // login_btn
            // 
            this.login_btn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.login_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.login_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.login_btn.IconColor = System.Drawing.Color.Black;
            this.login_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.login_btn.Location = new System.Drawing.Point(475, 299);
            this.login_btn.Margin = new System.Windows.Forms.Padding(4);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(476, 52);
            this.login_btn.TabIndex = 9;
            this.login_btn.Text = "Login";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // language_cbb
            // 
            this.language_cbb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.language_cbb.FormattingEnabled = true;
            this.language_cbb.Location = new System.Drawing.Point(865, 75);
            this.language_cbb.Margin = new System.Windows.Forms.Padding(4);
            this.language_cbb.Name = "language_cbb";
            this.language_cbb.Size = new System.Drawing.Size(160, 28);
            this.language_cbb.TabIndex = 11;
            this.language_cbb.SelectedIndexChanged += new System.EventHandler(this.language_cbb_SelectedIndexChanged);
            // 
            // exit_btn
            // 
            this.exit_btn.FlatAppearance.BorderSize = 0;
            this.exit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit_btn.IconChar = FontAwesome.Sharp.IconChar.X;
            this.exit_btn.IconColor = System.Drawing.Color.Black;
            this.exit_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.exit_btn.IconSize = 25;
            this.exit_btn.Location = new System.Drawing.Point(948, 1);
            this.exit_btn.Margin = new System.Windows.Forms.Padding(0);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(80, 31);
            this.exit_btn.TabIndex = 12;
            this.exit_btn.UseVisualStyleBackColor = true;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            this.exit_btn.MouseEnter += new System.EventHandler(this.exit_btn_MouseEnter);
            this.exit_btn.MouseLeave += new System.EventHandler(this.exit_btn_MouseLeave);
            // 
            // minus_btn
            // 
            this.minus_btn.FlatAppearance.BorderSize = 0;
            this.minus_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minus_btn.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.minus_btn.IconColor = System.Drawing.Color.Black;
            this.minus_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.minus_btn.IconSize = 25;
            this.minus_btn.Location = new System.Drawing.Point(868, 1);
            this.minus_btn.Margin = new System.Windows.Forms.Padding(0);
            this.minus_btn.Name = "minus_btn";
            this.minus_btn.Size = new System.Drawing.Size(80, 31);
            this.minus_btn.TabIndex = 13;
            this.minus_btn.UseVisualStyleBackColor = true;
            this.minus_btn.Visible = false;
            this.minus_btn.MouseEnter += new System.EventHandler(this.minus_btn_MouseEnter);
            this.minus_btn.MouseLeave += new System.EventHandler(this.minus_btn_MouseLeave);
            // 
            // loadingProgressBar
            // 
            this.loadingProgressBar.Location = new System.Drawing.Point(475, 299);
            this.loadingProgressBar.Margin = new System.Windows.Forms.Padding(4);
            this.loadingProgressBar.Name = "loadingProgressBar";
            this.loadingProgressBar.Size = new System.Drawing.Size(476, 52);
            this.loadingProgressBar.TabIndex = 14;
            this.loadingProgressBar.Visible = false;
            // 
            // sataEllipseControl1
            // 
            this.sataEllipseControl1.CornerRadius = 25;
            this.sataEllipseControl1.TargetControl = this;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 412);
            this.Controls.Add(this.loadingProgressBar);
            this.Controls.Add(this.minus_btn);
            this.Controls.Add(this.exit_btn);
            this.Controls.Add(this.language_cbb);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.logo_ptb);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormLogin";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLogin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLogin_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.logo_ptb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_ptb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lock_ptb)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox logo_ptb;
        private FontAwesome.Sharp.IconPictureBox user_ptb;
        private FontAwesome.Sharp.IconPictureBox lock_ptb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton eye_ptb;
        private System.Windows.Forms.TextBox userName_tb;
        private System.Windows.Forms.TextBox password_tb;
        private FontAwesome.Sharp.IconButton login_btn;
        private System.Windows.Forms.ComboBox language_cbb;
        private FontAwesome.Sharp.IconButton exit_btn;
        private FontAwesome.Sharp.IconButton minus_btn;
        private System.Windows.Forms.ProgressBar loadingProgressBar;
        private SATAUiFramework.Controls.SATAEllipseControl sataEllipseControl1;
    }
}