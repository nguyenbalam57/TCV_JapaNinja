namespace TCV_JapaNinja.Forms.Study.Kanji
{
    partial class FormKanji
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
            this.chillformKanji_pn = new System.Windows.Forms.Panel();
            this.lessonNumber_flpn = new System.Windows.Forms.FlowLayoutPanel();
            this.level_flpn = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // chillformKanji_pn
            // 
            this.chillformKanji_pn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chillformKanji_pn.Location = new System.Drawing.Point(1, 95);
            this.chillformKanji_pn.Name = "chillformKanji_pn";
            this.chillformKanji_pn.Size = new System.Drawing.Size(1064, 459);
            this.chillformKanji_pn.TabIndex = 8;
            // 
            // lessonNumber_flpn
            // 
            this.lessonNumber_flpn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lessonNumber_flpn.AutoScroll = true;
            this.lessonNumber_flpn.Location = new System.Drawing.Point(134, 1);
            this.lessonNumber_flpn.Margin = new System.Windows.Forms.Padding(4);
            this.lessonNumber_flpn.Name = "lessonNumber_flpn";
            this.lessonNumber_flpn.Size = new System.Drawing.Size(931, 87);
            this.lessonNumber_flpn.TabIndex = 7;
            // 
            // level_flpn
            // 
            this.level_flpn.AutoScroll = true;
            this.level_flpn.Location = new System.Drawing.Point(1, 1);
            this.level_flpn.Margin = new System.Windows.Forms.Padding(4);
            this.level_flpn.Name = "level_flpn";
            this.level_flpn.Size = new System.Drawing.Size(125, 87);
            this.level_flpn.TabIndex = 5;
            // 
            // FormKanji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.chillformKanji_pn);
            this.Controls.Add(this.lessonNumber_flpn);
            this.Controls.Add(this.level_flpn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormKanji";
            this.Text = "FormKanji";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel chillformKanji_pn;
        private System.Windows.Forms.FlowLayoutPanel lessonNumber_flpn;
        private System.Windows.Forms.FlowLayoutPanel level_flpn;
    }
}