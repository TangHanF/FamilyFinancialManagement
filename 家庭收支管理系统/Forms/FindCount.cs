//======================================================================
//
//        Copyright (C) 2012-2014 唐寒枫   
//        All rights reserved
//        文件名 :FindCount
//        说明 :
//			可以学习参考，但禁止随意传播。如若在网上传播，请联系作者QQ：992470084或者保留此说明。
//        created by 唐寒枫 at  2014/6/17 10:13:08
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
using System.Collections;

namespace 家庭收支管理系统.Forms
{
    public partial class FindCount : Form
    {
        private DataGridView datagridview = null;
        private Label labCountNum = null;
        FamilyBLL fbll = new FamilyBLL();
        public FindCount()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);

        }

        public FindCount(DataGridView datagridview, Label labCountNum)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);

            this.datagridview = datagridview;
            this.labCountNum = labCountNum;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbShiJianDian.Checked)
                panel1.Visible = false;
            else
                panel1.Visible = true;

        }

        #region 移动
        Boolean isMove = false;
        int x0, y0;

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMove = true;
                x0 = e.X;
                y0 = e.Y;
            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isMove)
            {
                int dx = e.X - x0;//想一下为什么是用“-”而不是用“+”？很简单，就是为了计算出鼠标移动的距离
                //首先x0记录了鼠标第一次点击时的位置，e.X，e.Y是鼠标目前的位置，利用e.X和
                //e.Y减去原来的x0,y0就是鼠标移动过的距离，然后将这个距离应用到窗体的left和top属性即可
                int dy = e.Y - y0;
                this.Location = new Point(this.Left + dx, this.Top + dy);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }
        #endregion

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFangShi.Checked)
                panelFangSHi.Enabled = true;
            else
                panelFangSHi.Enabled = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLeiBie.Checked)
                panelLeiBie.Enabled = true;
            else
                panelLeiBie.Enabled = false;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkJinE.Checked)
                panelJinE.Enabled = true;
            else
                panelJinE.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxAimItem.Items.Add(listBox1.SelectedItem);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            catch (Exception)
            { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(listBoxAimItem.SelectedItem);
            listBoxAimItem.Items.RemoveAt(listBoxAimItem.SelectedIndex);

        }

        private void FindCount_Load(object sender, EventArgs e)
        {
            //初始化列表框
            // //下面这种直接绑定方式在删除列表框项时会出现：设置 DataSource 属性后无法修改项集合 的异常、
            ////所以我们换一种方式：遍历的方式
            //listBox1.DataSource = fbll.returnDataTableFormProj_type();
            //listBox1.ValueMember = "proj_name";
            for (int i = 1; i <= 31; i++)
            {
                cmbSDay.Items.Add(i);
                cmbEDay.Items.Add(i);
            }
            DataTable dt = fbll.returnDataTableFormProj_type();
            foreach (DataRow d in dt.Rows)
            {
                listBox1.Items.Add(d["proj_name"]);
            }
        }

        public ArrayList getListItems()
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < listBoxAimItem.Items.Count; i++)
            {
                list.Add(listBoxAimItem.Items[i].ToString());
            }
            return list;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                panelDongTaiJinE.Enabled = false;
                panelGuDin个JinE.Visible = true;
            }
            else
            {
                panelDongTaiJinE.Enabled = true;
                panelGuDin个JinE.Visible = false;
            }
        }

       
        public void updateLabCountNum()
        {
            labCountNum.Text = "匹配个数：" + datagridview.RowCount;
        }

        private void cmbSYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void setDataGridViewHeader()
        {
            datagridview.Columns[0].HeaderText = "编号";
            datagridview.Columns[1].HeaderText = "日期";
            datagridview.Columns[2].HeaderText = "类型";
            datagridview.Columns[3].HeaderText = "收支项目";
            datagridview.Columns[4].HeaderText = "金额";
            datagridview.Columns[5].HeaderText = "备注";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //查询方式、类别选择
            //查询方式、金额范围
            //类别选择、金额范围
            //查询方式、类别选择、金额范围


            try
            {
                string dateSart = cmbSYear.Text + "/" + cmbSMonth.Text + "/" + cmbSDay.Text + " 00:00:00";
                string dateEnd = cmbEYear.Text + "/" + cmbEMonth.Text + "/" + cmbEDay.Text + " 11:59:59 PM";

                DateTime dtSart = Convert.ToDateTime(dateSart);
                DateTime dtEnd = Convert.ToDateTime(dateEnd);

                //只选中查询方式
                if (checkFangShi.Checked && !checkLeiBie.Checked && !checkJinE.Checked)
                {
                    if (rbShiJianDuan.Checked)
                    {
                        //MessageBox.Show("只选中查询方式,且选中时间段" + "---" + "开始" + dtSart.ToString() + "结束：" + dtEnd.ToString());
                        datagridview.DataSource = fbll.selectByTimeDuan(dtSart, dtEnd);
                        updateLabCountNum();
                    }
                    else if (rbShiJianDian.Checked)
                    {
                        //MessageBox.Show("只选中查询方式,且选中时间点"+dtSart.ToString());
                        datagridview.DataSource = fbll.selectByTimePoint(dtSart);
                        updateLabCountNum();
                    }
                }
                //只选中类别选择
                else if (!checkFangShi.Checked && checkLeiBie.Checked && !checkJinE.Checked)
                {
                    //MessageBox.Show("只选中类别选择");
                    ArrayList list = getListItems();
                    if (list.Count == 0)
                    {
                        MessageBox.Show("请添加查询类别！", "查询提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        datagridview.DataSource = fbll.selectByType(list);
                        setDataGridViewHeader();
                        updateLabCountNum();
                    }
                }
                //只选中金额范围
                else if (!checkFangShi.Checked && !checkLeiBie.Checked && checkJinE.Checked)
                {
                    try
                    {
                        //MessageBox.Show("只选中金额范围");
                        if (checkBox1.Checked)//固定金额查询
                        {
                            double jingMoney = Convert.ToDouble(txtJingMoney.Text.Trim());
                            datagridview.DataSource = fbll.selectByMoney(jingMoney);
                            updateLabCountNum();
                        }
                        else
                        {
                            double sMoney = Convert.ToDouble(textMoneyStart.Text.Trim());
                            double eMoney = Convert.ToDouble(textMoneyEnd.Text.Trim());
                            datagridview.DataSource = fbll.selectByMoney(sMoney, eMoney);
                            updateLabCountNum();
                        }
                    }
                    catch (Exception ex)
                    {
                        //防止转换出错导致崩溃
                        MessageBox.Show(ex.Message);
                    }
                }
                //选中查询方式、类别选择
                else if (checkFangShi.Checked && checkLeiBie.Checked && !checkJinE.Checked)
                {
                    //注意还要考虑时间段 时间点
                    //MessageBox.Show("选中查询方式、类别选择");
                    if (rbShiJianDuan.Checked)//时间段
                    {
                        ArrayList list = getListItems();
                        if (list.Count == 0)
                        {
                            MessageBox.Show("请添加查询类别！", "查询提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            datagridview.DataSource = fbll.selectByFangShi_TimeDuan_Type(dateSart, dateEnd, list);
                            setDataGridViewHeader();
                            updateLabCountNum();
                        }
                    }
                    else if (rbShiJianDian.Checked)
                    {
                        ArrayList list = getListItems();
                        if (list.Count == 0)
                        {
                            MessageBox.Show("请添加查询类别！", "查询提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            datagridview.DataSource = fbll.selectByFangShi_TimePoint_Type(dateSart, list);
                            setDataGridViewHeader();
                            updateLabCountNum();
                        }
                    }
                }
                //选中查询方式、金额范围
                else if (checkFangShi.Checked && checkJinE.Checked && !checkLeiBie.Checked)
                {
                    //MessageBox.Show("选中查询方式、金额范围");
                    //注意还要考虑时间段 金额范围
                    if (rbShiJianDuan.Checked)//时间段
                    {
                        //时间段 dateSart, dateEnd
                        if (checkBox1.Checked)//固定金额查询
                        {
                            double jingMoney = Convert.ToDouble(txtJingMoney.Text.Trim());
                            datagridview.DataSource = fbll.selectByTimeDuan_GuDingMoeny(dateSart, dateEnd, jingMoney);
                            updateLabCountNum();
                        }
                        else//动态金额查询
                        {
                            double sMoney = Convert.ToDouble(textMoneyStart.Text.Trim());
                            double eMoney = Convert.ToDouble(textMoneyEnd.Text.Trim());
                            datagridview.DataSource = fbll.selectByTimeDuan_DongTaiMoeny(dateSart, dateEnd, sMoney, eMoney);
                            updateLabCountNum();
                        }
                        updateLabCountNum();
                    }
                    else if (rbShiJianDian.Checked)//时间点 dateSart
                    {

                        //固定金额   动态金额判断
                        if (checkBox1.Checked)//固定金额查询
                        {
                            double jingMoney = Convert.ToDouble(txtJingMoney.Text.Trim());
                            datagridview.DataSource = fbll.selectByTimePoint_GuDingMoeny(dateSart, jingMoney);
                            updateLabCountNum();
                        }
                        else//动态金额查询
                        {
                            double sMoney = Convert.ToDouble(textMoneyStart.Text.Trim());
                            double eMoney = Convert.ToDouble(textMoneyEnd.Text.Trim());
                            datagridview.DataSource = fbll.selectByTimePoint_DongTaiMoeny(dateSart, sMoney, eMoney);
                            updateLabCountNum();
                        }
                        updateLabCountNum();
                    }
                }

                //选中类别选择、金额范围
                else if (checkLeiBie.Checked && checkJinE.Checked && !checkFangShi.Checked)
                {
                    //MessageBox.Show("选中类别选择、金额范围");
                    try
                    {
                        ArrayList list = getListItems();
                        if (list.Count == 0)
                        {
                            MessageBox.Show("请添加查询类别！", "查询提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (!checkBox1.Checked)
                            {
                                double sMoney = Convert.ToDouble(textMoneyStart.Text.Trim());
                                double eMoney = Convert.ToDouble(textMoneyEnd.Text.Trim());

                                datagridview.DataSource = fbll.selectByTypeMoney(list, sMoney, eMoney);
                                updateLabCountNum();
                            }
                            else
                            {
                                double jingMoney = Convert.ToDouble(txtJingMoney.Text.Trim());
                                datagridview.DataSource = fbll.selectByTypeGuDingMoney(list, jingMoney);
                                updateLabCountNum();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                //选中全部
                else if (checkFangShi.Checked && checkLeiBie.Checked && checkJinE.Checked)
                {
                    //MessageBox.Show("选中全部");
                    //时间点  时间段判断
                    //动态金额  固定金额判断
                    //判断 list是否为空

                    ArrayList list = getListItems();


                    if (rbShiJianDuan.Checked)//时间段
                    {
                        if (list.Count == 0)
                        {
                            MessageBox.Show("请添加查询类别！", "查询提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (checkBox1.Checked)//固定金额
                            {
                                double jingMoney = Convert.ToDouble(txtJingMoney.Text.Trim());
                                datagridview.DataSource = fbll.selectByTimeDuan_Type_GuDingMoney(dateSart, dateEnd, list, jingMoney);
                                setDataGridViewHeader();
                                updateLabCountNum();
                            }
                            else//动态金额
                            {
                                double sMoney = Convert.ToDouble(textMoneyStart.Text.Trim());
                                double eMoney = Convert.ToDouble(textMoneyEnd.Text.Trim());
                                datagridview.DataSource = fbll.selectByTimeDuan_Type_DongTaiMoney(dateSart, dateEnd, list, sMoney, eMoney);
                                setDataGridViewHeader();
                                updateLabCountNum();
                            }
                        }
                    }
                    else //时间点
                    {

                    }

                }
            }
            catch (FormatException)
            {
                MessageBox.Show("请检查日期是否超界，比如月份是否有28、29、30、31天或者是否在全选模式下金额是否补充完整！", "");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
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











    }
}
