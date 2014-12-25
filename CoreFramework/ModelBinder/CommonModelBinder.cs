using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using CommonHelper;

namespace CoreFramework.ModelBinder
{
    [ModelBinderType(typeof(string))]
    public class CommonModelBinder<T> : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var json = controllerContext.HttpContext.Request[bindingContext.ModelName] as string;
            if (json == null) return null;

            return SerializeHelper.Deserialize<T>(json);
        }
    }
}
