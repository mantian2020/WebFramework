using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CacheFramework.Config;

namespace CacheFramework
{
  public class TianTianCache
  {
    private static ICacheStrategy cs;
    private static volatile TianTianCache instance = null;
    private static object lockHelper = new object();
    /// <summary>
    /// 是否使用memcached
    /// </summary>
    private static bool applyMemCached = false;

    private TianTianCache()
    {
      if (MemCachedConfigs.GetConfig() != null && MemCachedConfigs.GetConfig().ApplyMemCached)
        applyMemCached = true;
     
      if (applyMemCached)
      {
        try
        {
            cs = new MemCachedStrategy();
        }
        catch
        {
          throw new Exception("请检查.dll文件是否被放置在bin目录下并配置正确");
        }
      }
      else
      {
        cs = new DefaultCacheStrategy();
      }
    }

    /// <summary>
    /// 单体模式返回当前类的实例
    /// </summary>
    /// <returns></returns>
    private static TianTianCache GetCacheService()
    {
      if (instance == null)
      {
        lock (lockHelper)
        {
          if (instance == null)
          {
            instance = new TianTianCache();
          }
        }
      }
      return instance;
    }
    /// <summary>
    /// 缓存策略
    /// </summary>
    public static ICacheStrategy CacheStrategy
    {
      get
      {
        if (cs == null)
        {
          GetCacheService();
        }
        return cs;
      }
    }
  }
}
