using Microsoft.EntityFrameworkCore;
using TetraPolimerSistem.DataAccess.Concrete.EntityFrameworkCore.Mappings;
using TetraPolimerSistem.Entities.Concrete;

namespace TetraPolimerSistem.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class TetraPolimerSistemContext :DbContext
    {

        public TetraPolimerSistemContext(DbContextOptions<TetraPolimerSistemContext> options):base(options)
        {
           
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server = DESKTOP - LTM3SCO; Initial Catalog = TetraPolimerDB; Integrated Security = true; TrustServerCertificate = True;");
        //    base.OnConfiguring(optionsBuilder);
        //}      


        public DbSet<DisTicaret> disTicaretler { get; set; }

        public DbSet<DisTicaretMaliyet> disTicaretMaliyetler { get; set; }

        public DbSet<Order> orders { get; set; }

        public DbSet<SevkiyatDetay> sevkiyatDetaylar { get; set; }

        public DbSet<AppUser> appUser { get; set; }

        public DbSet<AppRole> appRole { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DisTicaretMap());
            builder.ApplyConfiguration(new DisTicaretMaliyetMap());
            builder.ApplyConfiguration(new SevkiyatDetayMap());
            builder.ApplyConfiguration(new OrderMap());
            base.OnModelCreating(builder);
        }
    }
}
