namespace TCV_JapaNinja.Forms.Admin_Management.InputDatabase
{
    partial class FormInputDatabase
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
            this.grammar_tb = new System.Windows.Forms.TextBox();
            this.dataGrammar_dgv = new System.Windows.Forms.DataGridView();
            this.grammar_btn = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.vocabulary_tb = new System.Windows.Forms.TextBox();
            this.dataVocabulary_dgv = new System.Windows.Forms.DataGridView();
            this.vocabulary_btn = new FontAwesome.Sharp.IconButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.kanji_tb = new System.Windows.Forms.TextBox();
            this.dataKanji_dgv = new System.Windows.Forms.DataGridView();
            this.kanji_btn = new FontAwesome.Sharp.IconButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.technical_tb = new System.Windows.Forms.TextBox();
            this.dataTechnical_dgv = new System.Windows.Forms.DataGridView();
            this.technical_btn = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrammar_dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataVocabulary_dgv)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataKanji_dgv)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTechnical_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // grammar_tb
            // 
            this.grammar_tb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grammar_tb.Location = new System.Drawing.Point(4, 17);
            this.grammar_tb.Margin = new System.Windows.Forms.Padding(4);
            this.grammar_tb.Name = "grammar_tb";
            this.grammar_tb.Size = new System.Drawing.Size(791, 23);
            this.grammar_tb.TabIndex = 0;
            // 
            // dataGrammar_dgv
            // 
            this.dataGrammar_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrammar_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrammar_dgv.Location = new System.Drawing.Point(3, 83);
            this.dataGrammar_dgv.Name = "dataGrammar_dgv";
            this.dataGrammar_dgv.Size = new System.Drawing.Size(1054, 417);
            this.dataGrammar_dgv.TabIndex = 2;
            // 
            // grammar_btn
            // 
            this.grammar_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.grammar_btn.IconColor = System.Drawing.Color.Black;
            this.grammar_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.grammar_btn.Location = new System.Drawing.Point(4, 48);
            this.grammar_btn.Margin = new System.Windows.Forms.Padding(4);
            this.grammar_btn.Name = "grammar_btn";
            this.grammar_btn.Size = new System.Drawing.Size(100, 28);
            this.grammar_btn.TabIndex = 1;
            this.grammar_btn.Text = "Import File";
            this.grammar_btn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.grammar_tb);
            this.panel1.Controls.Add(this.dataGrammar_dgv);
            this.panel1.Controls.Add(this.grammar_btn);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1060, 500);
            this.panel1.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(-1, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1068, 529);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1060, 500);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Grammar";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1060, 500);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Vocabulary";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.vocabulary_tb);
            this.panel2.Controls.Add(this.dataVocabulary_dgv);
            this.panel2.Controls.Add(this.vocabulary_btn);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1060, 500);
            this.panel2.TabIndex = 4;
            // 
            // vocabulary_tb
            // 
            this.vocabulary_tb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vocabulary_tb.Location = new System.Drawing.Point(4, 17);
            this.vocabulary_tb.Margin = new System.Windows.Forms.Padding(4);
            this.vocabulary_tb.Name = "vocabulary_tb";
            this.vocabulary_tb.Size = new System.Drawing.Size(791, 23);
            this.vocabulary_tb.TabIndex = 0;
            // 
            // dataVocabulary_dgv
            // 
            this.dataVocabulary_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataVocabulary_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataVocabulary_dgv.Location = new System.Drawing.Point(3, 83);
            this.dataVocabulary_dgv.Name = "dataVocabulary_dgv";
            this.dataVocabulary_dgv.Size = new System.Drawing.Size(1054, 417);
            this.dataVocabulary_dgv.TabIndex = 2;
            // 
            // vocabulary_btn
            // 
            this.vocabulary_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.vocabulary_btn.IconColor = System.Drawing.Color.Black;
            this.vocabulary_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.vocabulary_btn.Location = new System.Drawing.Point(4, 48);
            this.vocabulary_btn.Margin = new System.Windows.Forms.Padding(4);
            this.vocabulary_btn.Name = "vocabulary_btn";
            this.vocabulary_btn.Size = new System.Drawing.Size(100, 28);
            this.vocabulary_btn.TabIndex = 1;
            this.vocabulary_btn.Text = "Import File";
            this.vocabulary_btn.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1060, 500);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Kanji";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.kanji_tb);
            this.panel3.Controls.Add(this.dataKanji_dgv);
            this.panel3.Controls.Add(this.kanji_btn);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1060, 500);
            this.panel3.TabIndex = 4;
            // 
            // kanji_tb
            // 
            this.kanji_tb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kanji_tb.Location = new System.Drawing.Point(4, 17);
            this.kanji_tb.Margin = new System.Windows.Forms.Padding(4);
            this.kanji_tb.Name = "kanji_tb";
            this.kanji_tb.Size = new System.Drawing.Size(791, 23);
            this.kanji_tb.TabIndex = 0;
            // 
            // dataKanji_dgv
            // 
            this.dataKanji_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataKanji_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataKanji_dgv.Location = new System.Drawing.Point(3, 83);
            this.dataKanji_dgv.Name = "dataKanji_dgv";
            this.dataKanji_dgv.Size = new System.Drawing.Size(1054, 417);
            this.dataKanji_dgv.TabIndex = 2;
            // 
            // kanji_btn
            // 
            this.kanji_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.kanji_btn.IconColor = System.Drawing.Color.Black;
            this.kanji_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.kanji_btn.Location = new System.Drawing.Point(4, 48);
            this.kanji_btn.Margin = new System.Windows.Forms.Padding(4);
            this.kanji_btn.Name = "kanji_btn";
            this.kanji_btn.Size = new System.Drawing.Size(100, 28);
            this.kanji_btn.TabIndex = 1;
            this.kanji_btn.Text = "Import File";
            this.kanji_btn.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel4);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1060, 500);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Technical";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.technical_tb);
            this.panel4.Controls.Add(this.dataTechnical_dgv);
            this.panel4.Controls.Add(this.technical_btn);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1060, 500);
            this.panel4.TabIndex = 4;
            // 
            // technical_tb
            // 
            this.technical_tb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.technical_tb.Location = new System.Drawing.Point(4, 17);
            this.technical_tb.Margin = new System.Windows.Forms.Padding(4);
            this.technical_tb.Name = "technical_tb";
            this.technical_tb.Size = new System.Drawing.Size(791, 23);
            this.technical_tb.TabIndex = 0;
            // 
            // dataTechnical_dgv
            // 
            this.dataTechnical_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataTechnical_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTechnical_dgv.Location = new System.Drawing.Point(3, 83);
            this.dataTechnical_dgv.Name = "dataTechnical_dgv";
            this.dataTechnical_dgv.Size = new System.Drawing.Size(1054, 417);
            this.dataTechnical_dgv.TabIndex = 2;
            // 
            // technical_btn
            // 
            this.technical_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.technical_btn.IconColor = System.Drawing.Color.Black;
            this.technical_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.technical_btn.Location = new System.Drawing.Point(4, 48);
            this.technical_btn.Margin = new System.Windows.Forms.Padding(4);
            this.technical_btn.Name = "technical_btn";
            this.technical_btn.Size = new System.Drawing.Size(100, 28);
            this.technical_btn.TabIndex = 1;
            this.technical_btn.Text = "Import File";
            this.technical_btn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Input Data";
            // 
            // FormInputDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormInputDatabase";
            this.Text = "FormInputDatabase";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrammar_dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataVocabulary_dgv)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataKanji_dgv)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTechnical_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox grammar_tb;
        private System.Windows.Forms.DataGridView dataGrammar_dgv;
        private FontAwesome.Sharp.IconButton grammar_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox vocabulary_tb;
        private System.Windows.Forms.DataGridView dataVocabulary_dgv;
        private FontAwesome.Sharp.IconButton vocabulary_btn;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox kanji_tb;
        private System.Windows.Forms.DataGridView dataKanji_dgv;
        private FontAwesome.Sharp.IconButton kanji_btn;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox technical_tb;
        private System.Windows.Forms.DataGridView dataTechnical_dgv;
        private FontAwesome.Sharp.IconButton technical_btn;
    }
}