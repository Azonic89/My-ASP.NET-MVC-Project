using CarSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarSystem.Data
{
    public class CarSystemDbContext : IdentityDbContext<User>
    {
        public CarSystemDbContext()
            : base("CarSystemDb")
        {
        }

        public static CarSystemDbContext Create()
        {
            return new CarSystemDbContext();
        }
    }
}
