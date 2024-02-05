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
    public class SevkiyatDetayMap : EntityMap<SevkiyatDetay>
    {
        public override void Configure(EntityTypeBuilder<SevkiyatDetay> builder)
        {
            builder.HasKey(x=>x.Id);





            builder.HasMany(x => x.Order).WithOne(x=>x.SevkiyatDetay);

            base.Configure(builder);
        }
    }
}
