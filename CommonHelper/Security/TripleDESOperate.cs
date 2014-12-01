using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace CommonHelper.Security
{
    /// <summary>
    /// TripleDES加密
    /// </summary>
  public  class TripleDESOperate
    {
        /// <summary>   
        /// DESEnCode DES加密   
        /// </summary>   
        /// <param name="pToEncrypt">要加密的数据</param>   
        /// <param name="sKey">密钥</param>   
        /// <returns>经过加密的字符串</returns>   
        public static string DESEnCode(string pToEncrypt, string sKey)
        {
            //pToEncrypt = HttpContext.Current.Server.UrlEncode(pToEncrypt);   
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.GetEncoding("UTF-8").GetBytes(pToEncrypt);

            //建立加密对象的密钥和偏移量      
            //原文使用ASCIIEncoding.ASCII方法的GetBytes方法      
            //使得输入密码必须输入英文文本      
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:x2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }

        /// <summary>   
        /// DESDeCode DES解密   
        /// </summary>   
        /// <param name="pToDecrypt"> 待解密的字符串</param>   
        /// <param name="sKey"> 解密密钥,要求为8字节,和加密密钥相同</param>   
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>          
        public static string DESDeCode(string pToDecrypt, string sKey)
        {
            //    HttpContext.Current.Response.Write(pToDecrypt + “<br>” + sKey);     
            //    HttpContext.Current.Response.End();     
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            StringBuilder ret = new StringBuilder();

            return System.Text.Encoding.Default.GetString(ms.ToArray());
          
        }  
    }
}
