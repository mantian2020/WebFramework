using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CoreFramework.Extends;

namespace CoreFramework.Modules
{
    public class UrlModule:IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpContext context = (sender as HttpApplication).Context;
            HttpContextExtend.CurrentUrl = context.Request.RawUrl;
        }
    }
}
