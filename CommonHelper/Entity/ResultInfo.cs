using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper.Entity
{
    public class ResultInfo<T> where T : class
    {
        /// <summary>
        /// 状态标识
        /// </summary>
        public bool Success { set; get; }
        /// <summary>
        /// 返回提示信息
        /// </summary>
        public string Msg { set; get; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data { set; get; }
    }
}
