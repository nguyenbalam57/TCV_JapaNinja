namespace TCV_JapaNinja.Forms.Admin_Management.Accounts
{
    partial class FormRole
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
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.roleView_dgv = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.roleDescription_tb = new System.Windows.Forms.TextBox();
            this.roleName_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cancel_btn = new FontAwesome.Sharp.IconButton();
            this.regiter_Update_btn = new FontAwesome.Sharp.IconButton();
            this.crud_pn = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.delete_cb = new System.Windows.Forms.CheckBox();
            this.update_cb = new System.Windows.Forms.CheckBox();
            this.read_cb = new System.Windows.Forms.CheckBox();
            this.create_cb = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.roles_flp = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roleView_dgv)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.crud_pn.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.label1, 2);
            this.label1.Location = new System.Drawing.Point(180, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(592, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Form Role";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.roleView_dgv, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 335F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(952, 679);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // roleView_dgv
            // 
            this.roleView_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roleView_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.roleView_dgv.Location = new System.Drawing.Point(5, 340);
            this.roleView_dgv.Margin = new System.Windows.Forms.Padding(5);
            this.roleView_dgv.Name = "roleView_dgv";
            this.roleView_dgv.Size = new System.Drawing.Size(942, 334);
            this.roleView_dgv.TabIndex = 0;
            this.roleView_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.roleView_dgv_CellClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.crud_pn, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 2, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(952, 335);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.roleDescription_tb);
            this.panel1.Controls.Add(this.roleName_tb);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(176, 52);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 125);
            this.panel1.TabIndex = 0;
            // 
            // roleDescription_tb
            // 
            this.roleDescription_tb.Location = new System.Drawing.Point(110, 43);
            this.roleDescription_tb.Margin = new System.Windows.Forms.Padding(4);
            this.roleDescription_tb.Multiline = true;
            this.roleDescription_tb.Name = "roleDescription_tb";
            this.roleDescription_tb.Size = new System.Drawing.Size(186, 78);
            this.roleDescription_tb.TabIndex = 3;
            // 
            // roleName_tb
            // 
            this.roleName_tb.Location = new System.Drawing.Point(110, 4);
            this.roleName_tb.Margin = new System.Windows.Forms.Padding(4);
            this.roleName_tb.Name = "roleName_tb";
            this.roleName_tb.Size = new System.Drawing.Size(186, 23);
            this.roleName_tb.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Decription";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 46);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.cancel_btn);
            this.panel2.Controls.Add(this.regiter_Update_btn);
            this.panel2.Location = new System.Drawing.Point(176, 299);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 36);
            this.panel2.TabIndex = 1;
            // 
            // cancel_btn
            // 
            this.cancel_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.cancel_btn.IconColor = System.Drawing.Color.Black;
            this.cancel_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.cancel_btn.Location = new System.Drawing.Point(313, 6);
            this.cancel_btn.Margin = new System.Windows.Forms.Padding(0);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(133, 29);
            this.cancel_btn.TabIndex = 99;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancelRole_btn_Click);
            // 
            // regiter_Update_btn
            // 
            this.regiter_Update_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.regiter_Update_btn.IconColor = System.Drawing.Color.Black;
            this.regiter_Update_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.regiter_Update_btn.Location = new System.Drawing.Point(150, 6);
            this.regiter_Update_btn.Margin = new System.Windows.Forms.Padding(0);
            this.regiter_Update_btn.Name = "regiter_Update_btn";
            this.regiter_Update_btn.Size = new System.Drawing.Size(133, 29);
            this.regiter_Update_btn.TabIndex = 98;
            this.regiter_Update_btn.Text = "Regiter";
            this.regiter_Update_btn.UseVisualStyleBackColor = true;
            this.regiter_Update_btn.Click += new System.EventHandler(this.regiter_Update_btn_Click);
            // 
            // crud_pn
            // 
            this.crud_pn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crud_pn.Controls.Add(this.label8);
            this.crud_pn.Controls.Add(this.label7);
            this.crud_pn.Controls.Add(this.delete_cb);
            this.crud_pn.Controls.Add(this.update_cb);
            this.crud_pn.Controls.Add(this.read_cb);
            this.crud_pn.Controls.Add(this.create_cb);
            this.crud_pn.Location = new System.Drawing.Point(176, 177);
            this.crud_pn.Margin = new System.Windows.Forms.Padding(0);
            this.crud_pn.Name = "crud_pn";
            this.crud_pn.Size = new System.Drawing.Size(300, 122);
            this.crud_pn.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(84, 9);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Permission";
            // 
            // delete_cb
            // 
            this.delete_cb.AutoSize = true;
            this.delete_cb.Location = new System.Drawing.Point(110, 93);
            this.delete_cb.Name = "delete_cb";
            this.delete_cb.Size = new System.Drawing.Size(68, 21);
            this.delete_cb.TabIndex = 7;
            this.delete_cb.Text = "Delete";
            this.delete_cb.UseVisualStyleBackColor = true;
            // 
            // update_cb
            // 
            this.update_cb.AutoSize = true;
            this.update_cb.Location = new System.Drawing.Point(110, 66);
            this.update_cb.Name = "update_cb";
            this.update_cb.Size = new System.Drawing.Size(73, 21);
            this.update_cb.TabIndex = 6;
            this.update_cb.Text = "Update";
            this.update_cb.UseVisualStyleBackColor = true;
            // 
            // read_cb
            // 
            this.read_cb.AutoSize = true;
            this.read_cb.Location = new System.Drawing.Point(110, 39);
            this.read_cb.Name = "read_cb";
            this.read_cb.Size = new System.Drawing.Size(61, 21);
            this.read_cb.TabIndex = 5;
            this.read_cb.Text = "Read";
            this.read_cb.UseVisualStyleBackColor = true;
            // 
            // create_cb
            // 
            this.create_cb.AutoSize = true;
            this.create_cb.Location = new System.Drawing.Point(110, 12);
            this.create_cb.Name = "create_cb";
            this.create_cb.Size = new System.Drawing.Size(69, 21);
            this.create_cb.TabIndex = 4;
            this.create_cb.Text = "Create";
            this.create_cb.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.roles_flp);
            this.panel3.Location = new System.Drawing.Point(476, 52);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.tableLayoutPanel2.SetRowSpan(this.panel3, 2);
            this.panel3.Size = new System.Drawing.Size(300, 247);
            this.panel3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Role";
            // 
            // roles_flp
            // 
            this.roles_flp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roles_flp.AutoScroll = true;
            this.roles_flp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.roles_flp.Location = new System.Drawing.Point(0, 28);
            this.roles_flp.Margin = new System.Windows.Forms.Padding(0);
            this.roles_flp.Name = "roles_flp";
            this.roles_flp.Size = new System.Drawing.Size(303, 222);
            this.roles_flp.TabIndex = 8;
            this.roles_flp.WrapContents = false;
            // 
            // FormRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(957, 683);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormRole";
            this.Text = "FormRole";
            this.Load += new System.EventHandler(this.FormRole_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.roleView_dgv)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.crud_pn.ResumeLayout(false);
            this.crud_pn.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView roleView_dgv;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox roleDescription_tb;
        private System.Windows.Forms.TextBox roleName_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton cancel_btn;
        private FontAwesome.Sharp.IconButton regiter_Update_btn;
        private System.Windows.Forms.FlowLayoutPanel roles_flp;
        private System.Windows.Forms.Panel crud_pn;
        private System.Windows.Forms.CheckBox delete_cb;
        private System.Windows.Forms.CheckBox update_cb;
        private System.Windows.Forms.CheckBox read_cb;
        private System.Windows.Forms.CheckBox create_cb;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}