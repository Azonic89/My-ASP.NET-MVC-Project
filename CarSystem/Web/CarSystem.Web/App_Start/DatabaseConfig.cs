using System.Data.Entity;

using CarSystem.Data;
using CarSystem.Data.Migrations;

namespace CarSystem.Web.App_Start
{
    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarSystemDbContext, Configuration>());
            CarSystemDbContext.Create().Database.CreateIfNotExists();
        }
    }
}