namespace TCV_JapaNinja.Forms.Study.CommonSection
{
    partial class FormFlashCard
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
            this.navigationPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.controlsPanel = new System.Windows.Forms.Panel();
            this.btnHint = new FontAwesome.Sharp.IconButton();
            this.btnRemember = new FontAwesome.Sharp.IconButton();
            this.btnNext = new FontAwesome.Sharp.IconButton();
            this.btnPrev = new FontAwesome.Sharp.IconButton();
            this.topPanel = new System.Windows.Forms.Panel();
            this.hintPanel = new System.Windows.Forms.Panel();
            this.cardPanel = new System.Windows.Forms.Panel();
            this.navigationPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.controlsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigationPanel
            // 
            this.navigationPanel.BackColor = System.Drawing.Color.White;
            this.navigationPanel.Controls.Add(this.tableLayoutPanel1);
            this.navigationPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navigationPanel.Location = new System.Drawing.Point(0, 313);
            this.navigationPanel.Margin = new System.Windows.Forms.Padding(0);
            this.navigationPanel.Name = "navigationPanel";
            this.navigationPanel.Size = new System.Drawing.Size(611, 37);
            this.navigationPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 319F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.controlsPanel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(611, 37);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // controlsPanel
            // 
            this.controlsPanel.Controls.Add(this.btnHint);
            this.controlsPanel.Controls.Add(this.btnRemember);
            this.controlsPanel.Controls.Add(this.btnNext);
            this.controlsPanel.Controls.Add(this.btnPrev);
            this.controlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlsPanel.Location = new System.Drawing.Point(146, 0);
            this.controlsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.controlsPanel.Name = "controlsPanel";
            this.controlsPanel.Size = new System.Drawing.Size(319, 37);
            this.controlsPanel.TabIndex = 0;
            // 
            // btnHint
            // 
            this.btnHint.FlatAppearance.BorderSize = 0;
            this.btnHint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHint.IconChar = FontAwesome.Sharp.IconChar.Lightbulb;
            this.btnHint.IconColor = System.Drawing.Color.Black;
            this.btnHint.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHint.IconSize = 35;
            this.btnHint.Location = new System.Drawing.Point(174, 1);
            this.btnHint.Margin = new System.Windows.Forms.Padding(0);
            this.btnHint.Name = "btnHint";
            this.btnHint.Size = new System.Drawing.Size(60, 35);
            this.btnHint.TabIndex = 0;
            this.btnHint.UseVisualStyleBackColor = true;
            // 
            // btnRemember
            // 
            this.btnRemember.FlatAppearance.BorderSize = 0;
            this.btnRemember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemember.IconChar = FontAwesome.Sharp.IconChar.Heart;
            this.btnRemember.IconColor = System.Drawing.Color.Black;
            this.btnRemember.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRemember.IconSize = 35;
            this.btnRemember.Location = new System.Drawing.Point(88, 1);
            this.btnRemember.Margin = new System.Windows.Forms.Padding(0);
            this.btnRemember.Name = "btnRemember";
            this.btnRemember.Size = new System.Drawing.Size(60, 35);
            this.btnRemember.TabIndex = 0;
            this.btnRemember.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.IconChar = FontAwesome.Sharp.IconChar.RightLong;
            this.btnNext.IconColor = System.Drawing.Color.Black;
            this.btnNext.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNext.IconSize = 35;
            this.btnNext.Location = new System.Drawing.Point(259, 0);
            this.btnNext.Margin = new System.Windows.Forms.Padding(0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(60, 35);
            this.btnNext.TabIndex = 0;
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            this.btnPrev.FlatAppearance.BorderSize = 0;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.IconChar = FontAwesome.Sharp.IconChar.LongArrowAltLeft;
            this.btnPrev.IconColor = System.Drawing.Color.Black;
            this.btnPrev.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPrev.IconSize = 35;
            this.btnPrev.Location = new System.Drawing.Point(0, 1);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(60, 35);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // topPanel
            // 
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(611, 37);
            this.topPanel.TabIndex = 1;
            // 
            // hintPanel
            // 
            this.hintPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hintPanel.Location = new System.Drawing.Point(0, 269);
            this.hintPanel.Margin = new System.Windows.Forms.Padding(0);
            this.hintPanel.Name = "hintPanel";
            this.hintPanel.Size = new System.Drawing.Size(611, 44);
            this.hintPanel.TabIndex = 2;
            // 
            // cardPanel
            // 
            this.cardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardPanel.Location = new System.Drawing.Point(0, 37);
            this.cardPanel.Margin = new System.Windows.Forms.Padding(8);
            this.cardPanel.Name = "cardPanel";
            this.cardPanel.Size = new System.Drawing.Size(611, 232);
            this.cardPanel.TabIndex = 3;
            // 
            // FormFlashCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 350);
            this.Controls.Add(this.cardPanel);
            this.Controls.Add(this.hintPanel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.navigationPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(350, 350);
            this.Name = "FormFlashCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormFlashCard";
            this.Load += new System.EventHandler(this.FormFlashCard_Load);
            this.Resize += new System.EventHandler(this.FormFlashCard_Resize);
            this.navigationPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.controlsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel navigationPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel controlsPanel;
        private FontAwesome.Sharp.IconButton btnPrev;
        private System.Windows.Forms.Panel hintPanel;
        private FontAwesome.Sharp.IconButton btnNext;
        private FontAwesome.Sharp.IconButton btnRemember;
        private FontAwesome.Sharp.IconButton btnHint;
        private System.Windows.Forms.Panel cardPanel;
    }
}