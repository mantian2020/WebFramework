using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSOFramework;

namespace CoreFramework.Services
{
    public class LoginServices
    {
        /// <summary>
        /// 校验用户是否登陆
        /// </summary>
        /// <returns></returns>
        public static bool CheckLogin()
        {
            UserCookiesService sso = new UserCookiesService();
            CommonHelper.Entity.ResultInfo<SSOFramework.UserInfo> result = sso.CheckLogin();
            return result.Success;
        }
        /// <summary>
        /// 登陆，记录用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="menus"></param>
        public static void Login(string userName,List<Menu> menus)
        {
            UserCookiesService sso = new UserCookiesService();
            sso.SignLogin(new SSOFramework.UserInfo() { UserName = userName,Menus = menus});
        }
        /// <summary>
        /// 退出
        /// </summary>
        public static void SignOut()
        {
            UserCookiesService sso = new UserCookiesService();
            sso.SignOut();
        }
        /// <summary>
        /// 获取用户菜单列表
        /// </summary>
        /// <returns></returns>
        public static List<Menu> GetUserMenus()
        {
            UserCookiesService sso = new UserCookiesService();
            CommonHelper.Entity.ResultInfo<SSOFramework.UserInfo> result = sso.CheckLogin();
            return result.Data.Menus;
        }
    }
}
