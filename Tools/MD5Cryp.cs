//======================================================================
//
//        Copyright (C) 2012-2014 唐寒枫   
//        All rights reserved
//        文件名 :MD5Cryp
//        说明 :
//			可以学习参考，但禁止随意传播。如若在网上传播，请联系作者QQ：992470084或者保留此说明。
//        created by 唐寒枫 at  2014/6/15 18:23:56
//        新浪微博：http://weibo.com/u/2829927145
//        创建年份: 2014年
//
//======================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Tools
{
   public class MD5Cryp
    {
       public static string getCrypByMD5(string context)
       {
           MD5 md5 = new MD5CryptoServiceProvider();
           byte[] palindata = Encoding.Default.GetBytes(context);//将要加密的字符串转换为字节数组
           byte[] encryptdata = md5.ComputeHash(palindata);//将字符串加密后也转换为字符数组
           return Convert.ToBase64String(encryptdata);//将加密后的字节数组转换为加密字符串
       
       }
    }
}
