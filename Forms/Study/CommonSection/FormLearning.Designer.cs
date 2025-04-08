namespace TCV_JapaNinja.Forms.Study.CommonSection
{
    partial class FormLearning
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
            this.viewVocabulary_flpn = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // viewVocabulary_flpn
            // 
            this.viewVocabulary_flpn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewVocabulary_flpn.AutoScroll = true;
            this.viewVocabulary_flpn.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.viewVocabulary_flpn.Location = new System.Drawing.Point(0, 0);
            this.viewVocabulary_flpn.Margin = new System.Windows.Forms.Padding(0);
            this.viewVocabulary_flpn.Name = "viewVocabulary_flpn";
            this.viewVocabulary_flpn.Size = new System.Drawing.Size(1067, 554);
            this.viewVocabulary_flpn.TabIndex = 0;
            // 
            // FormLearning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.viewVocabulary_flpn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormLearning";
            this.Text = "FormLearning";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel viewVocabulary_flpn;
    }
}