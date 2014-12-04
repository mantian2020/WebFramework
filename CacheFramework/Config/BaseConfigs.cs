using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CacheFramework.Config
{
  /// <summary>
  /// 基本设置类
  /// </summary>
  public class BaseConfigs
  {

    private static System.Timers.Timer baseConfigTimer = new System.Timers.Timer(60000);

    private static BaseConfigInfo m_configinfo;

    /// <summary>
    /// 静态构造函数初始化相应实例和定时器
    /// </summary>
    static BaseConfigs()
    {
      m_configinfo = BaseConfigFileManager.LoadConfig();
      baseConfigTimer.AutoReset = true;
      baseConfigTimer.Enabled = true;
      baseConfigTimer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
      baseConfigTimer.Start();
    }

    private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
      ResetConfig();
    }


    /// <summary>
    /// 重设配置类实例
    /// </summary>
    public static void ResetConfig()
    {
      m_configinfo = BaseConfigFileManager.LoadConfig();
    }


    /// <summary>
    /// 重设配置类实例
    /// </summary>
    public static void ResetRealConfig()
    {
      m_configinfo = BaseConfigFileManager.LoadRealConfig();
    }

    public static BaseConfigInfo GetBaseConfig()
    {
      return m_configinfo;
    }
   
    /// <summary>
    /// 返回论坛路径
    /// </summary>
    public static string WebPath
    {
      get
      {
        return GetBaseConfig().WebPath;
      }
    }
  }
}
