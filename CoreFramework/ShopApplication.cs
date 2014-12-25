using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using CoreFramework.Infrastructure.Ioc;

namespace CoreFramework
{
    public class ShopApplication : HttpApplication
    {
        public ShopApplication()
        {
            this.AcquireRequestState += ShopApplication_AcquireRequestState;
            this.AuthenticateRequest += ShopApplication_AuthenticateRequest;
        }
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        }

        void ShopApplication_AuthenticateRequest(object sender, EventArgs e)
        {
           
        }

        void ShopApplication_AcquireRequestState(object sender, EventArgs e)
        {
            
        }

        protected void Application_Start()
        {
            //autofac自动注入
            var builder = AutofacManager.AutoRegisterContainerBuilder();
            //实现Controller的IOC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));

            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
           
        }
    }
}
