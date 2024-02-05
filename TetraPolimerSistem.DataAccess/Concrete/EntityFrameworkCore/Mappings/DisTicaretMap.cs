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
    public class DisTicaretMap : EntityMap<DisTicaret>
    {
        public override void Configure(EntityTypeBuilder<DisTicaret> builder)
        {
            builder.HasKey(x => x.Id);



            builder.HasOne(x => x.disTicaretMaliyet).WithOne(x=>x.disTicaret);

            base.Configure(builder);
        }
    }
}
