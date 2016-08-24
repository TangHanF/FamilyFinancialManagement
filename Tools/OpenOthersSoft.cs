//======================================================================
//
//        Copyright (C) 2012-2014 唐寒枫   
//        All rights reserved
//        文件名 :OpenOthersSoft
//        说明 :
//			可以学习参考，但禁止随意传播。如若在网上传播，请联系作者QQ：992470084或者保留此说明。
//        created by 唐寒枫 at  2014/6/15 16:25:53
//        新浪微博：http://weibo.com/u/2829927145
//        创建年份: 2014年
//
//======================================================================

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tools
{
    public class OpenOthersSoft
    {
        public static void openSoft(string softName)
        {
            try
            {
                System.Diagnostics.Process.Start(softName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }

        }
    }
}
