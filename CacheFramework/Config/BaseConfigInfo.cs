using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CacheFramework.Config
{
  public class BaseConfigInfo : IConfigInfo
  {
    private string m_webpath;
    /// <summary>
    /// 网站的路径
    /// </summary>
    public string WebPath
    {
      set { m_webpath = value; }
      get { return m_webpath; }
    }
  }
}
