//======================================================================
//
//        Copyright (C) 2012-2014 唐寒枫   
//        All rights reserved
//        文件名 :AddType
//        说明 :
//			可以学习参考，但禁止随意传播。如若在网上传播，请联系作者QQ：992470084或者保留此说明。
//        created by 唐寒枫 at  2014/6/16 11:46:44
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
    public partial class AddType : Form
    {

        private ComboBox combobox = null;


        public AddType()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
        }

        public AddType(ComboBox combobox)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            this.combobox = combobox;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            combobox.DataSource = fbll.initShouZhiType();
            this.Dispose();
        }

        FamilyBLL fbll = new FamilyBLL();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("请输入类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
            }
            else if (fbll.addType(textBox1.Text.Trim()))
            {
                combobox.DataSource = fbll.initShouZhiType();
                combobox.ValueMember = "proj_name";
                this.Dispose();
            }
        }

        private void 单多行显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (单多行显示ToolStripMenuItem.Checked)
            {
                MessageBox.Show("选中");
                listBox1.MultiColumn = !listBox1.MultiColumn;
            }
            else
            {
                MessageBox.Show("取消选中");
                listBox1.MultiColumn = !listBox1.MultiColumn;//多列显示

            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                //绑定数据
                ListBoxBind();
            }
        }

        private void 删除该类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tyepName = listBox1.SelectedValue.ToString() ;
            if (fbll.deleteType(tyepName))
            {
                //重新绑定数据
                ListBoxBind();
            }
            else
            {
                MessageBox.Show("删除失败", "删除提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ListBoxBind()
        {
            listBox1.DataSource = fbll.initShouZhiType();
            listBox1.ValueMember = "proj_name";
        }
    }
}
