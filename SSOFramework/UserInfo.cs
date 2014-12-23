using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSOFramework
{
    /// <summary>
    /// 会员信息
    /// </summary>
    public class UserInfo
    {
        public string UserName { set; get; }
        public string Code { set; get; }

        public List<Menu> Menus { set; get; }
    }

    public class Menu
    {
        public string Url { set; get; }
        public string Name { set; get; }
        /// <summary>
        /// 二级菜单
        /// </summary>
        public List<Menu> SecondMenus { set; get; }
        /// <summary>
        /// 是否有二级菜单
        /// </summary>
        public bool HaveSecondMenus { set; get; }
    }
}
