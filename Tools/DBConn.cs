using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Tools
{
    public class DBConn
    {
        
        static string connStr = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=" +Application.StartupPath +@"\source\data.mdb;";
        public static OleDbConnection getConn()
        {
            OleDbConnection conn = new OleDbConnection(connStr);
            return conn;
        }
    }
}
