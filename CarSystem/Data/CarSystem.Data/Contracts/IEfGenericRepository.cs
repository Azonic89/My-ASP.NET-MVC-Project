using System.Linq;

namespace CarSystem.Data.Contracts
{
    public interface IEfGenericRepository<T> where T : class
    {
        IQueryable<T> All { get; }

        T GetById(object id);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}
