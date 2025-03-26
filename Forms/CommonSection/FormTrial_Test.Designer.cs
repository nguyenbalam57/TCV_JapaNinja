namespace TCV_JapaNinja.Forms.CommonSection
{
    partial class FormTrial_Test
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTrial_Test));
            this.panel1 = new System.Windows.Forms.Panel();
            this.text_Focus_lb = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.vocabulary_btn = new FontAwesome.Sharp.IconButton();
            this.grammar_btn = new FontAwesome.Sharp.IconButton();
            this.reading_btn = new FontAwesome.Sharp.IconButton();
            this.listening_btn = new FontAwesome.Sharp.IconButton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Controls.Add(this.text_Focus_lb);
            this.panel1.Location = new System.Drawing.Point(3, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 498);
            this.panel1.TabIndex = 3;
            // 
            // text_Focus_lb
            // 
            this.text_Focus_lb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_Focus_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.text_Focus_lb.Location = new System.Drawing.Point(3, 0);
            this.text_Focus_lb.Name = "text_Focus_lb";
            this.text_Focus_lb.Size = new System.Drawing.Size(1092, 46);
            this.text_Focus_lb.TabIndex = 0;
            this.text_Focus_lb.Text = "label1";
            this.text_Focus_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.vocabulary_btn);
            this.flowLayoutPanel1.Controls.Add(this.grammar_btn);
            this.flowLayoutPanel1.Controls.Add(this.reading_btn);
            this.flowLayoutPanel1.Controls.Add(this.listening_btn);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1100, 45);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // vocabulary_btn
            // 
            this.vocabulary_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.vocabulary_btn.IconColor = System.Drawing.Color.Black;
            this.vocabulary_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.vocabulary_btn.Location = new System.Drawing.Point(3, 3);
            this.vocabulary_btn.Name = "vocabulary_btn";
            this.vocabulary_btn.Size = new System.Drawing.Size(99, 34);
            this.vocabulary_btn.TabIndex = 0;
            this.vocabulary_btn.Text = "Tu Vung";
            this.vocabulary_btn.UseVisualStyleBackColor = true;
            this.vocabulary_btn.Click += new System.EventHandler(this.vocabulary_btn_Click);
            // 
            // grammar_btn
            // 
            this.grammar_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.grammar_btn.IconColor = System.Drawing.Color.Black;
            this.grammar_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.grammar_btn.Location = new System.Drawing.Point(108, 3);
            this.grammar_btn.Name = "grammar_btn";
            this.grammar_btn.Size = new System.Drawing.Size(99, 34);
            this.grammar_btn.TabIndex = 0;
            this.grammar_btn.Text = "Ngu Phap";
            this.grammar_btn.UseVisualStyleBackColor = true;
            this.grammar_btn.Click += new System.EventHandler(this.grammar_btn_Click);
            // 
            // reading_btn
            // 
            this.reading_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.reading_btn.IconColor = System.Drawing.Color.Black;
            this.reading_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.reading_btn.Location = new System.Drawing.Point(213, 3);
            this.reading_btn.Name = "reading_btn";
            this.reading_btn.Size = new System.Drawing.Size(99, 34);
            this.reading_btn.TabIndex = 0;
            this.reading_btn.Text = "Doc Hieu";
            this.reading_btn.UseVisualStyleBackColor = true;
            this.reading_btn.Click += new System.EventHandler(this.reading_btn_Click);
            // 
            // listening_btn
            // 
            this.listening_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.listening_btn.IconColor = System.Drawing.Color.Black;
            this.listening_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.listening_btn.Location = new System.Drawing.Point(318, 3);
            this.listening_btn.Name = "listening_btn";
            this.listening_btn.Size = new System.Drawing.Size(99, 34);
            this.listening_btn.TabIndex = 0;
            this.listening_btn.Text = "Nghe Hieu";
            this.listening_btn.UseVisualStyleBackColor = true;
            this.listening_btn.Click += new System.EventHandler(this.listening_btn_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.richTextBox1);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(11, 72);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1079, 415);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1072, 176);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // FormTrial_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 554);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormTrial_Test";
            this.Text = "FormTrial_Test";
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label text_Focus_lb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private FontAwesome.Sharp.IconButton vocabulary_btn;
        private FontAwesome.Sharp.IconButton grammar_btn;
        private FontAwesome.Sharp.IconButton reading_btn;
        private FontAwesome.Sharp.IconButton listening_btn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}