namespace TCV_JapaNinja.Forms.Study.Alphabet
{
    partial class FormAlphabet
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
            this.hira_kata_btn = new FontAwesome.Sharp.IconButton();
            this.alphabet_tlpn = new System.Windows.Forms.TableLayoutPanel();
            this.hiragana_pn = new System.Windows.Forms.Panel();
            this.katakana_pn = new System.Windows.Forms.Panel();
            this.panelOpenChill_pn = new System.Windows.Forms.Panel();
            this.name_Mode_lb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.alphabet_tlpn.SuspendLayout();
            this.hiragana_pn.SuspendLayout();
            this.katakana_pn.SuspendLayout();
            this.panelOpenChill_pn.SuspendLayout();
            this.SuspendLayout();
            // 
            // hira_kata_btn
            // 
            this.hira_kata_btn.BackColor = System.Drawing.Color.Lime;
            this.hira_kata_btn.FlatAppearance.BorderSize = 0;
            this.hira_kata_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hira_kata_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.hira_kata_btn.IconColor = System.Drawing.Color.Black;
            this.hira_kata_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.hira_kata_btn.Location = new System.Drawing.Point(13, 13);
            this.hira_kata_btn.Margin = new System.Windows.Forms.Padding(4);
            this.hira_kata_btn.Name = "hira_kata_btn";
            this.hira_kata_btn.Size = new System.Drawing.Size(100, 28);
            this.hira_kata_btn.TabIndex = 0;
            this.hira_kata_btn.Text = "Hira_Kata";
            this.hira_kata_btn.UseVisualStyleBackColor = false;
            this.hira_kata_btn.Click += new System.EventHandler(this.hira_kata_btn_Click);
            // 
            // alphabet_tlpn
            // 
            this.alphabet_tlpn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.alphabet_tlpn.ColumnCount = 2;
            this.alphabet_tlpn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.alphabet_tlpn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.alphabet_tlpn.Controls.Add(this.katakana_pn, 1, 0);
            this.alphabet_tlpn.Controls.Add(this.hiragana_pn, 0, 0);
            this.alphabet_tlpn.Location = new System.Drawing.Point(0, 0);
            this.alphabet_tlpn.Margin = new System.Windows.Forms.Padding(0);
            this.alphabet_tlpn.Name = "alphabet_tlpn";
            this.alphabet_tlpn.RowCount = 1;
            this.alphabet_tlpn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.alphabet_tlpn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.alphabet_tlpn.Size = new System.Drawing.Size(1110, 492);
            this.alphabet_tlpn.TabIndex = 2;
            // 
            // hiragana_pn
            // 
            this.hiragana_pn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hiragana_pn.BackColor = System.Drawing.SystemColors.Info;
            this.hiragana_pn.Controls.Add(this.label1);
            this.hiragana_pn.Location = new System.Drawing.Point(4, 4);
            this.hiragana_pn.Margin = new System.Windows.Forms.Padding(4);
            this.hiragana_pn.Name = "hiragana_pn";
            this.hiragana_pn.Size = new System.Drawing.Size(547, 484);
            this.hiragana_pn.TabIndex = 0;
            // 
            // katakana_pn
            // 
            this.katakana_pn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.katakana_pn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.katakana_pn.Controls.Add(this.label2);
            this.katakana_pn.Location = new System.Drawing.Point(559, 4);
            this.katakana_pn.Margin = new System.Windows.Forms.Padding(4);
            this.katakana_pn.Name = "katakana_pn";
            this.katakana_pn.Size = new System.Drawing.Size(547, 484);
            this.katakana_pn.TabIndex = 0;
            // 
            // panelOpenChill_pn
            // 
            this.panelOpenChill_pn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOpenChill_pn.Controls.Add(this.alphabet_tlpn);
            this.panelOpenChill_pn.Location = new System.Drawing.Point(2, 48);
            this.panelOpenChill_pn.Margin = new System.Windows.Forms.Padding(0);
            this.panelOpenChill_pn.Name = "panelOpenChill_pn";
            this.panelOpenChill_pn.Size = new System.Drawing.Size(1110, 492);
            this.panelOpenChill_pn.TabIndex = 3;
            // 
            // name_Mode_lb
            // 
            this.name_Mode_lb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.name_Mode_lb.Location = new System.Drawing.Point(983, 13);
            this.name_Mode_lb.Name = "name_Mode_lb";
            this.name_Mode_lb.Size = new System.Drawing.Size(119, 22);
            this.name_Mode_lb.TabIndex = 4;
            this.name_Mode_lb.Text = "label1";
            this.name_Mode_lb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(175, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hiragana";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(194, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ktakana";
            // 
            // FormAlphabet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 543);
            this.Controls.Add(this.name_Mode_lb);
            this.Controls.Add(this.panelOpenChill_pn);
            this.Controls.Add(this.hira_kata_btn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormAlphabet";
            this.Text = "FormAlphabet";
            this.Load += new System.EventHandler(this.FormAlphabet_Load);
            this.alphabet_tlpn.ResumeLayout(false);
            this.hiragana_pn.ResumeLayout(false);
            this.hiragana_pn.PerformLayout();
            this.katakana_pn.ResumeLayout(false);
            this.katakana_pn.PerformLayout();
            this.panelOpenChill_pn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton hira_kata_btn;
        private System.Windows.Forms.TableLayoutPanel alphabet_tlpn;
        private System.Windows.Forms.Panel katakana_pn;
        private System.Windows.Forms.Panel hiragana_pn;
        private System.Windows.Forms.Panel panelOpenChill_pn;
        private System.Windows.Forms.Label name_Mode_lb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}