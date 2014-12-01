using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper
{
    public class Config
    {
        /// <summary>
        /// 根据key，获取AppSettings的值
        /// </summary>
        /// <param name="key">key值</param>
        /// <returns></returns>
        public static string GetAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
