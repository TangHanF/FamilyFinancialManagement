//======================================================================
//
//        Copyright (C) 2012-2014 唐寒枫   
//        All rights reserved
//        文件名 :MainForm
//        说明 :
//			可以学习参考，但禁止随意传播。如若在网上传播，请联系作者QQ：992470084或者保留此说明。
//        created by 唐寒枫 at  2014/6/15 13:59:47
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
using Tools;
using System.Collections;
using Entity;

namespace 家庭收支管理系统
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            pictureBox2.Image = Properties.Resources.刷新;
        }

        FamilyBLL fbll = new FamilyBLL();
        Count_tab_Untity count = new Count_tab_Untity();
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            toolTime.Text = dt.ToString("yyyy年 MM月dd日 hh:mm:ss");
        }

        #region
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            lab.Font = new Font(Font.FontFamily, 12, FontStyle.Bold);
            lab.BackColor = Color.FromArgb(194, 224, 255);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            lab.Font = new Font(Font.FontFamily, 12, FontStyle.Regular);
            lab.BackColor = Color.Transparent;
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            

            //读取配置文件，设置窗体位置
            this.Location = FormTools.getFormLocationFromConfig();

            dataGridView1.ReadOnly = true;//设置成只读
            // 设置用户不能手动给 DataGridView1 添加新行
            dataGridView1.AllowUserToAddRows = false;

            // 设定包括Header和所有单元格的列宽自动调整
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            //绑定数据
            bindDataGridbView();

            lbCountNum.Text = "总记账个数：" + dataGridView1.RowCount;

        }
        public void bindDataGridbView()
        {
            dataGridView1.DataSource = fbll.returnDataTableFormCount_tab();
            setHeader();

            double ZhiChu = fbll.getMoney("支出");
            double ShouRu = fbll.getMoney("收入");
            labZongShouRu.Text = "总收入：" + ShouRu.ToString() + "元";
            labZongZhiChu.Text = "总支出：" + ZhiChu.ToString() + "元";
            //总金额=收入+支出
            //净收入=收入-支出
            labZJinE.Text = "总金额：" + (ZhiChu + ShouRu).ToString() + "元";
            labJingShouRu.Text = "净收入：" + (ShouRu - ZhiChu).ToString() + "元";

            toolStripProgressBarShouRu.Value = Convert.ToInt32(fbll.getMoney("收入"));
            toolStripProgressBarZhiChu.Value = Convert.ToInt32(fbll.getMoney("支出"));
            if (ShouRu > ZhiChu)
            {
                toolStripStatusLabelChaE.ForeColor = Color.Black;
                toolStripStatusLabelChaE.Text = "当前收入大于支出--" + (ShouRu - ZhiChu).ToString() + "元";
            }
            else if (ShouRu < ZhiChu)
            {
                toolStripStatusLabelChaE.Text = "当前收入小于支出--" + (ZhiChu - ShouRu).ToString() + "元";
                toolStripStatusLabelChaE.ForeColor = Color.Red;
            }
            else
            {
                toolStripStatusLabelChaE.Text = "当前收入与支出持平--";
            }
        }

        //设置标题
        public void setHeader()
        {
            dataGridView1.Columns[0].HeaderText = "编号";
            dataGridView1.Columns[1].HeaderText = "日期";
            dataGridView1.Columns[2].HeaderText = "类型";
            dataGridView1.Columns[3].HeaderText = "收支项目";
            dataGridView1.Columns[4].HeaderText = "金额";
            dataGridView1.Columns[5].HeaderText = "备注";
        }

        private void 计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenOthersSoft.openSoft("calc");
        }

        private void 记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenOthersSoft.openSoft("notepad");
        }
        private void wordToolWord_Click(object sender, EventArgs e)
        {
            OpenOthersSoft.openSoft("winword.exe");
        }

        private void excelToolExcel_Click(object sender, EventArgs e)
        {
            OpenOthersSoft.openSoft("excel.exe");
        }


        #region 导航操作
        private void labAdd_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.8;
            new Forms.AddCount(this, dataGridView1, toolStripProgressBarShouRu, toolStripProgressBarZhiChu, toolStripStatusLabelChaE, labZongShouRu, labZongZhiChu, labZJinE, labJingShouRu, "添加").ShowDialog();
        }


        private void labEdit_Click(object sender, EventArgs e)
        {
            try
            {
                //封装数据信息
                int hang = dataGridView1.CurrentRow.Index;

                count.Id = Convert.ToInt32(dataGridView1[0, hang].Value);
                count.Count_data = Convert.ToDateTime(dataGridView1[1, hang].Value);
                count.Count_type = dataGridView1[2, hang].Value.ToString();
                count.Count_proj = dataGridView1[3, hang].Value.ToString();
                count.Count_money = Convert.ToDouble(dataGridView1[4, hang].Value.ToString());
                count.Count_remark = dataGridView1[5, hang].Value.ToString();

                this.Opacity = 0.8;
                new Forms.EditCount(this, count, dataGridView1, toolStripProgressBarShouRu, toolStripProgressBarZhiChu, toolStripStatusLabelChaE, labZongShouRu, labZongZhiChu, labZJinE, labJingShouRu, "修改").ShowDialog();

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "异常提示"); }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void 设置预算金额ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Forms.SetYuSuan().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void labDel_Click(object sender, EventArgs e)
        {
            string id = this.dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            int countid = Convert.ToInt32(id);
            if (fbll.DeleteCount(countid))
            {
                //MessageBox.Show("删除成功");
                bindDataGridbView();
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            lab.ForeColor = Color.Red;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            lab.ForeColor = Color.Black;
        }



        Boolean isMove = false;
        int x0, y0;
        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMove = true;
                x0 = e.X;
                y0 = e.Y;
            }
        }

        private void menuStrip1_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isMove)
            {
                int dx = e.X - x0;
                int dy = e.Y - y0;
                this.Location = new Point(this.Left + dx, this.Top + dy);
            }
        }

        private void 冻结表头ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (冻结表头ToolStripMenuItem.Checked)
            {
                dataGridView1.Rows[2].Frozen = true;
            }
            else
                dataGridView1.Rows[2].Frozen = false;
        }

        ArrayList list = new ArrayList();
        private void 冻结本行ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int index = dataGridView1.CurrentCell.RowIndex;
            list.Add(index);
            for (int i = 0; i < list.Count; i++)
            {
                if (Convert.ToInt32(list[i]) == index)
                {

                    dataGridView1.Rows[index].Frozen = true;
                }
                else
                {
                    dataGridView1.Rows[i].Frozen = false;
                }
            }
        }

        private void 统计选中总金额ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double zongMoney = 0.0;
            DataGridViewSelectedCellCollection c = dataGridView1.SelectedCells;
            for (int i = 0; i < c.Count; i++)
            {
                //MessageBox.Show(c[i].ToString());//行 列
                //MessageBox.Show("所在行"+c[i].RowIndex);
                //MessageBox.Show("所在行金额：" + dataGridView1[4, c[i].RowIndex].Value.ToString());
                if (c[i].ColumnIndex == 4)
                    zongMoney += Convert.ToDouble(dataGridView1[4, c[i].RowIndex].Value);
            }
            MessageBox.Show("当前选中总金额是：" + zongMoney.ToString() + "元", "统计结果", MessageBoxButtons.OK);

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = dataGridView1.CurrentRow.Index;
            int lie = dataGridView1.CurrentCell.ColumnIndex;

            if (lie == 5)
            {
                //应该传送给一个窗体显示，便于查看和修改
                int id = Convert.ToInt32(dataGridView1[0, hang].Value);
                //MessageBox.Show(id.ToString());
                string remark = dataGridView1[5, hang].Value.ToString();
                //MessageBox.Show(remark);

                new Forms.ShowRemark(id, remark, dataGridView1).ShowDialog();
            }

        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            //pictureBox2.BackgroundImageLayout = ImageLayout.Center;
            pictureBox2.Image = Properties.Resources.刷新2;
            FormTools.setToolTip(pictureBox2, "点击刷新数据");

        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            //pictureBox2.BackgroundImageLayout = ImageLayout.Center;
            pictureBox2.Image = Properties.Resources.刷新;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            bindDataGridbView();
            lbCountNum.Text = "总记账个数：" + dataGridView1.RowCount;
        }

        private void 关于作者ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Forms.AboutAuthor().ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //写入配置文件位置信息
            Point p = FormTools.getFormLocationFromForm(this);
            string x = p.X.ToString();
            string y = p.Y.ToString();
            FormTools.IniWriteValue("form", "x", x);
            FormTools.IniWriteValue("form", "y", y);
            //MessageBox.Show(p.X + "," + p.Y);
        }

        Forms.FindCount findForm = null;
        private void lanSelect_Click(object sender, EventArgs e)
        {
            if (findForm == null || findForm.IsDisposed)
            {
                findForm = new Forms.FindCount(dataGridView1, lbCountNum);
                findForm.Show();
            }
            else
            {
                findForm.Activate();
            }
        }

        private void 修改登录密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Forms.EditUserPwd().ShowDialog();
        }

        private void picAdd_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.8;
            new Forms.AddCount(this, dataGridView1, toolStripProgressBarShouRu, toolStripProgressBarZhiChu, toolStripStatusLabelChaE, labZongShouRu, labZongZhiChu, labZJinE, labJingShouRu, "添加").ShowDialog();
        
        }

        private void picSelect_Click(object sender, EventArgs e)
        {
            if (findForm == null || findForm.IsDisposed)
            {
                findForm = new Forms.FindCount(dataGridView1, lbCountNum);
                findForm.Show();
            }
            else
            {
                findForm.Activate();
            }
        }

        private void picDel_Click(object sender, EventArgs e)
        {
            string id = this.dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            int countid = Convert.ToInt32(id);
            if (fbll.DeleteCount(countid))
            {
                //MessageBox.Show("删除成功");
                bindDataGridbView();
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        private void picEdit_Click(object sender, EventArgs e)
        {
            try
            {
                //封装数据信息
                int hang = dataGridView1.CurrentRow.Index;

                count.Id = Convert.ToInt32(dataGridView1[0, hang].Value);
                count.Count_data = Convert.ToDateTime(dataGridView1[1, hang].Value);
                count.Count_type = dataGridView1[2, hang].Value.ToString();
                count.Count_proj = dataGridView1[3, hang].Value.ToString();
                count.Count_money = Convert.ToDouble(dataGridView1[4, hang].Value.ToString());
                count.Count_remark = dataGridView1[5, hang].Value.ToString();

                this.Opacity = 0.8;
                new Forms.EditCount(this, count, dataGridView1, toolStripProgressBarShouRu, toolStripProgressBarZhiChu, toolStripStatusLabelChaE, labZongShouRu, labZongZhiChu, labZJinE, labJingShouRu, "修改").ShowDialog();

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "异常提示"); }
        }

        private void pictExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictExit_MouseEnter(object sender, EventArgs e)
        {
            pictExit.Image = Properties.Resources.退出系统Enter;
        }

        private void pictExit_MouseLeave(object sender, EventArgs e)
        {
            pictExit.Image = Properties.Resources.退出系统Normal;
        }

        private void picEdit_MouseEnter(object sender, EventArgs e)
        {
            picEdit.Image = Properties.Resources.修改记账Enter;
        }

        private void picEdit_MouseLeave(object sender, EventArgs e)
        {
            picEdit.Image = Properties.Resources.修改记账Normal;
        }

        private void picDel_MouseEnter(object sender, EventArgs e)
        {
            picDel.Image = Properties.Resources.删除记账Enter;
        }

        private void picDel_MouseLeave(object sender, EventArgs e)
        {
            picDel.Image = Properties.Resources.删除记账Normal;
        }

        private void picSelect_MouseEnter(object sender, EventArgs e)
        {
            picSelect.Image = Properties.Resources.记账查询Enter;
        }

        private void picSelect_MouseLeave(object sender, EventArgs e)
        {
            picSelect.Image = Properties.Resources.记账查询Normal;
        }

        private void picAdd_MouseEnter(object sender, EventArgs e)
        {
            picAdd.Image = Properties.Resources.新增记账Enter;
        }

        private void picAdd_MouseLeave(object sender, EventArgs e)
        {
            picAdd.Image = Properties.Resources.新增记账Normal;
        }

        




    }
}
