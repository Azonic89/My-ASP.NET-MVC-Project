using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

using Bytes2you.Validation;

using CarSystem.Data.Contracts;

namespace CarSystem.Data.Repositories
{
    public class EfCarSystemDataProvider<T> : IEfCarSystemDataProvider<T> where T : class
    {
        private readonly ICarSystemDbContext carSystemDbContext;

        public EfCarSystemDataProvider(ICarSystemDbContext carSystemDbContext)
        {
            Guard.WhenArgument(carSystemDbContext, nameof(ICarSystemDbContext)).IsNull().Throw();

            this.carSystemDbContext = carSystemDbContext;
            this.DbSet = this.carSystemDbContext.Set<T>();
        }

        protected IDbSet<T> DbSet { get; set; }

        protected ICarSystemDbContext Context { get; set; }

        public virtual IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public virtual T GetById(int id)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        public virtual void Delete(int id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public virtual void Detach(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            entry.State = EntityState.Detached;
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}
