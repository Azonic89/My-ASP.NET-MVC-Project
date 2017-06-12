using System.Data.Entity.Migrations;
using System.Linq;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using CarSystem.Data.Models;

namespace CarSystem.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<CarSystemEfDbContext>
    {
        public Configuration()
        {

            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CarSystemEfDbContext context)
        {
            //if (context.Categories.Count() == 0)
            //{
            //    context.Categories.AddOrUpdate(c => c.Id,
            //        new Category { Id = 1, Name = "Bus" },
            //        new Category { Id = 2, Name = "Caravan" },
            //        new Category { Id = 3, Name = "Car" },
            //        new Category { Id = 4, Name = "Motorbike" },
            //        new Category { Id = 5, Name = "SUV" }
            //    );
            //}

            //if (context.Manufacturers.Count() == 0)
            //{
            //    context.Manufacturers.AddOrUpdate(m => m.Id,
            //        new Manufacturer { Id = 1, Name = "Audi" },
            //        new Manufacturer { Id = 2, Name = "Peugeot" },
            //        new Manufacturer { Id = 3, Name = "KIA" },
            //        new Manufacturer { Id = 4, Name = "Dacia" },
            //        new Manufacturer { Id = 5, Name = "Lamborghini" },
            //        new Manufacturer { Id = 6, Name = "Daihatsu" },
            //        new Manufacturer { Id = 7, Name = "Hyundai" },
            //        new Manufacturer { Id = 8, Name = "Ferrari" },
            //        new Manufacturer { Id = 9, Name = "Mercedes" },
            //        new Manufacturer { Id = 10, Name = "Toyota" },
            //        new Manufacturer { Id = 11, Name = "Kamaz" },
            //        new Manufacturer { Id = 12, Name = "Mack" },
            //        new Manufacturer { Id = 13, Name = "Tesla" },
            //        new Manufacturer { Id = 14, Name = "Infiniti" },
            //        new Manufacturer { Id = 15, Name = "Ford" },
            //        new Manufacturer { Id = 16, Name = "Nissan" },
            //        new Manufacturer { Id = 17, Name = "Rolce Royce" },
            //        new Manufacturer { Id = 18, Name = "Bentley" },
            //        new Manufacturer { Id = 19, Name = "Alpha Romeo" },
            //        new Manufacturer { Id = 20, Name = "Porsche" },
            //        new Manufacturer { Id = 21, Name = "Mclaren" }
            //    );
            //}

            //if (context.VehicleModels.Count() == 0)
            //{
            //    context.VehicleModels.AddOrUpdate(v => v.Id,
            //        new VehicleModel { Id = 1, Name = "P1", CategoryId = 1, ManufacturerId = 2 },
            //        new VehicleModel { Id = 2, Name = "A6", CategoryId = 1, ManufacturerId = 1 },
            //        new VehicleModel { Id = 3, Name = "A8", CategoryId = 2, ManufacturerId = 1 },
            //        new VehicleModel { Id = 4, Name = "Model X", CategoryId = 1, ManufacturerId = 1 },
            //        new VehicleModel { Id = 5, Name = "Model S", CategoryId = 1, ManufacturerId = 2 },
            //        new VehicleModel { Id = 6, Name = "i40", CategoryId = 2, ManufacturerId = 1 },
            //        new VehicleModel { Id = 7, Name = "Qashkai", CategoryId = 1, ManufacturerId = 1 },
            //        new VehicleModel { Id = 8, Name = "Toureg", CategoryId = 2, ManufacturerId = 1 },
            //        new VehicleModel { Id = 9, Name = "Corolla", CategoryId = 1, ManufacturerId = 2 },
            //        new VehicleModel { Id = 10, Name = "Phantom", CategoryId = 1, ManufacturerId = 1 },
            //        new VehicleModel { Id = 11, Name = "Aventador", CategoryId = 1, ManufacturerId = 1 },
            //        new VehicleModel { Id = 12, Name = "Terios", CategoryId = 1, ManufacturerId = 2 },
            //        new VehicleModel { Id = 13, Name = "Logan", CategoryId = 1, ManufacturerId = 2 },
            //        new VehicleModel { Id = 14, Name = "Seed", CategoryId = 1, ManufacturerId = 1 },
            //        new VehicleModel { Id = 15, Name = "S500 AMG", CategoryId = 1, ManufacturerId = 3 },
            //        new VehicleModel { Id = 16, Name = "306", CategoryId = 1, ManufacturerId = 2 },
            //        new VehicleModel { Id = 17, Name = "La Ferrari", CategoryId = 1, ManufacturerId = 1 },
            //        new VehicleModel { Id = 18, Name = "Escort", CategoryId = 1, ManufacturerId = 1 },
            //        new VehicleModel { Id = 19, Name = "Q50", CategoryId = 1, ManufacturerId = 2 }
            //    );
            //}

            //if (context.Cities.Count() == 0)
            //{
            //    context.Cities.AddOrUpdate(c => c.Id,
            //        new City { Id = 1, Name = "Sofia" },
            //        new City { Id = 2, Name = "Dupnica" },
            //        new City { Id = 3, Name = "Veliko Tarnovo" },
            //        new City { Id = 4, Name = "Varna" },
            //        new City { Id = 5, Name = "Plovdiv" },
            //        new City { Id = 6, Name = "Stara Zagora" },
            //        new City { Id = 7, Name = "Burgas" },
            //        new City { Id = 8, Name = "Blagoevgrad" },
            //        new City { Id = 9, Name = "Sandanski" },
            //        new City { Id = 10, Name = "Elena" },
            //        new City { Id = 11, Name = "Pavlikeni" },
            //        new City { Id = 12, Name = "Haskovo" },
            //        new City { Id = 13, Name = "Vidin" },
            //        new City { Id = 14, Name = "Dobrich" },
            //        new City { Id = 15, Name = "Ruse" },
            //        new City { Id = 16, Name = "Shumen" }
            //    );
            //}

            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                this.AddUserAndRole(context);
            }

            if (!context.Categories.Any())
            {
                context.Categories.AddOrUpdate(c => c.Id,
                    new Category { Id = 0, Name = "Bus" },
                    new Category { Id = 1, Name = "Caravan" },
                    new Category { Id = 2, Name = "Car" },
                    new Category { Id = 3, Name = "Motorbike" },
                    new Category { Id = 5, Name = "SUV" }
                );
            }

            if (!context.Manufacturers.Any())
            {
                context.Manufacturers.AddOrUpdate(m => m.Id,
                    new Manufacturer { Id = 1, Name = "Audi" },
                    new Manufacturer { Id = 2, Name = "Peugeot" },
                    new Manufacturer { Id = 3, Name = "KIA" },
                    new Manufacturer { Id = 4, Name = "Dacia" },
                    new Manufacturer { Id = 5, Name = "Lamborghini" },
                    new Manufacturer { Id = 6, Name = "BMV" }
                );
            }

            if (!context.VehicleModels.Any())
            {
                context.VehicleModels.AddOrUpdate(v => v.Id,
                    new VehicleModel { Id = 1, Name = "A4", CategoryId = 1, ManufacturerId = 1 },
                    new VehicleModel { Id = 2, Name = "A6", CategoryId = 1, ManufacturerId = 1 },
                    new VehicleModel { Id = 3, Name = "A8", CategoryId = 2, ManufacturerId = 1 },
                    new VehicleModel { Id = 4, Name = "100", CategoryId = 1, ManufacturerId = 1 },
                    new VehicleModel { Id = 5, Name = "S8", CategoryId = 1, ManufacturerId = 1 },
                    new VehicleModel { Id = 6, Name = "XS", CategoryId = 2, ManufacturerId = 2 },
                    new VehicleModel { Id = 7, Name = "TT", CategoryId = 1, ManufacturerId = 1 },
                    new VehicleModel { Id = 8, Name = "Uou", CategoryId = 2, ManufacturerId = 3 },
                    new VehicleModel { Id = 9, Name = "Test", CategoryId = 1, ManufacturerId = 1 },
                    new VehicleModel { Id = 10, Name = "80", CategoryId = 1, ManufacturerId = 1 }
                );
            }

            if (!context.Cities.Any())
            {
                context.Cities.AddOrUpdate(c => c.Id,
                    new City { Id = 1, Name = "Sofia" },
                    new City { Id = 2, Name = "Dupnica" },
                    new City { Id = 3, Name = "Tyrnovo" },
                    new City { Id = 4, Name = "Haskovo" }
                );
            }
        }

        private bool AddUserAndRole(CarSystemEfDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var indentityResult = roleManager.Create(new IdentityRole("admin"));
            var userManager = new UserManager<User>(new UserStore<User>(context));

            var user = new User
            {
                UserName = "dedoviqtAdmin@yahoo.com",
            };

            indentityResult = userManager.Create(user, "Parolishen");
            if (indentityResult.Succeeded == false)
            {
                return indentityResult.Succeeded;

            }
            indentityResult = userManager.AddToRole(user.Id, "admin");

            return indentityResult.Succeeded;
        }
    }
}
