using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CacheFramework;

namespace CoreFramework.Services
{
    public class ModuleServices
    {
        /// <summary>
        /// 记录模块IDs到cache中
        /// </summary>
        /// <param name="moduleIds"></param>
        public static void RecordModuleIds(string moduleIds)
        {
            TianTianCache.CacheStrategy.AddObject("MODULEIDS", moduleIds);
        }
        /// <summary>
        /// 从cache中获取模块IDs
        /// </summary>
        /// <returns></returns>
        public static string GetModulesIds()
        {
            object result = TianTianCache.CacheStrategy.RetrieveObject("MODULEIDS");
            return result == null ? string.Empty : result.ToString();
        }
    }
}
