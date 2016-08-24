//======================================================================
//
//        Copyright (C) 2012-2014 唐寒枫   
//        All rights reserved
//        文件名 :Users
//        说明 :
//			可以学习参考，但禁止随意传播。如若在网上传播，请联系作者QQ：992470084或者保留此说明。
//        created by 唐寒枫 at  2014/6/15 18:42:43
//        新浪微博：http://weibo.com/u/2829927145
//        创建年份: 2014年
//
//======================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
   public class Users
    {
        private string user_name;

        public string User_name
        {
            get { return user_name; }
            set { user_name = value; }
        }
        private string user_pwd;

        public string User_pwd
        {
            get { return user_pwd; }
            set { user_pwd = value; }
        }
        private string user_type;

        public string User_type
        {
            get { return user_type; }
            set { user_type = value; }
        }
    }
}
