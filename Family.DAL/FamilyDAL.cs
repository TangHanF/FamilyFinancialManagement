using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tools;
using System.Data.OleDb;

using Entity;

namespace Family.DAL
{
    public class FamilyDAL
    {

        public DataTable returnDataTableFormCount_tab_DAL()
        {
            using (OleDbConnection conn = DBConn.getConn())
            {
                conn.Open();
                string sql = "select * from count_tab";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                DataTable dt = new DataTable();
                OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                sda.Fill(dt);
                return dt;
            }
        }

        public DataTable returnDataTableFormProj_type_DAL()
        {
            using (OleDbConnection conn = DBConn.getConn())
            {
                conn.Open();
                string sql = "select * from proj_type";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                DataTable dt = new DataTable();
                OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                sda.Fill(dt);
                return dt;
            }
        }

        public double getMoney_DAL(string flag)
        {
            double money = 0.0;
            using (OleDbConnection conn = DBConn.getConn())
            {
                conn.Open();
                string sql = string.Format("select count_money from count_tab where count_type='{0}'", flag);
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    money += Convert.ToDouble(reader["count_money"].ToString());
                }
                //double i = Convert.ToDouble(reader["count_money"]);

                return money;
            }
        }





        public Users checkUsers(string name, string crpy)
        {
            Users users = null;
            using (OleDbConnection conn = DBConn.getConn())
            {
                conn.Open();
                string sql = string.Format("select user_name,user_pwd  from users where user_name='{0}' and user_pwd='{1}'", name, crpy);
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    users = new Users();
                    users.User_name = reader["user_name"].ToString();
                    users.User_pwd = reader["user_pwd"].ToString();
                }
                return users;
            }
        }

        public bool SaveJiZhang_DAL(Count_tab_Untity count)
        {
            using (OleDbConnection conn = DBConn.getConn())
            {
                conn.Open();
                string sql = string.Format("insert into count_tab(count_data,count_type,count_proj,count_money,count_remark) values('{0}','{1}','{2}','{3}','{4}')", count.Count_data, count.Count_type, count.Count_proj, count.Count_money, count.Count_remark);
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool DeleteCount_DAL(int id)
        {
            using (OleDbConnection conn = DBConn.getConn())
            {
                conn.Open();
                string sql = string.Format("delete * from count_tab where id={0}", id);
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public DataTable initShouZhiType_DAL()
        {
            using (OleDbConnection conn = DBConn.getConn())
            {
                conn.Open();
                string sql = string.Format("select proj_name from proj_type ");
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }

        public bool addType_DAL(string typeName)
        {
            using (OleDbConnection conn = DBConn.getConn())
            {
                conn.Open();
                string sql = string.Format("insert into proj_type( proj_name) values('{0}') ", typeName);
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                    return true;
                else
                    return false;
            }
        }

        public bool deleteType_DAL(string typeName)
        {
            using (OleDbConnection conn = DBConn.getConn())
            {
                conn.Open();
                //delete * from proj_type where type_name='11'
                string sql = string.Format("DELETE FROM proj_type WHERE   (proj_name = '{0}')", typeName);
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                    return true;
                else
                    return false;
            }
        }

        public bool updateRemark_DAL(int id, string remark)
        {
            using (OleDbConnection conn = DBConn.getConn())
            {
                conn.Open();
                string sql = string.Format("update count_tab set count_remark='{0}' where ID={1}", remark, id);
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                    return true;
                else
                    return false;
            }
        }

        public bool editCount_DAL(Count_tab_Untity counttab, int id)
        {
            using (OleDbConnection conn = DBConn.getConn())
            {
                conn.Open();
                string sql = string.Format("update count_tab set count_data='{0}',count_type='{1}',count_proj='{2}',count_money={3},count_remark='{4}' where ID={5}", counttab.Count_data, counttab.Count_type, counttab.Count_proj, counttab.Count_money, counttab.Count_remark, id);
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                    return true;
                else
                    return false;
            }
        }

        #region 重载

        //查询 xxx<=金额<=xxx
        public DataTable selectByMoney_DAL(double sMoney, double eMoney)
        {
            using (OleDbConnection conn = DBConn.getConn())
            {
                conn.Open();
                string sql = string.Format("select * from count_tab where (count_money BETWEEN CDbl({0}) AND CDbl({1}))", sMoney, eMoney);
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                DataTable dt = new DataTable();
                OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                sda.Fill(dt);
                return dt;
            }
        }

        public DataTable selectByMoney_DAL(double jingMoney)
        {
            using (OleDbConnection conn = DBConn.getConn())
            {
                conn.Open();
                string sql = string.Format("select * from count_tab where (count_money=CDbl({0}))", jingMoney);
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                DataTable dt = new DataTable();
                OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                sda.Fill(dt);
                return dt;
            }
        }
        #endregion


        /// <summary>
        /// 处理用户选择的类型，比如工资收入 购物消费，方便封装成sql查询语句
        /// </summary>
        /// <param name="list"></param>
        /// <returns>tempWhereStr ,eg:count_proj='xxxxx'</returns>
        public string dailUserSelectedType(System.Collections.ArrayList list)
        {
            string whereStr = "";
            string tempWhereStr = "";
            int length = 0;
            int listSize = list.Count;
            for (int i = 0; i < list.Count; i++)
            {
                if (listSize == 1)
                    whereStr = "count_proj='" + list[i].ToString() + "'";
                else
                {
                    whereStr += "count_proj='" + list[i].ToString() + "'" + " or ";
                }
            }
            if (listSize > 1)
            {
                length = whereStr.Length - (whereStr.Length - whereStr.LastIndexOf(" or "));
                tempWhereStr = whereStr.Substring(0, length);
            }
            else
            {
                tempWhereStr = whereStr;
            }
            return tempWhereStr;
        }

        public DataTable selectByType_DAL(System.Collections.ArrayList list)
        {
            using (OleDbConnection conn = DBConn.getConn())
            {
                conn.Open();
                string sql = string.Format("select * from count_tab where " + dailUserSelectedType(list));
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                DataTable dt = new DataTable();
                OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                sda.Fill(dt);
                return dt;
            }
        }

        public DataTable selectByTimePoint_DAL(DateTime dtSart)
        {
            string date = dtSart.Year + "/" + dtSart.Month + "/" + dtSart.Day;
            using (OleDbConnection conn = DBConn.getConn())
            {
                conn.Open();
                string sql = string.Format("select * from count_tab where datediff('d',count_data,#{0}#)=0", date);
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                DataTable dt = new DataTable();
                OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                sda.Fill(dt);
                return dt;
            }
        }
        /// <summary>
        /// 按照时间段查询
        /// </summary>
        /// <param name="dtSart">起始时间</param>
        /// <param name="dtEnd">结束时间</param>
        /// <returns></returns>
        public DataTable selectByTimeDuan_DAL(DateTime dtSart, DateTime dtEnd)
        {
            using (OleDbConnection conn = DBConn.getConn())
            {
                conn.Open();
                string sql = string.Format("SELECT * FROM count_tab WHERE(count_data <= #{0}#) AND (count_data >= #{1}#)", dtEnd, dtSart);
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                DataTable dt = new DataTable();
                OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                sda.Fill(dt);
                return dt;
            }
        }


        public DataTable selectByTypeMoney_DAL(System.Collections.ArrayList list, double sMoney, double eMoney)
        {
            using (OleDbConnection conn = DBConn.getConn())
            {
                conn.Open();
                string sql = string.Format("select * from count_tab where (" + dailUserSelectedType(list) + ") and (count_money between CDbl({0}) and CDbl({1}))", sMoney, eMoney);
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                DataTable dt = new DataTable();
                OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                sda.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// 根据类型+固定金额查询
        /// </summary>
        /// <param name="list">封装的ArrayList对象</param>
        /// <param name="jingMoney">输入的固定金额</param>
        /// <returns></returns>
        public DataTable selectByTypeGuDingMoney_DAL(System.Collections.ArrayList list, double jingMoney)
        {
            using (OleDbConnection conn = DBConn.getConn())
            {
                conn.Open();
                string sql = string.Format("select * from count_tab where (" + dailUserSelectedType(list) + ") and (count_money = CDbl({0}) )", jingMoney);
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                DataTable dt = new DataTable();
                OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                sda.Fill(dt);
                return dt;
            }
        }

        public bool updateUserPwd_DAL(string userName, string newPwd)
        {
            using (OleDbConnection conn = DBConn.getConn())
            {
                conn.Open();
                string sql = string.Format("update users set user_pwd='{0}' where user_name='{1}'", newPwd, userName);
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                    return true;
                else
                    return false;
            }
        }


        /// <summary>
        /// 按照方式（时间段）+类型查询
        /// </summary>
        /// <param name="dateSart"></param>
        /// <param name="dateEnd"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public DataTable selectByFangShi_TimeDuan_Type_DAL(string dateSart, string dateEnd, System.Collections.ArrayList list)
        {
            DataTable dt = null;
            try
            {
                using (OleDbConnection conn = DBConn.getConn())
                {
                    conn.Open();
                    string sql = string.Format("SELECT * FROM count_tab WHERE(count_data <= #{0}#) AND (count_data >= #{1}#) AND ({2})", dateEnd, dateSart, dailUserSelectedType(list));
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    dt = new DataTable();
                    OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                    sda.Fill(dt);
                    
                }
            }
            catch (Exception ex) {
                Console.Write(ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// 根据时间点+类型查询
        /// </summary>
        /// <param name="dateSart"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public DataTable selectByFangShi_TimePoint_Type_DAL(string dateSart, System.Collections.ArrayList list)
        {
            DataTable dt = null ;
            try
            {
                using (OleDbConnection conn = DBConn.getConn())
                {
                    conn.Open();
                    string sql = string.Format("SELECT * from count_tab WHERE ({0}) AND (datediff('d', count_data, #{1}#) = 0)",  dailUserSelectedType(list),dateSart);
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    dt = new DataTable();
                    OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                    sda.Fill(dt);//语法错误 (操作符丢失) 在查询表达式 '(count_data = #2014/6/18 00:00:00#) AND ()' 中。
                }
            }
            catch (Exception){            }
            return dt;

        }

        /// <summary>
        /// 根据时间段+固定金额查询
        /// </summary>
        /// <param name="dateSart"></param>
        /// <param name="dateEnd"></param>
        /// <param name="jingMoney"></param>
        /// <returns></returns>
        public DataTable selectByTimeDuan_GuDingMoeny_DAL(string dateSart, string dateEnd, double jingMoney)
        {
            DataTable dt = null;
            try
            {
                using (OleDbConnection conn = DBConn.getConn())
                {
                    conn.Open();
                    string sql = string.Format("SELECT * FROM count_tab WHERE(count_data <= #{0}#) AND (count_data >= #{1}#) AND (count_money=CDbl({2}))", dateEnd, dateSart, jingMoney);
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    dt = new DataTable();
                    OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                    sda.Fill(dt);

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// 根据时间段+动态金额查询
        /// </summary>
        /// <param name="dateSart"></param>
        /// <param name="dateEnd"></param>
        /// <param name="sMoney"></param>
        /// <param name="eMoney"></param>
        /// <returns></returns>
        public DataTable selectByTimeDuan_DongTaiMoeny_DAL(string dateSart, string dateEnd, double sMoney, double eMoney)
        {
            DataTable dt = null;
            try
            {
                using (OleDbConnection conn = DBConn.getConn())
                {
                    conn.Open();
                    string sql = string.Format("SELECT * FROM count_tab WHERE(count_data <= #{0}#) AND (count_data >= #{1}#) AND (count_money<=CDbl({2}) and count_money>=CDbl({3}))", dateEnd, dateSart, eMoney,sMoney);
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    dt = new DataTable();
                    OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                    sda.Fill(dt);

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// 时间点+固定金额查询
        /// </summary>
        /// <param name="dateSart"></param>
        /// <param name="jingMoney"></param>
        /// <returns></returns>
        public object selectByTimePoint_GuDingMoeny_DAL(string dateSart, double jingMoney)
        {
            DataTable dt = null;
            try
            {
                using (OleDbConnection conn = DBConn.getConn())
                {
                    conn.Open();
                    string sql = string.Format("SELECT * FROM count_tab WHERE (count_money = CDbl({0})) AND (Datediff('d', count_data, #{1}#) = 0)",jingMoney,dateSart);
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    dt = new DataTable();
                    OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                    sda.Fill(dt);

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// 根据时间点+动态金额
        /// </summary>
        /// <param name="dateSart"></param>
        /// <param name="sMoney"></param>
        /// <param name="eMoney"></param>
        /// <returns></returns>
        public object selectByTimePoint_DongTaiMoeny_DAL(string dateSart, double sMoney, double eMoney)
        {
            DataTable dt = null;
            try
            {
                using (OleDbConnection conn = DBConn.getConn())
                {
                    conn.Open();
                    string sql = string.Format("SELECT * FROM count_tab WHERE (count_money <= CDbl({0}) and count_money >= CDbl({1}) ) AND (Datediff('d', count_data, #{2}#) = 0)", eMoney,sMoney, dateSart);
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    dt = new DataTable();
                    OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                    sda.Fill(dt);

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return dt;
        }



       

        public object selectByTimeDuan_Type_GuDingMoney(string dateSart, string dateEnd, System.Collections.ArrayList list, double jingMoney)
        {
            throw new NotImplementedException();
        }

        public object selectByTimeDuan_Type_DongTaiMoney_DAL(string dateSart, string dateEnd, System.Collections.ArrayList list, double sMoney, double eMoney)
        {
            throw new NotImplementedException();
        }
    }
}
