using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

using Bytes2you.Validation;

using CarSystem.Data.Contracts;

namespace CarSystem.Data.Repositories
{
    public class EfGenericRepository<T> : IEfGenericRepository<T> where T : class
    {
        private readonly ICarSystemDbContext carSystemDbContext;

        public EfGenericRepository(ICarSystemDbContext carSystemDbContext)
        {
            Guard.WhenArgument(carSystemDbContext, nameof(ICarSystemDbContext)).IsNull().Throw();

            this.carSystemDbContext = carSystemDbContext;
            this.DbSet = this.carSystemDbContext.Set<T>();
        }

        protected DbSet<T> DbSet { get; set; }

        public IQueryable<T> All => this.DbSet;

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public void Add(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Added;
        }

        public void Delete(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Deleted;
        }

        public void Update(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }

        private DbEntityEntry AttachIfDetached(T entity)
        {
            var entry = this.carSystemDbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            return entry;
        }
    }
}
