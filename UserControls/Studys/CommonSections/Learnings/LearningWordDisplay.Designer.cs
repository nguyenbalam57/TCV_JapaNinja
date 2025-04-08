namespace TCV_JapaNinja.UserControls.Studys.CommonSections.Learnings
{
    partial class LearningWordDisplay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.vocabulary_lb = new System.Windows.Forms.Label();
            this.phienAm_lb = new System.Windows.Forms.Label();
            this.meaning_lb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // vocabulary_lb
            // 
            this.vocabulary_lb.AutoSize = true;
            this.vocabulary_lb.Location = new System.Drawing.Point(31, 19);
            this.vocabulary_lb.Name = "vocabulary_lb";
            this.vocabulary_lb.Size = new System.Drawing.Size(79, 17);
            this.vocabulary_lb.TabIndex = 0;
            this.vocabulary_lb.Text = "Vocabulary";
            // 
            // phienAm_lb
            // 
            this.phienAm_lb.AutoSize = true;
            this.phienAm_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phienAm_lb.Location = new System.Drawing.Point(43, 42);
            this.phienAm_lb.Name = "phienAm_lb";
            this.phienAm_lb.Size = new System.Drawing.Size(60, 15);
            this.phienAm_lb.TabIndex = 0;
            this.phienAm_lb.Text = "Phiên âm";
            // 
            // meaning_lb
            // 
            this.meaning_lb.AutoSize = true;
            this.meaning_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meaning_lb.Location = new System.Drawing.Point(31, 65);
            this.meaning_lb.Name = "meaning_lb";
            this.meaning_lb.Size = new System.Drawing.Size(95, 22);
            this.meaning_lb.TabIndex = 0;
            this.meaning_lb.Text = "Dịch nghĩa";
            // 
            // LearningWordDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.meaning_lb);
            this.Controls.Add(this.phienAm_lb);
            this.Controls.Add(this.vocabulary_lb);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "LearningWordDisplay";
            this.Size = new System.Drawing.Size(318, 108);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label vocabulary_lb;
        public System.Windows.Forms.Label phienAm_lb;
        public System.Windows.Forms.Label meaning_lb;
    }
}
