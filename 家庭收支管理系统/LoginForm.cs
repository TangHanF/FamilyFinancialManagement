using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Family.BLL;

namespace 家庭收支管理系统
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        FamilyBLL fbll = new FamilyBLL();

        #region 移动无窗体
        Boolean isMove = false;
        int x0, y0;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMove = true;
                x0 = e.X;
                y0 = e.Y;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isMove)
            {
                int dx = e.X - x0;
                int dy = e.Y - y0;
                this.Location = new Point(this.Left + dx, this.Top + dy);
            }
        }
        #endregion

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            lab.ForeColor = Color.Red;
            
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            lab.ForeColor = Color.Black;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("请输入用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            }
            else if (txtPwd.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPwd.Focus();
            }
            else
            {
                //检查

                if (fbll.Check(txtName.Text.Trim(), txtPwd.Text.Trim()))
                {
                    this.Hide();
                    //new MainForm().Show();
                    new Forms.Loading().ShowDialog();
                }
                else
                {
                    MessageBox.Show("用户名或者密码错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }




            
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)//回车键
                SendKeys.Send("{Tab}");
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                SendKeys.Send("{Tab}");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new Forms.RegUsers().ShowDialog();
        }
    }
}
