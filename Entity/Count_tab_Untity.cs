using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Count_tab_Untity
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime count_data;

        public DateTime Count_data
        {
            get { return count_data; }
            set { count_data = value; }
        }
        
        
        private string count_type;

        public string Count_type
        {
            get { return count_type; }
            set { count_type = value; }
        }
        private string count_proj;

        public string Count_proj
        {
            get { return count_proj; }
            set { count_proj = value; }
        }
        private double count_money;

        public double Count_money
        {
            get { return count_money; }
            set { count_money = value; }
        }

        
        private string count_remark;

        public string Count_remark
        {
            get { return count_remark; }
            set { count_remark = value; }
        }
    }
}
