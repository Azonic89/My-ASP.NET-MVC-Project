using Bytes2you.Validation;

using CarSystem.Data.Contracts;

namespace CarSystem.Data.EfDbSetCocoon
{
    public class CarSystemDbContextSaveChanges : ICarSystemEfDbContextSaveChanges
    {
        private readonly ICarSystemEfDbContext carSystemEfDbContext;

        public CarSystemDbContextSaveChanges(ICarSystemEfDbContext carSystemEfDbContext)
        {
            Guard.WhenArgument(carSystemEfDbContext, nameof(carSystemEfDbContext)).IsNull().Throw();

            this.carSystemEfDbContext = carSystemEfDbContext;
        }

        public int SaveChanges()
        {
            return this.carSystemEfDbContext.SaveChanges();
        }

        public void Dispose()
        {

        }
    }
}
