using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using CommonHelper.Entity;
using CommonHelper.Log;

namespace SSOFramework
{
    public abstract class BaseSsO<T> where T : class 
    {
        private ILogService logger = LogFactory.GetScorer(ScorerCategory.Log4net, typeof(BaseSsO<T>)); 
        protected int expiresMinutes = 20;
        private string domain = string.Empty;

        /// <summary>
        /// Cookie域
        /// </summary>
        protected string Domain
        {
            get { return domain; }
            set { domain = value; }
        }

        /// <summary>
        /// Cookie超时时间
        /// </summary>
        public int ExpiresMinutes
        {
            get { return expiresMinutes; }
            set { expiresMinutes = value; }
        }

        /// <summary>
        /// 串行化用户数据
        /// </summary>
        /// <typeparam name="T">用户数据类型</typeparam>
        /// <param name="user">用户数据类</param>
        /// <returns>串行化后的结果</returns>
        public abstract string SerializeUserInfo(T user);

        /// <summary>
        /// 并行化用户数据
        /// </summary>
        /// <typeparam name="T">用户数据类型</typeparam>
        /// <param name="userData">用户数据</param>
        /// <returns>并行化后的结果</returns>
        public abstract T DeserializeUserInfo(string userData);

        /// <summary>
        /// 返回用户类中的用户名数据
        /// </summary>
        /// <typeparam name="T">用户数据类型</typeparam>
        /// <param name="user">用户数据类</param>
        /// <returns>用户的帐号名</returns>
        public abstract string GetUserAccount(T user);

        /// <summary>
        /// 检查登录并获得用户信息
        /// </summary>
        /// <param name="user">用户信息实体</param>
        /// <returns>是否登录</returns>
        public virtual ResultInfo<T> CheckLogin()
        {
            ResultInfo<T> result = new ResultInfo<T>();
            result.Success = true;
            HttpContext csContext = HttpContext.Current;

            if (csContext.User != null && csContext.User.Identity.IsAuthenticated && csContext.User.Identity.Name != string.Empty && csContext.User.Identity.AuthenticationType == "Forms")
            {
                FormsIdentity id = HttpContext.Current.User.Identity as FormsIdentity;

                if (id != null)
                {
                    FormsAuthenticationTicket ticket = id.Ticket;

                    result.Data = this.DeserializeUserInfo(ticket.UserData);

                    if (result.Data == null)
                    {
                        result.Success = false;
                    }
                }
                else
                {
                    result.Data = default(T);
                    result.Success = false;
                }
            }
            else
            {
                result.Data = default(T);
                result.Success = false;
            }
            return result;
        }

        /// <summary>
        /// 登录时把用户数据写入Cookie
        /// </summary>
        /// <param name="user">用户信息实体</param>
        public virtual void SignLogin(T user)
        {
            string userData = this.SerializeUserInfo(user);

            HttpContext.Current.Response.Cookies.Add(this.GetAuthCookie(userData, this.GetUserAccount(user)));
        }

        /// <summary>
        /// 利用asp.net中form验证加密数据，写入Cookie
        /// </summary>
        /// <param name="userData">Base64后的实体数据</param>
        /// <returns>加密的cookie</returns>
        protected virtual HttpCookie GetAuthCookie(string userData, string userName)
        {
            logger.Info("userData:" + userData + ",userName:" + userName + ",Domain:" + this.domain + ",Minutes:" + this.expiresMinutes);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                2,
                userName,
                System.DateTime.Now,
                DateTime.Now.AddMinutes(expiresMinutes),
                false,
                userData,
                FormsAuthentication.FormsCookiePath);

            string encTicket = FormsAuthentication.Encrypt(ticket);

            if ((encTicket == null) || (encTicket.Length < 1))
            {
                throw new HttpException("Unable_to_encrypt_cookie_ticket");
            }

            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            cookie.Path = "/";
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.HttpOnly = true;

            if (this.domain != string.Empty)
            {
                bool urlIsDomain = HttpContext.Current.Request.Url.Host.EndsWith(this.domain);

                if (urlIsDomain)
                {
                    cookie.Domain = this.domain;
                }
            }

            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }

            return cookie;
        }

        /// <summary>
        /// 注销
        /// </summary>
        public virtual void SignOut()
        {
            HttpContext context = HttpContext.Current;

            FormsAuthentication.SignOut();

            HttpCookie cookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null)
            {
                cookie = new HttpCookie(FormsAuthentication.FormsCookieName);
            }

            cookie.Path = "/";
            if (this.domain != string.Empty)
            {
                bool urlIsDomain = HttpContext.Current.Request.Url.Host.ToString().EndsWith(this.domain);

                if (urlIsDomain)
                {
                    cookie.Domain = this.domain;
                }
            }
            cookie.Expires = DateTime.Now.AddYears(-10);

            context.Response.Cookies.Add(cookie);

            //特殊处理
            HttpCookie autoCookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (autoCookie != null)
            {
                autoCookie.Domain = this.domain;
                autoCookie.Value = "";
                autoCookie.Expires = DateTime.Now.AddYears(-10);

                context.Response.Cookies.Add(autoCookie);
            }

            if (context.Session != null)
            {
                context.Session.Clear();
                context.Session.Abandon();
            }
        }
    }
}
