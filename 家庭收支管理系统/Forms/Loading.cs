//======================================================================
//
//        Copyright (C) 2012-2014 唐寒枫   
//        All rights reserved
//        文件名 :Loading
//        说明 :
//			可以学习参考，但禁止随意传播。如若在网上传播，请联系作者QQ：992470084或者保留此说明。
//        created by 唐寒枫 at  2014/6/16 22:07:15
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

namespace 家庭收支管理系统.Forms
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        int count = 0;
        string str = ".....";
        string tempStr = "";
        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if (count == 2)
            {
                timer1.Enabled = false;
                this.Dispose();
                new MainForm().Show();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (str.Length <= 10 && count < str.Length)
            {
                tempStr += str[count];
                label1.Text = "玩命加载中" + tempStr;
            }
            else {
                count = 0;
                tempStr = "";
                label1.Text = "玩命加载中";
            }
        }
    }
}
