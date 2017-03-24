using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using Microsoft.AspNet.Identity.EntityFramework;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data
{
    public class CarSystemEfDbContext : IdentityDbContext<User>, ICarSystemEfDbContext, ICarSystemEfDbContextSaveChanges
    {
        public CarSystemEfDbContext()
            : base("CarSystemDb")
        {
        }

        public IDbSet<Advert> Adverts { get; set; }
               
        public IDbSet<AdvertImage> AdvertImages { get; set; }
               
        public IDbSet<Category> Categories { get; set; }
               
        public IDbSet<City> Cities { get; set; }
               
        public IDbSet<Manufacturer> Manufacturers { get; set; }
               
        public IDbSet<VehicleModel> VehicleModels { get; set; }

        public static CarSystemEfDbContext Create()
        {
            return new CarSystemEfDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
