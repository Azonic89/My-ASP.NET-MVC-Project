using System.Linq;

namespace CarSystem.Data.Contracts
{
    public interface IEfCarSystemDbSetCocoon<T> where T : class
    {
        IQueryable<T> All();

        T GetById(int? id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);
    }
}
