using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CoreFramework.Extends
{
    public static class HttpContextExtend
    {
        public static string CurrentUrl { set; get; }
        /// <summary>
        /// 判断是否是当前URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsCurrentUrl(List<string> menuUrls)
        {
            return menuUrls.Contains(CurrentUrl);
        }
    }
}
