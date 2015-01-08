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
        /// <summary>
        /// 记录所有模块
        /// </summary>
        /// <param name="modules"></param>
        public static void RecordModules(string modules)
        {
            TianTianCache.CacheStrategy.AddObject("MODULES", modules);
        }
        /// <summary>
        /// 从cache中获取模块集合
        /// </summary>
        /// <returns></returns>
        public static string GetModules()
        {
            object result = TianTianCache.CacheStrategy.RetrieveObject("MODULES");
            return result == null ? string.Empty : result.ToString();
        }
    }
}
