using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetraPolimerSistem.Core.Entities;

namespace TetraPolimerSistem.Core.DataAccess.EntityFrameworkCore.Mapping
{
    public class EntityMap<T> : IEntityTypeConfiguration<T> where T : class, IEntity, new()
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
        }
    }
}
