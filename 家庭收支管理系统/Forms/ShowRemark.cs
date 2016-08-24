//======================================================================
//
//        Copyright (C) 2012-2014 唐寒枫   
//        All rights reserved
//        文件名 :ShowRemark
//        说明 :
//			可以学习参考，但禁止随意传播。如若在网上传播，请联系作者QQ：992470084或者保留此说明。
//        created by 唐寒枫 at  2014/6/16 19:58:14
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
using Family.BLL;

namespace 家庭收支管理系统.Forms
{
    public partial class ShowRemark : Form
    {
        private int id;
        private string remark;
        private DataGridView datagridview = null;
        FamilyBLL fbll = new FamilyBLL();

        #region 构造重载
        public ShowRemark()
        {
            InitializeComponent();
        }

        public ShowRemark(int id, string remark, DataGridView datagridview)
        {
            InitializeComponent();
            this.id = id;
            this.remark = remark;
            this.datagridview = datagridview;

        }
        #endregion

        private void labEdit_Click(object sender, EventArgs e)
        {
            if (labEdit.Text == "修改")
            {
                labEdit.Text = "更新";
                txtRemark.ReadOnly = false;
            }
            else
            {
                labEdit.Text = "修改";
                if (fbll.updateRemark(id, txtRemark.Text))
                {
                    ////DataGridView重新刷新
                    datagridview.DataSource = fbll.returnDataTableFormCount_tab();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("更新失败", "更新提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ShowRemark_Load(object sender, EventArgs e)
        {
            txtRemark.Text = remark;
            txtRemark.SelectionStart = 0;
        }

        private void labReturn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void labEdit_MouseEnter(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            lab.ForeColor = Color.FromArgb(255, 240, 208);
        }

        private void labEdit_MouseLeave(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            lab.ForeColor = Color.Black;
        }
    }
}
