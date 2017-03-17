using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using Microsoft.AspNet.Identity.EntityFramework;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data
{
    public class CarSystemDbContext : IdentityDbContext<User>, ICarSystemDbContext
    {
        public CarSystemDbContext()
            : base("CarSystemDb")
        {
        }

        public virtual DbSet<Advert> Adverts { get; set; }
               
        public virtual DbSet<AdvertImage> AdvertImages { get; set; }
               
        public virtual DbSet<Category> Categories { get; set; }
               
        public virtual DbSet<City> Cities { get; set; }
               
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
               
        public virtual DbSet<VehicleModel> VehicleModels { get; set; }

        void ICarSystemDbContext.SaveChanges()
        {
            base.SaveChanges();
        }
        public static CarSystemDbContext Create()
        {
            return new CarSystemDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
