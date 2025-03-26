namespace TCV_JapaNinja.Forms.Study.Technical
{
    partial class FormTechnical
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
            this.groups_flpn = new System.Windows.Forms.FlowLayoutPanel();
            this.numVocas_flpn = new System.Windows.Forms.FlowLayoutPanel();
            this.chillformTechnical_pn = new System.Windows.Forms.Panel();
            this.group_btn = new System.Windows.Forms.Button();
            this.Vocabulary = new System.Windows.Forms.Button();
            this.levels_flpn = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // groups_flpn
            // 
            this.groups_flpn.AutoScroll = true;
            this.groups_flpn.Location = new System.Drawing.Point(3, 2);
            this.groups_flpn.Margin = new System.Windows.Forms.Padding(4);
            this.groups_flpn.Name = "groups_flpn";
            this.groups_flpn.Size = new System.Drawing.Size(125, 87);
            this.groups_flpn.TabIndex = 0;
            // 
            // numVocas_flpn
            // 
            this.numVocas_flpn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numVocas_flpn.AutoScroll = true;
            this.numVocas_flpn.Location = new System.Drawing.Point(269, 2);
            this.numVocas_flpn.Margin = new System.Windows.Forms.Padding(4);
            this.numVocas_flpn.Name = "numVocas_flpn";
            this.numVocas_flpn.Size = new System.Drawing.Size(839, 87);
            this.numVocas_flpn.TabIndex = 1;
            // 
            // chillformTechnical_pn
            // 
            this.chillformTechnical_pn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chillformTechnical_pn.Location = new System.Drawing.Point(3, 96);
            this.chillformTechnical_pn.Name = "chillformTechnical_pn";
            this.chillformTechnical_pn.Size = new System.Drawing.Size(1105, 402);
            this.chillformTechnical_pn.TabIndex = 3;
            // 
            // group_btn
            // 
            this.group_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.group_btn.Location = new System.Drawing.Point(3, 504);
            this.group_btn.Name = "group_btn";
            this.group_btn.Size = new System.Drawing.Size(88, 48);
            this.group_btn.TabIndex = 0;
            this.group_btn.Text = "Regiter Group";
            this.group_btn.UseVisualStyleBackColor = true;
            this.group_btn.Click += new System.EventHandler(this.group_btn_Click);
            // 
            // Vocabulary
            // 
            this.Vocabulary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Vocabulary.Location = new System.Drawing.Point(97, 504);
            this.Vocabulary.Name = "Vocabulary";
            this.Vocabulary.Size = new System.Drawing.Size(88, 48);
            this.Vocabulary.TabIndex = 1;
            this.Vocabulary.Text = "Regiter Vocabulary";
            this.Vocabulary.UseVisualStyleBackColor = true;
            this.Vocabulary.Click += new System.EventHandler(this.Vocabulary_Click);
            // 
            // levels_flpn
            // 
            this.levels_flpn.AutoScroll = true;
            this.levels_flpn.Location = new System.Drawing.Point(136, 2);
            this.levels_flpn.Margin = new System.Windows.Forms.Padding(4);
            this.levels_flpn.Name = "levels_flpn";
            this.levels_flpn.Size = new System.Drawing.Size(125, 87);
            this.levels_flpn.TabIndex = 0;
            // 
            // FormTechnical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 554);
            this.Controls.Add(this.Vocabulary);
            this.Controls.Add(this.chillformTechnical_pn);
            this.Controls.Add(this.group_btn);
            this.Controls.Add(this.numVocas_flpn);
            this.Controls.Add(this.levels_flpn);
            this.Controls.Add(this.groups_flpn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormTechnical";
            this.Text = "FormTechnical";
            this.Load += new System.EventHandler(this.FormTechnical_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel groups_flpn;
        private System.Windows.Forms.FlowLayoutPanel numVocas_flpn;
        private System.Windows.Forms.Panel chillformTechnical_pn;
        private System.Windows.Forms.Button Vocabulary;
        private System.Windows.Forms.Button group_btn;
        private System.Windows.Forms.FlowLayoutPanel levels_flpn;
    }
}