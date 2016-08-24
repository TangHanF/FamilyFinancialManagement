namespace 家庭收支管理系统.Forms
{
    partial class ShowRemark
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labReturn = new System.Windows.Forms.Label();
            this.labEdit = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.BackgroundImage = global::家庭收支管理系统.Properties.Resources.backLeft;
            this.groupBox1.Controls.Add(this.labReturn);
            this.groupBox1.Controls.Add(this.labEdit);
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 230);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "备注详细信息";
            // 
            // labReturn
            // 
            this.labReturn.AutoSize = true;
            this.labReturn.BackColor = System.Drawing.Color.Transparent;
            this.labReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labReturn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labReturn.Location = new System.Drawing.Point(236, 207);
            this.labReturn.Name = "labReturn";
            this.labReturn.Size = new System.Drawing.Size(42, 16);
            this.labReturn.TabIndex = 2;
            this.labReturn.Text = "返回";
            this.labReturn.Click += new System.EventHandler(this.labReturn_Click);
            this.labReturn.MouseEnter += new System.EventHandler(this.labEdit_MouseEnter);
            this.labReturn.MouseLeave += new System.EventHandler(this.labEdit_MouseLeave);
            // 
            // labEdit
            // 
            this.labEdit.AutoSize = true;
            this.labEdit.BackColor = System.Drawing.Color.Transparent;
            this.labEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labEdit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labEdit.Location = new System.Drawing.Point(101, 205);
            this.labEdit.Name = "labEdit";
            this.labEdit.Size = new System.Drawing.Size(42, 16);
            this.labEdit.TabIndex = 1;
            this.labEdit.Text = "修改";
            this.labEdit.Click += new System.EventHandler(this.labEdit_Click);
            this.labEdit.MouseEnter += new System.EventHandler(this.labEdit_MouseEnter);
            this.labEdit.MouseLeave += new System.EventHandler(this.labEdit_MouseLeave);
            // 
            // txtRemark
            // 
            this.txtRemark.BackColor = System.Drawing.Color.White;
            this.txtRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRemark.Location = new System.Drawing.Point(8, 34);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(5, 12, 3, 3);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ReadOnly = true;
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemark.Size = new System.Drawing.Size(379, 159);
            this.txtRemark.TabIndex = 0;
            this.txtRemark.Text = "dsdh很多公司";
            // 
            // ShowRemark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::家庭收支管理系统.Properties.Resources.back1;
            this.ClientSize = new System.Drawing.Size(399, 230);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowRemark";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowRemark";
            this.Load += new System.EventHandler(this.ShowRemark_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labReturn;
        private System.Windows.Forms.Label labEdit;
        private System.Windows.Forms.TextBox txtRemark;
    }
}