using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper.Entity
{
    public class PageInfo<T> where T : class
    {
        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { set; get; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { set; get; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPageCount {
            get { return Convert.ToInt32(Math.Ceiling(TotalCount/(PageSize*1.0))); }
        }
        /// <summary>
        /// 总条数
        /// </summary>
        public int TotalCount { set; get; }
        public List<T> Items { set; get; }

    }
}
