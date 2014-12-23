using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper
{
    public class Config
    {
        /// <summary>
        /// 根据key，获取链接字段串
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConnectionString(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }
        /// <summary>
        /// shop库连接字符串
        /// </summary>
        public static string ShopConnectionString {
            get { return ConfigurationManager.ConnectionStrings["MySQLShop"].ConnectionString; }
        }

        /// <summary>
        /// 根据key，获取AppSettings的值
        /// </summary>
        /// <param name="key">key值</param>
        /// <returns></returns>
        public static string GetAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        /// <summary>
        /// 生成MachineKey
        /// </summary>
        /// <returns></returns>
        public static string GenerateMachineKey()
        {
            String[] commandLineArgs = System.Environment.GetCommandLineArgs();
            string decryptionKey = CreateKey(48);
            string validationKey = CreateKey(128);
            return string.Format("<machineKey validationKey=\"{0}\" decryptionKey=\"{1}\" validation=\"SHA1\"/>",
                validationKey, decryptionKey);
        }

        private static String CreateKey(int length)
        {
            // 要返回的字符格式为16进制,byte最大值255
            // 需要2个16进制数保存1个byte,因此除2
            byte[] random = new byte[length / 2];

            // 使用加密服务提供程序 (CSP) 提供的实现来实现加密随机数生成器 (RNG)
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            // 用经过加密的强随机值序列填充字节数组
            rng.GetBytes(random);

            StringBuilder machineKey = new StringBuilder(length);
            for (int i = 0; i < random.Length; i++)
            {
                machineKey.Append(string.Format("{0:X2}", random[i]));
            }
            return machineKey.ToString();
        }
    }
}
