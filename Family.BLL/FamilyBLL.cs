using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Family.DAL;
using System.Windows.Forms;
using Tools;
using Entity;
using System.Collections;
namespace Family.BLL
{
    public class FamilyBLL
    {
        FamilyDAL fdal = new FamilyDAL();

        public DataTable returnDataTableFormCount_tab()
        {
            return fdal.returnDataTableFormCount_tab_DAL();
        }
        public DataTable returnDataTableFormProj_type()
        {
            return fdal.returnDataTableFormProj_type_DAL();
        }



        public double getMoney(string flag)
        {
            return fdal.getMoney_DAL(flag);
        }





        public bool Check(string name, string pwd)
        {
            string crpy = MD5Cryp.getCrypByMD5(pwd);//md5加密用户输入的密码
            Users users = fdal.checkUsers(name, crpy);
            if (users != null)
            {
                return true;
            }
            else
                return false;
        }

        public bool SaveJiZhang(Count_tab_Untity count)
        {
            if (fdal.SaveJiZhang_DAL(count))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCount(int id)
        {
            if (fdal.DeleteCount_DAL(id))
            {
                return true;
            }
            else
                return false;
        }



        public DataTable initShouZhiType()
        {
            return fdal.initShouZhiType_DAL();
        }

        public bool addType(string typeName)
        {
            return fdal.addType_DAL(typeName);
        }

        public bool deleteType(string typeName)
        {
            return fdal.deleteType_DAL(typeName);
        }

        public bool updateRemark(int id, string remark)
        {
            return fdal.updateRemark_DAL(id, remark);
        }

        public bool editCount(Count_tab_Untity counttab, int id)
        {
            return fdal.editCount_DAL(counttab, id);
        }


        #region 重载
        /// <summary>
        /// 查询某个金额范围之间的项
        /// </summary>
        /// <param name="sMoney">最小金额</param>
        /// <param name="eMoney">最大金额</param>
        /// <returns>返回DataTable</returns>
        public DataTable selectByMoney(double sMoney, double eMoney)
        {
            return fdal.selectByMoney_DAL(sMoney, eMoney);
        }
        /// <summary>
        /// 查询指定金额的项
        /// </summary>
        /// <param name="jingMoney">一个固定金额</param>
        /// <returns>返回DataTable</returns>
        public DataTable selectByMoney(double jingMoney)
        {
            return fdal.selectByMoney_DAL(jingMoney);
        }
        #endregion

        public DataTable selectByType(ArrayList list)
        {
            return fdal.selectByType_DAL(list);
        }

        public DataTable selectByTimePoint(DateTime dtSart)
        {
            return fdal.selectByTimePoint_DAL(dtSart);
        }

        public DataTable selectByTypeMoney(ArrayList list, double sMoney, double eMoney)
        {
            return fdal.selectByTypeMoney_DAL(list, sMoney, eMoney);
        }

        public DataTable selectByTypeGuDingMoney(ArrayList list, double jingMoney)
        {
            return fdal.selectByTypeGuDingMoney_DAL(list, jingMoney);
        }

        public bool updateUserPwd(string userName, string newPwd)
        {
            return fdal.updateUserPwd_DAL(userName, newPwd);

        }

        public DataTable selectByTimeDuan(DateTime dtSart, DateTime dtEnd)
        {
            return fdal.selectByTimeDuan_DAL(dtSart, dtEnd);
        }

        public DataTable selectByFangShi_TimeDuan_Type(string dateSart, string dateEnd, ArrayList list)
        {
            return fdal.selectByFangShi_TimeDuan_Type_DAL(dateSart, dateEnd, list);
        }

        public DataTable selectByFangShi_TimePoint_Type(string dateSart, ArrayList list)
        {
            return fdal.selectByFangShi_TimePoint_Type_DAL(dateSart, list);
        }

        public DataTable selectByTimeDuan_GuDingMoeny(string dateSart, string dateEnd, double jingMoney)
        {
            return fdal.selectByTimeDuan_GuDingMoeny_DAL(dateSart,dateEnd,jingMoney);
        }

        public DataTable selectByTimeDuan_DongTaiMoeny(string dateSart, string dateEnd, double sMoney, double eMoney)
        {
            return fdal.selectByTimeDuan_DongTaiMoeny_DAL(dateSart, dateEnd, sMoney,eMoney);
        }

        /// <summary>
        /// 时间点+动态金额查询
        /// </summary>
        /// <param name="dateSart"></param>
        /// <param name="sMoney"></param>
        /// <param name="eMoney"></param>
        /// <returns></returns>
        public object selectByTimePoint_DongTaiMoeny(string dateSart,  double sMoney, double eMoney)
        {
            return fdal.selectByTimePoint_DongTaiMoeny_DAL(dateSart, sMoney,eMoney);
        }
        /// <summary>
        /// 时间点+固定金额查询
        /// </summary>
        /// <param name="dateSart"></param>
        /// <param name="jingMoney"></param>
        /// <returns></returns>
        public object selectByTimePoint_GuDingMoeny(string dateSart,  double jingMoney)
        {
            return fdal.selectByTimePoint_GuDingMoeny_DAL(dateSart,jingMoney);
        }


        /// <summary>
        /// 根据时间段+类型+动态金额
        /// </summary>
        /// <param name="dateSart"></param>
        /// <param name="dateEnd"></param>
        /// <param name="list"></param>
        /// <param name="sMoney"></param>
        /// <param name="eMoney"></param>
        /// <returns></returns>
        public object selectByTimeDuan_Type_DongTaiMoney(string dateSart, string dateEnd, ArrayList list, double sMoney, double eMoney)
        {
            return fdal.selectByTimeDuan_Type_DongTaiMoney_DAL(dateSart, dateEnd,list, sMoney, eMoney);
        }

        /// <summary>
        /// 根据时间段+类型+固定金额查询
        /// </summary>
        /// <param name="dateSart"></param>
        /// <param name="dateEnd"></param>
        /// <param name="list"></param>
        /// <param name="jingMoney"></param>
        /// <returns></returns>
        public object selectByTimeDuan_Type_GuDingMoney(string dateSart, string dateEnd, ArrayList list, double jingMoney)
        {
            return fdal.selectByTimeDuan_Type_GuDingMoney(dateSart, dateEnd, list, jingMoney);
        }
    }
}
