using System.Data.Entity.Migrations;

namespace CarSystem.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<CarSystemEfDbContext>
    {
        public Configuration()
        {

            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        } 
    }
}
