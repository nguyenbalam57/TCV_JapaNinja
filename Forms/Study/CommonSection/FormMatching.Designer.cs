namespace TCV_JapaNinja.Forms.Study.CommonSection
{
    partial class FormMatching
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
            this.topPn = new System.Windows.Forms.Panel();
            this.bottomPn = new System.Windows.Forms.Panel();
            this.contentPn = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.leftFlp = new System.Windows.Forms.FlowLayoutPanel();
            this.rightFlp = new System.Windows.Forms.FlowLayoutPanel();
            this.contentPn.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPn
            // 
            this.topPn.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPn.Location = new System.Drawing.Point(0, 0);
            this.topPn.Margin = new System.Windows.Forms.Padding(0);
            this.topPn.Name = "topPn";
            this.topPn.Size = new System.Drawing.Size(1067, 15);
            this.topPn.TabIndex = 0;
            // 
            // bottomPn
            // 
            this.bottomPn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPn.Location = new System.Drawing.Point(0, 519);
            this.bottomPn.Margin = new System.Windows.Forms.Padding(0);
            this.bottomPn.Name = "bottomPn";
            this.bottomPn.Size = new System.Drawing.Size(1067, 35);
            this.bottomPn.TabIndex = 1;
            // 
            // contentPn
            // 
            this.contentPn.Controls.Add(this.tableLayoutPanel1);
            this.contentPn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPn.Location = new System.Drawing.Point(0, 15);
            this.contentPn.Margin = new System.Windows.Forms.Padding(0);
            this.contentPn.Name = "contentPn";
            this.contentPn.Size = new System.Drawing.Size(1067, 504);
            this.contentPn.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.leftFlp, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.rightFlp, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1067, 504);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // leftFlp
            // 
            this.leftFlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftFlp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.leftFlp.Location = new System.Drawing.Point(10, 20);
            this.leftFlp.Margin = new System.Windows.Forms.Padding(0);
            this.leftFlp.Name = "leftFlp";
            this.leftFlp.Size = new System.Drawing.Size(506, 464);
            this.leftFlp.TabIndex = 0;
            // 
            // rightFlp
            // 
            this.rightFlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightFlp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.rightFlp.Location = new System.Drawing.Point(551, 20);
            this.rightFlp.Margin = new System.Windows.Forms.Padding(0);
            this.rightFlp.Name = "rightFlp";
            this.rightFlp.Size = new System.Drawing.Size(506, 464);
            this.rightFlp.TabIndex = 1;
            // 
            // FormMatching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.contentPn);
            this.Controls.Add(this.bottomPn);
            this.Controls.Add(this.topPn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMatching";
            this.Text = "FormMatching";
            this.contentPn.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPn;
        private System.Windows.Forms.Panel bottomPn;
        private System.Windows.Forms.Panel contentPn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel leftFlp;
        private System.Windows.Forms.FlowLayoutPanel rightFlp;
    }
}