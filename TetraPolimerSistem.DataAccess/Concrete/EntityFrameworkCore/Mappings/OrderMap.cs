using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetraPolimerSistem.Core.DataAccess.EntityFrameworkCore.Mapping;
using TetraPolimerSistem.Entities.Concrete;

namespace TetraPolimerSistem.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class OrderMap : EntityMap<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x=>x.Id);


            builder.HasOne(x=>x.SevkiyatDetay).WithMany(x=>x.Order);
            base.Configure(builder);
        }
    }
}
