using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper;

namespace CacheFramework.Config
{
  public class MemCachedConfigFileManager : DefaultConfigFileManager
  {
    private static MemCachedConfigInfo m_configinfo;

    /// <summary>
    /// 文件修改时间
    /// </summary>
    private static DateTime m_fileoldchange;


    /// <summary>
    /// 初始化文件修改时间和对象实例
    /// </summary>
    static MemCachedConfigFileManager()
    {
      if (FileHelper.FileExists(ConfigFilePath))
      {
        m_fileoldchange = System.IO.File.GetLastWriteTime(ConfigFilePath);
        m_configinfo = (MemCachedConfigInfo)DeserializeInfo(ConfigFilePath, typeof(MemCachedConfigInfo));
      }
    }

    /// <summary>
    /// 当前的配置类实例
    /// </summary>
    public new static IConfigInfo ConfigInfo
    {
      get { return m_configinfo; }
      set { m_configinfo = (MemCachedConfigInfo)value; }
    }

    /// <summary>
    /// 配置文件所在路径
    /// </summary>
    public static string filename = null;


    /// <summary>
    /// 获取配置文件所在路径
    /// </summary>
    public new static string ConfigFilePath
    {
      get
      {
        if (filename == null)
        {
          filename = FileHelper.GetMapPath("config/memcached.config");
        }

        return filename;
      }
    }

    /// <summary>
    /// 返回配置类实例
    /// </summary>
    /// <returns></returns>
    public static MemCachedConfigInfo LoadConfig()
    {
        if (FileHelper.FileExists(ConfigFilePath))
      {
        ConfigInfo = LoadConfig(ref m_fileoldchange, ConfigFilePath, ConfigInfo);
        return ConfigInfo as MemCachedConfigInfo;
      }
      else
        return null;
    }
  }
}
