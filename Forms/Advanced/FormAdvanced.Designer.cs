namespace TCV_JapaNinja.Forms.Advanced
{
    partial class FormAdvanced
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
            this.advanced_btn = new System.Windows.Forms.Button();
            this.chillformAdvanced_pn = new System.Windows.Forms.Panel();
            this.level_btn = new System.Windows.Forms.Button();
            this.advanced_flpn = new System.Windows.Forms.FlowLayoutPanel();
            this.level_flpn = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // advanced_btn
            // 
            this.advanced_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.advanced_btn.Location = new System.Drawing.Point(95, 504);
            this.advanced_btn.Name = "advanced_btn";
            this.advanced_btn.Size = new System.Drawing.Size(88, 48);
            this.advanced_btn.TabIndex = 16;
            this.advanced_btn.Text = "Regiter Year";
            this.advanced_btn.UseVisualStyleBackColor = true;
            this.advanced_btn.Click += new System.EventHandler(this.advanced_Click);
            // 
            // chillformAdvanced_pn
            // 
            this.chillformAdvanced_pn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chillformAdvanced_pn.Location = new System.Drawing.Point(1, 96);
            this.chillformAdvanced_pn.Name = "chillformAdvanced_pn";
            this.chillformAdvanced_pn.Size = new System.Drawing.Size(1064, 402);
            this.chillformAdvanced_pn.TabIndex = 18;
            // 
            // level_btn
            // 
            this.level_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.level_btn.Location = new System.Drawing.Point(1, 504);
            this.level_btn.Name = "level_btn";
            this.level_btn.Size = new System.Drawing.Size(88, 48);
            this.level_btn.TabIndex = 14;
            this.level_btn.Text = "Regiter Level";
            this.level_btn.UseVisualStyleBackColor = true;
            this.level_btn.Click += new System.EventHandler(this.group_btn_Click);
            // 
            // advanced_flpn
            // 
            this.advanced_flpn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advanced_flpn.AutoScroll = true;
            this.advanced_flpn.Location = new System.Drawing.Point(134, 2);
            this.advanced_flpn.Margin = new System.Windows.Forms.Padding(4);
            this.advanced_flpn.Name = "advanced_flpn";
            this.advanced_flpn.Size = new System.Drawing.Size(931, 87);
            this.advanced_flpn.TabIndex = 17;
            // 
            // level_flpn
            // 
            this.level_flpn.AutoScroll = true;
            this.level_flpn.Location = new System.Drawing.Point(1, 2);
            this.level_flpn.Margin = new System.Windows.Forms.Padding(4);
            this.level_flpn.Name = "level_flpn";
            this.level_flpn.Size = new System.Drawing.Size(125, 87);
            this.level_flpn.TabIndex = 15;
            // 
            // FormAdvanced
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.advanced_btn);
            this.Controls.Add(this.chillformAdvanced_pn);
            this.Controls.Add(this.level_btn);
            this.Controls.Add(this.advanced_flpn);
            this.Controls.Add(this.level_flpn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormAdvanced";
            this.Text = "FormAdvanced";
            this.Load += new System.EventHandler(this.FormKanji_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button advanced_btn;
        private System.Windows.Forms.Panel chillformAdvanced_pn;
        private System.Windows.Forms.Button level_btn;
        private System.Windows.Forms.FlowLayoutPanel advanced_flpn;
        private System.Windows.Forms.FlowLayoutPanel level_flpn;
    }
}