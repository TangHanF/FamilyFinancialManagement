//======================================================================
//
//        Copyright (C) 2012-2014 唐寒枫   
//        All rights reserved
//        文件名 :EditUserPwd
//        说明 :
//			可以学习参考，但禁止随意传播。如若在网上传播，请联系作者QQ：992470084或者保留此说明。
//        created by 唐寒枫 at  2014/6/17 20:58:55
//        新浪微博：http://weibo.com/u/2829927145
//        创建年份: 2014年
//
//======================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tools;
using Family.BLL;

namespace 家庭收支管理系统.Forms
{
    public partial class EditUserPwd : Form
    {
        public EditUserPwd()
        {
            InitializeComponent();
        }

        private FamilyBLL fbll = new FamilyBLL();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ("".Equals(txtName.Text.Trim()))
            {
                MessageBox.Show("请输入被修改的密码的用户名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            }
            
            else if ("".Equals(txtOldPwd.Text.Trim()))
            {
                MessageBox.Show("请输入原密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldPwd.Focus();
            }
            else if ("".Equals(txtNewPwd.Text.Trim()))
            {
                MessageBox.Show("请输入新密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPwd.Focus();
            }
            else if ("".Equals(txtRePwd.Text.Trim()))
            {
                MessageBox.Show("请再次输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRePwd.Focus();
            }
            else
            {
                string oldPwd = MD5Cryp.getCrypByMD5(txtOldPwd.Text.Trim());//MD5加密处理
                string newPwd = MD5Cryp.getCrypByMD5(txtNewPwd.Text.Trim());

                //检查用户名是否存在
                if (fbll.Check(txtName.Text.Trim(), txtOldPwd.Text.Trim()))
                {
                    if (txtNewPwd.Text.Trim().Equals(txtRePwd.Text.Trim()))
                    {
                        if (fbll.updateUserPwd(txtName.Text.Trim(),newPwd))
                        {
                            MessageBox.Show("登录密码修改成功，下次登录请使用该密码登录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("登录密码修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Dispose();
                        }
                    }
                    else
                    {
                        MessageBox.Show("两次密码输入不一致，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("用户名或者原密码不正确，请检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }
    }
}
