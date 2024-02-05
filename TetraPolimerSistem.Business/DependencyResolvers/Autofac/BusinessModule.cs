using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetraPolimerSistem.Business.Abstarct;
using TetraPolimerSistem.Business.Concrete;

namespace TetraPolimerSistem.Business.DependencyResolvers.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DisTicaretManager>().As<IDisTicaretService>();
            builder.RegisterType<DisTicaretMaliyetManager>().As<IDisTicaretMaliyetService>();
            builder.RegisterType<OrderManager>().As<IOrderService>();
            builder.RegisterType<SevkiyatDetayManager>().As<ISevkiyatDetayService>();

            base.Load(builder);
        }
    }
}
