using System.Linq;

using Bytes2you.Validation;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;
using CarSystem.Data.Services.Contracts;

namespace CarSystem.Data.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IEfCarSystemDbSetCocoon<Category> categoryDbSetCocoon;

        public CategoryService(IEfCarSystemDbSetCocoon<Category> categoryDbSetCocoon)
        {
            Guard.WhenArgument(categoryDbSetCocoon, nameof(categoryDbSetCocoon)).IsNull().Throw();

            this.categoryDbSetCocoon = categoryDbSetCocoon;
        }

        public IQueryable<Category> GetAllCategories()
        {
            return this.categoryDbSetCocoon.All();
        }

        public Category GetById(int id)
        {
            return this.categoryDbSetCocoon.GetById(id);
        }
    }
}
