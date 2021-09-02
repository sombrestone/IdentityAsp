using ApiRep.Models;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRep
{
    public class AutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           builder.RegisterType<ProductRepository>().As<IRepository<Product>>().InstancePerLifetimeScope();
           builder.RegisterType<UnitRepository>().As<IRepository<Unit>>().InstancePerLifetimeScope();
        }
    }
}
