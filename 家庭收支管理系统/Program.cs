using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace 家庭收支管理系统
{

    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        private static System.Threading.Mutex mutex;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mutex = new System.Threading.Mutex(true, "OnlyRun");
            if (mutex.WaitOne(0, false))
            {
                Application.Run(new LoginForm());
                //Application.Run(new MainForm());

                //Application.Run(new Forms.Loading());
                //Application.Run(new Forms.FindCount());
                //Application.Run(new MainForm());
                //Application.Run(new MainForm());
                //Application.Run(new MainForm());
                //Application.Run(new MainForm());
            }
            else
            {
                MessageBox.Show("程序已经在运行！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }

    }

}
