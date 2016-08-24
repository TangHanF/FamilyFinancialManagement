//======================================================================
//
//        Copyright (C) 2012-2014 唐寒枫   
//        All rights reserved
//        文件名 :FormTools
//        说明 :
//			可以学习参考，但禁止随意传播。如若在网上传播，请联系作者QQ：992470084或者保留此说明。
//        created by 唐寒枫 at  2014/6/16 22:29:24
//        新浪微博：http://weibo.com/u/2829927145
//        创建年份: 2014年
//
//======================================================================

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Tools
{
    public class FormTools
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        private static string iniPath = Application.StartupPath + @"\config\config.ini";

        public static void setToolTip(Control control, string toolTipStr)
        {
            ToolTip tip = new ToolTip();
            tip.ShowAlways = true;
            tip.SetToolTip(control, toolTipStr);
        }

        //定义一个专门读取的方法
        public static string IniReadValue(string section, string key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", temp, 255, iniPath);
            return temp.ToString();
        }

        public static void IniWriteValue(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, iniPath);

        }

        public static Point getFormLocationFromForm(Form f)
        {
            Point p = new Point();
            p.X = f.Location.X;
            p.Y = f.Location.Y;
            return p;
        }

        public static Point getFormLocationFromConfig()
        {
            string x = FormTools.IniReadValue("form", "x");
            string y = FormTools.IniReadValue("form", "y");
            Point p = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
            return p;
        }
    }
}
