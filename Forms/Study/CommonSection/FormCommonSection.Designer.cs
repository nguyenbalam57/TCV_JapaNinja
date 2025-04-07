namespace TCV_JapaNinja.Forms.Study.CommonSection
{
    partial class FormCommonSection
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.learning_btn = new FontAwesome.Sharp.IconButton();
            this.flashCard_btn = new FontAwesome.Sharp.IconButton();
            this.matching_btn = new FontAwesome.Sharp.IconButton();
            this.gap_Filling_btn = new FontAwesome.Sharp.IconButton();
            this.word_Selection_btn = new FontAwesome.Sharp.IconButton();
            this.mini_Test_btn = new FontAwesome.Sharp.IconButton();
            this.chillFormSection_pn = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.learning_btn);
            this.flowLayoutPanel1.Controls.Add(this.flashCard_btn);
            this.flowLayoutPanel1.Controls.Add(this.matching_btn);
            this.flowLayoutPanel1.Controls.Add(this.gap_Filling_btn);
            this.flowLayoutPanel1.Controls.Add(this.word_Selection_btn);
            this.flowLayoutPanel1.Controls.Add(this.mini_Test_btn);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1061, 45);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // learning_btn
            // 
            this.learning_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.learning_btn.IconColor = System.Drawing.Color.Black;
            this.learning_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.learning_btn.Location = new System.Drawing.Point(3, 3);
            this.learning_btn.Name = "learning_btn";
            this.learning_btn.Size = new System.Drawing.Size(99, 34);
            this.learning_btn.TabIndex = 0;
            this.learning_btn.Text = "Hoc Tap";
            this.learning_btn.UseVisualStyleBackColor = true;
            this.learning_btn.Click += new System.EventHandler(this.learning_btn_Click);
            // 
            // flashCard_btn
            // 
            this.flashCard_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.flashCard_btn.IconColor = System.Drawing.Color.Black;
            this.flashCard_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.flashCard_btn.Location = new System.Drawing.Point(108, 3);
            this.flashCard_btn.Name = "flashCard_btn";
            this.flashCard_btn.Size = new System.Drawing.Size(99, 34);
            this.flashCard_btn.TabIndex = 0;
            this.flashCard_btn.Text = "FlashCard";
            this.flashCard_btn.UseVisualStyleBackColor = true;
            this.flashCard_btn.Click += new System.EventHandler(this.flashCard_btn_Click);
            // 
            // matching_btn
            // 
            this.matching_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.matching_btn.IconColor = System.Drawing.Color.Black;
            this.matching_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.matching_btn.Location = new System.Drawing.Point(213, 3);
            this.matching_btn.Name = "matching_btn";
            this.matching_btn.Size = new System.Drawing.Size(99, 34);
            this.matching_btn.TabIndex = 0;
            this.matching_btn.Text = "Ghep Cap";
            this.matching_btn.UseVisualStyleBackColor = true;
            this.matching_btn.Click += new System.EventHandler(this.matching_btn_Click);
            // 
            // gap_Filling_btn
            // 
            this.gap_Filling_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.gap_Filling_btn.IconColor = System.Drawing.Color.Black;
            this.gap_Filling_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.gap_Filling_btn.Location = new System.Drawing.Point(318, 3);
            this.gap_Filling_btn.Name = "gap_Filling_btn";
            this.gap_Filling_btn.Size = new System.Drawing.Size(99, 34);
            this.gap_Filling_btn.TabIndex = 0;
            this.gap_Filling_btn.Text = "Dien Tu";
            this.gap_Filling_btn.UseVisualStyleBackColor = true;
            this.gap_Filling_btn.Click += new System.EventHandler(this.gap_Filling_btn_Click);
            // 
            // word_Selection_btn
            // 
            this.word_Selection_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.word_Selection_btn.IconColor = System.Drawing.Color.Black;
            this.word_Selection_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.word_Selection_btn.Location = new System.Drawing.Point(423, 3);
            this.word_Selection_btn.Name = "word_Selection_btn";
            this.word_Selection_btn.Size = new System.Drawing.Size(99, 34);
            this.word_Selection_btn.TabIndex = 0;
            this.word_Selection_btn.Text = "Chon Tu";
            this.word_Selection_btn.UseVisualStyleBackColor = true;
            this.word_Selection_btn.Click += new System.EventHandler(this.word_Selection_btn_Click);
            // 
            // mini_Test_btn
            // 
            this.mini_Test_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.mini_Test_btn.IconColor = System.Drawing.Color.Black;
            this.mini_Test_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.mini_Test_btn.Location = new System.Drawing.Point(528, 3);
            this.mini_Test_btn.Name = "mini_Test_btn";
            this.mini_Test_btn.Size = new System.Drawing.Size(99, 34);
            this.mini_Test_btn.TabIndex = 0;
            this.mini_Test_btn.Text = "Mini Test";
            this.mini_Test_btn.UseVisualStyleBackColor = true;
            this.mini_Test_btn.Click += new System.EventHandler(this.mini_Test_btn_Click);
            // 
            // chillFormSection_pn
            // 
            this.chillFormSection_pn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chillFormSection_pn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.chillFormSection_pn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chillFormSection_pn.Location = new System.Drawing.Point(3, 54);
            this.chillFormSection_pn.Name = "chillFormSection_pn";
            this.chillFormSection_pn.Size = new System.Drawing.Size(1061, 498);
            this.chillFormSection_pn.TabIndex = 1;
            // 
            // FormCommonSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.chillFormSection_pn);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormCommonSection";
            this.Text = "     ";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel chillFormSection_pn;
        private FontAwesome.Sharp.IconButton learning_btn;
        private FontAwesome.Sharp.IconButton flashCard_btn;
        private FontAwesome.Sharp.IconButton matching_btn;
        private FontAwesome.Sharp.IconButton gap_Filling_btn;
        private FontAwesome.Sharp.IconButton word_Selection_btn;
        private FontAwesome.Sharp.IconButton mini_Test_btn;
    }
}