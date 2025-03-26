namespace TCV_JapaNinja.Forms.Trial
{
    partial class FormTrial
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
            this.year_btn = new System.Windows.Forms.Button();
            this.chillformTrial_pn = new System.Windows.Forms.Panel();
            this.level_btn = new System.Windows.Forms.Button();
            this.year_flpn = new System.Windows.Forms.FlowLayoutPanel();
            this.level_flpn = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // year_btn
            // 
            this.year_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.year_btn.Location = new System.Drawing.Point(95, 504);
            this.year_btn.Name = "year_btn";
            this.year_btn.Size = new System.Drawing.Size(88, 48);
            this.year_btn.TabIndex = 11;
            this.year_btn.Text = "Regiter Year";
            this.year_btn.UseVisualStyleBackColor = true;
            this.year_btn.Click += new System.EventHandler(this.year_Click);
            // 
            // chillformTrial_pn
            // 
            this.chillformTrial_pn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chillformTrial_pn.Location = new System.Drawing.Point(1, 96);
            this.chillformTrial_pn.Name = "chillformTrial_pn";
            this.chillformTrial_pn.Size = new System.Drawing.Size(1064, 402);
            this.chillformTrial_pn.TabIndex = 13;
            // 
            // level_btn
            // 
            this.level_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.level_btn.Location = new System.Drawing.Point(1, 504);
            this.level_btn.Name = "level_btn";
            this.level_btn.Size = new System.Drawing.Size(88, 48);
            this.level_btn.TabIndex = 9;
            this.level_btn.Text = "Regiter Level";
            this.level_btn.UseVisualStyleBackColor = true;
            this.level_btn.Click += new System.EventHandler(this.level_btn_Click);
            // 
            // year_flpn
            // 
            this.year_flpn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.year_flpn.AutoScroll = true;
            this.year_flpn.Location = new System.Drawing.Point(134, 2);
            this.year_flpn.Margin = new System.Windows.Forms.Padding(4);
            this.year_flpn.Name = "year_flpn";
            this.year_flpn.Size = new System.Drawing.Size(931, 87);
            this.year_flpn.TabIndex = 12;
            // 
            // level_flpn
            // 
            this.level_flpn.AutoScroll = true;
            this.level_flpn.Location = new System.Drawing.Point(1, 2);
            this.level_flpn.Margin = new System.Windows.Forms.Padding(4);
            this.level_flpn.Name = "level_flpn";
            this.level_flpn.Size = new System.Drawing.Size(125, 87);
            this.level_flpn.TabIndex = 10;
            // 
            // FormTrial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.year_btn);
            this.Controls.Add(this.chillformTrial_pn);
            this.Controls.Add(this.level_btn);
            this.Controls.Add(this.year_flpn);
            this.Controls.Add(this.level_flpn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormTrial";
            this.Text = "Trial";
            this.Load += new System.EventHandler(this.FormTrial_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button year_btn;
        private System.Windows.Forms.Panel chillformTrial_pn;
        private System.Windows.Forms.Button level_btn;
        private System.Windows.Forms.FlowLayoutPanel year_flpn;
        private System.Windows.Forms.FlowLayoutPanel level_flpn;
    }
}