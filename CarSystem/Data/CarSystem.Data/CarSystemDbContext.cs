using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSystem.Data.Models;
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
