using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetraPolimerSistem.DataAccess.Abstarct;
using TetraPolimerSistem.DataAccess.Concrete.EntityFrameworkCore;

namespace TetraPolimerSistem.Business.DependencyResolvers.Extension
{
    public static class Container
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddScoped<IDisTicaretDal,DisTicaretDal>();
            services.AddScoped<IDisTicaretMaliyetDal,DisTicaretMaliyetDal>();
            services.AddScoped<IOrderDal,OrderDal>();
            services.AddScoped<ISevkiyatDetayDal,SevkiyatDetayDal>();
            return services;
        }
    }
}
