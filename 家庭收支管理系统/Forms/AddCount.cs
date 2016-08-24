//======================================================================
//
//        Copyright (C) 2012-2014 唐寒枫   
//        All rights reserved
//        文件名 :Edit
//        说明 :
//			可以学习参考，但禁止随意传播。如若在网上传播，请联系作者QQ：992470084或者保留此说明。
//        created by 唐寒枫 at  2014/6/15 16:44:26
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
using Entity;
using Utils;

namespace 家庭收支管理系统.Forms
{
    public partial class AddCount : Form
    {
        string flag = "";//判断是修改还是新增
        
        DataGridView datagridview = null;
        FamilyBLL fbll = new FamilyBLL();
        ToolStripProgressBar process1 = null;
        ToolStripProgressBar process2 = null;
        ToolStripLabel lab = null;

        Label shouru = null;
        Label zhichu = null;
        Label zongjine = null;
        Label jingshouru = null;
        Form f = null;
        public AddCount()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
           
        }

        //public AddCount(DataGridView datagridview,string flag)
        //{
        //    InitializeComponent();
        //    this.datagridview = datagridview;
        //    this.flag = flag;

        //}
        public AddCount(Form f,DataGridView datagridview, ToolStripProgressBar process1, ToolStripProgressBar process2, ToolStripLabel lab,Label shouru,Label zhichu,Label zongjine,Label jingshouru, string flag)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
           
            this.f = f;
            this.datagridview = datagridview;
            this.process1 = process1;
            this.process2 = process2;
            this.lab = lab;
            this.shouru = shouru;
            this.zhichu = zhichu;
            this.zongjine = zongjine;
            this.jingshouru = jingshouru;
            this.flag = flag;
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
                if (combType.Text != "" && comShouZhiType.Text != "" && txtMoney.Text != "")
                {
                    //封装数据
                    Count_tab_Untity count = new Count_tab_Untity();
                    count.Count_data = Convert.ToDateTime(dateTimePicker1.Value);
                    count.Count_type = combType.Text;
                    count.Count_proj = comShouZhiType.Text;
                    count.Count_money = Convert.ToDouble(txtMoney.Text.Trim());
                    count.Count_remark = txtRemark.Text;


                    if (fbll.SaveJiZhang(count))
                    {
                        //MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindDataGridView bind = new BindDataGridView(datagridview, process1, process2, lab, shouru, zhichu,zongjine,jingshouru, "添加");
                        bind.bindDataGridbView();
                        //跳转到刚才添加的数据所在行
                        datagridview.CurrentCell = datagridview.Rows[datagridview.RowCount - 1].Cells[0];
                        f.Opacity = 1;
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        f.Opacity = 1;
                        this.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("请将信息输入完整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException )
            {
                MessageBox.Show("金额输入有误，请检查输入","异常提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtMoney.Focus();
            }
              
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new Forms.AddType(comShouZhiType).ShowDialog();
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "yyyy年MM月dd日 hh:mm dddd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //初始化收支类型
            comShouZhiType.DataSource = fbll.initShouZhiType();
            comShouZhiType.ValueMember = "proj_name";
            if (combType.Items.Count > 0)
            {
                combType.SelectedIndex = 0;
            }
            if (comShouZhiType.Items.Count > 0)
            {
                comShouZhiType.SelectedIndex = 0;
            }
        }


        #region 移动
        Boolean isMove = false;
        int x0, y0;
		
        private void AddCount_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMove = true;
                x0 = e.X;
                y0 = e.Y;
            }
        }

        private void AddCount_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isMove)
            {
                int dx = e.X - x0;
                int dy = e.Y - y0;
                this.Location = new Point(this.Left + dx, this.Top + dy);
            }
        }

        private void AddCount_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (combType.Text != "" && comShouZhiType.Text != "" && txtMoney.Text != "")
                {
                    //封装数据
                    Count_tab_Untity count = new Count_tab_Untity();
                    count.Count_data = Convert.ToDateTime(dateTimePicker1.Value);
                    count.Count_type = combType.Text;
                    count.Count_proj = comShouZhiType.Text;
                    count.Count_money = Convert.ToDouble(txtMoney.Text.Trim());
                    count.Count_remark = txtRemark.Text;


                    if (fbll.SaveJiZhang(count))
                    {
                        //MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindDataGridView bind = new BindDataGridView(datagridview, process1, process2, lab, shouru, zhichu, zongjine, jingshouru, "添加");
                        bind.bindDataGridbView();
                        //跳转到刚才添加的数据所在行
                        datagridview.CurrentCell = datagridview.Rows[datagridview.RowCount - 1].Cells[0];
                        f.Opacity = 1;
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        f.Opacity = 1;
                        this.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("请将信息输入完整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("金额输入有误，请检查输入", "异常提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMoney.Focus();
            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.确定Enter;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.确定Normal;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.取消Enter;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.取消Normal;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            f.Opacity = 1;
            this.Dispose();
        }

        
    }
}
