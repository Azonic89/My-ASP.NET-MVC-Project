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

        public virtual IDbSet<Advert> Adverts { get; set; }
               
        public virtual IDbSet<AdvertImage> AdvertImages { get; set; }
               
        public virtual IDbSet<Category> Categories { get; set; }
               
        public virtual IDbSet<City> Cities { get; set; }
               
        public virtual IDbSet<Manufacturer> Manufacturers { get; set; }
               
        public virtual IDbSet<VehicleModel> VehicleModels { get; set; }

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
