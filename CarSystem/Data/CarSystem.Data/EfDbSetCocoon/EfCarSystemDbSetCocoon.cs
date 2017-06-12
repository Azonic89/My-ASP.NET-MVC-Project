using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

using Bytes2you.Validation;

using CarSystem.Data.Contracts;

namespace CarSystem.Data.EfDbSetCocoon
{
    public class EfCarSystemDbSetCocoon<T> : IEfCarSystemDbSetCocoon<T> where T : class
    {
        public EfCarSystemDbSetCocoon(ICarSystemEfDbContext carSystemDbContext)
        {
            Guard.WhenArgument(carSystemDbContext, nameof(ICarSystemEfDbContext)).IsNull().Throw();

            this.Context = carSystemDbContext;
            this.DbSet = this.Context.Set<T>();
        }

        public IDbSet<T> DbSet { get; set; }

        public ICarSystemEfDbContext Context { get; set; }

        public virtual IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public virtual T GetById(int? id)
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
    }
}
