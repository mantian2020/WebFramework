using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CoreFramework.Services;

namespace CoreFramework.ActionFilters
{
    /// <summary>
    /// 登陆校验
    /// </summary>
    public class LoginFilterAttribute : ActionFilterAttribute
    {
        public string Message { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (!LoginServices.CheckLogin())
            {
                filterContext.HttpContext.Response.Redirect("~/template/template/login");
            }
        }
    }
}
