using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using CoreFramework.Infrastructure.Interfaces;

namespace CoreFramework.Infrastructure.Ioc
{
    public class AutofacManager
    {
        public static ContainerBuilder AutoRegisterContainerBuilder()
        {
            var builder = new ContainerBuilder();
            var baseType = typeof (IDependency);
            var assemblys = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var allServices =assemblys
                .SelectMany(s => s.GetTypes())
                .Where(p => baseType.IsAssignableFrom(p) && p != baseType);

            builder.RegisterAssemblyTypes(assemblys.ToArray())
                   .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
                   .AsImplementedInterfaces().InstancePerLifetimeScope();
            return builder;
        }
    }
}
