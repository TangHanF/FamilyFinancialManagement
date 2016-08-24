using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Family.BLL;
using System.Drawing;

namespace Utils
{
    public class BindDataGridView
    {
        string flag = "";
        DataGridView datagridview = null;
        ToolStripProgressBar process1 = null;
        ToolStripProgressBar process2 = null;
        ToolStripLabel lab = null;
        Label shouru = null;
        Label zhichu = null;
        Label zongjine = null;
        Label jingshouru = null;
        FamilyBLL fbll = new FamilyBLL();

        public BindDataGridView(DataGridView datagridview, ToolStripProgressBar process1, ToolStripProgressBar process2, ToolStripLabel lab, Label shouru, Label zhichu, Label zongjine, Label jingshouru, string flag)
        {
            this.datagridview = datagridview;
            this.process1 = process1;
            this.process2 = process2;
            this.lab = lab;
            this.shouru=shouru;
            this.zhichu=zhichu;
            this.zongjine = zongjine;
            this.jingshouru = jingshouru;
            this.flag = flag;
        }

        public void bindDataGridbView()
        {
            datagridview.DataSource = fbll.returnDataTableFormCount_tab();

            double ZhiChu = fbll.getMoney("支出");
            double ShouRu = fbll.getMoney("收入");
            shouru.Text = "总收入："+ShouRu.ToString() + "元";
            zhichu.Text = "总支出："+ZhiChu.ToString() + "元";

            zongjine.Text = "总金额：" + (ZhiChu + ShouRu).ToString() + "元";
            jingshouru.Text = "净收入：" + (ShouRu - ZhiChu).ToString() + "元";

            process1.Value = Convert.ToInt32(fbll.getMoney("收入"));
            process2.Value = Convert.ToInt32(fbll.getMoney("支出"));
            if (ShouRu > ZhiChu)
            {
                lab.ForeColor = Color.Black;
                lab.Text = "当前收入大于支出--" + (ShouRu - ZhiChu).ToString() + "元";
            }
            else if (ShouRu < ZhiChu)
            {
                lab.Text = "当前收入小于支出--" + (ZhiChu - ShouRu).ToString() + "元";
                lab.ForeColor = Color.Red;
            }
            else
            {
                lab.Text = "当前收入与支出持平--";
            }
        }
    }
}
