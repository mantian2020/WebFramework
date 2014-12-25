using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CoreFramework.Enum;

namespace Shop.Authority
{
    public class AuthorityAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return ProjectName.Authority; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            string[] controllerNamespaces = new[] { "Shop."+ ProjectName.Authority +".Controllers" };
            context.MapRoute("AuthorityDefault"
                , ProjectName.Authority + "/{controller}/{action}"
                , new { controller = "Authority", action = "Index" }
                , null, controllerNamespaces);
        }
    }
}
