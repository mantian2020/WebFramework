using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Mvc;
using CoreFramework.Infrastructure.Interfaces;

namespace CoreFramework.Infrastructure.Ioc
{
    public class AutofacManager
    {
        public static ContainerBuilder AutoRegisterContainerBuilder()
        {
            var builder = new ContainerBuilder();

            var baseType = typeof(IDependency);
            var assemblys = AppDomain.CurrentDomain.GetAssemblies().ToList();
            //注册所有的controller
            builder.RegisterControllers(assemblys.ToArray());

            //注册所有的程序集
            builder.RegisterAssemblyTypes(assemblys.ToArray())
                   .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
                   .AsImplementedInterfaces().InstancePerHttpRequest();

            /** 1.如何实现AsImplementedInterfaces()方法?
             * 这个方法的作用是，指定注册类型以接口形式存在。
             * builder.RegisterType<ListMovieFinder>().AsImplementedInterfaces(); 
             * 以类ListMovieFinder的接口IMovieFinder注册
             * 那么我使用 Resolve<IMovieFinder>()要获取一个接口实例的时候，会返回一个ListMovieFinder的实例
             * 2. 如何实现对同一个类型的注册，后面的覆盖前面的注册?
             * builder.RegisterType<ListMovieFinder>().AsImplementedInterfaces();
             * builder.RegisterType<DBMovieFinder>().AsImplementedInterfaces();
             * 后面的DBMovieFinder会覆盖掉ListMovieFinder的注册
             * 这样，当我调用 Resolve<IMovieFinder>()要获取一个接口实例的时候，会返回一个DBMovieFinder的实例
             */


            return builder;
        }
    }
}
