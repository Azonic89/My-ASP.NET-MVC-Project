using System.Linq;

using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Contracts
{
    public interface ICategoryService
    {
        IQueryable<Category> GetAllCategories();

        Category GetById(int id);
    }
}