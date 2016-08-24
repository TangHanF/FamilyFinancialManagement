//======================================================================
//
//        Copyright (C) 2012-2014 唐寒枫   
//        All rights reserved
//        文件名 :EditCount
//        说明 :
//			可以学习参考，但禁止随意传播。如若在网上传播，请联系作者QQ：992470084或者保留此说明。
//        created by 唐寒枫 at  2014/6/16 23:24:05
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
using Entity;
using Family.BLL;
using Utils;
namespace 家庭收支管理系统.Forms
{
    public partial class EditCount : Form
    {
        private Count_tab_Untity count = null;
        string flag = "";//判断是修改还是新增

        Form f = null;
        DataGridView datagridview = null;
        ToolStripProgressBar pshouru = null;
        ToolStripProgressBar pzhichu = null;
        ToolStripLabel lab = null;

        Label shouru = null;
        Label zhichu = null;
        Label zongjine = null;
        Label jingshouru = null;
        FamilyBLL fbll = new FamilyBLL();
        public EditCount()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
           
        }

        public EditCount(Form f,Count_tab_Untity count,DataGridView datagridview, ToolStripProgressBar pshouru, ToolStripProgressBar pzhichu, ToolStripLabel lab, Label shouru, Label zhichu, Label zongjine, Label jingshouru, string flag)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
           
            this.f = f;
            this.datagridview = datagridview;
            this.pshouru = pshouru;
            this.pzhichu = pzhichu;
            this.lab = lab;
            this.shouru = shouru;
            this.zhichu = zhichu;
            this.zongjine = zongjine;
            this.jingshouru = jingshouru;
            this.flag = flag;
            this.count = count;
        }

        private void EditCount_Load(object sender, EventArgs e)
        {
            //初始化收支类型
            combShouZhiType.DataSource = fbll.initShouZhiType();
            combShouZhiType.ValueMember = "proj_name";
            dateTimePicker1.CustomFormat = "yyyy年MM月dd日 hh:mm";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;

            dateTimePicker1.Value = count.Count_data;
            combType.Text = count.Count_type;
            combShouZhiType.Text = count.Count_proj;
            txtMoney.Text = count.Count_money.ToString();
            txtRemark.Text = count.Count_remark;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f.Opacity = 1;
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Count_tab_Untity counttab = new Count_tab_Untity();
                int id = count.Id;
                counttab.Count_data = dateTimePicker1.Value;
                counttab.Count_type = combType.Text;
                counttab.Count_proj = combShouZhiType.Text;
                counttab.Count_money = Convert.ToDouble(txtMoney.Text);
                counttab.Count_remark = txtRemark.Text;
                if (fbll.editCount(counttab,id))
                {
                    datagridview.DataSource = fbll.returnDataTableFormCount_tab();
                    BindDataGridView bind = new BindDataGridView(datagridview, pshouru, pzhichu, lab, shouru, zhichu, zongjine, jingshouru, "添加");
                    bind.bindDataGridbView();
                    f.Opacity = 1;
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("记账信息修改失败","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    f.Opacity = 1;
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "异常提示");
            }
        }

        #region 移动
        Boolean isMove = false;
        int x0, y0;
        private void EditCount_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMove = true;
                x0 = e.X;
                y0 = e.Y;
            }
        }

        private void EditCount_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isMove)
            {
                int dx = e.X - x0;
                int dy = e.Y - y0;
                this.Location = new Point(this.Left + dx, this.Top + dy);
            }
        }

        private void EditCount_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                Count_tab_Untity counttab = new Count_tab_Untity();
                int id = count.Id;
                counttab.Count_data = dateTimePicker1.Value;
                counttab.Count_type = combType.Text;
                counttab.Count_proj = combShouZhiType.Text;
                counttab.Count_money = Convert.ToDouble(txtMoney.Text);
                counttab.Count_remark = txtRemark.Text;
                if (fbll.editCount(counttab, id))
                {
                    datagridview.DataSource = fbll.returnDataTableFormCount_tab();
                    BindDataGridView bind = new BindDataGridView(datagridview, pshouru, pzhichu, lab, shouru, zhichu, zongjine, jingshouru, "添加");
                    bind.bindDataGridbView();
                    f.Opacity = 1;
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("记账信息修改失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.Opacity = 1;
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "异常提示");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            f.Opacity = 1;
            this.Dispose();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.确定Enter;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.确定Normal; ;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.取消Enter;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.取消Normal;
        }
    }
}
