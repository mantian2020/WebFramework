using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Module.Model
{
    public class Shop_Modules
    {
        /// <summary>
        /// 模块ID
        /// </summary>
        public int Shop_Modules_Id { set; get; }
        /// <summary>
        /// 模块名
        /// </summary>
        public string Shop_Modules_Name { set; get; }
        /// <summary>
        /// 模块描述
        /// </summary>
        public string Shop_Modules_Description { set; get; }
        /// <summary>
        /// 模块是否开启(1:开启,0:禁用)
        /// </summary>
        public int Shop_Modules_IsStart { set; get; }
        /// <summary>
        /// 模块是否有效(1:有效,0:无效)
        /// </summary>
        public int Shop_Modules_IsValid { set; get; }
        /// <summary>
        /// 模块添加时间
        /// </summary>
        public DateTime Shop_Modules_AddTime { set; get; }
        /// <summary>
        /// 模块排序
        /// </summary>
        public int Shop_Modules_Sort { set; get; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Shop_Modules_Creator { set; get; }


    }
}
